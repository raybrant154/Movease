using Movease.Data;
using Movease.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Movease.Service
{  //GetMovieFromAPI
    public class MyMovieCollectionService
    {
        private readonly Guid _userId;

        public MyMovieCollectionService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateMovieCollection(CollectionCreate model)
        {
            var entity =
                new MovieCollection()
                {
                    MyMovieID = model.MyMovieID,
                    CollectionName = model.CollectionName,
                    Description = model.Description,

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.MovieCollections.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MovieCollectionItem> GetMovieCollections()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .MyMovieCollections    //Name correct?
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new MovieCollectionItem
                                {
                                    MyMovieID = e.MyMovieID,
                                    CollectionName = e.CollectionName,
                                    Description = e.Description
                                }
                                );
                return query.ToArray();
            }
        }

        public MovieCollectionDetail GetCollectionById(int id)
        {
            var entity =
                ctx
                    .MyMovieCollections
                    .Single(e => e.Id == id && e.UserId == _userId);
            return
                new MovieCollectionDetail
                {
                    MyMovieID = entity.MyMovieID,
                    CollectionName = entity.CollectionName,
                    Description = entity.Description
                };
        }
    }
}
