using Grand.Infrastructure.Models;

namespace Widgets.CustomForm.Models
{
    public class CustomFormInListModel: BaseModel
    {
        public string Id { get; set; }

        public string FullName { get; set; }

        public int Age { get; set; }

        public string LevelOfEducation { get; set; }

        public string FieldOfStudy { get; set; }

        public string Address { get; set; }

        public string WantedCities { get; set; }
    }
}
