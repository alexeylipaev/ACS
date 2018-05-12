using Microsoft.VisualStudio.TestTools.UnitTesting;
using ACS.WEB.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACS.BLL.Interfaces;
using ACS.BLL.DTO;
using ACS.WEB.Tests.Controllers.TetServices;
using System.Web.Mvc;

namespace ACS.WEB.Tests
{
    [TestClass()]
    public class ChancelleryControllerTests
    {
        public ChancelleryControllerTests()
        {
            ChancelleryServiceTest cst = new ChancelleryServiceTest();
            //EmployeeServiceTest est = new EmployeeServiceTest();
            ChancelleryController = new ChancelleryController(cst);
        }

        public ChancelleryController ChancelleryController { get; set; }

        [TestMethod()]
        public void ChancelleryControllerTest()
        {
            
            Assert.Fail();
        }

        [TestMethod()]
        public void IndexTest()
        {
            // Arrange
            //ChancelleryController;

            // Act
            ViewResult result = ChancelleryController.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void DetailsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EditTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EditTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest1()
        {
            Assert.Fail();
        }
    }

    
}