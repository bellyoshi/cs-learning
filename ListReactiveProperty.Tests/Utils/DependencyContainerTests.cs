using NUnit.Framework;
using ListReactiveProperty.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListReactiveProperty.Utils.Tests
{
    [TestFixture()]
    public class DependencyContainerTests
    {
        public class MyClass
        {
            public string Value { get; }

            public MyClass(string value)
            {
                Value = value;
            }

            public string DisplayValue()
            {
                return Value;
            }
        }
        [Test()]
        public void RegisterInstanceTest()
        {
            var container = new DependencyContainer();
            container.RegisterInstance(new MyClass("Hello"));

            // 必要な場所でインスタンスを取得
            var myClassInstance = container.GetInstance<MyClass>();
            Assert.That(myClassInstance.DisplayValue(), Is.EqualTo("Hello"));
        }
    }
}