﻿using AutoMapper;
using Films.Models;
using Films.Models.DTO;
using Films.Models.ViewModels;
using Films.Repository.IRepository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.JSInterop.Implementation;

namespace Films.Controllers
{
    public class CategoryController : Controller
    {
        public readonly ICategoryRepository _categoryRepo;
        public IMapper _mapper { get; set; }

        public CategoryController(
            ICategoryRepository categoryRepo,
            IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var objList = _categoryRepo.GetAll(u => u.DeleteTime == null);
            var categoryDTOs = _mapper.Map<List<CategoryDTO>>(objList);
            return View(categoryDTOs);
        }

        public IActionResult Create()
        {
            CategoryVM categoryVM = new()
            {
                CategoryDTO = new CategoryDTO(),
                CategorySelectList = _categoryRepo.GetAllDropdownList(WC.CategotyName)
            };

            return View(categoryVM);
        }

        // POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryVM obj)
        {
            if (ModelState.IsValid)
            {
                Category category = new();

                if (obj.CategoryDTO.Parent_category_id == null)
                {
                    category.Name = obj.CategoryDTO.Name;
                    category.Parent_category_id = null;
                    category.NestingLevel = 1;
                    category.CreateTime = DateTime.Now;
                }
                else
                {
                    Category categoryObjFromDb = _categoryRepo.FirstOrDefault(u => u.Id == obj.CategoryDTO.Parent_category_id);
                    
                    category.Name = obj.CategoryDTO.Name;
                    category.Parent_category_id = obj.CategoryDTO.Parent_category_id;
                    category.NestingLevel = categoryObjFromDb.NestingLevel +1;
                    category.CreateTime = DateTime.Now;
                }

                _categoryRepo.Add(category);
                _categoryRepo.Save();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET - DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category category = _categoryRepo.FirstOrDefault(u => u.Id == id, includePropreties:"ParentCategory");

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST - DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _categoryRepo.Find(id.GetValueOrDefault());
            if (id == null)
            {
                return NotFound();
            }

            _categoryRepo.Delete(obj.Id);
            _categoryRepo.Save();

            return RedirectToAction("Index");
        }
    }
}
