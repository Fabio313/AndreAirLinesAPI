using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using APIAndreAirLines.Controllers;
using APIAndreAirLines.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace File
{
    public class ControlFile
    {
        #region JsonToSQL
        public static List<APIAndreAirLines.Model.Passageiro> GetDadosPassageiro(string pathFile)
        {
            StreamReader r = new StreamReader(pathFile);
            string jsonString = r.ReadToEnd();
            var lst = JsonConvert.DeserializeObject<List<APIAndreAirLines.Model.Passageiro>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd" }) as List<Passageiro>;
            if (lst != null)
                return lst;
            return null;
        }
        public static List<APIAndreAirLines.Model.Aeronave> GetDadosAeronaves(string pathFile)
        {
            StreamReader r = new StreamReader(pathFile);
            string jsonString = r.ReadToEnd();
            var lst = JsonConvert.DeserializeObject<List<APIAndreAirLines.Model.Aeronave>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd hh:mm:ss" }) as List<Aeronave>;
            if (lst != null)
                return lst;
            return null;
        }

        public static List<APIAndreAirLines.Model.Aeroporto> GetDadosAeroportos(string pathFile)
        {
            StreamReader r = new StreamReader(pathFile);
            string jsonString = r.ReadToEnd();
            var lst = JsonConvert.DeserializeObject<List<APIAndreAirLines.Model.Aeroporto>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd hh:mm:ss" }) as List<Aeroporto>;
            if (lst != null)
                return lst;
            return null;
        }

        public static List<APIAndreAirLines.Model.PrecoBase> GetDadosPrecosBase(string pathFile)
        {
            StreamReader r = new StreamReader(pathFile);
            string jsonString = r.ReadToEnd();
            var lst = JsonConvert.DeserializeObject<List<APIAndreAirLines.Model.PrecoBase>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-ddThh:mm:ss" }) as List<PrecoBase>;
            if (lst != null)
                return lst;
            return null;
        }

        public static List<APIAndreAirLines.Model.Classe> GetDadosClasses(string pathFile)
        {
            StreamReader r = new StreamReader(pathFile);
            string jsonString = r.ReadToEnd();
            var lst = JsonConvert.DeserializeObject<List<APIAndreAirLines.Model.Classe>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-ddThh:mm:ss" }) as List<Classe>;
            if (lst != null)
                return lst;
            return null;
        }

        public static List<APIAndreAirLines.Model.Voo> GetDadosVoos(string pathFile)
        {
            StreamReader r = new StreamReader(pathFile);
            string jsonString = r.ReadToEnd();
            var lst = JsonConvert.DeserializeObject<List<APIAndreAirLines.Model.Voo>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-ddThh:mm:ss" }) as List<Voo>;
            if (lst != null)
                return lst;
            return null;
        }

        public static List<APIAndreAirLines.Model.Passagem> GetDadosPassagens(string pathFile)
        {
            StreamReader r = new StreamReader(pathFile);
            string jsonString = r.ReadToEnd();
            var lst = JsonConvert.DeserializeObject<List<APIAndreAirLines.Model.Passagem>>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-ddThh:mm:ss" }) as List<Passagem>;
            if (lst != null)
                return lst;
            return null;
        }

        #endregion

        #region Relatorios

        public static async void RelatorioPrecosBase(HttpClient APIAndreAirLines)
        {
            HttpResponseMessage response = await APIAndreAirLines.GetAsync("https://localhost:44333/api/PrecoBases");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
            System.IO.File.WriteAllText(@"C:\Users\Fabio Z Ferrenha\Desktop\AndreAirLines\RelatorioRelatorioPrecosBase.json", responseBody);
        }

        #endregion
    }
}