using Grand.Business.Core.Interfaces.Cms;
using Grand.Business.Core.Interfaces.Common.Localization;

namespace Widgets.CustomForm
{
    public class CustomFormWidgetProvider: IWidgetProvider
    {
        private readonly ITranslationService _translationService;
        private readonly CustomFormWidgetSettings _requestWidgetSettings;

        public CustomFormWidgetProvider(ITranslationService translationService, CustomFormWidgetSettings requestWidgetSettings)
        {
            _translationService = translationService;
            _requestWidgetSettings = requestWidgetSettings;
        }

        public string ConfigurationUrl => CustomFormWidgetDefaults.ConfigurationUrl;

        public string SystemName => CustomFormWidgetDefaults.ProviderSystemName;

        public string FriendlyName => _translationService.GetResource(CustomFormWidgetDefaults.FriendlyName);

        public int Priority => _requestWidgetSettings.DisplayOrder;

        public IList<string> LimitedToStores => _requestWidgetSettings.LimitedToStores;

        public IList<string> LimitedToGroups => _requestWidgetSettings.LimitedToGroups;

        public async Task<IList<string>> GetWidgetZones()
        {
            return await Task.FromResult(new List<string>
            {
                CustomFormWidgetDefaults.WidgetZoneCustomFormPage,
            });
        }

        public Task<string> GetPublicViewComponentName(string widgetZone)
        {
            return Task.FromResult("WidgetCustomForm");
        }
    }
}
