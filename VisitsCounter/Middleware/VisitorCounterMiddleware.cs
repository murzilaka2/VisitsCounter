using VisitsCounter.Interfaces;

namespace VisitsCounter.Middleware
{
    public class VisitorCounterMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        public VisitorCounterMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext context, IVisitor _visitors)
        {
            string visitorId = context.Request.Cookies["VisitorId"];
            if (visitorId == null)
            {              
                context.Response.Cookies.Append("VisitorId", Guid.NewGuid().ToString(), new CookieOptions()
                {
                    Path = "/",
                    HttpOnly = true,
                    Secure = false,
                    Expires = DateTimeOffset.UtcNow.AddDays(1)
                });
                await _visitors.IncrementVisitors();
            }
            else
            {
                await _visitors.IncrementViews();
            }

            await _requestDelegate(context);
        }
    }
}
