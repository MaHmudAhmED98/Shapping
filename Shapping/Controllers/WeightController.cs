using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shapping.DTO.Weight;
using Shapping.Handler.Weight;
using Shapping.Model;
using static Shapping.DTO.Weight.Weight;

namespace Shapping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeightController : ControllerBase
    {
        private readonly IWeightHandler weightHandler;

        public WeightController(IWeightHandler weightHandler)
        {
            this.weightHandler = weightHandler;
        }
        [HttpPost]
        public async Task<ActionResult> AddWeigt(AddWeightDto weightDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await weightHandler.Add(weightDto);
            return Ok(new { message = "Weight was Added successfully." });

        }
        [HttpPut]
        public async Task<ActionResult> Update(UpdateWeightDto weight)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await weightHandler.Update(weight);
            if (result > 0)
            {
                return Ok(new { message = "Weight was updated successfully." });
            }
            ModelState.AddModelError("save", "Can't save Weight may be something wrong!");
            return BadRequest(ModelState);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetWeightById(int id)
        {
            var weight = await weightHandler.GetWeightByIdAsync(id);
            if (weight == null)
            {
                return NotFound();
            }

            return Ok(weight);
        }
    }
}
