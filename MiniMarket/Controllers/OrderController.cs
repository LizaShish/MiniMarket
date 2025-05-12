using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniMarket.Interfaces;
using MiniMarket.Models;

namespace MiniMarket.Controllers;

public class OrderController : Controller
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [Authorize]
    public IActionResult Checkout()
    {
        return View();
    }

    [HttpPost]
    [Authorize]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CheckoutConfirmed()
    {
       var usrtId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier!));
       try
       {
           await _orderService.PlaceOrderAsync(usrtId);
           return RedirectToAction("MyOrders");
       }
       catch (Exception ex)
       {
           ModelState.AddModelError("", ex.Message);
           return View("Checkout");
       }
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> MyOrders()
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var orders = await _orderService.GetUsersOrders(userId);
        return View(orders);
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Details(int id)
    {
        var order = await _orderService.GetOrderDetails(id);
        if (order == null)
        {
            return NotFound();
        }
        return View(order);
    }
}