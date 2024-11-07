using Blazor.Test.Extensions;
using Blazor.Endpoint.Account.Dto;
using Blazor.Test;
using Xunit.Abstractions;

namespace Blazor.Test.Account;

[Collection(nameof(Blazor))]
public class GuestSignIn: IClassFixture<CustomWebApplicationFactory>
{
    private readonly CustomWebApplicationFactory _factory;
    private readonly BlazorFixture _fixture;

    public GuestSignIn(BlazorFixture fixture, CustomWebApplicationFactory factory, ITestOutputHelper output)
    {
        _fixture = fixture;
        _fixture.SetOutputHelper(output);

        _factory = factory;
    }

    [Fact]
    public async Task EmptyAccount()
    {
        using var client = _factory.CreateClient();

        var resGuestSignIn = await client.Post<GuestSignInRes>("/api/account/GuestSignIn",
            new GuestSignInReq("", "", ""));

        Assert.NotNull(resGuestSignIn);

        Assert.Equal(500, resGuestSignIn.StatusCode);
    }

    [Fact]
    public async Task Normal()
    {
        using var client = _factory.CreateClient();

        var resGuestSignIn = await client.Post<GuestSignInRes>("/api/account/GuestSignIn",
            new GuestSignInReq("elky", "", ""));

        Assert.NotNull(resGuestSignIn);

        Assert.Equal(200, resGuestSignIn.StatusCode);
    }
}