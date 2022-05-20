using System.IO;

namespace Alura.ListaLeitura.App.HTML
{
	public class HtmlUtils
	{
		public static string CarregaArquivoHTML(string nomeDoArquivo)
		{
			var nomeCompletoDoArquivo = $"C:\\Users\\dougl\\Documents\\Curso Dados\\Alura.ListaLeitura\\Alura.ListaLeitura.App\\HTML/{nomeDoArquivo}.html";
			using (var arquivo = File.OpenText(nomeCompletoDoArquivo))
			{
				return arquivo.ReadToEnd();
			}
		}
	}
}
