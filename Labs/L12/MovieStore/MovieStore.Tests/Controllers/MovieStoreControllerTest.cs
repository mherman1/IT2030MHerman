using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieStore.Controllers;
using MovieStore.Models;

namespace MovieStore.Tests.Controllers
{
    

    [TestClass]
    public class MovieStoreControllerTest
    {
        [TestMethod]
        public void MovieStore_Index_TestView()
        {
            //Arrange
            MoviesController controller = new MoviesController();

            //Act
            ViewResult result = controller.Index() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void MovieStore_Details_Success()
        {
            //Goal: Query from our own list instead of the database.

            //Step 1
            var list = new List<Movie>
            {
                new Movie() {MovieId = 1, Title = "Superman 1"},
                new Movie() {MovieId = 2, Title = "Superman 2"}
            }.AsQueryable();

            //Step 2
            Mock<MovieStoreDbContext> mockContext = new Mock<MovieStoreDbContext>();
            Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();

            //Step 3
            mockSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());
                //mockSet.As<IQueryable<Movie>>().Setup(m => m.Provider).Returns(list.Provider);
                //mockSet.As<IQueryable<Movie>>().Setup(m => m.ElementType).Returns(list.ElementType);
            mockSet.Setup(m => m.Find(It.IsAny<Object>())).Returns(list.First());

            //Step 4
            mockContext.Setup(db => db.Movies).Returns(mockSet.Object);

            //Arrange
            MoviesController controller = new MoviesController(mockContext.Object);

            //Act
            ViewResult result = controller.Details(id: 1) as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void MovieStore_Details_IdIsNull()
        {
            //Goal: Query from our own list instead of the database.

            //Step 1
            var list = new List<Movie>
            {
                new Movie() {MovieId = 1, Title = "Superman 1"},
                new Movie() {MovieId = 2, Title = "Superman 2"}
            }.AsQueryable();

            //Step 2
            Mock<MovieStoreDbContext> mockContext = new Mock<MovieStoreDbContext>();
            Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();

            //Step 3
            mockSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());
                //mockSet.As<IQueryable<Movie>>().Setup(m => m.Provider).Returns(list.Provider);
                //mockSet.As<IQueryable<Movie>>().Setup(m => m.ElementType).Returns(list.ElementType);
            mockSet.Setup(m => m.Find(It.IsAny<Object>())).Returns(list.First());

            //Step 4
            mockContext.Setup(db => db.Movies).Returns(mockSet.Object);

            //Arrange
            MoviesController controller = new MoviesController(mockContext.Object);

            //Act
            HttpStatusCodeResult result = controller.Details(id: null) as HttpStatusCodeResult;

            //Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, (HttpStatusCode)result.StatusCode);
        }

        [TestMethod]
        public void MovieStore_Details_MovieIsNull()
        {
            //Goal: Query from our own list instead of the database.

            //Step 1
            var list = new List<Movie>
            {
                new Movie() {MovieId = 1, Title = "Superman 1"},
                new Movie() {MovieId = 2, Title = "Superman 2"}
            }.AsQueryable();

            //Step 2
            Mock<MovieStoreDbContext> mockContext = new Mock<MovieStoreDbContext>();
            Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();

            //Step 3
            mockSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());
                //mockSet.As<IQueryable<Movie>>().Setup(m => m.Provider).Returns(list.Provider);
                //mockSet.As<IQueryable<Movie>>().Setup(m => m.ElementType).Returns(list.ElementType);

            Movie movie = null;

            mockSet.Setup(m => m.Find(It.IsAny<Object>())).Returns(movie);

            //Step 4
            mockContext.Setup(db => db.Movies).Returns(mockSet.Object);

            //Arrange
            MoviesController controller = new MoviesController(mockContext.Object);

            //Act
            HttpStatusCodeResult result = controller.Details(id: 0) as HttpStatusCodeResult;

            //Assert
            Assert.AreEqual(HttpStatusCode.NotFound, (HttpStatusCode)result.StatusCode);
        }

        [TestMethod]
        public void MovieStore_Create_TestView()
        {
            //Arrange
            MoviesController controller = new MoviesController();

            //Act
            ViewResult result = controller.Create() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void MovieStore_Create_ValidModel()
        {
            //Goal: Query from our own list instead of the database.

            ////Step 1
            //var list = new List<Movie>
            //{
            //    new Movie() {MovieId = 1, Title = "Superman 1"},
            //    new Movie() {MovieId = 2, Title = "Superman 2"}
            //}.AsQueryable();

            //Step 2
            Mock<MovieStoreDbContext> mockContext = new Mock<MovieStoreDbContext>();
            Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();

            ////Step 3
            //mockSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());
            //    //mockSet.As<IQueryable<Movie>>().Setup(m => m.Provider).Returns(list.Provider);
            //    //mockSet.As<IQueryable<Movie>>().Setup(m => m.ElementType).Returns(list.ElementType);

            Movie movie = new Movie() { MovieId = 1, Title = "The Matrix"};

            mockSet.Setup(m => m.Find(It.IsAny<Object>())).Returns(movie);

            //Step 4
            mockContext.Setup(db => db.Movies).Returns(mockSet.Object);

            //Arrange
            MoviesController controller = new MoviesController(mockContext.Object);

            controller.ModelState.Clear();

            //Act
            RedirectToRouteResult result = controller.Create(movie) as RedirectToRouteResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void MovieStore_Create_ModelWithErrors()
        {
            //Goal: Query from our own list instead of the database.

            ////Step 1
            //var list = new List<Movie>
            //{
            //    new Movie() {MovieId = 1, Title = "Superman 1"},
            //    new Movie() {MovieId = 2, Title = "Superman 2"}
            //}.AsQueryable();

            //Step 2
            Mock<MovieStoreDbContext> mockContext = new Mock<MovieStoreDbContext>();
            Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();

            ////Step 3
            //mockSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());
            //    //mockSet.As<IQueryable<Movie>>().Setup(m => m.Provider).Returns(list.Provider);
            //    //mockSet.As<IQueryable<Movie>>().Setup(m => m.ElementType).Returns(list.ElementType);

            //Step 4
            mockContext.Setup(db => db.Movies).Returns(mockSet.Object);

            //Arrange
            MoviesController controller = new MoviesController(mockContext.Object);

            Movie movie = null;

            controller.ModelState.AddModelError("test", "test");

            //Act
            ViewResult result = controller.Create(movie) as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void MovieStore_Edit_Success()
        {
            //Goal: Query from our own list instead of the database.

            //Step 1
            var list = new List<Movie>
            {
                new Movie() {MovieId = 1, Title = "Superman 1"},
                new Movie() {MovieId = 2, Title = "Superman 2"}
            }.AsQueryable();

            //Step 2
            Mock<MovieStoreDbContext> mockContext = new Mock<MovieStoreDbContext>();
            Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();

            //Step 3
            mockSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());
                //mockSet.As<IQueryable<Movie>>().Setup(m => m.Provider).Returns(list.Provider);
                //mockSet.As<IQueryable<Movie>>().Setup(m => m.ElementType).Returns(list.ElementType);
            mockSet.Setup(m => m.Find(It.IsAny<Object>())).Returns(list.First());

            //Step 4
            mockContext.Setup(db => db.Movies).Returns(mockSet.Object);

            //Arrange
            MoviesController controller = new MoviesController(mockContext.Object);

            //Act
            ViewResult result = controller.Edit(id: 1) as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void MovieStore_Edit_IdIsNull()
        {
            //Goal: Query from our own list instead of the database.

            //Step 1
            var list = new List<Movie>
            {
                new Movie() {MovieId = 1, Title = "Superman 1"},
                new Movie() {MovieId = 2, Title = "Superman 2"}
            }.AsQueryable();

            //Step 2
            Mock<MovieStoreDbContext> mockContext = new Mock<MovieStoreDbContext>();
            Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();

            //Step 3
            mockSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());
                //mockSet.As<IQueryable<Movie>>().Setup(m => m.Provider).Returns(list.Provider);
                //mockSet.As<IQueryable<Movie>>().Setup(m => m.ElementType).Returns(list.ElementType);
            mockSet.Setup(m => m.Find(It.IsAny<Object>())).Returns(list.First());

            //Step 4
            mockContext.Setup(db => db.Movies).Returns(mockSet.Object);

            //Arrange
            MoviesController controller = new MoviesController(mockContext.Object);

            //Act
            HttpStatusCodeResult result = controller.Edit(id: null) as HttpStatusCodeResult;

            //Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, (HttpStatusCode)result.StatusCode);
        }

        [TestMethod]
        public void MovieStore_Edit_MovieIsNull()
        {
            //Goal: Query from our own list instead of the database.

            //Step 1
            var list = new List<Movie>
            {
                new Movie() {MovieId = 1, Title = "Superman 1"},
                new Movie() {MovieId = 2, Title = "Superman 2"}
            }.AsQueryable();

            //Step 2
            Mock<MovieStoreDbContext> mockContext = new Mock<MovieStoreDbContext>();
            Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();

            //Step 3
            mockSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());
                //mockSet.As<IQueryable<Movie>>().Setup(m => m.Provider).Returns(list.Provider);
                //mockSet.As<IQueryable<Movie>>().Setup(m => m.ElementType).Returns(list.ElementType);

            Movie movie = null;

            mockSet.Setup(m => m.Find(It.IsAny<Object>())).Returns(movie);

            //Step 4
            mockContext.Setup(db => db.Movies).Returns(mockSet.Object);

            //Arrange
            MoviesController controller = new MoviesController(mockContext.Object);

            //Act
            HttpStatusCodeResult result = controller.Edit(id: 0) as HttpStatusCodeResult;

            //Assert
            Assert.AreEqual(HttpStatusCode.NotFound, (HttpStatusCode)result.StatusCode);
        }

        [TestMethod]
        public void MovieStore_Edit_ValidModel()
        {
            //Goal: Query from our own list instead of the database.

            ////Step 1
            //var list = new List<Movie>
            //{
            //    new Movie() {MovieId = 1, Title = "Superman 1"},
            //    new Movie() {MovieId = 2, Title = "Superman 2"}
            //}.AsQueryable();

            //Step 2
            Mock<MovieStoreDbContext> mockContext = new Mock<MovieStoreDbContext>();
            Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();

            ////Step 3
            //mockSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());
            //    //mockSet.As<IQueryable<Movie>>().Setup(m => m.Provider).Returns(list.Provider);
            //    //mockSet.As<IQueryable<Movie>>().Setup(m => m.ElementType).Returns(list.ElementType);

            Movie movie = new Movie() { MovieId = 1, Title = "The Matrix" };

            mockSet.Setup(m => m.Find(It.IsAny<Object>())).Returns(movie);

            //Step 4
            mockContext.Setup(db => db.Movies).Returns(mockSet.Object);

            //Arrange
            MoviesController controller = new MoviesController(mockContext.Object);

            controller.ModelState.Clear();

            //Act
            RedirectToRouteResult result = controller.Edit(movie) as RedirectToRouteResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void MovieStore_Edit_ModelWithErrors()
        {
            //Goal: Query from our own list instead of the database.

            ////Step 1
            //var list = new List<Movie>
            //{
            //    new Movie() {MovieId = 1, Title = "Superman 1"},
            //    new Movie() {MovieId = 2, Title = "Superman 2"}
            //}.AsQueryable();

            //Step 2
            Mock<MovieStoreDbContext> mockContext = new Mock<MovieStoreDbContext>();
            Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();

            ////Step 3
            //mockSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());
            //    //mockSet.As<IQueryable<Movie>>().Setup(m => m.Provider).Returns(list.Provider);
            //    //mockSet.As<IQueryable<Movie>>().Setup(m => m.ElementType).Returns(list.ElementType);

            //Step 4
            mockContext.Setup(db => db.Movies).Returns(mockSet.Object);

            //Arrange
            MoviesController controller = new MoviesController(mockContext.Object);

            Movie movie = null;

            controller.ModelState.AddModelError("test", "test");

            //Act
            ViewResult result = controller.Edit(movie) as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void MovieStore_Delete_Success()
        {
            //Goal: Query from our own list instead of the database.

            //Step 1
            var list = new List<Movie>
            {
                new Movie() {MovieId = 1, Title = "Superman 1"},
                new Movie() {MovieId = 2, Title = "Superman 2"}
            }.AsQueryable();

            //Step 2
            Mock<MovieStoreDbContext> mockContext = new Mock<MovieStoreDbContext>();
            Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();

            //Step 3
            mockSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());
            //mockSet.As<IQueryable<Movie>>().Setup(m => m.Provider).Returns(list.Provider);
            //mockSet.As<IQueryable<Movie>>().Setup(m => m.ElementType).Returns(list.ElementType);
            mockSet.Setup(m => m.Find(It.IsAny<Object>())).Returns(list.First());

            //Step 4
            mockContext.Setup(db => db.Movies).Returns(mockSet.Object);

            //Arrange
            MoviesController controller = new MoviesController(mockContext.Object);

            //Act
            ViewResult result = controller.Delete(id: 1) as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void MovieStore_Delete_IdIsNull()
        {
            //Goal: Query from our own list instead of the database.

            //Step 1
            var list = new List<Movie>
            {
                new Movie() {MovieId = 1, Title = "Superman 1"},
                new Movie() {MovieId = 2, Title = "Superman 2"}
            }.AsQueryable();

            //Step 2
            Mock<MovieStoreDbContext> mockContext = new Mock<MovieStoreDbContext>();
            Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();

            //Step 3
            mockSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());
            //mockSet.As<IQueryable<Movie>>().Setup(m => m.Provider).Returns(list.Provider);
            //mockSet.As<IQueryable<Movie>>().Setup(m => m.ElementType).Returns(list.ElementType);
            mockSet.Setup(m => m.Find(It.IsAny<Object>())).Returns(list.First());

            //Step 4
            mockContext.Setup(db => db.Movies).Returns(mockSet.Object);

            //Arrange
            MoviesController controller = new MoviesController(mockContext.Object);

            //Act
            HttpStatusCodeResult result = controller.Details(id: null) as HttpStatusCodeResult;

            //Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, (HttpStatusCode)result.StatusCode);
        }

        [TestMethod]
        public void MovieStore_Delete_MovieIsNull()
        {
            //Goal: Query from our own list instead of the database.

            //Step 1
            var list = new List<Movie>
            {
                new Movie() {MovieId = 1, Title = "Superman 1"},
                new Movie() {MovieId = 2, Title = "Superman 2"}
            }.AsQueryable();

            //Step 2
            Mock<MovieStoreDbContext> mockContext = new Mock<MovieStoreDbContext>();
            Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();

            //Step 3
            mockSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());
            //mockSet.As<IQueryable<Movie>>().Setup(m => m.Provider).Returns(list.Provider);
            //mockSet.As<IQueryable<Movie>>().Setup(m => m.ElementType).Returns(list.ElementType);

            Movie movie = null;

            mockSet.Setup(m => m.Find(It.IsAny<Object>())).Returns(movie);

            //Step 4
            mockContext.Setup(db => db.Movies).Returns(mockSet.Object);

            //Arrange
            MoviesController controller = new MoviesController(mockContext.Object);

            //Act
            HttpStatusCodeResult result = controller.Delete(id: 0) as HttpStatusCodeResult;

            //Assert
            Assert.AreEqual(HttpStatusCode.NotFound, (HttpStatusCode)result.StatusCode);
        }

        [TestMethod]
        public void MovieStore_DeleteConfirmed()
        {
            //Goal: Query from our own list instead of the database.

            //Step 1
            var list = new List<Movie>
            {
                new Movie() {MovieId = 1, Title = "Superman 1"},
                new Movie() {MovieId = 2, Title = "Superman 2"}
            }.AsQueryable();

            //Step 2
            Mock<MovieStoreDbContext> mockContext = new Mock<MovieStoreDbContext>();
            Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();

            //Step 3
            mockSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());
                //mockSet.As<IQueryable<Movie>>().Setup(m => m.Provider).Returns(list.Provider);
                //mockSet.As<IQueryable<Movie>>().Setup(m => m.ElementType).Returns(list.ElementType);
            mockSet.Setup(m => m.Find(It.IsAny<Object>())).Returns(list.First());
            
            //Step 4
            mockContext.Setup(db => db.Movies).Returns(mockSet.Object);

            //Arrange
            MoviesController controller = new MoviesController(mockContext.Object);

            //Act
            RedirectToRouteResult result = controller.DeleteConfirmed(id: 1) as RedirectToRouteResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }
    }
}
