using Movease.Data;
using Movease.Models.MoviesModel;
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

        public MovieService(/*string t*/)
        {
            //HttpClient httpClient = new HttpClient();

            //Task<HttpResponseMessage> getTask = httpClient.GetAsync("http://www.omdbapi.com/?apikey=223a36fc&t=" + t);

            //HttpResponseMessage response = getTask.Result;

            //HttpResponseMessage getResponse = httpClient.GetAsync("http://www.omdbapi.com/?apikey=223a36fc&t=" + t).Result;
        }

        public async Task<Movie> GetMovieAsync(string t)
        {
            Task<HttpResponseMessage> getTask = _httpClient.GetAsync("http://www.omdbapi.com/?apikey=223a36fc&t=" + t);

            HttpResponseMessage response = getTask.Result;


            //HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                Movie movie = await response.Content.ReadAsAsync<Movie>(); 
                return movie;
            }
            else
            {

            return null;
            }
        }

        //public MovieDetail GetMovieByTitleAsync(string title)
        //{
            
        //}
    }
}
