using Microsoft.AspNetCore.Mvc;
using RedisCartAPI.Entities;
using RedisCartAPI.Repository;
using System.Net;

namespace RedisCartAPI.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CartController : ControllerBase
{
    private readonly ICartRepository cartRepository;

    public CartController(ICartRepository cartRepository)
    {
        this.cartRepository = cartRepository;
    }

    [HttpGet]
    [ProducesResponseType(typeof(Cart), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<Cart>> GetCartAsync(string userName)
    {
        return Ok(await cartRepository.GetCartAsync(userName));
    }

    [HttpPost]
    [ProducesResponseType(typeof(Cart), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<Cart>> InsertCartAsync([FromBody]Cart cart)
    {
        if (cart == null) Ok();
        cart = await cartRepository.InsertCartAsync(cart);
        return Ok(cart);
    }

    [HttpDelete]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public Task DeleteCartAsync(string userName)
    {
        return cartRepository.DeleteCartAsync(userName);
    }

}
