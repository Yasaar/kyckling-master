using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kyckling.Domain.Models;

namespace Kyckling.Domain.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        User AddUser(Domain.Models.User user);
        User GetUser(Domain.Models.User user);
    }
}
