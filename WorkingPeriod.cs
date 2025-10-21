namespace PairOfEmployees;

public record struct WorkingPeriod(DateOnly DateFrom, DateOnly DateTo)
{
    public static implicit operator (DateOnly DateFrom, DateOnly DateTo)(WorkingPeriod value) 
        => (value.DateFrom, value.DateFrom);

    public static implicit operator WorkingPeriod((DateOnly dateFrom, DateOnly dateTo) value) 
        => new(value.dateFrom, value.dateTo);
}
