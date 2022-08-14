using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;

namespace Chapter03
{
    [TestClass]
    public class Chapter03
    {
        [TestMethod]
        public void PatternMAtching()
        {
            object o = "4";

            if(o is int a)
            {
                Assert.Fail();
            }
            int j = 4;
            if(j is int i)
            {
                i++;
                Assert.AreEqual(4, j);
                Assert.AreEqual(5, i);
            }
        }

        [TestMethod]
        public void TestSwitchExpressions()
        {
            int day = 4;
            var message = day switch
            {
                1 => "Monday",
                2 => "Tuesday",
                3 => "Wednesday",
                4 => "Thursday",
                5 => "Friday",
                6 => "Saturday",
                7 => "Sunday",
                _ => throw new Exception("Out of range")
            };
            Assert.AreEqual("Thursday", message);
        }
        [TestMethod]
        public void LoopList()
        {
            var names = new[] { "Ronaldo", "Siamak", "Afi" };

            foreach(var name in names)
            {
                Console.WriteLine($"{name} has {name.Length} characters");
            }

            IEnumerator e = names.GetEnumerator();

            while (e.MoveNext())
            {
                var name = (string)e.Current;
                Console.WriteLine($"{name} has {name.Length} characters");
            }
        }
        [TestMethod]
        public void ConvertTypes()
        {
            var a = 1.8;
            int b = (int)a;
            int c = Convert.ToInt32(a);
            var d = Math.Round(a, mode: MidpointRounding.AwayFromZero);
            var e = int.Parse("8");
            Assert.AreEqual(1, b);
            Assert.AreEqual(2, c);
            Assert.AreEqual(2, d);
            Assert.AreEqual(8, e);
        }
        [TestMethod]
        [DataRow(null)]
        [DataRow("23")]
        public void ExceptionTest(string? ageString)
        {
            try
            {
                var age = IntConvertor(ageString);
                Assert.AreEqual(int.Parse(ageString), age);
            }
            catch (Exception ex)
            {
                Assert.AreEqual($"{ageString} is not a number", ex.Message);
            }
            
        }
        private int? IntConvertor(string age)
        {
            if(int.TryParse(age, out int ageInt))
            {
                return ageInt;
            }
            else
            {
                throw new Exception($"{age} is not a number");
            }
        }
    }
}