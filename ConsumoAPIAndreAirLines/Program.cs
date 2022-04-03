using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using APIAndreAirLines.Model;
using File;

namespace ConsumoAPIAndreAirLines
{
    internal class Program
    {
        static readonly HttpClient APIAndreAirLines = new HttpClient();

        static async Task Main(string[] args)
        {
            string pathFilePassageiro = @"C:\Users\Fabio Z Ferrenha\Desktop\AndreAirLines\passageiros.json";
            var passageiros = ControlFile.GetDadosPassageiro(pathFilePassageiro);

            string pathFileAeroportos = @"C:\Users\Fabio Z Ferrenha\Desktop\AndreAirLines\aeroportos.json";
            var aeroportos = ControlFile.GetDadosAeroportos(pathFileAeroportos);

            string pathFileAeronaves = @"C:\Users\Fabio Z Ferrenha\Desktop\AndreAirLines\aeronaves.json";
            var aeronaves = ControlFile.GetDadosAeronaves(pathFileAeronaves);

            string pathFileClasses = @"C:\Users\Fabio Z Ferrenha\Desktop\AndreAirLines\classes.json";
            var classes = ControlFile.GetDadosClasses(pathFileClasses);

            string pathFilePrecosBase = @"C:\Users\Fabio Z Ferrenha\Desktop\AndreAirLines\precosbase.json";
            var precosbase = ControlFile.GetDadosPrecosBase(pathFilePrecosBase);

            string pathFileVoos = @"C:\Users\Fabio Z Ferrenha\Desktop\AndreAirLines\voos.json";
            var voos = ControlFile.GetDadosVoos(pathFileVoos);

            string pathFilePassagens = @"C:\Users\Fabio Z Ferrenha\Desktop\AndreAirLines\passagens.json";
            var passagens = ControlFile.GetDadosPassagens(pathFilePassagens);


            //USADO APENAS QUANDO FOR POPULAR O BANCO
            /*try
            {
                APIAndreAirLines.BaseAddress = new Uri("https://localhost:44333/");
                APIAndreAirLines.DefaultRequestHeaders.Accept.Clear();


                

                aeronaves.ForEach(p => APIAndreAirLines.PostAsJsonAsync("api/Aeronaves", p));
                aeroportos.ForEach(p => APIAndreAirLines.PostAsJsonAsync("api/Aeroportoes", p));
                passageiros.ForEach(p => APIAndreAirLines.PostAsJsonAsync("api/Passageiroes", p));
                classes.ForEach(p => APIAndreAirLines.PostAsJsonAsync("api/Classes", p));
                precosbase.ForEach(p => APIAndreAirLines.PostAsJsonAsync("api/PrecoBases", p));
                voos.ForEach(p => APIAndreAirLines.PostAsJsonAsync("api/Voos", p));
                passagens.ForEach(p => APIAndreAirLines.PostAsJsonAsync("api/Passagems", p));


            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nExceprion Caught!");
                Console.WriteLine("Message: {0}", e.Message);
            }*/

            //RELATORIO PRECO BASE
           /* HttpResponseMessage RelatorioPrecosBase = await APIAndreAirLines.GetAsync("https://localhost:44333/api/PrecoBases");
            RelatorioPrecosBase.EnsureSuccessStatusCode();
            string responseBody = await RelatorioPrecosBase.Content.ReadAsStringAsync();
            System.IO.File.WriteAllText(@"C:\Users\Fabio Z Ferrenha\Desktop\AndreAirLines\Relatorio\RelatorioPrecosBase.json", responseBody);*/

            //RELATORIO DE VENDA DE PASSAGEM POR MES
           /* HttpResponseMessage RelatorioPassagens = await APIAndreAirLines.GetAsync("https://localhost:44333/api/PrecoBases");
            RelatorioPassagens.EnsureSuccessStatusCode();
            string resposta = await RelatorioPassagens.Content.ReadAsStringAsync();
            System.IO.File.WriteAllText(@"C:\Users\Fabio Z Ferrenha\Desktop\AndreAirLines\Relatorio\RelatorioPassagensMes.json", resposta);*/

        }
    }
}
