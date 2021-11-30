using Ecom.Controllers;
using Ecom.Data;
using Ecom.Models;
using Ecom.Views.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Utilities;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using Xunit;

namespace EcomTests
{
    public class AdminCategoriesControllerTest 
    {
        private readonly ApplicationDbContext _context;
        private readonly AdminCategoriesController _sut;




 


        public AdminCategoriesControllerTest()
        {
            _sut = new AdminCategoriesController(_context);

            //_context = new ApplicationDbContext();
           
        }
       
   IQueryable<Category> data = new[]
     { new Category
            {
                CategoryID = 1, CategoryName = "Title"
            },
                new Category
                {
                    CategoryID = 2, CategoryName = "No Title2"
                },
                new Category
                {
                    CategoryID = 3, CategoryName = "No Title2"
                }
            }.AsQueryable();

        //Get
        //[Fact]
        //public async void IndexTest_checkDbConnection()
        //{
        //    var result = await _sut.Index();
        //    Assert.IsType<ViewResult>(result);
        //}
        //Get
        [Fact]
        public async void IndexTest_GetCategories()
        {

            //Act
            var _context = new ApplicationDbContext();
            var _sut = new AdminCategoriesController(_context);
           
            var testItem = new Category
            {

                CategoryName = "No Title5"
            };

            var testItem2 = new Category
            {

                CategoryName = "No Title7"
            };
            //act
            _sut.Create(testItem);
            _sut.Create(testItem2);

           var listOfCategories = _sut.Index();
            //asert
            Assert.NotNull(listOfCategories);


        }

        //Create
        [Fact]
        public async void CreateTest()
        {
            //Arrange
            

            var testItem = new Category
            {
              
                CategoryName = "No Title2"
            };

            var _context = new ApplicationDbContext();
            //Act

           var _sut = new AdminCategoriesController(_context);

          var result =  await _sut.Create(testItem);

            //Assert
            

            Assert.NotNull(result);
        
        }


        //delete
        [Fact]
        public async void DeleteTest()
        {
            var categoryItem = new Category
            {
               
                CategoryName = "test65"
            };

            var _context = new ApplicationDbContext();
            //Act

            var _sut = new AdminCategoriesController(_context);

            var addCategory = _sut.Create(categoryItem);

            var deleteResult = _sut.Delete("test65");

            var listOfCategories = _sut.Index();

            Assert.DoesNotContain(null,"test65");
        }

            [Fact]
        public async void updateTest()
        {
            var categoryItem = new Category
            {
                
                CategoryName = "test19"
            };

            var _context = new ApplicationDbContext();
            //Act

            var _sut = new AdminCategoriesController(_context);

            var addResult = await _sut.Create(categoryItem);


            var result = _context.Update(addResult);

            Assert.IsType<IActionResult>(result);
        }
    }


}
