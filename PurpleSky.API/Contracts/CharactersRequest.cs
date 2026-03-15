using PurpleSkyTTRPG.Core.Enum;

namespace PurpleSky.API.Contracts
{
    public record CharactersRequest(
        Guid OwnerId,
        GameSystem System,
        string CharacterName,
        string CharData);
}
