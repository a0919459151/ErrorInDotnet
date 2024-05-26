using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using X.PagedList.Mvc.Core;
using X.PagedList.Web.Common;

namespace Core.Helpers
{
    public class PagerHelper
    {
        private readonly IHtmlHelper _htmlHelper;
        private readonly IUrlHelper _urlHelper;
        private readonly IHttpContextAccessor? _httpContextAccessor;

        private PagedListRenderOptions DefaultOptions
            => new() { LiElementClasses = ["page-item"], PageClasses = ["page-link"] };

        public PagerHelper(
            IHtmlHelper htmlHelper,
            IActionContextAccessor actionContextAccessor,
            IUrlHelperFactory urlHelperFactory,
            IHttpContextAccessor? httpContextAccessor)
        {
            _htmlHelper = htmlHelper;
            _urlHelper = urlHelperFactory.GetUrlHelper(actionContextAccessor.ActionContext ?? throw new Exception("ActionContext not found"));
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetPagerInfo(IPagedList? pagedList)
        {
            if (pagedList is null) return string.Empty;

            return string.Format(
                PaginationConstants.PagerInfoFormat,
                pagedList.TotalItemCount,
                pagedList.PageSize,
                pagedList.PageCount);
        }

        public HtmlString CreatePager(IPagedList? pagedList, IPaginationQuery queryModel)
        {
            if (pagedList is null)
                pagedList = pagedList ?? GetEmptyPagedList();

            return _htmlHelper.PagedListPager(pagedList, GeneratePageUrl(queryModel), DefaultOptions);
        }

        private PagedList<object> GetEmptyPagedList()
        {
            return new PagedList<object>([], 1, 1);
        }

        private Func<int, string> GeneratePageUrl(IPaginationQuery queryModel)
        {
            return page =>
            {
                var actionName = GetActionName();
                queryModel.PageNumber = page;
                return _urlHelper.Action(actionName, queryModel) ?? throw new Exception("Action not found");
            };
        }

        private string? GetActionName()
        {
            string? actionName = _httpContextAccessor?.HttpContext?.Request.RouteValues["action"]?.ToString();
            return actionName;
        }
    }
}
