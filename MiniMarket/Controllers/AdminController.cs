using Microsoft.AspNetCore.Mvc;
using MiniMarket.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace MiniMarket.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController: Controller
{
    private readonly IOrderService _orderService;

    public AdminController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public async Task<IActionResult> Orders()
    {
        var oders = await _orderService.GetAllOrdersAsync();
        return View(oders);
    }

    public async Task<IActionResult> Details(int id)
    {
        var order = await _orderService.GetOrderDetails(id);
        if (order == null)
        {
            return NotFound();
        }
        return View(order);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateStatus(int id, string ststus)
    {
        await _orderService.UpdateOrderStatusAsync(id, ststus);
        return RedirectToAction("Orders");
    }
}