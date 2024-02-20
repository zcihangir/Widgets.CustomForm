using Grand.Business.Core.Interfaces.Cms;
using Grand.Business.Core.Interfaces.Common.Configuration;
using Grand.Business.Core.Interfaces.Common.Localization;
using Grand.Business.Core.Interfaces.Storage;
using Grand.Domain.Stores;
using Grand.Web.Common.Controllers;
using Grand.Web.Common.Security.Captcha;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Widgets.CustomForm.Models;
using Widgets.CustomForm.Services;

namespace Widgets.CustomForm.Controllers
{
    public class MyCustomFormController: BasePluginController
    {
        #region fields
        private readonly IPictureService _pictureService;
        private readonly ITranslationService _translationService;
        private readonly ICustomFormService _requestService;
        private readonly ILanguageService _languageService;
        private readonly ISettingService _settingService;
        private readonly CustomFormWidgetSettings _requestWidgetSettings;
        private readonly CaptchaSettings _captchaSettings;
        #endregion

        public MyCustomFormController(IPictureService pictureService,
            ITranslationService translationService,
            ICustomFormService requestService,
            ILanguageService languageService,
            ISettingService settingService,
            CustomFormWidgetSettings requestWidgetSettings,
            CaptchaSettings captchaSettings)
        {
            this._pictureService = pictureService;
            this._translationService = translationService;
            this._requestService = requestService;
            this._languageService = languageService;
            this._settingService = settingService;
            this._requestWidgetSettings = requestWidgetSettings;
            this._captchaSettings = captchaSettings;
        }


        public async Task<IActionResult> Create()
        {
            var model = new CustomFormModel();
            //locales
            await AddLocales(_languageService, model.Locales);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create( 
            [FromServices] StoreInformationSettings storeInformationSettings,
            [FromServices] IPageService pageService, CustomFormModel model, IFormCollection form, bool captchaValid)
        {
            if (storeInformationSettings.StoreClosed)
            {
                var closestorepage = await pageService.GetPageBySystemName("ContactUs");
                if (closestorepage == null || !closestorepage.AccessibleWhenStoreClosed)
                    return RedirectToRoute("StoreClosed");
            }

            //validate CAPTCHA
            if (_captchaSettings.Enabled && _captchaSettings.ShowOnContactUsPage && !captchaValid)
            {
                ModelState.AddModelError("", _captchaSettings.GetWrongCaptchaMessage(_translationService));
            }

            if (ModelState.IsValid)
            {
                var request = model.ToEntity();
                request.Locales = model.Locales.ToLocalizedProperty();

                await _requestService.InsertRequest(request);

                Success(_translationService.GetResource("Widgets.CustomForm.Added"));
                return RedirectToAction("CreateSuccessfully", new { id = request.Id });

            }
            return View(model);
        }

        public IActionResult CreateSuccessfully()
        {
            return View();
        }
    }
}
