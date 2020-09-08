using Movease.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Movease.Service
{
    public class MovieService
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<Movie> GetMovieAsync(string url)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                Movie movie = await response.Content.ReadAsAsync<Movie>();
                return movie;
            }

            return null;
        }
    }
}
