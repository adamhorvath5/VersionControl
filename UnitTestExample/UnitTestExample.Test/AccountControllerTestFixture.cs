using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UnitTestExample.Test
{
    public class AccountControllerTestFixture
    {
        [Test]
        private void TestValidateEmail(string email, bool expectedResult)
        {
            var acController = new Controllers.AccountController();
            var actualResult = acController.ValidateEmail(email);
            Assert.AreEqual(expectedResult, actualResult);
        }


    }
}
