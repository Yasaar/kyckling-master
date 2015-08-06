using System;
using Kyckling.Domain;
using Kyckling.Domain.Infrastructure.Repositories;
using Kyckling.Domain.Models;

namespace Kyckling.Web.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private EFContext _context;
        public UserRepository()
        {
            _context = new EFContext();
        }
        public User GetUser(Domain.Models.User user)
        {
            throw new NotImplementedException();
        }

        public User AddUser(Domain.Models.User user)
        {
            throw new NotImplementedException();
        }
    }
}
