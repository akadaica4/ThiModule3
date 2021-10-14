using Cakes_Management.Entities;
using Cakes_Management.Models.Cake;
using Cakes_Management.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cakes_Management.Controllers
{
    public class CakeController : Controller
    {
        private readonly ICakeService cakeService;
        private readonly ICategoryService categoryService;
        private readonly IWebHostEnvironment webHostEnvironment;
        private static Category category = new Category();
        public CakeController(ICakeService cakeService, ICategoryService categoryService, IWebHostEnvironment webHostEnvironment)
        {
            this.cakeService = cakeService;
            this.categoryService = categoryService;
            this.webHostEnvironment = webHostEnvironment;
        }
        [Route("/Cake/Index/{catId}")]
        public IActionResult Index(int catId)
        {
            category = categoryService.Get(catId);
            ViewBag.Category = category;
            return View(cakeService.GetProductByCategoryId(catId));
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Category = category;
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateCake model)
        {
            if (ModelState.IsValid)
            {
                model.CategoryId = category.CategoryId;
                var cake = new Cake()
                {
                    CategoryId = model.CategoryId,
                    CakeName = model.CakeName,
                    DateOfManufacture = model.DateOfManufacture,
                    Ingredient = model.Ingredient,
                    Expiry = model.Expiry,
                    Status = model.Status,
                    Price = model.Price,
                };
                if (cakeService.Create(cake))
                {
                    return RedirectToAction("Index", new { catId = category.CategoryId });
                }
            }
            ViewBag.Category = category;
            return View(model);
        }
        [HttpGet]
        [Route("Cake/Edit/{cakeId}")]
        public IActionResult Edit(int cakeId)
        {
            var cake = cakeService.Get(cakeId);
            var editCake = new EditCake()
            {
                CategoryId = cake.CategoryId,
                CakeName = cake.CakeName,
                cakeId = cake.cakeId,
                Ingredient = cake.Ingredient,
                Expiry = cake.Expiry,
                DateOfManufacture = cake.DateOfManufacture,
                Price = cake.Price,
                Status = cake.Status
            };
            ViewBag.Category = category;
            return View(editCake);
        }
        [HttpPost]
        public IActionResult Edit(EditCake model)
        {
            if (ModelState.IsValid)
            {
                var cake = cakeService.Get(model.cakeId);
                cake.CategoryId = model.CategoryId;
                cake.Price = model.Price;
                cake.CakeName = model.CakeName;
                cake.Ingredient = model.Ingredient;
                cake.Expiry = model.Expiry;
                cake.DateOfManufacture = model.DateOfManufacture;
                cake.Status = model.Status;
                if (cakeService.Edit(cake))
                {
                    return RedirectToAction("Index", "Cake", new { catId = model.CategoryId });
                }
            }
            ViewBag.Category = category;

            return View(model);
        }
        [HttpGet]
        [Route("Cake/Detail/{cakeId}")]
        public IActionResult Detail(int cakeId)
        {
            var cake = cakeService.Get(cakeId);
            var detailCake = new DetailCake()
            {
                CategoryId = cake.CategoryId,
                cakeId = cake.cakeId,
                CakeName = cake.CakeName,
                Price = cake.Price,
                Ingredient = cake.Ingredient,
                Expiry = cake.Expiry,
                DateOfManufacture = cake.DateOfManufacture,
                Status = cake.Status
            };
            ViewBag.Category = category;
            return View(detailCake);
        }
        [HttpGet]
        [Route("Cake/ChangeStatus/{cakeId}")]
        public IActionResult ChangeStatus(int cakeId)
        {
            if (cakeService.ChangeStatus(cakeId))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
