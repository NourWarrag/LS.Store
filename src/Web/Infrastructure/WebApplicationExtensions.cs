using System.Reflection;
using LS.Store.Web.Endpoints;

namespace LS.Store.Web.Infrastructure;
public static class WebApplicationExtensions
{
    public static RouteGroupBuilder MapGroup(this WebApplication app, EndpointGroupBase group)
    {
        var groupName = group.GetType().Name;

        return app
            .MapGroup($"/api/{groupName}")
            .WithGroupName(groupName)
            .WithTags(groupName)
            .WithOpenApi();
    }

    public static WebApplication MapEndpoints(this WebApplication app)
    {
        var p = new Products();

        p.MapProducts(app);

        return app;
    }
}
