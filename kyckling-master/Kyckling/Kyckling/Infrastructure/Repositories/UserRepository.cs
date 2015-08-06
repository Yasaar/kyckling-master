using System;
using Kyckling.Domain;
using Kyckling.Domain.Infrastructure.Repositories;

namespace Kyckling.WebUI.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private UserContext _context;
        public UserRepository()
        {
            _context = new UserContext();
        }
        public Domain.Entities.User GetUser(Domain.Models.UserModel user)
        {
            throw new NotImplementedException();
        }

        public Domain.Entities.User AddUser(Domain.Models.UserModel user)
        {
            throw new NotImplementedException();
        }
    }
}
