using Grand.Business.Core.Extensions;
using Grand.Business.Core.Interfaces.Common.Localization;
using Grand.Business.Core.Interfaces.Storage;
using Grand.Data;
using Grand.Infrastructure.Plugins;

namespace Widgets.CustomForm
{

    public class CustomFormWidgetPlugin : BasePlugin, IPlugin
    {
        private readonly IPictureService _pictureService;
        private readonly IRepository<Domain.CustomFormDomain> _CustomFormRepository;
        private readonly ITranslationService _translationService;
        private readonly ILanguageService _languageService;
        private readonly IDatabaseContext _databaseContext;

        public CustomFormWidgetPlugin(IPictureService pictureService,
            IRepository<Domain.CustomFormDomain> CustomFormRepository,
            ITranslationService translationService,
            ILanguageService languageService,
            IDatabaseContext databaseContext)
        {
            _pictureService = pictureService;
            _CustomFormRepository = CustomFormRepository;
            _translationService = translationService;
            _languageService = languageService;
            _databaseContext = databaseContext;
        }
        public override async Task Install()
        {
            //Create index
            await _databaseContext.CreateIndex(_CustomFormRepository, OrderBuilder<Domain.CustomFormDomain>.Create()
                .Ascending(x => x.Id), "CustomFormId_DisplayOrder");


            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.FriendlyName", "Widget form Request");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Added", "form Request added");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Addnew", "Add new form Request");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.AvailableStores", "Available stores");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.AvailableStores.Hint", "Select stores for which the faqs will be shown.");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Backtolist", "Back to list");

            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Edit", "Edit form Request");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Edited", "form Request edited");



            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.FullWidth", "Full width");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.FullWidth.hint", "Full width");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Info", "Info");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.LimitedToStores", "Limited to stores");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.LimitedToStores.Hint", "Determines whether the reperesentation request is available only at certain stores.");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Link", "URL");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Link.Hint", "Enter URL. Leave empty if you don't want this picture to be clickable.");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Manage", "Manage form Request");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Collection", "Collection");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Collection.Hint", "Select the collection where faq should appear.");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Collection.Required", "Collection is required");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Brand", "Brand");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Brand.Hint", "Select the brand where faq should appear.");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Brand.Required", "Brand is required");


            //------------------------
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.DisplayOrder", "Display order");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.LimitedToGroups", "Limited to groups");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.LimitedToStores", "Limited to stores");


            //------------------------
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.inputform.head1", "head1");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.inputform.head2", "head2");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.inputform.head3", "head3");
            //------------------------
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.FullName", "Full name");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.FullName.Hint", "Enter your full name");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.FullName.Required", "fullname is required");

            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.Age", "Age");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.Age.Hint", "Enter your age");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.Age.Required", "fullname is required");

            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.LevelOfEducation", "Level Of education");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.LevelOfEducation.Hint", "Enter your level of education");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.LevelOfEducation.Required", "level of education is required");

            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.FieldOfStudy", "FieldOfStudy");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.FieldOfStudy.label", "Field of study");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.FieldOfStudy.Hint", "Enter your field of study");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.FieldOfStudy.Required", "Field of study of education is required");


            //
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.Address", "Address");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.Address.Hint", "Enter your address");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.Address.Required", "address is required");

            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.Job", "Job");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.Job.Hint", "Enter your job");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.Job.Required", "job is required");

            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.JobExperience", "Job Experience (Year)");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.JobExperience.Hint", "Enter your job experience (year)");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.JobExperience.Required", "job experience is required");

            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.WorkAddress", "Work Address");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.WorkAddress.Hint", "Enter your work address");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.WorkAddress.Required", "work address is required");

            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.WorkTel", "Work Tel");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.WorkTel.Hint", "Enter your work tel");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.WorkTel.Required", "work tel is required");

            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.BusinessWebsite", "Business Website");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.BusinessWebsite.Hint", "Enter your business website");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.BusinessWebsite.Required", "business website is required");

            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.InstagramChannel", "Instagram Channel");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.InstagramChannel.Hint", "Enter your instagram channel");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.InstagramChannel.Required", "instagram channel is required");

            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.WhoDidYouGetToKnowZAP", "Who did you get to know ZAP");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.WhoDidYouGetToKnowZAP.Hint", "Enter who did you get to know ZAP");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.WhoDidYouGetToKnowZAP.Required", "Who did you get to know ZAP is required");

            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.StrengthAndWeakness", "Strength and weakness of ZAP");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.StrengthAndWeakness.Hint", "Enter Strength and weakness of ZAP");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.StrengthAndWeakness.Required", "Strength and weakness of ZAP is required");

            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.EstimateOfSell", "Estimate of sell");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.EstimateOfSell.Hint", "Enter your estimate of sell");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.EstimateOfSell.Required", "Estimate of sell is required");

            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.SellPromotionalProgram", "Sell promotional program");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.SellPromotionalProgram.Hint", "Enter your sell promotional program");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.SellPromotionalProgram.Required", "Sell promotional program is required");

            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.WantedCities", "Wanted cities");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.WantedCities.Hint", "Enter your wanted cities");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Fields.WantedCities.Required", "Wanted cities is required");



            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.Stores", "Stores");


            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Widgets.CustomForm.SendButton", "Send Form");


            



            await base.Install();
        }

        public override async Task Uninstall()
        {
            await _CustomFormRepository.DeleteAsync(_CustomFormRepository.Table.ToList());
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Widgets.CustomForm.FriendlyName");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Widgets.CustomForm.Added");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Widgets.CustomForm.Addnew");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Widgets.CustomForm.AvailableStores");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Widgets.CustomForm.AvailableStores.Hint");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Widgets.CustomForm.Backtolist");

            await this.DeletePluginTranslationResource(_translationService, _languageService, "Widgets.CustomForm.Edit");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Widgets.CustomForm.Edited");



            await this.DeletePluginTranslationResource(_translationService, _languageService, "Widgets.CustomForm.FullWidth");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Widgets.CustomForm.FullWidth.hint");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Widgets.CustomForm.Info");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Widgets.CustomForm.LimitedToStores");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Widgets.CustomForm.LimitedToStores.Hint");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Widgets.CustomForm.Link");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Widgets.CustomForm.Link.Hint");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Widgets.CustomForm.Manage");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Widgets.CustomForm.Collection");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Widgets.CustomForm.Collection.Hint");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Widgets.CustomForm.Collection.Required");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Widgets.CustomForm.Brand");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Widgets.CustomForm.Brand.Hint");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Widgets.CustomForm.Brand.Required");


            //------------------------
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Widgets.CustomForm.Fields.DisplayOrder");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Widgets.CustomForm.Fields.LimitedToGroups");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Widgets.CustomForm.Fields.LimitedToStores");

            //------------------------



            await this.DeletePluginTranslationResource(_translationService, _languageService, "Widgets.CustomForm.Stores");



            await base.Uninstall();
        }

        public override string ConfigurationUrl()
        {
            return CustomFormWidgetDefaults.ConfigurationUrl;
        }
    }
}
