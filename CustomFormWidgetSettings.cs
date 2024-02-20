using Grand.Domain.Configuration;

namespace Widgets.CustomForm
{
    public class CustomFormWidgetSettings : ISettings
    {
        public CustomFormWidgetSettings()
        {
            LimitedToStores = new List<string>();
            LimitedToGroups = new List<string>();
        }
        public int DisplayOrder { get; set; }
        public IList<string> LimitedToStores { get; set; }

        public IList<string> LimitedToGroups { get; set; }
    }
}
