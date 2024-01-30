namespace LessonMonitorAPICore8.Components
{
    public class LogRequestMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _filePath;

        public LogRequestMiddleware(RequestDelegate next, string filePath)
        {
            _next = next;
            _filePath = filePath;
        }

        public Task Invoke(HttpContext context)
        {
            string body;
            using (StreamReader reader = new StreamReader(context.Request.Body))
            {
                body = reader.ReadToEndAsync().Result;
            }


            string logMessage = $"Protocol: {context.Request.Protocol}\n" +
                                $"Method: {context.Request.Method}\n" +
                                $"Path: {context.Request.Path}\n" +
                                $"Body: {body}\n\n";

            File.AppendAllText(_filePath, logMessage);

            return _next(context);
        }
    }
}
