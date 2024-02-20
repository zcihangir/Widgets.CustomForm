using Grand.Infrastructure.ModelBinding;
using Grand.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Widgets.CustomForm.Models
{
    public class ConfigurationModel : BaseModel
    {

        [GrandResourceDisplayName("Widgets.CustomForm.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [UIHint("CustomerGroups")]
        [GrandResourceDisplayName("Widgets.CustomForm.Fields.LimitedToGroups")]
        public string[] CustomerGroups { get; set; }

        //Store acl
        [GrandResourceDisplayName("Widgets.CustomForm.Fields.LimitedToStores")]
        [UIHint("Stores")]
        public string[] Stores { get; set; }
    }
}
