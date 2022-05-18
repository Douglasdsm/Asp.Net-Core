using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddRouting();
		}
		public void Configure(IApplicationBuilder app)
		{
			var builder = new RouteBuilder(app);
			builder.MapRoute("Livros/ParaLer", LivroParaLer);
			builder.MapRoute("Livros/Lendo", LivroLendo);
			builder.MapRoute("Livros/Lidos", LivroLido);
			builder.MapRoute("Cadastro/NovoLivro/{nome}/{autor}", NovoLivroParaLer);
			builder.MapRoute("Livros/Detalhes/{id:int}", ExibeDetalhes);
			builder.MapRoute("Cadastro/NovoLivro", ExibeFormulario);
			builder.MapRoute("Cadastro/Incluir", ProcessaFormulario);
			var rotas = builder.Build();
			app.UseRouter(rotas);
			//app.Run(Roteamento);

		}

		private Task ProcessaFormulario(HttpContext context)
		{
			var livro = new Livro()
			{
				Titulo = context.Request.Query["Titulo"].First(),
				Autor = context.Request.Query["autor"].First(),
			};

			var repo = new LivroRepositorioCSV();
			repo.Incluir(livro);
			return context.Response.WriteAsync("O Livro foi incluido com sucesso");
		}

		private Task ExibeFormulario(HttpContext context)
		{
			var html = @"
			<html>
				<form action='/Cadastro/Incluir'>
					<label>Titulo:</label>
					<input name='Titulo'/>
					<br/>
					<label>Autor:</label>
					<input name='Autor'/>
					<br/>
					<button>Gravar</button>
				</form>
			</html>";
			return context.Response.WriteAsync(html);
		}

		private Task ExibeDetalhes(HttpContext context)
		{
			int id = Convert.ToInt32(context.GetRouteValue("id"));
			var repo = new LivroRepositorioCSV();
			var livro = repo.Todos.First(l => l.Id == id);
			return context.Response.WriteAsync(livro.Detalhes());
		}

		public Task NovoLivroParaLer(HttpContext context)
		{
			var livro = new Livro()
			{
				Titulo = Convert.ToString(context.GetRouteValue("nome")),
				Autor = Convert.ToString(context.GetRouteValue("autor"))
			};

			var repo = new LivroRepositorioCSV();
			repo.Incluir(livro);
			return context.Response.WriteAsync("O Livro foi incluido com sucesso");
		}

		public Task Roteamento(HttpContext contexto)
		{
			var _repo = new LivroRepositorioCSV();
			var rotas = new Dictionary<string, RequestDelegate>
			{
				{"/Livros/ParaLer",LivroParaLer },
				{"/Livros/Lendo",LivroLendo},
				{"/Livros/Lidos",LivroLido}
			};
			if (rotas.ContainsKey(contexto.Request.Path))
			{
				var metodo = rotas[contexto.Request.Path];
				return metodo.Invoke(contexto);
			}
			contexto.Response.StatusCode = 404;
			return contexto.Response.WriteAsync("Caminho Inexistente!");
		}

		public Task LivroParaLer(HttpContext contexto)
		{
			var _repo = new LivroRepositorioCSV();
			return contexto.Response.WriteAsync(_repo.ParaLer.ToString());
		}

		public Task LivroLido(HttpContext contexto)
		{
			var _repo = new LivroRepositorioCSV();
			return contexto.Response.WriteAsync(_repo.Lidos.ToString());
		}

		public Task LivroLendo(HttpContext contexto)
		{
			var _repo = new LivroRepositorioCSV();
			return contexto.Response.WriteAsync(_repo.Lendo.ToString());
		}
	}
}