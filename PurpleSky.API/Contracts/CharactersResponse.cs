using PurpleSkyTTRPG.Core.Enum;

namespace PurpleSky.API.Contracts
{
    public record CharactersResponse(
        Guid Id,
        Guid OwnerId,
        GameSystem System,
        string CharacterName,
        string CharData);
}
