using Cakes_Management.Contexts;
using Cakes_Management.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cakes_Management.Services
{
    public class CakeService : ICakeService
    {
        private readonly CakesManegementDBContext context;

        public CakeService(CakesManegementDBContext context)
        {
            this.context = context;
        }

        public bool ChangeStatus(int cakeId)
        {
            try
            {
                var cake = Get(cakeId);
                cake.Status = !cake.Status;
                context.Attach(cake);
                context.Entry(cake).State = EntityState.Modified;
                return context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Create(Cake model)
        {
            try
            {
                context.Add(model);
                return context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Edit(Cake cake)
        {
            try
            {
                context.Attach(cake);
                return context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Cake Get(int cakeId)
        {
            return context.Cakes.Include(p => p.Category).FirstOrDefault(p => p.cakeId == cakeId);
        }
        public List<Cake> GetProductByCategoryId(int categoryId)
        {
            return context.Cakes.Include(p => p.Category).Where(p => p.CategoryId == categoryId).ToList();
        }
    }
}
