using Movease.Data;
using Movease.Models;
using Movease.Models.CommentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movease.Service
{
    public class CommentService
    {
        private readonly Guid _userId;

        public CommentService(Guid userId)
        {
            _userId = userId;
        }


        public bool CreateComment(CommentCreate model)
        {
            var entity =
                new Comment()
                {
                    UserId = _userId,
                    Text = model.Text,

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CommentListItem> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Comments
                        .Where(e => e.UserId == _userId)
                        .Select(
                        e =>
                            new CommentListItem
                            {
                                Id = e.Id,
                                Text = e.Text
                            }
                            );
                return query.ToArray();
            }
        }

        public CommentDetail GetCommentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.Id == id && e.UserId == _userId);
                return
                    new CommentDetail
                    {
                        Id = entity.Id,
                        Text = entity.Text
                    };
            }
        }

        public bool UpdateComment(CommentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.Id == model.Id && e.UserId == _userId);
                entity.Text = model.Text;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteComment(int noteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.Id == noteId && e.UserId == _userId);

                ctx.Comments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
