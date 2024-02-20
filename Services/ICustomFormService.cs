using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Widgets.CustomForm.Domain;

namespace Widgets.CustomForm.Services
{
    public partial interface ICustomFormService
    {
        Task DeleteRequest(CustomFormDomain request);
        Task<IList<CustomFormDomain>> GetRequests();

        Task<CustomFormDomain> GetById(string requestId);

        Task InsertRequest(CustomFormDomain request);
        Task UpdateRequest(CustomFormDomain request);
    }
}
