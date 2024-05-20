using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using server_side.Models;
using server_side.Services;
namespace server_side.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PetController : ControllerBase
    {
        private readonly PetService _petService;

        public PetController(PetService petService)
        {
            _petService = petService;
        }


        [HttpGet]
        public async Task<List<Pet>> GetAll() 
        {
            return await _petService.GetAll();
        }

        [HttpPost]
        public async Task<IActionResult> PostPet([FromBody] Pet pet)
        {
            pet.Created_At = DateTime.Now;
            await _petService.AddPet(pet);
            return CreatedAtAction(nameof(PostPet), new { id = pet.Id }, pet);

        }
    }
}
