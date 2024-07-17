/*add the libraries needed*/
using System;
using System.IO;
using PdfSharp.Pdf;

/*create a class to hold the data for each flight*/
public class FlightPlanData {
    public string Date { get; set; }
    public string AircraftRegistration { get; set; }
    public string Route { get; set; }
    public string AlternateAirdrome1 { get; set; }
    public string AlternateAirdrome2 { get; set; }
    public string FlightNumber { get; set; }
    public string ATCCallSign { get; set; }
    public string DepartureTime { get; set; }
    public string ArrivalTime { get; set; }
    public string ZeroFuelMass { get; set; }
    public string TimeToDestination { get; set; }
    public string FuelToDestination { get; set; }
    public string TimeToAlternate { get; set; }
    public string FuelToAlternate { get; set; }
    public string MinimumFuelRequired { get; set; }
    public string RouteFirstAndLastNavigationPoint { get; set; }
    public string GainLoss { get; set; }
}

public class CrewBriefingData {
    /* create a class to hold the data for each crew briefing */
    public int BusinessClassPassengers { get; set; }
    public int EconomyClassPassengers { get; set; }
    public int DryOperatingWeight { get; set; }
    public double DryOperatingIndex { get; set; }
    public string[] CrewAndFunctions { get; set; }
}