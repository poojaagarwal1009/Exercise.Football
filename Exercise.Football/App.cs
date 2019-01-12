using Exercise.Football.Model;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Serilog;
using System;
using Exercise.Football.Services.Interface;

namespace Exercise.Football
{
    public class App
    {
        private readonly ILogger _logger;
        private readonly IValidator _validator;
        private readonly IMapper _mapper;

        public App(ILogger logger, IValidator validator, IMapper mapper)
        {
            _logger = logger;
            _validator = validator;
            _mapper = mapper;
        }

        public void Run(string filePath)
        {
            try
            {
                var teams = new List<FootballTeam>();

                if (_validator.ValidateCsvFile(filePath))
                {
                    foreach (string eachRow in File.ReadLines(filePath).Skip(1))
                    {
                        if (_validator.ValidateColumnCount(eachRow))
                        {
                            FootballTeam eachFootballTeam = _mapper.FootballTeamMapper(eachRow, _validator);
                            _logger.Information($"{eachFootballTeam.TeamName}: {eachFootballTeam.Difference}");
                            teams.Add(eachFootballTeam);
                        }
                    }

                }
                if (teams.Count > 0)
                {
                    var sortedList = teams.OrderBy(o => o.PositiveDifference);
                    var smallestDifferenceTeam = sortedList.First();
                    _logger.Information(
                        $"And the team with the smallest difference of {smallestDifferenceTeam.PositiveDifference} is {smallestDifferenceTeam.TeamName}");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Oops! something went wrong.");
            }
            Log.CloseAndFlush();
            //Console.ReadKey();
        }
    }
}
