using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;

namespace RecourceCloud.Tests
{
    public class Tests
    {

        [Test]
        public void DepartamenCloudInitialization()
        {
            DepartmentCloud departmentCloud = new DepartmentCloud();

            Assert.That(departmentCloud, Is.Not.Null);
            Assert.That(departmentCloud.Resources, Is.Not.Null);
            Assert.That(departmentCloud.Tasks, Is.Not.Null);    
            Assert.That(departmentCloud.Resources.Count, Is.EqualTo(0));
            Assert.That(departmentCloud.Tasks.Count, Is.EqualTo(0));
        }    
        
        [Test]
        public void LogTaskMethod_WorksNormally()
        {
            DepartmentCloud departmentCloud = new DepartmentCloud();
            string[] arguments= new string[] {"1", "2","3"};    

            string result=departmentCloud.LogTask(arguments);

            Assert.That(result, Is.EqualTo("Task logged successfully."));
            Assert.That(departmentCloud.Tasks.Count, Is.EqualTo(1));
        }     
        
        [Test]
        public void LogTaskMethod_ThrowsException_WhenArgumensAreMoreOrLessThatThree()
        {
            DepartmentCloud departmentCloud = new DepartmentCloud();
            string[] arguments= new string[] {"1", "2"};    

            var exception=Assert.Throws<ArgumentException>(()=>departmentCloud.LogTask(arguments));

            Assert.That(exception.Message, Is.EqualTo("All arguments are required."));

            string[] argumentsTwo = new string[] { "1", "2", "3", "4" };
            Assert.Throws<ArgumentException>(() => departmentCloud.LogTask(argumentsTwo));
        }     


        [Test]
        public void LogTaskMethod_ThrowsException_WhenArgumensAreNull()
        {
            DepartmentCloud departmentCloud = new DepartmentCloud();
            string[] arguments= new string[] {"1", "2", null};    

            var exception=Assert.Throws<ArgumentException>(()=>departmentCloud.LogTask(arguments));

            Assert.That(exception.Message, Is.EqualTo("Arguments values cannot be null."));

        }

        [Test]
        public void LogTaskMethod_RetursMessage_WhereIsAlreadyLogged()
        {
            DepartmentCloud departmentCloud = new DepartmentCloud();
            string[] arguments = new string[] { "1", "2", "3" };

            string result = departmentCloud.LogTask(arguments);
            string[] argumentsTwo = new string[] { "1", "2", "3" };

            string resultTwo = departmentCloud.LogTask(arguments);

            Assert.That(result, Is.EqualTo("Task logged successfully."));
            Assert.That(departmentCloud.Tasks.Count, Is.EqualTo(1));

            Assert.That(resultTwo, Is.EqualTo("3 is already logged."));
            Assert.That(departmentCloud.Tasks.Count, Is.EqualTo(1));
        }

        [Test]
        public void LogTaskMethod_ThrowsExceptionOutRange()
        {
            DepartmentCloud departmentCloud = new DepartmentCloud();
            string[] arguments = new string[] { "ivan", "2", "3" };

            Assert.Throws<System.FormatException>(() => departmentCloud.LogTask(arguments));

        }

        [Test]
        public void CreateResourceMethod_WorksNormalyReturnsTrue()
        {
            DepartmentCloud departmentCloud = new DepartmentCloud();
            string[] arguments = new string[] { "1", "2", "3" };

            string result = departmentCloud.LogTask(arguments);
            Assert.That(departmentCloud.Tasks.Count, Is.EqualTo(1));

            bool isValid =departmentCloud.CreateResource();
            Assert.That(departmentCloud.Resources.Count, Is.EqualTo(1));
            Assert.That(departmentCloud.Tasks.Count, Is.EqualTo(0));
            Assert.That(isValid, Is.True);

   

        }

        [Test]
        public void CreateResourceMethod_WorksNormalyReturnsFalse()
        {
            DepartmentCloud departmentCloud = new DepartmentCloud();

            bool isValid=departmentCloud.CreateResource();
            Assert.That(isValid, Is.False);

        }

        [Test]
        public void TestResourceMethod_WorksNormaly()
        {
            DepartmentCloud departmentCloud = new DepartmentCloud();
            string[] arguments = new string[] { "1", "2", "3" };

            string result = departmentCloud.LogTask(arguments);

            bool isValid = departmentCloud.CreateResource();
            Assert.That(isValid, Is.True);

            Resource resourceResult= departmentCloud.TestResource("3");

            Assert.That(resourceResult,Is.Not.Null);
            Assert.That(resourceResult.IsTested,Is.True);
            Assert.That(resourceResult.Name, Is.EqualTo("3"));
            Assert.That(resourceResult.ResourceType, Is.EqualTo("2"));


        }

        [Test]
        public void TestResourceMethod_ReturnNull()
        {
            DepartmentCloud departmentCloud = new DepartmentCloud();
            string[] arguments = new string[] { "1", "2", "3" };

            string result = departmentCloud.LogTask(arguments);

            bool isValid = departmentCloud.CreateResource();
            Assert.That(isValid, Is.True);

            Resource resourceResult= departmentCloud.TestResource("1");

            Assert.That(resourceResult,Is.Null);



        }

        [Test]
        public void TestResourceMethod_ReturnNull_WhenDireclyIsGiveNull()
        {
            DepartmentCloud departmentCloud = new DepartmentCloud();
            string[] arguments = new string[] { "1", "2", "3" };

            string result = departmentCloud.LogTask(arguments);

            bool isValid = departmentCloud.CreateResource();
            Assert.That(isValid, Is.True);

            Resource resourceResult= departmentCloud.TestResource(null);

            Assert.That(resourceResult,Is.Null);



        }
    }
}