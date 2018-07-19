using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Student_Management;
using Models;
using Common;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class Controller
    {
        [TestInitialize]
        public void TestInitialize()
        {
            StudentController studentController = new StudentController();
            IDictionary<string, object> filters = new Dictionary<string, object>();
            foreach (var entity in studentController.Get(filters))
            {
                studentController.Delete(entity.Id);
            }
        }

        [TestMethod]
        public void Controller_CreateOperation_Success()
        {
            StudentController studentController = new StudentController();
            string[] data = { "University", "Leia", "Female", "20151231145934" };
            IEntity entity = EntityFactory.CreateEntity(EntityType.Student, data);
            studentController.Add(entity);

            IDictionary<string, object> filters = new Dictionary<string, object>();
            var count = studentController.Get(filters).Count;

            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void Controller_FilterOperation_Success()
        {
            StudentController studentController = new StudentController();
            string[] data = { "University", "Leia", "Female", "20151231145934" };
            IEntity entity = EntityFactory.CreateEntity(EntityType.Student, data);
            studentController.Add(entity);

            data[1] = "Wilson";
            IEntity entity2 = EntityFactory.CreateEntity(EntityType.Student, data);
            studentController.Add(entity2);

            IDictionary<string, object> filters = new Dictionary<string, object>();
            filters.Add("Name", "Leia");
            var count = studentController.Get(filters).Count;

            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void Controller_SortAlphabetically_Success()
        {
            StudentController studentController = new StudentController();
            string[] data = { "University", "Leia", "Female", "20151231145934" };
            IEntity entity = EntityFactory.CreateEntity(EntityType.Student, data);
            studentController.Add(entity);

            data[1] = "Wilson";
            IEntity entity2 = EntityFactory.CreateEntity(EntityType.Student, data);
            studentController.Add(entity2);

            data[1] = "Ammy";
            IEntity entity3 = EntityFactory.CreateEntity(EntityType.Student, data);
            studentController.Add(entity3);

            IDictionary<string, object> filters = new Dictionary<string, object>();
            var entities = studentController.Get(filters);

            Assert.AreEqual(((Student)(entities[0])).Name, "Ammy");
            Assert.AreEqual(((Student)(entities[1])).Name, "Leia");
            Assert.AreEqual(((Student)(entities[2])).Name, "Wilson");
        }

        [TestMethod]
        public void Controller_SortByDate_Success()
        {
            StudentController studentController = new StudentController();
            string[] data = { "University", "Leia", "Female", "20151231145934" };
            IEntity entity = EntityFactory.CreateEntity(EntityType.Student, data);
            studentController.Add(entity);

            data[1] = "Wilson";
            data[3] = "20181231145934";
            IEntity entity2 = EntityFactory.CreateEntity(EntityType.Student, data);
            studentController.Add(entity2);

            data[1] = "Ammy";
            data[3] = "20121231145934";
            IEntity entity3 = EntityFactory.CreateEntity(EntityType.Student, data);
            studentController.Add(entity3);

            IDictionary<string, object> filters = new Dictionary<string, object>();
            filters.Add("Gender", "F");
            var entities = studentController.Get(filters);

            Assert.AreEqual(((Student)(entities[0])).Name, "Wilson");
            Assert.AreEqual(((Student)(entities[1])).Name, "Leia");
            Assert.AreEqual(((Student)(entities[2])).Name, "Ammy");
        }

        [TestMethod]
        public void Controller_UpdateOperation_Success()
        {
            StudentController studentController = new StudentController();
            string[] data = { "University", "Leia", "Female", "20151231145934" };
            IEntity entity = EntityFactory.CreateEntity(EntityType.Student, data);
            studentController.Add(entity);

            IDictionary<string, object> filters = new Dictionary<string, object>();
            var createdEntity = studentController.Get(filters)[0];
            ((Student)createdEntity).Name = "Updated";
            studentController.Update(createdEntity.Id, createdEntity);

            var updatedEntity = studentController.Get(filters)[0];

            Assert.AreEqual(((Student)(updatedEntity)).Name, "Updated");
        }


        [TestMethod]
        public void Controller_DeleteOperation_Success()
        {
            StudentController studentController = new StudentController();
            string[] data = { "University", "Leia", "Female", "20151231145934" };
            IEntity entity = EntityFactory.CreateEntity(EntityType.Student, data);
            studentController.Add(entity);

            IDictionary<string, object> filters = new Dictionary<string, object>();
            var createdEntity = studentController.Get(filters)[0];
            studentController.Delete(createdEntity.Id);

            var count = studentController.Get(filters).Count;

            Assert.AreEqual(count, 0);
        }
    }
}
