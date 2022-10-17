using Amazon.Repositories;

namespace Amazon.Tests
{
    public class CategoryTests
    {
        CategoryRepository? categoryRepository = new();

        [Fact]
        public void GetCategoriesTest()
        {
            Assert.NotEmpty(categoryRepository.GetCategories());
        }

        [Fact]
        public void GetCategoriesTestWithBooksDeptId()
        {
            Assert.NotEmpty(categoryRepository.GetCategories(1));
        }

        [Fact]
        public void GetCategoriesTestWithElectronicsDeptId()
        {
            Assert.NotEmpty(categoryRepository.GetCategories(2));
        }
    }
}