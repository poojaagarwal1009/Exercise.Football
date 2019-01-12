using Exercise.Football.Model;
using Exercise.Football.Services;
using Exercise.Football.Services.Interface;
using NUnit.Framework;
using Serilog;

namespace NUnitTest.Exercise.Football.Services
{
    class ModelMapperUnitTest
    {
        private readonly IMapper _mapper;
        private readonly IValidator _validator;

        public ModelMapperUnitTest()
        {
            ILogger logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
            _validator = new Validator(logger);
            _mapper = new ModelMapper(logger);
        }

        [TestCase("")]
        [TestCase("dafd,awefawe,wefwef")]
        public void ReturnsNullForInvalidRow(string row)
        {
            var result = _mapper.FootballTeamMapper(row,_validator);

            Assert.IsNull(result);
        }

        [TestCase("Team1,awefawe,wefwef,dwew,wef,qef,qerf,qwefq,wer")]
        public void ReturnsFootballTeamWithZeroForTheGivenRow(string row)
        {
            var result = _mapper.FootballTeamMapper(row, _validator);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<FootballTeam>(result);
            Assert.AreEqual(result.Played,0);
            Assert.AreEqual(result.ForGoal,0);
            Assert.AreEqual(result.AgainstGoal,0);
        }

        [TestCase("Team1,12,12,34,34,4,-,34,2")]
        public void ReturnsFootballTeamWithRightValueForTheGivenRow(string row)
        {
            var result = _mapper.FootballTeamMapper(row, _validator);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<FootballTeam>(result);
            Assert.AreEqual(result.Played, 12);
            Assert.AreEqual(result.ForGoal, 4);
            Assert.AreEqual(result.AgainstGoal, 34);
            Assert.AreEqual(result.PositiveDifference, 30);
        }
    }
}
