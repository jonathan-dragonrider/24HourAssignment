using JAKs24HourSocialMedia.RealData;
using JAKs24HourSocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JAKs24HourSocialMedia.Services
{
    public class UserService
    {
        private readonly Guid _userId;

        public UserService(Guid userId)
        {
            _userId = userId;

        }

        public bool UserCreate(CreateUser model)
        {
            var entity =
                new User()
                {
                    Id= _userId,
                    Name = model.Name,
                    Email = model.Email,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Users.Add(entity);
                return ctx.SaveChanges() == 1;
            }



        }

        public IEnumerable<UserListItems> GetUsers()
        {

            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Users
                    .Where(e => e.Id == _userId)
                    .Select(
                        e =>
                        new UserListItems
                        {
                            Id = e.Id,
                            Name = e.Name,
                            Email = e.Email

                        }
                        );
                return query.ToArray();
            }


        }

        public UserDetails GetUserById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Users
                        .Single(e => e.Id == _userId);
                return
                    new UserDetails
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        Email = entity.Email,

                    };
            }
        }

        public bool UpdateUser(UserEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Users
                        .Single(e => e.Id == model.Id);

                entity.Name = model.Name;
                entity.Email = model.Email;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteUser(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Users
                        .Single(e => e.Id == _userId);

                ctx.Users.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
