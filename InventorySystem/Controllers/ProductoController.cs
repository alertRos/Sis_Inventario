using InventorySystem.Core.Application.Helper;
using InventorySystem.Core.Application.Interface.Services;
using InventorySystem.Core.Application.Services;
using InventorySystem.Core.Application.ViewModel.Marca;
using InventorySystem.Core.Application.ViewModel.Producto;
using InventorySystem.Core.Application.ViewModel.Usuario;
using Microsoft.AspNetCore.Mvc;
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
            return View(await _productService.GetAllViewModel());
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
            vm.IdNegocio = _HttpContextAccessor.HttpContext.Session.Get<UsuarioSaveViewModel>("user").IdNegocio;
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
            var vm = await _productService.GetById(id);
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductoSaveViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            await _productService.Update(vm);
            return RedirectToRoute(new { controller = "Producto", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View("Delete", await _productService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _productService.Delete(id);
            return RedirectToRoute(new { controller = "Marca", action = "Index" });
        }

    }
}
