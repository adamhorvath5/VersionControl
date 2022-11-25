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
        [Test,
         TestCase("abcd1234", false),
         TestCase("irf@uni-corvinus", false),
         TestCase("irf.uni-corvinus.hu",false),
         TestCase("irf@uni-corvinus.hu", true)
        ]
        public void TestValidateEmail(string email, bool expectedResult)
        {
            var acController = new Controllers.AccountController();
            var actualResult = acController.ValidateEmail(email);
            Assert.AreEqual(expectedResult, actualResult);
        }


        [Test,
            TestCase("abcdefgh", false),
            TestCase("ABCD1234", false),
            TestCase("abcd1234", false),
            TestCase("abcd", false),
            TestCase("AbCd1234", true)
            ]
        public void TestValidatePassword(string password, bool expectedResult)
        {
            var acController = new Controllers.AccountController();
            var actualResult = acController.ValidatePassword(password);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [
        Test,
        TestCase("irf@uni-corvinus.hu", "Abcd1234"),
        TestCase("irf@uni-corvinus.hu", "Abcd1234567"),
]
        public void TestRegisterHappyPath(string email, string password)
        {
            // Arrange
            var accountController = new Controllers.AccountController();

            // Act
            var actualResult = accountController.Register(email, password);

            // Assert
            Assert.AreEqual(email, actualResult.Email);
            Assert.AreEqual(password, actualResult.Password);
            Assert.AreNotEqual(Guid.Empty, actualResult.ID);
        }


    }
}
