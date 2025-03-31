using System.Text;

public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestResponseLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Log the request
            var request = await FormatRequest(context.Request);
            Console.WriteLine($"Request: {request}");

            // Copy the original response body stream
            var originalResponseBodyStream = context.Response.Body;

            using (var responseBodyStream = new MemoryStream())
            {
                context.Response.Body = responseBodyStream;

                await _next(context);

                // Log the response
                var response = await FormatResponse(context.Response);
                Console.WriteLine($"Response: {response}");

                await responseBodyStream.CopyToAsync(originalResponseBodyStream);
            }
        }

        private async Task<string> FormatRequest(HttpRequest request)
        {
            request.EnableBuffering();
            var buffer = new byte[Convert.ToInt32(request.ContentLength)];
            await request.Body.ReadAsync(buffer, 0, buffer.Length);
            var bodyAsText = Encoding.UTF8.GetString(buffer);
            request.Body.Position = 0;

            return $"{request.Method} {request.Path} {request.QueryString} {bodyAsText}";
        }

        private async Task<string> FormatResponse(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            var text = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);

            return $"{response.StatusCode}: {text}";
        }
    }