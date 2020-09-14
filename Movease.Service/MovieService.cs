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
        private readonly Guid _userId;

        public MovieService(Guid userId)
        {
            _userId = userId;
        }

        public MovieService() { }

        public async Task<MovieDetail> GetMovieFromAPIAsync(string t)
        {
            Task<HttpResponseMessage> getTask = _httpClient.GetAsync("http://www.omdbapi.com/?apikey=223a36fc&t=" + t);

            HttpResponseMessage response = getTask.Result;

            if (response.IsSuccessStatusCode)
            {
                MovieDetail movie = await response.Content.ReadAsAsync<MovieDetail>(); 
                return movie;
            }

            return null;

        }


        public bool CreateMovie(MovieCreate model)
        {
            var entity =
                new Movie()
                {
                    Title = model.Title,
                    Year = model.Year,
                    Rated = model.Rated,
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
                var changes = ctx.SaveChanges();
                   return changes == 1;
            }
        }
    }
}
