using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kyckling.Domain.Models;

namespace Kyckling.Domain.Infrastructure.Services
{
    public interface IFileService
    {
        void Upload(Restaurant restaurant, FileStream file);

    }
}
