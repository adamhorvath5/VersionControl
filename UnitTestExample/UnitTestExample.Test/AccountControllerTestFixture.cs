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
            TestCase("abcd", false),
            TestCase("ABCD1234", false),
            TestCase("abcd1234", false),
            TestCase("ab", false),
            TestCase("AbCd1234", true)
            ]
        public void TestValidatePassword(string password, bool expectedResult)
        {
            var acController = new Controllers.AccountController();
            var actualResult = acController.ValidatePassword(password);
            Assert.AreEqual(expectedResult, actualResult);
        }



    }
}
