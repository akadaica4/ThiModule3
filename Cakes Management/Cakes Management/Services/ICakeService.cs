using Cakes_Management.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cakes_Management.Services
{
    public interface ICakeService
    {
        List<Cake> GetProductByCategoryId(int categoryId);
        bool Create(Cake model);
        bool Edit(Cake model);
        Cake Get(int cakeId);
        bool ChangeStatus(int cakeId);
    }
}
