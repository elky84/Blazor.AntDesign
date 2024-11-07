using Blazor.Common;
using Char = Blazor.Domain.Char.Char;


namespace Blazor.Endpoint.Account.Dto;

public record GuestSignInRes : BaseResponse
{
    public Blazor.Domain.Account.Account? Account { get; init; }

    public IEnumerable<Char> Chars { get; set; } = [];
}