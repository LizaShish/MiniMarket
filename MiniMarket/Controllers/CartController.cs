using Microsoft.AspNetCore.Mvc;
using MiniMarket.Interfaces;

namespace MiniMarket.Controllers;

public class CartController : Controller
{
    private readonly ICartService _cartService;

    public CartController(ICartService cartService)
    {
        _cartService = cartService;
    }
    private int GetUserId() => 1;
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var cart = await _cartService.GetCart(GetUserId());
        return View(cart);
    }

    [HttpPost]
    public async Task<IActionResult> Add(int productId, int quantity = 1)
    {
        await _cartService.AddToCartAsync(GetUserId(),productId, quantity);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Remove(int productId)
    {
       await _cartService.RemoveFromCartAsync(GetUserId(), productId);
       return RedirectToAction("Index");
    }
    
    [HttpPost]
    public async Task<IActionResult> Clear()
    {
        await _cartService.ClearCartAsync(GetUserId());
        return RedirectToAction("Index");
    }
}