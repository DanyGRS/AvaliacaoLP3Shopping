using Microsoft.AspNetCore.Mvc;
using AvaliacaoLP3.ViewModels;
using AvaliacaoLP3.Models;
using System.Diagnostics;

namespace AvaliacaoLP3.Controllers;

public class LojaController : Controller
{
    private static List<LojaViewModel> lojas = new List<LojaViewModel>();

    public IActionResult Index()
    {
        return View(lojas);
    }

    public IActionResult Delete([FromForm]int id){
        lojas.RemoveAt(id);

        return View(lojas);
    }

    public IActionResult ValidacaoNome([FromForm] int id, [FromForm] string piso, [FromForm] string nome, [FromForm] string descricao, [FromForm] string lK, [FromForm] string email )
    {
        foreach (var loja in lojas)
        {
            if(nome == loja.Nome){
                ViewData["Nome"] = nome;
                return View();
            }
        } 
        LojaViewModel lojaNova = new LojaViewModel(id, piso, nome, descricao, lK, email);
        lojas.Add(lojaNova);
        return View("Cadastramento");
    }
    
    public IActionResult Gerenciamento()
    {
        return View(lojas);
    }

    public IActionResult Cadastramento()
    {
        return View();
    }

    public IActionResult Detalhes([FromForm]int id)
    {
        return View(lojas[id]);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}