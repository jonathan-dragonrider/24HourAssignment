using JAKs24HourSocialMedia.Data;
using JAKs24HourSocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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
                    Id = _userId,
                    Name = model.Name,
                    Email = model.Email,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Users.Add(entity);
                return ctx.SaveChanges() == 1;
            }

            IEnumerable<UserListItems> GetUsers()
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
                }
            }



        }
    }
}
