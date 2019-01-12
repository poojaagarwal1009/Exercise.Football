namespace Exercise.Football.Model
{
    public class FootballTeam
    {
        public string TeamName { get; set; }

        public int Played { get; set; }

        public int Won { get; set; }

        public int Lost { get; set; }

        public int Draw { get; set; }

        public int ForGoal { get; set; }

        public int AgainstGoal{ get; set; }

        public int Difference => ForGoal - AgainstGoal;

        public int PositiveDifference => Difference > 0 ? Difference : -Difference;
    }
}
