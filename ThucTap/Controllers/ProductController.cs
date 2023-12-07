using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThucTap.Iservice;
using ThucTap.Payloads.Requests.OrderRequests;
using ThucTap.Payloads.Requests.ReviewRequests;
using ThucTap.services;

namespace ThucTap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController()
        {
            _productService = new ProductService();
        }
        [HttpGet("Get-All")]
        public IActionResult Get()
        {
            var res = _productService.GetAll();
            return Ok(res);
        }
        [HttpGet("Get-Review")]
        public IActionResult GetReview(int id)
        {
            var res = _productService.GetReviews(id);
            return Ok(res);
        }
        [HttpGet("See-More")]
        public IActionResult GetMore(int id)
        {
            var res = _productService.GetMore(id);
            return Ok(res);
        }
        [HttpGet("Get-Order")]
        public IActionResult GetOrder()
        {
            var res = _productService.GetOrders();
            return Ok(res);
        }
        [HttpPost("Evaluate")]
        public IActionResult Evaluate(Request_Review _Review)
        {
            var res = _productService.AddReview(_Review);
            return Ok(res);
        }
        [HttpPost("Buy")]
        public IActionResult BuyOrder(Buy_OrderRequest request)
        {
            return Ok(_productService.NewOrder(request));
        }
    }
}
