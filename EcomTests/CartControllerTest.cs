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
    public class CartControllerTest
    {
        private readonly ApplicationDbContext _context;
        private readonly CartController _sut;







        public CartControllerTest()
        {
            _sut = new CartController(_context);

            //_context = new ApplicationDbContext();

        }

        IQueryable<Cart> data = new[]
          { new Cart
            {
                UserId = "1",
            },
                new Cart
                {
                     UserId = "2",
                }

            }.AsQueryable();

        //Get
        [Fact]
        public async void IndexTest_checkDbConnection()
        {
            var result = await _sut.Index();
            Assert.IsType<ViewResult>(result);
        }
        //Get
        [Fact]
        public async void IndexTest_GetProducts()
        {

            //Act
            var _context = new ApplicationDbContext();
            var _sut = new CartController(_context);

            var testItem = new Cart
            {
                UserId = "1",
            };
            var testItem2 = new Cart
            {
                UserId = "2",
            };
            //act
            _sut.Create(testItem);
            _sut.Create(testItem2);

            var cart = _sut.Index();
            //asert
            Assert.NotNull(cart);


        }

        //Create
        [Fact]
        public async void CreateTest()
        {
            //Arrange


            var testItem = new Cart
            {
                UserId = "1",
            };

            var _context = new ApplicationDbContext();
            //Act

            var _sut = new CartController(_context);

            var result = await _sut.Create(testItem);

            //Assert


            Assert.NotNull(result);

        }


        //delete
        [Fact]
        public async void DeleteTest()
        {
            var testItem = new Cart
            {
                UserId = "1",
            };



            var _context = new ApplicationDbContext();
            //Act

            var _sut = new CartController(_context);

            var addCategory = _sut.Create(testItem);

            var deleteResult = _sut.Delete(1);

            var cart = _sut.Index();

            Assert.DoesNotContain(null, "test65");
        }

        [Fact]
        public async void updateTest()
        {
            var testItem = new Cart
            {
                UserId = "1",
            };

            var _context = new ApplicationDbContext();
            //Act

            var _sut = new CartController(_context);

            var addResult = await _sut.Create(testItem);


            var result = _context.Update(addResult);

            Assert.IsType<IActionResult>(result);
        }
    }
}
