using Movease.Data;
using Movease.Models;
using Movease.Models.MyMovieCollectionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Movease.Service
{  
    public class MyMovieCollectionService
    {
        private readonly Guid _ownerId;

        public MyMovieCollectionService(Guid ownerId)
        {
            _ownerId = ownerId;
        }

        public bool CreateMovieCollection(MyMovieCollectionCreate model)
        {
            var entity =
                new MyMovieCollection()
                {
                    UserId = model.UserId,
                    CollectionName = model.CollectionName,
                    Description = model.Description,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.MyMovieCollections.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MyMovieCollectionListItem> GetMyMovieCollections()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .MyMovieCollections
                        .Where(e => e.User.OwnerId == _ownerId)
                        .Select(
                            e =>
                                new MyMovieCollectionListItem
                                {
                                    MyMovieId = e.MyMovieId,
                                    CollectionName = e.CollectionName,
                                    Description = e.Description
                                }
                                );
                return query.ToArray();
            }
        }

        public MyMovieCollectionDetail GetCollectionById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .MyMovieCollections
                        .Single(e => e.MyMovieId == id && e.User.OwnerId == _ownerId);
                return
                    new MyMovieCollectionDetail
                    {
                        MyMovieId = entity.MyMovieId,
                        CollectionName = entity.CollectionName,
                        Description = entity.Description
                    };
            }
        }

        public bool UpdateMyMovieCollection(MyMovieCollectionEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .MyMovieCollections
                        .Single(e => e.MyMovieId == model.MyMovieId && e.User.OwnerId == _ownerId);

                entity.MyMovieId = model.MyMovieId;
                entity.CollectionName = model.CollectionName;
                entity.Description = model.Description;


                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteMyMovieCollection(int MyMovieCollectionId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .MyMovieCollections
                        .Single(e => e.MyMovieId == MyMovieCollectionId && e.User.OwnerId == _ownerId);
                //.Single(e => e.MyMovieId == MyMovieCollectionId && e.User.OwnerId == _userId);
                ctx.MyMovieCollections.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
