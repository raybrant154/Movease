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

        public async Task<Movie> GetMovieFromAPIAsync(string t)
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

        public bool CreateMovie(MovieCreate model)
        {
            var entity =
                new Movie()
                {
                    Title = model.Title,
                    Year = model.Year,
                    Rated = model.Rated,
                    Released = model.Released,
                    Runtime = model.Runtime,
                    Genre = model.Genre,
                    Director = model.Director,
                    Writer = model.Writer,
                    Actors = model.Actors,
                    Plot = model.Plot,
                    Language = model.Language,
                    Country = model.Country,
                    Awards = model.Awards
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Movies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
