using AutoFinalTaskCS.Page;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFinalTaskCS.Test
{
    public class AccountTest : BaseTest
    {
        private readonly AccountPage accountPage = null!;

        [Test]
        public void TestRegister()
        {
            accountPage.Register();
        }
    }
}
