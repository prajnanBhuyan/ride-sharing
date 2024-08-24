namespace RideSharing;

class Ride
{
    #region Constants
    // A base fare of ₹50 is charged for every ride. 
    private const double BaseFare = 50.00;
    //  An additional ₹6.5 is charged for every kilometer traveled. 
    private const double FarePerKm = 6.50;
    //  An additional ₹2 is charged for every minute spent in the ride. 
    private const double FarePerMin = 2.00;
    //  A service tax of 20% is added to the final amount.
    private const double ServiceTaxRate = 0.2;
    #endregion

    private double _distance;
    private int _timeTakenInMins;
    private bool _isActive;

    public required string RideId { get; init; }
    public required Rider Rider { get; init; }
    public required Driver Driver { get; init; }
    public bool IsActive { get {return _isActive;} }

    public double CalculateFare()
    {
        var distanceFare = _distance * FarePerKm;
        var timeFare = _timeTakenInMins * FarePerMin;
        var totalFare = BaseFare + distanceFare + timeFare;
        var serviceTax = totalFare * ServiceTaxRate;
        return Math.Round(totalFare + serviceTax, 2);
    }

    public void StartRide()
    {
        Driver.IsAvailable = false;
        _isActive = true;
    }

    public void StopRide(Location destination, int timeTakenInMins)
    {
        Driver.IsAvailable = true;
        _isActive = false;
        _timeTakenInMins = timeTakenInMins;
        _distance = Math.Round(destination.CalculateDistance(Rider.Location), 2);
    }

}