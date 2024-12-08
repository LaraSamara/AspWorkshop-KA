using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Workshop.API.Helper;
using Workshop.Core.Dto_s.Cart;
using Workshop.Core.Interfaces;

namespace Workshop.API.Controllers
{
    [Route("Workshop/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICartRepository cartRepository;

        public CartsController(ICartRepository CartRepository)
        {
            cartRepository = CartRepository;
        }
        [HttpPost]
        [Route("/AddToCart")]
        public async Task<IActionResult> AddBulkQuantityToCart(CartItemDto Dto)
        {
            var Token = Request.Headers["Authorization"].ToString().Replace("Bearer", "");
            if (Token.IsNullOrEmpty())
            {
                return Unauthorized("Missing Token!!");
            }
            try
            {
                var UserId = ExtractClaim.ExtractUserId(Token);
                if(!UserId.HasValue)
                {
                    return Unauthorized("Invalid Token!!");
                }
                var Result = await cartRepository.AddBulkQuantityToCartAsync(Dto, UserId.Value);
                if(Result.Equals("Item Add To Cart Successfully"))
                {
                    return Ok(new { Message = "Item Add To Cart Successfully" });
                }
                else
                {
                    return BadRequest(Result);
                }
            }catch (Exception ex)
            {
                return Unauthorized("Invalid Token" + ex.Message);
            }
        }
    }
}
