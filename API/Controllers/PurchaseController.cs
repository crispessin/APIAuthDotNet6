using Application.DTOs;
using Application.Services;
using Application.Services.Interfaces;
using Domain.Validations;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;

        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] PurchaseDTO purchaseDTO)
        {
            try
            {
                var result = await _purchaseService.CreateAsync(purchaseDTO);
                if (result.IsSucess)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (DomainValidationException ex)
            {
                var result = ResultService.Fail(ex.Message);
                return BadRequest(result);
            }

        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var result = await _purchaseService.GetAsync();
            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var result = await _purchaseService.GetByIdAsync(id);
            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut]
        public async Task<ActionResult> EditAsync([FromBody] PurchaseDTO purchaseDTO)
        {
            try
            {
                var result = await _purchaseService.UpdateAsync(purchaseDTO);
                if (result.IsSucess)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (DomainValidationException ex)
            {
                var resul = ResultService.Fail(ex.Message);
                return BadRequest(resul);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _purchaseService.DeleteAsync(id);
            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
