public class StatisticDto
{
    // Prosečna ocena kompanije
    public double AverageCompanyRating { get; set; }

    // Grafički prikaz termina
    public GraphDataDto MonthlyTermGraph { get; set; }
    public GraphDataDto QuarterlyTermGraph { get; set; }
    public GraphDataDto AnnualTermGraph { get; set; }

    // Grafički prikaz rezervacija medicinske opreme
    public GraphDataDto MonthlyReservationGraph { get; set; }
    public GraphDataDto QuarterlyReservationGraph { get; set; }
    public GraphDataDto AnnualReservationGraph { get; set; }

    // Prihodi kompanije
    public RevenueDataDto CompanyRevenue { get; set; }
}

public class GraphDataDto
{
    public List<int> Labels { get; set; }
    public List<int> Data { get; set; }
}

public class RevenueDataDto
{
    public List<DateTime> Dates { get; set; }
    public List<decimal> Amounts { get; set; }
}
