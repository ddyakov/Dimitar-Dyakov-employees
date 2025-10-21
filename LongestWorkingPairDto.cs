namespace PairOfEmployees;

public class LongestWorkingPairDto
{
    public int FirstEmployeeId { get; set; }

    public int SecondEmployeeId { get; set; }

    public int TotalWorkingDays { get; set; }

    public Dictionary<int, int> WorkingDaysPerProject { get; set; } = [];
}
