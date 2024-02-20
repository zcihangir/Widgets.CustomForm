using Grand.Infrastructure.Endpoints;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Widgets.CustomForm
{
    public partial class EndpointProvider : IEndpointProvider
    {
        public void RegisterEndpoint(IEndpointRouteBuilder endpointRouteBuilder)
        {
            endpointRouteBuilder.MapControllerRoute("Plugin.Widgets.CustomForm.Create",
                 "Plugins/MyCustomForm/Create",
                 new { controller = "MyCustomForm", action = "Create" }
            );

            endpointRouteBuilder.MapControllerRoute("Plugin.Widgets.CustomForm.Create.small",
                 "new-form-request",
                 new { controller = "MyCustomForm", action = "Create" }
            );
        }
        public int Priority => 0;

    }
}
