namespace ForumApp.Filters
{
    using ForumApp.Infrastructure.Data.Common;
    using ForumApp.Infrastructure.Data.Entities;
    using Microsoft.AspNetCore.Http.Extensions;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.EntityFrameworkCore;

    public class PageVisitCountFilter : ActionFilterAttribute
    {
        private readonly IRepository repo;

        public PageVisitCountFilter(IRepository repo)
        {
            this.repo = repo;
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);

            //get current url from request
            string url = context.HttpContext.Request.GetDisplayUrl();

            //track only unique visits:
            //1)with ip addres:
            //string userIp = context.HttpContext.Connection.RemoteIpAddress.ToString();

            //2)with cookie:
            bool hasVisitCookie = context.HttpContext.Request.Cookies
                .TryGetValue("VisitCookie", out string visitCookieValue);

            if (!hasVisitCookie)
            {
                visitCookieValue = Guid.NewGuid().ToString();
                context.HttpContext.Response.Cookies.Append("VisitCookie", visitCookieValue);

                var currentPage = repo.All<PageVisit>()
                    .FirstOrDefaultAsync(p => p.Url == url && p.VisitCookie == visitCookieValue)
                    .GetAwaiter()
                    .GetResult();

                if (currentPage == null)
                {
                    currentPage = new PageVisit()
                    {
                        Url = url,
                        VisitsCount = 1,
                        VisitCookie = visitCookieValue,
                    };

                    repo.AddAsync(currentPage)
                        .GetAwaiter()
                        .GetResult();
                }
                else
                {
                    currentPage.VisitsCount += 1;
                    repo.Update(currentPage);
                }

                repo.SaveChangesAsync().GetAwaiter().GetResult();
            }
        }
    }
}
