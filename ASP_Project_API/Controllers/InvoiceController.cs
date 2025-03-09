using ASP_Project_API.HelperFunctions;
using ASP_Project_Core.Interfaces;
using ASP_Project_Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        /*private readonly IInvoiceRepository invoiceRepository;*/

        public InvoiceController(/*IInvoiceRepository invoiceRepository*/ IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            /*            this.invoiceRepository = invoiceRepository;*/
        }

        [HttpPost("Create_Invocie")]
        public async Task<IActionResult> CreateInvoice()
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

                var result = await unitOfWork.InvoiceRepository.CreateInvoiceAsync(userId.Value);
                if (result.StartsWith("Invoice created successfully"))
                {
                    return Ok(result);
                }
                return BadRequest(result);

            }
            catch (Exception ex)
            {

                return Unauthorized("invalid token :" + ex.Message);
            }
        }

        [HttpGet("GetInvoiceReciept")]

        public async Task<IActionResult> GetInvoiceReciept(int invoice_Id)
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

                var result = await unitOfWork.InvoiceRepository.GetInvoiceReciept(userId.Value , invoice_Id);
                if (result ==null)
                {
                    return NotFound("invoice not found");
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
