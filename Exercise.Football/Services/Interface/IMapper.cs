using Exercise.Football.Model;

namespace Exercise.Football.Services.Interface
{
    /// <summary>
    /// IMapper Interface
    /// </summary>
    public interface IMapper
    {
        /// <summary>
        /// Maps the given row into FootballTeam
        /// </summary>
        /// <param name="row">row</param>
        /// <param name="validator">validator</param>
        /// <returns>FootballTeam</returns>
        FootballTeam FootballTeamMapper(string row, IValidator validator);
    }
}
