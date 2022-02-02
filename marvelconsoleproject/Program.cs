using marvelconsoleproject.Helpers;
using System;
using System.Collections.Generic;

namespace marvelconsoleproject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ohhh, qué fue? Bienvenido a la Marvelpedia!!");
            var requester = new Request();
            MainMenu(requester);
        }

        private static void MainMenu(Request req)
        {
            
            while (true)
            {
                Console.WriteLine("---- Menú principal ----");
                Console.WriteLine("1. Consulta series de Marvel.");
                Console.WriteLine("S. Salir del programa.");
                Console.WriteLine("Teclea la opción deseada...");
                var mainInput = Console.ReadLine();

                if(mainInput.ToUpper() == "S")
                {
                    break;
                }
                else if(mainInput == "1")
                {
                    SeriesMenu(req);
                }
                else
                {
                    Console.WriteLine("Opción incorrecta.");
                }
            }
        }

        private static void SeriesMenu(Request req)
        {
            List<Serie> series = req.FetchSeries();

            while (true)
            {
                Console.WriteLine("----");
                Console.WriteLine("Listado de series de marvel:");
                for (int i = 0; i < series.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {series[i].title.Trim()}");
                }
                Console.WriteLine("V. Volver al menú principal.");
                Console.WriteLine("----");
                Console.WriteLine("Teclea el número de la serie cuyos personajes quieras consultar...");
                var seriesInput = Console.ReadLine();
                try
                {
                    if (seriesInput.ToUpper() == "V")
                    {
                        break;
                    }
                    else if (int.Parse(seriesInput) > 0 && int.Parse(seriesInput) <= series.Count)
                    {
                        int selectedSeries = int.Parse(seriesInput);
                        DisplayCharacters(req, selectedSeries);
                    }
                    else
                    {
                        Console.WriteLine("Opción incorrecta.");
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static void DisplayCharacters(Request req, int selectedSeries)
        {
            List<Character> characters = req.FetchCharacters(selectedSeries);
            Console.WriteLine("----");
            if (characters.Count > 0)
            {
                Console.WriteLine($"Los personajes de {req.GetSelectedSeriesName(selectedSeries)} son:");
                for (int i = 0; i < characters.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {characters[i].name}");
                }
            }
            else
            {
                Console.WriteLine("La serie seleccionada no tiene personajes. ¿Quieres probar con otra?");
            }
        }
    }
}
