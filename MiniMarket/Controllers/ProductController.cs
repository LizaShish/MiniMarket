using Microsoft.AspNetCore.Mvc;
using MiniMarket.DTOs;
using MiniMarket.Interfaces;
using MiniMarket.Helpers;
using MiniMarket.Models;
using System.Linq;

namespace MiniMarket.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    
    [HttpGet]
    public IActionResult Index(int page = 1, int pageSize = 10)
    {
        var allProducts = _productService.GetProduct();
        var totalCount = allProducts.Count();
        var pageProduct = PaginationHelper.Paginate(allProducts, page, pageSize).ToList();
        var totalPages = PaginationHelper.GetTotalPages(totalCount, pageSize);

        var viewModel = new ProductListViewModel
        {
            Products = pageProduct,
            PageNumber = page,
            TotalPages = totalPages,
            TotalCount = totalCount,
            PageSize = pageSize
        };
        
        return View(viewModel);
    }
}