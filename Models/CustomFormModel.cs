using Grand.Infrastructure.ModelBinding;
using Grand.Infrastructure.Models;
using Grand.Web.Common.Link;
using Grand.Web.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace Widgets.CustomForm.Models
{
    public class CustomFormModel: BaseEntityModel, ILocalizedModel<CustomFormLocalizedModel>, IStoreLinkModel
    {
        public CustomFormModel()
        {
            Locales = new List<CustomFormLocalizedModel>();
        }

        [GrandResourceDisplayName("Widgets.CustomForm.Fields.FullName")]
        public string FullName { get; set; }

        [GrandResourceDisplayName("Widgets.CustomForm.Fields.Age")]
        public int Age { get; set; }
        [GrandResourceDisplayName("Widgets.CustomForm.Fields.LevelOfEducation")]
        public string LevelOfEducation { get; set; }
        [GrandResourceDisplayName("Widgets.CustomForm.Fields.FieldOfStudy")]
        public string FieldOfStudy { get; set; }

        [GrandResourceDisplayName("Widgets.CustomForm.Fields.Address")]
        public string Address { get; set; }

        [GrandResourceDisplayName("Widgets.CustomForm.Fields.Job")]
        public string Job { get; set; }

        [GrandResourceDisplayName("Widgets.CustomForm.Fields.JobExperience")]
        public int JobExperience { get; set; }

        [GrandResourceDisplayName("Widgets.CustomForm.Fields.WorkAddress")]
        public string WorkAddress { get; set; }

        [GrandResourceDisplayName("Widgets.CustomForm.Fields.WorkTel")]
        public string WorkTel { get; set; }

        [GrandResourceDisplayName("Widgets.CustomForm.Fields.BusinessWebsite")]
        public string BusinessWebsite { get; set; }

        [GrandResourceDisplayName("Widgets.CustomForm.Fields.InstagramChannel")]
        public string InstagramChannel { get; set; }

        [GrandResourceDisplayName("Widgets.CustomForm.Fields.WhoDidYouGetToKnowZAP")]
        public string WhoDidYouGetToKnowZAP { get; set; }

        [GrandResourceDisplayName("Widgets.CustomForm.Fields.StrengthAndWeakness")]
        public string StrengthAndWeakness { get; set; }

        [GrandResourceDisplayName("Widgets.CustomForm.Fields.EstimateOfSell")]
        public int EstimateOfSell { get; set; }

        [GrandResourceDisplayName("Widgets.CustomForm.Fields.SellPromotionalProgram")]
        public string SellPromotionalProgram { get; set; }

        [GrandResourceDisplayName("Widgets.CustomForm.Fields.WantedCities")]
        public string WantedCities { get; set; }



        //ILocalizedModel------------------
        public IList<CustomFormLocalizedModel> Locales { get; set; }
        //---------------------------------


        //IStoreLinkModel ----------
        //Store acl
        [GrandResourceDisplayName("Widgets.CustomForm.LimitedToStores")]
        [UIHint("Stores")]
        public string[] Stores { get; set; }
    }

    public partial class CustomFormLocalizedModel : ILocalizedModelLocal
    {
        public string LanguageId { get; set; }

        
    }
}
