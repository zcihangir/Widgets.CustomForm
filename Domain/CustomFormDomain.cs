using Grand.Domain.Localization;
using Grand.Domain.Stores;
using Grand.Domain;

namespace Widgets.CustomForm.Domain
{
    public class CustomFormDomain : BaseEntity, ITranslationEntity, IStoreLinkEntity
    {
        public CustomFormDomain()
        {
            Stores = new List<string>();
            Locales = new List<TranslationEntity>();
        }

        //-----------------------

        public string FullName { get; set; }

        public int Age { get; set; }

        public string LevelOfEducation { get; set; }

        public string FieldOfStudy { get; set; }

        public string Address { get; set; }

        public string Job { get; set; }

        public int JobExperience { get; set; }

        public string WorkAddress { get; set; }

        public string WorkTel { get; set; }

        public string BusinessWebsite { get; set; }

        public string InstagramChannel { get; set; }

        public string WhoDidYouGetToKnowZAP { get; set; }

        public string StrengthAndWeakness { get; set; }

        public int EstimateOfSell { get; set; }

        public string SellPromotionalProgram { get; set; }

        public string WantedCities { get; set; }


        //ITranslationEntity-------------------------------------------------
        public IList<TranslationEntity> Locales { get; set; }
        //-----------------------------------------------------------------


        //IStoreLinkEntity -------------------------------------------------
        public bool LimitedToStores { get; set; }
        public IList<string> Stores { get; set; }
        //-----------------------------------------------------------------
    }
}
