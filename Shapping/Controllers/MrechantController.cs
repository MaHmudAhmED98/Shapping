using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shapping.DTO.Merchant;
using Shapping.DTO.RegestarDto;
using Shapping.DTO;
using Shapping.Handler.Marchant;

namespace Shapping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MrechantController : ControllerBase
    {
        private readonly IMerchantHandler merchantHandler;

        public MrechantController(IMerchantHandler merchantHandler)
        {
            this.merchantHandler = merchantHandler;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterMerchant(MerchantRegesterDTO registrationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await merchantHandler.RegisterMerchant(registrationDto);

            if (result > 0)
            {
                return Ok();
            }
            return StatusCode(500);

        }


        [HttpPut]
        public async Task<IActionResult> UpdateMerchant(string id, MerchantUpdateDto updateDto)
        {

            if (id != updateDto.Id)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await merchantHandler.UpdateMerchant(updateDto);

            if (result > 0)
            {
                return Ok();
            }

            return StatusCode(500);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteMerchant(string id)
        {
            var result = await merchantHandler.DeleteMerchant(id);

            if (result > 0)
            {
                return Ok();
            }
            return StatusCode(500);
        }



        [HttpGet]
        public async Task<IActionResult> GetAllMerchants()
        {
            var merchants = await merchantHandler.GetAllMarchentsAsync();
            return Ok(merchants);
        }



        [HttpPut("pass")]
        public async Task<IActionResult> UpdateMerchantPass(string id, UpdatePasswordDtos updateDto)
        {

            if (id != updateDto.Id)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await merchantHandler.UpdateMerchantPassword(updateDto);

            if (result > 0)
            {
                return Ok();
            }

            return StatusCode(500);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetMerchantById(string id)
        {
            var merchant = await merchantHandler.GetMerchantByIdWithSpecialPrices(id);

            if (merchant == null)
            {
                return NotFound();
            }

            return Ok(merchant);
        }
    }
}
