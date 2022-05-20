using Alura.ListaLeitura.App.Logica;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

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
			builder.MapRoute("Livros/ParaLer", LivroLogica.LivroParaLer);
			builder.MapRoute("Livros/Lendo", LivroLogica.LivroLendo);
			builder.MapRoute("Livros/Lidos", LivroLogica.LivroLido);
			builder.MapRoute("Cadastro/NovoLivro/{nome}/{autor}", CadastroLogica.NovoLivroParaLer);
			builder.MapRoute("Livros/Detalhes/{id:int}", LivroLogica.ExibeDetalhes);
			builder.MapRoute("Cadastro/NovoLivro", CadastroLogica.ExibeFormulario);
			builder.MapRoute("Cadastro/Incluir", CadastroLogica.ProcessaFormulario);
			var rotas = builder.Build();
			app.UseRouter(rotas);
			//app.Run(Roteamento);

		}
		// Rotas por dicionario 
		//public Task Roteamento(HttpContext contexto)
		//{
		//	var _repo = new LivroRepositorioCSV();
		//	var rotas = new Dictionary<string, RequestDelegate>
		//	{
		//		{"/Livros/ParaLer",LivroParaLer },
		//		{"/Livros/Lendo",LivroLendo},
		//		{"/Livros/Lidos",LivroLido}
		//	};
		//	if (rotas.ContainsKey(contexto.Request.Path))
		//	{
		//		var metodo = rotas[contexto.Request.Path];
		//		return metodo.Invoke(contexto);
		//	}
		//	contexto.Response.StatusCode = 404;
		//	return contexto.Response.WriteAsync("Caminho Inexistente!");
		//}
	}
}