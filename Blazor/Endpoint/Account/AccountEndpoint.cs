using Blazor.Endpoint.Account.Api;

namespace Blazor.Endpoint.Account;

public static class AccountEndpoint
{
    public static void Map(RouteGroupBuilder routeGroup)
    {
        var api = routeGroup.MapGroup("Account")
            .WithTags(nameof(Blazor.Endpoint.Account));

        api.MapPost("/GuestSignIn", GuestSignIn.Handle);
    }
}