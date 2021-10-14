using Cakes_Management.Contexts;
using Cakes_Management.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cakes_Management.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly CakesManegementDBContext context;

        public CategoryService(CakesManegementDBContext context )
        {
            this.context = context;
        }
        public Category Get(int CategoryId)
        {
            return context.Categories.FirstOrDefault(c => c.CategoryId == CategoryId);
        }

        public List<Category> Gets()
        {
            return context.Categories.Include(p => p.Cakes).ToList();
        }
    }
}
