using System;
using System.IO;
using Exercise.Football;
using Exercise.Football.Services;
using NUnit.Framework;
using Serilog;

namespace NUnitTest.Exercise.Football
{
    internal class AppTest
    {
        private readonly App _app;

        public AppTest()
        {
            var logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
            var validator = new Validator(logger);
            var mapper = new ModelMapper(logger);
            _app = new App(logger,validator,mapper);
        }

        [TestCase("")]
        [TestCase("/sdgdrg/ergter")]
        public void ShouldFail(string filePath)
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                _app.Run(filePath);
                Assert.IsTrue(sw.ToString().Contains("ERR"));
            }
        }


        [TestCase("football.csv")]
        public void ShouldPass(string value)
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, value);
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                _app.Run(filePath);
                Assert.IsTrue(sw.ToString().Contains("Aston_Villa"));
            }
        }
    }
}
