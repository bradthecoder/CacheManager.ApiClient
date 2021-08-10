#region Using Statements
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CacheManager.ApiClient.Models;
using CacheManager.ApiClient.Tests.MockData;
using CacheManager.ApiClient.Tests.RestClientMocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endregion

namespace CacheManager.ApiClient.Services.Tests
{
    [TestClass]
    public class ServiceTests : ServiceTestsBase
    {
        private readonly MockRestClient _mockRestClient = new MockRestClient();
        private readonly ErrorRestClient _mockErrorRestClient = new ErrorRestClient();
        private readonly ExceptionRestClient _exceptionClient = new ExceptionRestClient();
        private readonly CacheObjects _mockdata = new CacheObjects();

        private Service GetBasicService()
        {
            Service target = new Service(_configuration, _mockRestClient);
            return target;
        }

        private Service GetErrorService()
        {
            Service target = new Service(_configuration, _mockErrorRestClient);
            return target;
        }

        private Service GetExceptionService()
        {
            Service target = new Service(_configuration, _exceptionClient);
            return target;
        }

        [TestMethod]
        public void BaseUrlTest()
        {
            // Arrange
            Service target = new Service(_configuration, _exceptionClient);
            target.BaseUrl = null;

            // Act
            string error = null;
            try
            {
                var actual = target.BaseUrl;
            }
            catch (Exception ex)
            {
                error = ex.ToString();
            }

            // Assert
            Assert.IsNotNull(error);
        }

        [TestMethod]
        public void ApiUriTest()
        {
            // Arrange
            Service target = new Service(_configuration, _exceptionClient);
            target.ApiUri = null;

            // Act
            string error = null;
            try
            {
                var actual = target.ApiUri;
            }
            catch (Exception ex)
            {
                error = ex.ToString();
            }

            // Assert
            Assert.IsNotNull(error);
        }

        [TestMethod]
        public async Task GetObject_Test()
        {
            // Arrange
            Service target = GetBasicService();
            CacheObject expected = _mockdata.ExampleCacheObject();
            GetObjectRequest input = new() { Id = expected.Id, Type = expected.Type };

            // Act
            CacheObject actual = await target.GetObject(input);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsFalse(target.HasError);
        }

        [TestMethod]
        public async Task GetObjectProperty_Test()
        {
            // Arrange
            Service target = GetBasicService();
            CacheObject expected = _mockdata.ExampleCacheObject();
            GetObjectPropertyRequest input = new() { Id = expected.Id, Type = expected.Type, PropertyName = "Name" };

            // Act
            object actual = await target.GetObjectProperty(input);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsFalse(target.HasError);
        }

        [TestMethod]
        public async Task SetObject_Test()
        {
            // Arrange
            Service target = GetBasicService();
            CacheObject input = _mockdata.ExampleCacheObject();
            
            // Act
            await target.SetObject(input);

            // Assert
            Assert.IsFalse(target.HasError);
        }

        [TestMethod]
        public async Task SetObjectProperty_Test()
        {
            // Arrange
            Service target = GetBasicService();
            CacheObject expected = _mockdata.ExampleCacheObject();
            SetObjectPropertyRequest input = new() { Id = expected.Id, Type = expected.Type, Properties = new Dictionary<string, object>() };
            input.Properties.Add("title", "Manager");

            // Act
            await target.SetObjectProperty(input);

            // Assert
            Assert.IsFalse(target.HasError);
        }

        [TestMethod]
        public async Task RefreshObject_Test()
        {
            // Arrange
            Service target = GetBasicService();
            CacheObject expected = _mockdata.ExampleCacheObject();
            RefreshObjectRequest input = new() { Id = expected.Id, Type = expected.Type };

            // Act
            await target.RefreshObject(input);

            // Assert
            Assert.IsFalse(target.HasError);
        }

        [TestMethod]
        public async Task RemoveObject_Test()
        {
            // Arrange
            Service target = GetBasicService();
            CacheObject expected = _mockdata.ExampleCacheObject();
            RemoveObjectRequest input = new() { Id = expected.Id, Type = expected.Type };

            // Act
            await target.RemoveObject(input);

            // Assert
            Assert.IsFalse(target.HasError);
        }

        [TestMethod]
        public async Task RemoveObjectProperty_Test()
        {
            // Arrange
            Service target = GetBasicService();
            CacheObject expected = _mockdata.ExampleCacheObject();
            RemoveObjectPropertyRequest input = new() { Id = expected.Id, Type = expected.Type, Properties = new List<string>() };
            input.Properties.Add("JobTitle");

            // Act
            await target.RemoveObjectProperty(input);

            // Assert
            Assert.IsFalse(target.HasError);
        }

        //// ERRORS

        [TestMethod]
        public async Task GetObject_Error_Test()
        {
            // Arrange
            Service target = GetErrorService();
            CacheObject expected = _mockdata.ExampleCacheObject();
            GetObjectRequest input = new() { Id = expected.Id, Type = expected.Type };

            // Act
            CacheObject actual = await target.GetObject(input);

            // Assert
            Assert.IsTrue(target.HasError);
        }

        [TestMethod]
        public async Task GetObjectProperty_Error_Test()
        {
            // Arrange
            Service target = GetErrorService();
            CacheObject expected = _mockdata.ExampleCacheObject();
            GetObjectPropertyRequest input = new() { Id = expected.Id, Type = expected.Type, PropertyName = "Name" };

            // Act
            object actual = await target.GetObjectProperty(input);

            // Assert
            Assert.IsTrue(target.HasError);
        }

        [TestMethod]
        public async Task SetObject_Error_Test()
        {
            // Arrange
            Service target = GetErrorService();
            CacheObject input = _mockdata.ExampleCacheObject();

            // Act
            await target.SetObject(input);

            // Assert
            Assert.IsTrue(target.HasError);
        }

        [TestMethod]
        public async Task SetObjectProperty_Error_Test()
        {
            // Arrange
            Service target = GetErrorService();
            CacheObject expected = _mockdata.ExampleCacheObject();
            SetObjectPropertyRequest input = new() { Id = expected.Id, Type = expected.Type, Properties = new Dictionary<string, object>() };
            input.Properties.Add("title", "Manager");

            // Act
            await target.SetObjectProperty(input);

            // Assert
            Assert.IsTrue(target.HasError);
        }

        [TestMethod]
        public async Task RefreshObject_Error_Test()
        {
            // Arrange
            Service target = GetErrorService();
            CacheObject expected = _mockdata.ExampleCacheObject();
            RefreshObjectRequest input = new() { Id = expected.Id, Type = expected.Type };

            // Act
            await target.RefreshObject(input);

            // Assert
            Assert.IsTrue(target.HasError);
        }

        [TestMethod]
        public async Task RemoveObject_Error_Test()
        {
            // Arrange
            Service target = GetErrorService();
            CacheObject expected = _mockdata.ExampleCacheObject();
            RemoveObjectRequest input = new() { Id = expected.Id, Type = expected.Type };

            // Act
            await target.RemoveObject(input);

            // Assert
            Assert.IsTrue(target.HasError);
        }

        [TestMethod]
        public async Task RemoveObjectProperty_Error_Test()
        {
            // Arrange
            Service target = GetErrorService();
            CacheObject expected = _mockdata.ExampleCacheObject();
            RemoveObjectPropertyRequest input = new() { Id = expected.Id, Type = expected.Type, Properties = new List<string>() };
            input.Properties.Add("JobTitle");

            // Act
            await target.RemoveObjectProperty(input);

            // Assert
            Assert.IsTrue(target.HasError);
        }

        //// EXCEPTIONS

        [TestMethod]
        public async Task GetObject_Exception_Test()
        {
            // Arrange
            Service target = GetExceptionService();
            CacheObject expected = _mockdata.ExampleCacheObject();
            GetObjectRequest input = new() { Id = expected.Id, Type = expected.Type };

            // Act
            CacheObject actual = await target.GetObject(input);

            // Assert
            Assert.IsTrue(target.HasError);
        }

        [TestMethod]
        public async Task GetObjectProperty_Exception_Test()
        {
            // Arrange
            Service target = GetExceptionService();
            CacheObject expected = _mockdata.ExampleCacheObject();
            GetObjectPropertyRequest input = new() { Id = expected.Id, Type = expected.Type, PropertyName = "Name" };

            // Act
            object actual = await target.GetObjectProperty(input);

            // Assert
            Assert.IsTrue(target.HasError);
        }

        [TestMethod]
        public async Task SetObject_Exception_Test()
        {
            // Arrange
            Service target = GetExceptionService();
            CacheObject input = _mockdata.ExampleCacheObject();

            // Act
            await target.SetObject(input);

            // Assert
            Assert.IsTrue(target.HasError);
        }

        [TestMethod]
        public async Task SetObjectProperty_Exception_Test()
        {
            // Arrange
            Service target = GetExceptionService();
            CacheObject expected = _mockdata.ExampleCacheObject();
            SetObjectPropertyRequest input = new() { Id = expected.Id, Type = expected.Type, Properties = new Dictionary<string, object>() };
            input.Properties.Add("title", "Manager");

            // Act
            await target.SetObjectProperty(input);

            // Assert
            Assert.IsTrue(target.HasError);
        }

        [TestMethod]
        public async Task RefreshObject_Exception_Test()
        {
            // Arrange
            Service target = GetExceptionService();
            CacheObject expected = _mockdata.ExampleCacheObject();
            RefreshObjectRequest input = new() { Id = expected.Id, Type = expected.Type };

            // Act
            await target.RefreshObject(input);

            // Assert
            Assert.IsTrue(target.HasError);
        }

        [TestMethod]
        public async Task RemoveObject_Exception_Test()
        {
            // Arrange
            Service target = GetExceptionService();
            CacheObject expected = _mockdata.ExampleCacheObject();
            RemoveObjectRequest input = new() { Id = expected.Id, Type = expected.Type };

            // Act
            await target.RemoveObject(input);

            // Assert
            Assert.IsTrue(target.HasError);
        }

        [TestMethod]
        public async Task RemoveObjectProperty_Exception_Test()
        {
            // Arrange
            Service target = GetExceptionService();
            CacheObject expected = _mockdata.ExampleCacheObject();
            RemoveObjectPropertyRequest input = new() { Id = expected.Id, Type = expected.Type, Properties = new List<string>() };
            input.Properties.Add("JobTitle");

            // Act
            await target.RemoveObjectProperty(input);

            // Assert
            Assert.IsTrue(target.HasError);
        }

    }
}
