using MedicalEquipmentCompany.Model.Result;
using System;
using System.Collections.Generic;

public class Statistic : Entity
{
    // Prosečna ocena kompanije
    public double AverageCompanyRating { get; set; }

    // Grafički prikaz termina
    public GraphData MonthlyTermGraph { get; set; }
    public GraphData QuarterlyTermGraph { get; set; }
    public GraphData AnnualTermGraph { get; set; }

    // Grafički prikaz rezervacija medicinske opreme
    public GraphData MonthlyReservationGraph { get; set; }
    public GraphData QuarterlyReservationGraph { get; set; }
    public GraphData AnnualReservationGraph { get; set; }

    // Prihodi kompanije
    public RevenueData CompanyRevenue { get; set; }

    public Statistic()
    {
        // Inicijalizacija potrebnih podataka
        AverageCompanyRating = 0.0;
        MonthlyTermGraph = new GraphData();
        QuarterlyTermGraph = new GraphData();
        AnnualTermGraph = new GraphData();
        MonthlyReservationGraph = new GraphData();
        QuarterlyReservationGraph = new GraphData();
        AnnualReservationGraph = new GraphData();
        CompanyRevenue = new RevenueData();
    }
}

public class GraphData : Entity
{
    public List<int> Labels { get; set; }
    public List<int> Data { get; set; }

    public GraphData()
    {
        Labels = new List<int>();
        Data = new List<int>();
    }
}

public class RevenueData : Entity
{
    public List<DateTime> Dates { get; set; }
    public List<decimal> Amounts { get; set; }

    public RevenueData()
    {
        Dates = new List<DateTime>();
        Amounts = new List<decimal>();
    }
}
