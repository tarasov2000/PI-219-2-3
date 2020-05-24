using AutoMapper;
using BLL.DTO.Shop;
using BLL.Enums;
using BLL.Services;
using Repository.Entities.Shop;
using Repository.Interfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Tests
{
    [TestFixture]
    public class OutputServiceTests
    {
        private IMapper mapper;
        private Mock<IUnitOfWork> uowMock;
        OutputService outputService;

        public OutputServiceTests()
        {
            uowMock = new Mock<IUnitOfWork>();
            mapper = new MapperConfiguration(cfg => cfg.AddProfile<TestsMappingConfig>()).CreateMapper();
            outputService = CreateOutputService();
        }

        private OutputService CreateOutputService()
        {
            return new OutputService(uowMock.Object, mapper);
        }

        [Test]
        public void Get_ExistingId_ReturnsProductDTO()
        {
            int id = 2;
            uowMock.Setup(a => a.Products.Get(id)).Returns(GetProduct);
            ProductDTO expected = new ProductDTO
            {
                Id = 2,
                Name = "Product2",
                Description = "Description2",
                Company = "Company1",
                CategoryId = 1,
                Price = 1100
            };

            ProductDTO actual = outputService.Get(2);

            Assert.AreEqual(expected.Id, actual.Id);
        }

        [Test]
        public void Get_InvalidId_ReturnsNull()
        {
            int id = -1;

            ProductDTO actual = outputService.Get(id);

            Assert.Null(actual);
        }

        [Test]
        public void SearchByName_ExistingName_ReturnsProductDTOsList()
        {
            string name = "Product2";
            uowMock.Setup(a => a.Products.GetAll()).Returns(GetProductsList);
            List<ProductDTO> expected = new List<ProductDTO>
            {
                new ProductDTO()
                {
                    Id = 2,
                    Name = "Product2",
                    Description = "Description2",
                    Company = "Company1",
                    CategoryId = 1,
                    Price = 1100
                }
            };

            List<ProductDTO> actual = outputService.SearchByName(name).ToList();

            Assert.AreEqual(expected[0].Id, actual[0].Id);
        }

        [Test]
        public void SearchByName_NotExistingName_ReturnsEmptyList()
        {
            string name = "Product4";
            uowMock.Setup(a => a.Products.GetAll()).Returns(GetProductsList);

            List<ProductDTO> actual = outputService.SearchByName(name).ToList();

            Assert.True(actual.Count == 0);
        }

        [Test]
        public void GetByCategory_SortByNameWithExistingCategoryId_ReturnsSortedByNameProductDTOsList()
        {
            int categoryId = 1;
            uowMock.Setup(a => a.Products.GetAll()).Returns(GetProductsList);
            List<ProductDTO> expected = new List<ProductDTO>
            {
                new ProductDTO()
                {
                    Id = 1,
                    Name = "Product1",
                    Description = "Description1",
                    Company = "Company1",
                    CategoryId = 1,
                    Price = 1000
                },
                new ProductDTO()
                {
                    Id = 2,
                    Name = "Product2",
                    Description = "Description2",
                    Company = "Company1",
                    CategoryId = 1,
                    Price = 3100
                }
            };

            List<ProductDTO> actual = outputService.GetByCategory(categoryId, SortCriteria.ByName).ToList();

            Assert.AreEqual(expected[0].Id, actual[0].Id);
            Assert.AreEqual(expected[1].Id, actual[1].Id);
        }

        [Test]
        public void GetByCategory_SortByPriceWithExistingCategoryId_ReturnsSortedByPriceProductDTOsList()
        {
            int categoryId = 1;
            uowMock.Setup(a => a.Products.GetAll()).Returns(GetProductsList);
            List<ProductDTO> expected = new List<ProductDTO>
            {
                new ProductDTO()
                {
                    Id = 1,
                    Name = "Product1",
                    Description = "Description1",
                    Company = "Company1",
                    CategoryId = 1,
                    Price = 1000
                },
                new ProductDTO()
                {
                    Id = 2,
                    Name = "Product2",
                    Description = "Description2",
                    Company = "Company1",
                    CategoryId = 1,
                    Price = 3100
                }
            };

            List<ProductDTO> actual = outputService.GetByCategory(categoryId, SortCriteria.ByPrice).ToList();

            Assert.AreEqual(expected[0].Id, actual[0].Id);
            Assert.AreEqual(expected[1].Id, actual[1].Id);
        }

        [Test]
        public void GetByCategory_SortByNameDescendingWithExistingCategoryId_ReturnsSortedByNameDescendingProductDTOsList()
        {
            int categoryId = 1;
            uowMock.Setup(a => a.Products.GetAll()).Returns(GetProductsList);
            List<ProductDTO> expected = new List<ProductDTO>
            {
                new ProductDTO()
                {
                    Id = 2,
                    Name = "Product2",
                    Description = "Description2",
                    Company = "Company1",
                    CategoryId = 1,
                    Price = 1100
                },
                new ProductDTO()
                {
                    Id = 1,
                    Name = "Product1",
                    Description = "Description1",
                    Company = "Company1",
                    CategoryId = 1,
                    Price = 1100
                }
            };

            List<ProductDTO> actual = outputService.GetByCategory(categoryId, SortCriteria.ByNameDescending).ToList();

            Assert.AreEqual(expected[0].Id, actual[0].Id);
            Assert.AreEqual(expected[1].Id, actual[1].Id);
        }

        [Test]
        public void GetByCategory_SortByPriceDescendingWithExistingCategoryId_ReturnsSortedByPriceDescendingProductDTOsList()
        {
            int categoryId = 1;
            uowMock.Setup(a => a.Products.GetAll()).Returns(GetProductsList);
            List<ProductDTO> expected = new List<ProductDTO>
            {
                new ProductDTO()
                {
                    Id = 2,
                    Name = "Product2",
                    Description = "Description2",
                    Company = "Company1",
                    CategoryId = 1,
                    Price = 1100
                },
                new ProductDTO()
                {
                    Id = 1,
                    Name = "Product1",
                    Description = "Description1",
                    Company = "Company1",
                    CategoryId = 1,
                    Price = 1100
                }
            };

            List<ProductDTO> actual = outputService.GetByCategory(categoryId, SortCriteria.ByPriceDescending).ToList();

            Assert.AreEqual(expected[0].Id, actual[0].Id);
            Assert.AreEqual(expected[1].Id, actual[1].Id);
        }

        [TestCase(SortCriteria.ByName)]
        [TestCase(SortCriteria.ByNameDescending)]
        [TestCase(SortCriteria.ByPrice)]
        [TestCase(SortCriteria.ByPriceDescending)]
        public void GetByCategory_NotExistingCategoryId_ReturnsEmptyList(SortCriteria criteria)
        {
            int categoryId = 4;
            uowMock.Setup(a => a.Products.GetAll()).Returns(GetProductsList);

            List<ProductDTO> actual = outputService.GetByCategory(categoryId, criteria).ToList();

            Assert.True(actual.Count == 0);
        }

        [TestCase(SortCriteria.ByName)]
        [TestCase(SortCriteria.ByNameDescending)]
        [TestCase(SortCriteria.ByPrice)]
        [TestCase(SortCriteria.ByPriceDescending)]
        public void GetByCategory_InvalidCategoryId_ReturnsEmptyList(SortCriteria criteria)
        {
            int categoryId = -1;

            IEnumerable<ProductDTO> actual = outputService.GetByCategory(categoryId, criteria);

            Assert.Null(actual);
        }

        [Test]
        public void FilterByCompany_ExistingCompanies_ReturnsProductDTOsList()
        {
            string[] companies = new string[] { "Company1" };
            uowMock.Setup(a => a.Products.GetAll()).Returns(GetProductsList);
            
            List<ProductDTO> expected = new List<ProductDTO>
            {
                new ProductDTO()
                {
                    Id = 1,
                    Name = "Product1",
                    Description = "Description1",
                    Company = "Company1",
                    CategoryId = 1,
                    Price = 1100
                },
                new ProductDTO()
                {
                    Id = 2,
                    Name = "Product2",
                    Description = "Description2",
                    Company = "Company1",
                    CategoryId = 1,
                    Price = 1100
                }
            };

            List<ProductDTO> actual = outputService.FilterByCompany(companies).ToList();

            Assert.AreEqual(expected[0].Id, actual[0].Id);
            Assert.AreEqual(expected[1].Id, actual[1].Id);
        }

        [Test]
        public void FilterByPrice_CorrectBounds_ReturnsProductDTOsList()
        {
            double leftBound = 2000;
            double rightBound = 6000;
            uowMock.Setup(a => a.Products.GetAll()).Returns(GetProductsList);
            List<ProductDTO> expected = new List<ProductDTO>
            {
                new ProductDTO()
                {
                    Id = 2,
                    Name = "Product2",
                    Description = "Description2",
                    Company = "Company2",
                    CategoryId = 2,
                    Price = 3100
                },
                new ProductDTO()
                {
                    Id = 3,
                    Name = "Product3",
                    Description = "Description3",
                    Company = "Company3",
                    CategoryId = 1,
                    Price = 2050
                }
            };

            List<ProductDTO> actual = outputService.FilterByPrice(leftBound, rightBound).ToList();

            Assert.AreEqual(expected[0].Id, actual[0].Id);
            Assert.AreEqual(expected[1].Id, actual[1].Id);
        }

        [Test]
        public void FilterByPrice_IncorrectBounds_ReturnsNull()
        {
            double leftBound = 6000;
            double rightBound = 4000;

            IEnumerable<ProductDTO> actual = outputService.FilterByPrice(leftBound, rightBound);

            Assert.Null(actual);
        }

        [Test]
        public void FilterByCompany_NotExistingCompanies_ReturnsEmptyList()
        {
            string[] companies = new string[] { "Company4" };
            uowMock.Setup(a => a.Products.GetAll()).Returns(GetProductsList);

            List<ProductDTO> actual = outputService.FilterByCompany(companies).ToList();

            Assert.True(actual.Count == 0);
        }

        private List<ProductRepo> GetProductsList()
        {
            return new List<ProductRepo>()
            {
                new ProductRepo()
                {
                    Id = 1,
                    Name = "Product1",
                    Description = "Description1",
                    Company = "Company1",
                    CategoryId = 1,
                    Price = 1000
                },
                new ProductRepo()
                {
                    Id = 2,
                    Name = "Product2",
                    Description = "Description2",
                    Company = "Company1",
                    CategoryId = 1,
                    Price = 3100
                },
                new ProductRepo()
                {
                    Id = 3,
                    Name = "Product3",
                    Description = "Description3",
                    Company = "Company2",
                    CategoryId = 2,
                    Price = 2050
                }
            };
        }

        private ProductRepo GetProduct()
        {
            return new ProductRepo
            {
                Id = 2,
                Name = "Product2",
                Description = "Description2",
                Company = "Company1",
                CategoryId = 1,
                Price = 1100
            };
        }
    }
}
