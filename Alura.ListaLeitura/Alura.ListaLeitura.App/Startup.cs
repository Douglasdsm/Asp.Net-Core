using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Alura.ListaLeitura.App
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			//services.AddRouting();
			services.AddMvc();
		}
		public void Configure(IApplicationBuilder app)
		{
			app.UseDeveloperExceptionPage();
			app.UseMvcWithDefaultRoute();
			//var builder = new RouteBuilder(app);
			//builder.MapRoute("{controller}/{action",);
			//builder.MapRoute("Livros/ParaLer", LivroLogica.ParaLer);
			//builder.MapRoute("Livros/Lendo", LivroLogica.Lendo);
			//builder.MapRoute("Livros/Lidos", LivroLogica.Lido);
			//builder.MapRoute("Cadastro/NovoLivro/{nome}/{autor}", CadastroLogica.NovoLivro);
			//builder.MapRoute("Livros/Detalhes/{id:int}", LivroLogica.Detalhes);
			//builder.MapRoute("Cadastro/NovoLivro", CadastroLogica.ExibeFormulario);
			//builder.MapRoute("Cadastro/Incluir", CadastroLogica.Incluir);
			//var rotas = builder.Build();
			//app.UseRouter(rotas);
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