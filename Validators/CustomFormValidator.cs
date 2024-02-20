using FluentValidation;
using Grand.Business.Core.Interfaces.Common.Localization;
using Grand.Infrastructure.Validators;
using Widgets.CustomForm.Models;

namespace Widgets.CustomForm.Validators
{
    public class CustomFormValidator : BaseGrandValidator<CustomFormModel>
    {
        public CustomFormValidator(IEnumerable<IValidatorConsumer<CustomFormModel>> validators, 
            ITranslationService translationService) : base(validators)
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage(translationService.GetResource("Widgets.CustomForm.Fields.FullName.Required"));

            RuleFor(x => x.Address).NotEmpty().WithMessage(translationService.GetResource("Widgets.CustomForm.Fields.Address.Required"));
            RuleFor(x => x.Job).NotEmpty().WithMessage(translationService.GetResource("Widgets.CustomForm.Fields.Job.Required"));

            RuleFor(x => x.JobExperience).NotEmpty().WithMessage(translationService.GetResource("Widgets.CustomForm.Fields.JobExperience.Required"));
            RuleFor(x => x.WhoDidYouGetToKnowZAP).NotEmpty().WithMessage(translationService.GetResource("Widgets.CustomForm.Fields.WhoDidYouGetToKnowZAP.Required"));
            RuleFor(x => x.StrengthAndWeakness).NotEmpty().WithMessage(translationService.GetResource("Widgets.CustomForm.Fields.StrengthAndWeakness.Required"));

            RuleFor(x => x.EstimateOfSell).NotEmpty().WithMessage(translationService.GetResource("Widgets.CustomForm.Fields.EstimateOfSell.Required"));
            RuleFor(x => x.SellPromotionalProgram).NotEmpty().WithMessage(translationService.GetResource("Widgets.CustomForm.Fields.SellPromotionalProgram.Required"));
            RuleFor(x => x.WantedCities).NotEmpty().WithMessage(translationService.GetResource("Widgets.CustomForm.Fields.WantedCities.Required"));
        }
    }
}
