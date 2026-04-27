using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PurpleSky.API.Contracts;
using PurpleSkyTTRPG.Core.Interfaces;
using PurpleSkyTTRPG.Core.Models;

namespace PurpleSky.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly ICharactersService _charactersService;

        public CharactersController(ICharactersService charactersService) 
        {
            _charactersService = charactersService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CharactersResponse>>> GetCharacters()
        {
            var characters = await _charactersService.GetCharactersAsync();

            var response = characters.Select(c => new CharactersResponse(c.Id, c.OwnerId, c.System, c.CharacterName, c.CharData));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateCharacter([FromBody] CharactersRequest request)
        {
            var (character, error) = Character.Create(
                Guid.NewGuid(),
                request.OwnerId,
                request.System,
                request.CharacterName,
                request.CharData);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var characterId = await _charactersService.CreateCharacterAsync(character);

            return Ok(characterId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateCharacter(Guid id, [FromBody] CharactersRequest request)
        {
            var (character, error) = Character.Create(
                id,
                request.OwnerId,
                request.System,
                request.CharacterName,
                request.CharData
                );

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var characterId = await _charactersService.UpdateCharacterAsync(character);

            return Ok(characterId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteCharacter(Guid id)
        {
            return Ok(await _charactersService.DeleteCharacterAsync(id));
        }

    }
}
