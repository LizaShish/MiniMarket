using Microsoft.AspNetCore.Mvc;
using MiniMarket.DTOs;
using MiniMarket.Interfaces;
using MiniMarket.Helpers;
using MiniMarket.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace MiniMarket.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index(string? category, int page = 1, int pageSize = 10)
    {
        var allProducts = await _productService.GetProduct();
        var totalCount = allProducts.Count();
        var pageProduct = PaginationHelper.Paginate(allProducts, page, pageSize).ToList();
        var totalPages = PaginationHelper.GetTotalPages(totalCount, pageSize);

        var viewModel = new ProductListViewModel
        {
            Products = pageProduct,
            PageNumber = page,
            TotalPages = totalPages,
            TotalCount = totalCount,
            Category = category,
            PageSize = pageSize
        };
        
        return View(viewModel);
    }
    
    [HttpGet]
    public IActionResult Details(int id)
    {
        var product = _productService.GetProductById(id);
        if(product == null)
          return NotFound();
        return View();
    }
    
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(ProductDTO product)
    {
        if (!ModelState.IsValid)
        {
            return View(product);
        }
        await _productService.CreateAsync(product);
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Edit(int id)
    {
        var product = await _productService.GetProductById(id);
        if (product == null)
            return NotFound();

        return View(product);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Edit(ProductDTO productDTO)
    {
        if (!ModelState.IsValid)
            return View(productDTO);

        await _productService.UpdateAsync(productDTO);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        await _productService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}