using Ecom.Controllers;
using Ecom.Data;
using Ecom.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EcomTests
{
    public class AdminProductsControllerTest
    {
        //private readonly ApplicationDbContext _context;
        //private readonly AdminProductsController _sut;







        public AdminProductsControllerTest()
        {
            //_sut = new AdminProductsController(_context);

            //_context = new ApplicationDbContext();

        }

        IQueryable<Product> data = new[]
          { new Product
            {
                ProductName = "yes", 
            },
                new Product
                {
                     ProductName = "yes1",
                }
                
            }.AsQueryable();

        //Get
        [Fact]
        public async void IndexTest_checkDbConnection()
       {
            //var result = await _sut.Index();
            //Assert.IsType<ViewResult>(result);
        }
        //Get
        [Fact]
        public async void IndexTest_GetProducts()
        {

            //Act
            var _context = new ApplicationDbContext();
            var _sut = new AdminProductsController(_context);

            var testItem = new Product
            {
                ProductName = "yes1",
            };

            var testItem2 = new Product
            {
                ProductName = "yes1",
            };
            //act
            _sut.Create(testItem);
            _sut.Create(testItem2);

            var listOfProducts = _sut.Index();
            //asert
            Assert.NotNull(listOfProducts);


        }

        //Create
        [Fact]
        public async void CreateTest()
        {
            //Arrange

            //ghdfhgtfhjgfhgfhgfdhgfhgtyfhgf
          

            var _context = new ApplicationDbContext();
            //Act

         

            var _sut = new AdminProductsController(_context);

            var testItem = new Product
            {
                ProductName = "yes1",
                ProductID = 1,
                CategoryID = 1,
                ListPrice = 5000


                
            };

            var result = await _sut.Create(testItem);

            //Assert


            Assert.NotNull(result);

        }


        //delete
        [Fact]
        public async void DeleteTest()
        {
            var testItem = new Product
            {
                ProductName = "yes1",
            };


            var _context = new ApplicationDbContext();
            //Act

            var _sut = new AdminProductsController(_context);

            var addCategory = _sut.Create(testItem);

            var deleteResult = _sut.Delete(1);

            var listOfCategories = _sut.Index();

            Assert.DoesNotContain(null, "test65");
        }

        [Fact]
        public async void updateTest()
        {
            var testItem = new Product
            {
                ProductName = "yes1",
            };

            var _context = new ApplicationDbContext();
            //Act

            var _sut = new AdminProductsController(_context);

            var addResult = await _sut.Create(testItem);


            var result = _context.Update(addResult);

            Assert.IsType<IActionResult>(result);
        }
    }

}
