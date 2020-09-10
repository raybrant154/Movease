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
                    Runtime = model.Runtime,
                    Genre = model.Genre,
                    Director = model.Director,
                    Actors = model.Actors,
                    Plot = model.Plot
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Movies.Add(entity);
                var changes = ctx.SaveChanges();
                   return changes == 1;
            }
        }

        public bool UpdateMovie(MovieEdit model)
        {
            using(var movie = new ApplicationDbContext())
            {
                var entity =
                    movie
                        .Movies
                        .Single(e => e.MovieId == model.MovieId && e.UserId == _userId);

                entity.Title = model.Title;
                entity.Year = model.Year;
                entity.Rated = model.Rated;
                entity.Runtime = model.Runtime;
                entity.Genre = model.Genre;
                entity.Director = model.Director;
                entity.Actors = model.Actors;
                entity.Plot = model.Plot;

                return movie.SaveChanges() == 1;
            }
        }

        public bool DeleteMovie(int movieId)
        {
            using(var movie = new ApplicationDbContext())
            {
                var entity =
                    movie
                        .Movies
                        .Single(e => e.MovieId == movieId && e.UserId == _userId);

                movie.Movies.Remove(entity);

                return movie.SaveChanges() == 1;
            }
        }
    }
}
