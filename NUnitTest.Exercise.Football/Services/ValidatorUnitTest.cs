using System;
using System.IO;
using Exercise.Football.Services;
using Exercise.Football.Services.Interface;
using NUnit.Framework;
using Serilog;

namespace NUnitTest.Exercise.Football.UnitTest.Interface.Implement
{
    [TestFixture]
    public class ValidatorUnitTest
    {
        private readonly IValidator _validator;
        private readonly ILogger _logger;
        public ValidatorUnitTest()
        {
            _logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
            _validator = new Validator(_logger);
        }

        #region ValidateCsvFile
        [TestCase("football.txt")]
        [TestCase("football.dat")]
        [TestCase("empty_football.csv")]
        public void ReturnFalseWhenTheFileIsNotValid(string value)
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, value);

            var result = _validator.ValidateCsvFile(filePath);

            Assert.IsFalse(result);
        }

        [TestCase("football.csv")]
        public void ReturnTrueWhenTheFileIsValid(string value)
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, value);

            var result = _validator.ValidateCsvFile(filePath);

            Assert.IsTrue(result);
        }
        #endregion

        #region ValidateColumnCount

        [TestCase("frfgerger")]
        public void ReturnFalseForInvalidColumns(string value)
        {
            var result = _validator.ValidateColumnCount(value);

            Assert.IsFalse(result);
        }

        [TestCase("avc,kjshd,kajsdh,cadc,dsdf,csd,wfewe,cef,ef")]
        public void ReturnTrueWhenValidColumnCount(string value)
        {
            var result = _validator.ValidateColumnCount(value);

            Assert.IsTrue(result);
        }
        #endregion

        #region ValidateIsNumeric
        [TestCase(null)]
        [TestCase("")]
        [TestCase("          ")]
        [TestCase("test")]
        [TestCase("49.456")]
        public void ReturnFalseWhenTheGivenValueNotNumeric(string value)
        {
            var result = _validator.IsNumeric(value);

            Assert.IsFalse(result);
        }

        [TestCase("1")]
        [TestCase("-1")]
        [TestCase("0")]
        public void ReturnTrueWhenTheGivenValueIsNumeric(string value)
        {
            var result = _validator.IsNumeric(value);

            Assert.IsTrue(result);
        } 
        #endregion
    }
}
