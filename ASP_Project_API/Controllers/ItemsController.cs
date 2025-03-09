using ASP_Project_API.HelperFunctions;
using ASP_Project_Core.DTO_s;
using ASP_Project_Core.Interfaces;
using ASP_Project_Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Project_API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        /*private readonly IItemRepository itemRepository;*/

        public ItemsController(/*IItemRepository itemRepository*/ IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            /*this.itemRepository = itemRepository;*/
        }
        [HttpGet("GetItems")]
        public async Task<ActionResult<IEnumerable<ItemDto>>> GetItems(int page_index, int page_size)
        {
            var items= await unitOfWork.ItemRepository.GetItemsAsync(page_index , page_size);
            if (items ==null)
            {
                return NotFound("items not exists");
            }
            return Ok(items);


        }

        [HttpPost("AddItems")]
        public async Task<IActionResult> AddItems(AddItems item)
        {
            

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

            var result = await unitOfWork.ItemRepository.AddItems(item);
            if (result == null)
            {
                return BadRequest("item is not add");
            }
            return Ok(result);
        }

        [HttpDelete("DeleteItem")]

        public async Task<IActionResult> DeleteItems(int itemId)
        {
            var result = await unitOfWork.ItemRepository.DeleteItems(itemId);
            if (result == "the item not found") 
            {
                return NotFound("the item not found");
            }
            return Ok(result);

        }


        [HttpPut("UpdateItem")]

        public async Task<ActionResult<UpdateDto>> UpdateItems(UpdateDto dto,int itemId)
        {
            var result = await unitOfWork.ItemRepository.UpdateItem(dto,itemId);
            if (result == null)
            {
                return NotFound("item not found");
            }
            return Ok(result);

        }







    }
}
