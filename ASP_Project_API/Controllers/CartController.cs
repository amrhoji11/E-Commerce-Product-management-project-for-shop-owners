using ASP_Project_API.HelperFunctions;
using ASP_Project_Core.DTO_s;
using ASP_Project_Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace ASP_Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        /*private readonly ICartRepository cartRepository;*/

        public CartController(/*ICartRepository cartRepository*/ IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            /*this.cartRepository = cartRepository;*/
        }

        [HttpPost("add_bulk_items_to_cart")]
         public async Task<ActionResult> AddBulkItemsToCart(CartItemDto dto) // لانو بقدر اطولو من التوكين UserId هنا ما بلزم احط ال
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ","");

            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized("token is missing");

            }

            try
            {
                var userId = ExtractClaims.ExtractUserId(token);
                if (userId is null)
                {
                    return Unauthorized("invalid user token");

                }
                var result = await unitOfWork.CartRepository.AddBulkQuantityToCartAsync(dto,userId.Value);
                if (result == "item added to card successfully")
                {
                    return Ok(result);

                }
                else
                {
                    return BadRequest(result);
                }
                

            }
            catch (Exception ex)
            {

                return Unauthorized("invalid token :"+ ex.Message);
            }

        }

        [HttpPost("add_one_items_to_cart")]
        public async Task<IActionResult> AddOneItemsToCart(CartItemDto dto)
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized("token is missing");

            }

            try
            {
                var userId = ExtractClaims.ExtractUserId(token);
                if (userId is null)
                {
                    return Unauthorized("invalid user token");

                }
                var result = await unitOfWork.CartRepository.AddOneQuantityToCartAsync(dto, userId.Value);
                if (result == "items added to cart successfuly")
                {
                    return Ok(result);

                }
                else
                {
                    return BadRequest(result);
                }


            }
            catch (Exception ex)
            {

                return Unauthorized("invalid token :" + ex.Message);
            }

        }

        [HttpPost("Delete_one_items_to_cart")]
        public async Task<IActionResult> DeleteOneQuantityToCartAsync(CartItemDto dto)
        {

            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized("token is missing");

            }

            try
            {
                var userId = ExtractClaims.ExtractUserId(token);
                if (userId is null)
                {
                    return Unauthorized("invalid user token");

                }
                var result = await unitOfWork.CartRepository.DeleteOneQuantityToCartAsync(dto, userId.Value);
                if (result == "items remove to cart successfuly")
                {
                    return Ok(result);

                }
                else
                {
                    return BadRequest(result);
                }


            }
            catch (Exception ex)
            {

                return Unauthorized("invalid token :" + ex.Message);
            }



        }


        [HttpGet("GetAllItemsFromCart")]
        public async Task<IActionResult> GetAllItemsFromCart()
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized("token is missing");

            }

            try
            {
                var userId = ExtractClaims.ExtractUserId(token);
                if (userId is null)
                {
                    return Unauthorized("invalid user token");

                }
                var result = await unitOfWork.CartRepository.GetAllItemsFromCart(userId.Value);
                if (result == null)
                {
                    return NotFound("no items in your cart");

                }
               return Ok(result);


            }
            catch (Exception ex)
            {

                return Unauthorized("invalid token :" + ex.Message);
            }
        }


    }
}
