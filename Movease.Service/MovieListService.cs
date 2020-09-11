using Movease.Data;
using Movease.Models.MovieListModel;
using Movease.Models.MoviesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movease.Service
{
    public class MovieListService
    {
        private readonly Guid _userId;

        public MovieListService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateMovieList(ListCreate model)
        {
            var entity =
                new MovieOnList()
                {
                    UserId = _userId,
                    MovieId = model.MovieId,
                    CollectionId = model.CollectionId,
                    CommentId = model.CommentId
                };

            using (var movieList = new ApplicationDbContext())
            {
                movieList.MovieOnLists.Add(entity);
                return movieList.SaveChanges() == 1;
            }
        }

        public IEnumerable<MovieOnListItem> GetMovieList()
        {
            using (var movieList = new ApplicationDbContext())
            {
                var query =
                    movieList
                        .MovieOnLists
                        .Where(e => e.UserId == _userId)
                        .Select(
                        e =>
                            new MovieOnListItem
                            {
                                MovieId = e.MovieId,
                                CollectionId = e.CollectionId,
                                CommentId = e.CommentId
                            }
                        );
                return query.ToArray();
            }
        }

        public ListDetail GetMovieListById(int id)
        {
            using (var movieList = new ApplicationDbContext())
            {
                var entity =
                    movieList
                        .MovieOnLists
                        .Single(e => e.ListId == id && e.UserId == _userId);
                return
                    new ListDetail
                    {
                        ListId = entity.ListId,
                        MovieId = entity.MovieId,
                        CollectionId = entity.CollectionId,
                        CommentId = entity.CommentId
                    };
            }
        }

        public bool UpdateMovieOnList(ListEdit model)
        {
            using (var movieList = new ApplicationDbContext())
            {
                var entity =
                    movieList
                        .MovieOnLists
                        .Single(e => e.ListId == model.ListId && e.UserId == _userId);

                entity.MovieId = model.MovieId;
                entity.CollectionId = model.CollectionId;
                entity.CommentId = model.CommentId;

                return movieList.SaveChanges() == 1;
            }
        }

        public bool DeleteMovieList(int listId)
        {
            using (var movieList = new ApplicationDbContext())
            {
                var entity =
                    movieList
                        .MovieOnLists
                        .Single(e => e.ListId == listId && e.UserId == _userId);

                movieList.MovieOnLists.Remove(entity);

                return movieList.SaveChanges() == 1;
            }
        }
    }
}
