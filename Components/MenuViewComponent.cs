using Microsoft.AspNetCore.Mvc;
using Estoque.Models;
using Microsoft.Extensions.Logging;

namespace Estoque.Components.Menu
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly ILogger<MenuViewComponent> _logger;

        public MenuViewComponent(ILogger<MenuViewComponent> logger)
        {
            _logger = logger;
        }

        public IViewComponentResult Invoke()
        {
            _logger.LogInformation("MenuViewComponent Invoke method called");
            UsuarioModel usuario = new UsuarioModel();
            return View(usuario);
        }
    }
}
