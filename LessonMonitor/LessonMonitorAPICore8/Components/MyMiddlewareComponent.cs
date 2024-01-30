namespace LessonMonitorAPICore8.Components
{
    public class MyMiddlewareComponent
    {
        private readonly RequestDelegate _next;

        public MyMiddlewareComponent(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            return _next(context);
        }
    }
}
