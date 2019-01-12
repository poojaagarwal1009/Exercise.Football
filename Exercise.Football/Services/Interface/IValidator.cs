namespace Exercise.Football.Services.Interface
{
    /// <summary>
    /// The validator
    /// </summary>
    public interface IValidator
    {
        /// <summary>
        /// Validates the csv file
        /// </summary>
        /// <param name="filePath">filepath</param>
        /// <returns>bool</returns>
        bool ValidateCsvFile(string filePath);

        /// <summary>
        /// Validates the number of column in a row
        /// </summary>
        /// <param name="eachRow">each row</param>
        /// <returns>bool</returns>
        bool ValidateColumnCount(string eachRow);

        /// <summary>
        /// Checks if the value is numeric
        /// </summary>
        /// <param name="value">value</param>
        /// <returns>bool</returns>
        bool IsNumeric(string value);
    }
}
