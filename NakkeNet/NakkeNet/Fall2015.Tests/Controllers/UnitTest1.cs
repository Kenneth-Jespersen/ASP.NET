using System;
using NakkeNet.Controllers;
using NakkeNet.Models;
using NakkeNet.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace NakkeNet.Tests.Controllers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Mock<IUsersRepository> mockRepo = new Mock<IUsersRepository>();
            Mock<IEmailer> fakeEmailer = new Mock<IEmailer>();
            Mock<ICompetencyHeadersRepository> fakeComp = new Mock<ICompetencyHeadersRepository>();

            UsersController controller = new UsersController(mockRepo.Object, fakeComp.Object, fakeEmailer.Object);

            User s = new User
            {
                Firstname = "Daniel",
                Lastname = "Something"
            };
            controller.Create(s, null, null);

            mockRepo.Verify(a => a.InsertOrUpdate(s));
            mockRepo.Verify(a => a.Save());
        }
    }
}
