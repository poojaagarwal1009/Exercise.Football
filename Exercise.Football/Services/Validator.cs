using System;
using System.IO;
using Exercise.Football.Services.Interface;
using Serilog;

namespace Exercise.Football.Services
{
    public class Validator : IValidator
    {
        private readonly ILogger _logger;

        public Validator(ILogger logger)
        {
            _logger = logger;
        }

        /// <inheritdoc />
        public bool ValidateCsvFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                _logger.Error("Can not find the specified file");
                return false;
            }

            string fileExtension = Path.GetExtension(filePath);
            if (!".csv".Equals(fileExtension, StringComparison.OrdinalIgnoreCase))
            {
                _logger.Error("Please give a .csv file");
                return false;
            }

            string fileName = Path.GetFileName(filePath);
            FileInfo file = new FileInfo(fileName);
            if (file.Length < 0)
            {
                _logger.Error("File doesn't contain any data");
                return false;
            }

            return true;
        }

        /// <inheritdoc />
        public bool ValidateColumnCount(string eachRow)
        {
            string[] columns = eachRow.Split(',');

            return columns.Length == 9;
        }

        /// <inheritdoc />
        public bool IsNumeric(string value)
        {
            if (!String.IsNullOrWhiteSpace(value))
            {
                return Int32.TryParse(value, out _);
            }

            return false;
        }
    }
}
