using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedMango_API.Data;
using RedMango_API.Models;

namespace RedMango_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        protected ApiResponse _response;
        private readonly ApplicationDbContext _db;
        public ShoppingCartController(ApplicationDbContext db)
        {
            _response = new();
            _db = db;
        } 

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> AddOrUpdateItemInCart(string userId, int menuItemId, int updateQuantityBy)
        {
            // Shopping cart will have one entry per user id , even if a user has many items in cart.
            // Cart items will have all the items in shopping cart for a user
            // updatequantityby will have count by with an items quantity needs to be updated
            // if it is -1 that means we have lower a count if it is 5 it means we have to add 5 count to existing count.
            // if updatequantityby by is 0, item will be removed

            // when a user adds a new item to a new shopping cart for the first time
            // when a user adds a new item to an existing shopping cart (basically user has other items in cart)
            // when a user updated an exisitng item count
            // when a user removes an existing item

        }
    }
}
