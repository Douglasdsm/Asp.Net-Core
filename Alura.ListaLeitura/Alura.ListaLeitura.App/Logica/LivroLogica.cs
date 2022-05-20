using Alura.ListaLeitura.App.HTML;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App.Logica
{
	public class LivroLogica
	{
		
		public static Task ExibeDetalhes(HttpContext context)
		{
			int id = Convert.ToInt32(context.GetRouteValue("id"));
			var repo = new LivroRepositorioCSV();
			var livro = repo.Todos.First(l => l.Id == id);
			return context.Response.WriteAsync(livro.Detalhes());
		}
		public static Task LivroParaLer(HttpContext contexto)
		{
			var arquivo = HtmlUtils.CarregaArquivoHTML("ParaLer");
			var _repo = new LivroRepositorioCSV();

			foreach (var livro in _repo.ParaLer.Livros)
			{
				arquivo = arquivo.Replace("#NovoLivro", $"<li>{livro.Titulo} - {livro.Autor}</li> #NovoLivro");
			}
			arquivo = arquivo.Replace("#NovoLivro", "");
			return contexto.Response.WriteAsync(arquivo);
		}

		public static Task LivroLido(HttpContext contexto)
		{
			var _repo = new LivroRepositorioCSV();
			var arquivo = HtmlUtils.CarregaArquivoHTML("Lidos");
			foreach (var livro in _repo.Lidos.Livros)
			{
				arquivo = arquivo.Replace("#Livro", $"<li>{livro.Titulo} - {livro.Autor}</li> #Livro");
			}
			arquivo = arquivo.Replace("#Livro", "");
			return contexto.Response.WriteAsync(arquivo);
		}

		public static Task LivroLendo(HttpContext contexto)
		{
			var _repo = new LivroRepositorioCSV();
			var arquivo = HtmlUtils.CarregaArquivoHTML("Lendo");
			foreach (var livro in _repo.Lendo.Livros)
			{
				arquivo = arquivo.Replace("#Lendo", $"<li>{livro.Titulo} - {livro.Autor}</li> #Lendo");
			}
			arquivo = arquivo.Replace("#Lendo", "");
			return contexto.Response.WriteAsync(arquivo);
		}
	}
}
