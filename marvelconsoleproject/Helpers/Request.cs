using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace marvelconsoleproject.Helpers
{
    public class Request
    {
        public Request()
        {
            client = new HttpClient()
            {
                BaseAddress = new Uri("https://gateway.marvel.com/")
            };
            hg = new HashGenerator();
            Series = new List<Serie>();
        }

        private List<Serie> Series;
        private HttpClient client;
        private HashGenerator hg;
        

        public List<Serie> FetchSeries()
        {
            Series = new List<Serie>();
            string hash = hg.GetHash();
            var response = client.GetStringAsync($"v1/public/series?ts={hg.timeStamp}&apikey={HashGenerator.APIKEY}&hash={hash}").Result;
            MarvelSeriesResult jsonResponse = JsonConvert.DeserializeObject<MarvelSeriesResult>(response);

            foreach (var result in jsonResponse.data.results)
            {
                Series.Add(result);
            }

            return Series;
        }

        public List<Character> FetchCharacters(int selectedSeries)
        {
            var Characters = new List<Character>();

            if (selectedSeries <= Series.Count && selectedSeries > 0)
            {
                if (Series[selectedSeries - 1].characters.available > 0)
                {
                    foreach (var character in Series[selectedSeries - 1].characters.items)
                    {
                        Characters.Add(character);
                    }
                }       
            }

            return Characters;
        }

        public string GetSelectedSeriesName(int selectedSeries)
        {
            string name = "";

            if (selectedSeries <= Series.Count && selectedSeries > 0)
            {
                name = Series[selectedSeries - 1].title.Trim();
            }

            return name;
        }
    }
}
