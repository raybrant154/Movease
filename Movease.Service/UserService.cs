﻿using Movease.Data;
using Movease.Models;
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
                    UserId = _userId,
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
                        .Where(e => e.UserId == _userId)
                        .Select(
                        e =>
                            new UserListItem
                            {
                                FullName = e.FullName,
                                
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
                        .Single(e => e.Id == id && e.UserId == _userId);
                return
                    new UserDetail
                    {
                        FullName = entity.FullName
                        
                    };
            }
        }
    }
}