using src.Controllers;
using src.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GoldCSTests.Controllers
{
    public class CategoryControllerTest
    {
        public CategoryController _categoryController;
        public CategoryService _categoryService;

        public CategoryControllerTest(CategoryController categoryController, CategoryService categoryService)
        {
            _categoryController = categoryController;
            _categoryService = categoryService;
        }

        [Fact]
        public void GetAll_Category_ReturnTrue()
        {
            //Arrange

            //Act
            var result = _categoryController.GetCategoriesAsync(new src.Pagination.QueryPaginationParameters());

            //Assert
            Assert.Equal(HttpStatusCode.OK.ToString(), "teste");
        }
    }
}
