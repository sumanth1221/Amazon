using Amazon.Repositories;

namespace Amazon.Tests
{
    public class DepartmentTests
    {
        DepartmentRepository? departmentRepository = new();

        [Fact]
        public void CreateDepartmentTest()
        {
            Assert.NotNull(departmentRepository.CreateDepartment());
        }

        [Fact]
        public void ProductViewModelTest()
        {
            Assert.NotNull(departmentRepository.ProductViewModel());
        }

        [Fact]
        public void GetDepartmentsTest()
        {
            Assert.NotEmpty(departmentRepository.GetDepartments());
        }
    }
}