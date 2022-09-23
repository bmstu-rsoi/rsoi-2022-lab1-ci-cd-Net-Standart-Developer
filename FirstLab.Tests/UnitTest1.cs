using firstlab.Controllers;
using firstlab.Models;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstLab.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TestGetAllPersons()
        {
            var controller = new PersonController(new DB());

            var result = controller.GetPersons();

            Assert.NotNull(result);
            Assert.Equal(result.Count(), new DB().Persons.Count());
        }

        [Fact]
        public void TestGetPerson()
        {
            var controller = new PersonController(new DB());

            var result = controller.GetPerson(-1);

            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void TestCreatePerson()
        {
            var controller = new PersonController(new DB());

            var result = controller.CreatePerson(new Person() { Age = 18, Name = "Bob"});

            Assert.IsType<CreatedResult>(result);
        }

        [Fact]
        public void TestUpdatePerson()
        {
            var controller = new PersonController(new DB());

            var result = controller.UpdatePerson(0,new Person() {  Age = 18, Name = "Bob" });

            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void TestDeletePerson()
        {
            DB db = new DB();
            
            var controller = new PersonController(db);

            db.Persons.Add(new Person() { Id = 111, Name = "Tom", Age = 18 });
            db.SaveChanges();
            var result = controller.DeletePerson(111);

            Assert.IsType<NoContentResult>(result);
        }
    }
}