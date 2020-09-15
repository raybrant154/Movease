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
        private readonly Guid _ownerId;

        public MovieListService(Guid ownerId)
        {
            _ownerId = ownerId;
        }

        public bool CreateMovieList(ListCreate model)
        {
            var entity =
                new MovieOnList()
                {                    
                    MovieId = model.MovieId,
                    CollectionId = model.CollectionId,
                    Comment = model.Comment
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
                        .Where(e => e.MyMoviesCollection.User.OwnerId == _ownerId)
                        .Select(
                        e =>
                            new MovieOnListItem
                            {
                                MovieId = e.MovieId,
                                CollectionId = e.CollectionId,
                                Comment = e.Comment
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
                        .Single(e => e.ListId == id && e.MyMoviesCollection.User.OwnerId == _ownerId);
                return
                    new ListDetail
                    {
                        ListId = entity.ListId,
                        MovieId = entity.MovieId,
                        CollectionId = entity.CollectionId,
                        Comment = entity.Comment
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
                        .Single(e => e.ListId == model.ListId && e.MyMoviesCollection.User.OwnerId == _ownerId);

                entity.MovieId = model.MovieId;
                entity.CollectionId = model.CollectionId;
                entity.Comment = model.Comment;

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
                        .Single(e => e.ListId == listId && e.MyMoviesCollection.User.OwnerId == _ownerId);

                movieList.MovieOnLists.Remove(entity);
                return movieList.SaveChanges() == 1;
            }
        }
    }
}
