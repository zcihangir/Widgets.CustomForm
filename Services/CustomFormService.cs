using Grand.Infrastructure.Caching;
using Grand.Infrastructure;
using Widgets.CustomForm.Domain;
using Grand.Data;
using Grand.Business.Core.Interfaces.Common.Security;

namespace Widgets.CustomForm.Services
{

    public class CustomFormService : ICustomFormService
    {
        #region fields
        private readonly IRepository<CustomFormDomain> _reporistoryRequest;
        private readonly IWorkContext _workContext;
        private readonly IAclService _aclService;
        private readonly ICacheBase _cacheManager;

        /// <summary>
        /// Key for sliders
        /// </summary>
        /// <remarks>
        /// {0} : Store id
        /// {1} : Is important
        /// </remarks>
        public const string REQUEST_MODEL_KEY = "Grand.form-request-{0}-{1}";
        public const string REQUEST_PATTERN_KEY = "Grand.form-request";
        #endregion


        public CustomFormService(IRepository<CustomFormDomain> reporistoryRequest,
            IWorkContext workContext, IAclService aclService,
            ICacheBase cacheManager)
        {
            this._reporistoryRequest = reporistoryRequest;
            this._workContext = workContext;
            this._aclService = aclService;
            this._cacheManager = cacheManager;
        }
        public virtual async Task DeleteRequest(CustomFormDomain request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            //clear cache
            await _cacheManager.RemoveByPrefix(REQUEST_PATTERN_KEY);

            await _reporistoryRequest.DeleteAsync(request);
        }

        public virtual Task<CustomFormDomain> GetById(string requestId)
        {
            return _reporistoryRequest.GetOneAsync(x => x.Id == requestId);
        }

        public virtual async Task<IList<CustomFormDomain>> GetRequests()
        {
            return await Task.FromResult(_reporistoryRequest.Table
                .OrderByDescending(x => x.Id)
                .ToList());
        }

        

        public virtual async Task InsertRequest(CustomFormDomain request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            //clear cache
            await _cacheManager.RemoveByPrefix(REQUEST_PATTERN_KEY);

            await _reporistoryRequest.InsertAsync(request);
        }

        public virtual async Task UpdateRequest(CustomFormDomain request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            //clear cache
            await _cacheManager.RemoveByPrefix(REQUEST_PATTERN_KEY);

            await _reporistoryRequest.UpdateAsync(request);
        }
    }
}
