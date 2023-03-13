using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prasitestavimui
{
    public class MainTestClases
    {
        [Test]
        public static int AddNumbers(int a, int b)
        {
            int suma = AddNumbers(10, 20);
            return a + b; }
    }
}

   