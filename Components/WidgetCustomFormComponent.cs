using Grand.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Widgets.CustomForm.Models;
using Widgets.CustomForm.Services;

namespace Widgets.CustomForm.Components
{
    [ViewComponent(Name = "WidgetCustomForm")]
    public class WidgetCustomFormComponent : ViewComponent
    {
        private readonly ICustomFormService _requestService;
        private readonly IWorkContext _workContext;

        public WidgetCustomFormComponent(IWorkContext wc, ICustomFormService service )
        {
            this._requestService = service;
            this._workContext = wc;
        }

        public async Task<IViewComponentResult> InvokeAsync(string widgetZone, object additionalData = null)
        {
            var answers = await this._requestService.GetRequests();
            var model = new CustomFormModel();
            return View(model);
        }
    }
}
