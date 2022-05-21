using Alura.ListaLeitura.App.HTML;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App.Logica
{
	public class LivrosController:Controller
	{

		public string Detalhes(int id)
		{
			var repo = new LivroRepositorioCSV();
			var livro = repo.Todos.First(l => l.Id == id);
			return livro.Detalhes();
		}
		public IActionResult ParaLer()
		{
			var _repo = new LivroRepositorioCSV();
			ViewBag.Livros = _repo.ParaLer.Livros;
			return View("Lista");
		}

		public IActionResult  Lido()
		{
			var _repo = new LivroRepositorioCSV();
			ViewBag.Livros = _repo.ParaLer.Livros;
			return View("Lista");
		}

		public ActionResult Lendo()
		{
			var _repo = new LivroRepositorioCSV();
			ViewBag.Livros = _repo.Lendo.Livros;
			return View("Lista");
		}
		public string Teste()
		{
			return "Teste MVC";
		}
	}
}
