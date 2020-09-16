using Movease.Data;
using Movease.Models;
using Movease.Models.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movease.Service
{
   public class UserService
    {
        private readonly Guid _userId;

        public UserService(Guid userId)
        {
            _userId = userId;
        }


        public bool CreateUser(UserCreate model)
        {
            var entity =
                new User()
                {
                    OwnerId = _userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.UserProfile.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<UserListItem> GetUsers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .UserProfile
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                        e =>
                            new UserListItem
                            {
                                FullName = e.FirstName + " " + e.LastName                                
                            }
                            );
                return query.ToArray();
            }
        }

        public UserDetail GetUserById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .UserProfile
                        .Single(e => e.UserId == id && e.OwnerId == _userId);
                return
                    new UserDetail
                    {
                        FullName = entity.FullName                       
                    };
            }
        }

        public bool UpdateUser(UserEdit model)
        {
            using(var user = new ApplicationDbContext())
            {
                var entity =
                    user
                    .UserProfile
                    .Single(e => e.UserId == model.UserId && e.OwnerId == _userId);
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;

                return user.SaveChanges() == 1;
            }
        }

        public bool DeleteUser(int userId)
        {
            using (var user = new ApplicationDbContext())
            {
                var entity =
                    user
                        .UserProfile
                        .Single(e => e.UserId == userId && e.OwnerId == _userId);
                user.UserProfile.Remove(entity);

                return user.SaveChanges() == 1;
            }
        }
    }
}
