using Exercise.Football.Model;
using Exercise.Football.Services.Interface;
using Serilog;

namespace Exercise.Football.Services
{
    public class ModelMapper : IMapper
    {
        private readonly ILogger _logger;

        public ModelMapper(ILogger logger)
        {
            _logger = logger;
        }
        /// <inheritdoc />
        public FootballTeam FootballTeamMapper(string row, IValidator validator)
        {
            if (!validator.ValidateColumnCount(row))
            {
                _logger.Error("Given row does not have the required columns");
                return null;
            }

            var columns = row.Split(",");
            return new FootballTeam
            {
                TeamName = columns[0].Substring(columns[0].IndexOf('.') + 2),
                Played = validator.IsNumeric(columns[1]) ? int.Parse(columns[1]) : 0,
                Won = validator.IsNumeric(columns[2]) ? int.Parse(columns[2]) : 0,
                Lost = validator.IsNumeric(columns[3]) ? int.Parse(columns[3]) : 0,
                Draw = validator.IsNumeric(columns[4]) ? int.Parse(columns[4]) : 0,
                ForGoal = validator.IsNumeric(columns[5]) ? int.Parse(columns[5]) : 0,
                AgainstGoal = validator.IsNumeric(columns[7]) ? int.Parse(columns[7]) : 0
            };
        }
    }
}
