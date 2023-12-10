using InventorySystem.Core.Application.Helper;
using InventorySystem.Core.Application.Interface.Services;
using InventorySystem.Core.Application.Services;
using InventorySystem.Core.Application.ViewModel.Marca;
using InventorySystem.Core.Application.ViewModel.Producto;
using InventorySystem.Core.Application.ViewModel.Usuario;
using InventorySystem.Core.Domain.Entities;
using InventorySystem.Infrastructured.Persistences.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.NetworkInformation;


namespace InventorySystem.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProductoService _productService;
        private readonly IMarcaService _marcaService;
        private readonly ICategoryService _categoryService;
        private readonly IProveedorService _proveedorService;
        private readonly IHttpContextAccessor _HttpContextAccessor;
        public ProductoController(IHttpContextAccessor httpContext,IProductoService productService, IMarcaService marcaService, ICategoryService categoryService, IProveedorService service)
        {
            _productService = productService;
            _marcaService = marcaService;
            _categoryService = categoryService;
            _proveedorService = service;
            _HttpContextAccessor = httpContext;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Categorias = await _categoryService.GetAllViewModel();
            ViewBag.Marcas = await _marcaService.GetAllViewModel();
            ViewBag.Proveedor = await _proveedorService.GetAllViewModel();
            return View(await _productService.GetAllViewModel());
        }

        public async Task<IActionResult> GetBy (string? nombre, int? idMarca, int? idProveedor, int? idCategoria )
        {

            var productos = await _productService.GetBy(nombre, idMarca, idProveedor, idCategoria);
            ViewBag.Categorias = await _categoryService.GetAllViewModel();
            ViewBag.Marcas = await _marcaService.GetAllViewModel();
            ViewBag.Proveedor = await _proveedorService.GetAllViewModel();

            return View("Index", productos);
        }
        public async Task<IActionResult> Create()
        {
            ProductoSaveViewModel vm = new();
            vm.marcaViewModels = await _marcaService.GetAllViewModel();
            vm.categoriaViewModels = await _categoryService.GetAllViewModel();
            vm.proveedorSaveViews = await _proveedorService.GetAllViewModel();

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductoSaveViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.marcaViewModels = await _marcaService.GetAllViewModel();
                vm.categoriaViewModels = await _categoryService.GetAllViewModel();
                vm.proveedorSaveViews = await _proveedorService.GetAllViewModel();
                return View(vm);
            }
            vm.IdNegocio = _HttpContextAccessor.HttpContext.Session.Get<UsuarioViewModel>("user").IdNegocio;
            var producto = await _productService.Add(vm);

            if(producto != null)
            {
                vm.Id = producto.Id;
                vm.ImgUrl = AdmFiles.UploadFile(vm.ImgFile, producto.Id, "Producto");
                await _productService.Update(vm);
            }
            return RedirectToRoute(new { controller = "Producto", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            ProductoSaveViewModel vm = await _productService.GetById(id);
            vm.proveedorSaveViews = await _proveedorService.GetAllViewModel();
            vm.marcaViewModels = await _marcaService.GetAllViewModel();
            vm.categoriaViewModels = await _categoryService.GetAllViewModel();
            return View("Create",vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductoSaveViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.proveedorSaveViews = await _proveedorService.GetAllViewModel();
                vm.marcaViewModels = await _marcaService.GetAllViewModel();
                vm.categoriaViewModels = await _categoryService.GetAllViewModel();
                return View("Create",vm);
            }
            if (vm != null && vm.ImgFile !=null)
            {
                vm.Id = vm.Id;
                vm.ImgUrl = AdmFiles.UploadFile(vm.ImgFile, vm.Id, "Producto");
                await _productService.Update(vm);
            }else
            {
                await _productService.Update(vm);
            }
            return RedirectToRoute(new { controller = "Producto", action = "Index" });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.Delete(id);
            return RedirectToRoute(new { controller = "Producto", action = "Index" });
        }

    }
}
