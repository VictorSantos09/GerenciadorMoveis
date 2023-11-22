using Microsoft.AspNetCore.Mvc;
using MoveisCore.Models;
using MoveisCore.Models.ModelView;
using MoveisCore.Models.Services;
using System.Diagnostics;

namespace MoveisCore.Controllers;
public class MovelController : Controller
{
    private readonly MovelService _movelService;

    public MovelController()
    {
        _movelService = new MovelService();
    }

    public IActionResult Index()
    {
        var modelsViews = _movelService.ObterTodosAsModelView();
        return View(modelsViews);
    }

    public IActionResult Cadastrar()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Cadastrar(MovelModelView modelo)
    {
        var movel = new MovelModelView(modelo.Nome, modelo.Descricao, modelo.IsComprado);
        MovelService service = new MovelService();
        service.Adicionar(movel);

       return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
