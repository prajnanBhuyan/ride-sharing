using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;

namespace RideSharing;

class RideService
{
    #region Enums
    enum Command {        
        ADD_DRIVER,
        ADD_RIDER,
        MATCH,
        START_RIDE,
        STOP_RIDE,
        BILL
    }
    #endregion

    #region Constants
    // Match riders with drivers within a 5km range
    private const double MaxDriverDistance = 5.00;
    // A base fare of ₹50 is charged for every ride. 
    private const double BaseFare = 50.00;
    //  An additional ₹6.5 is charged for every kilometer traveled. 
    private const double FarePerKm = 6.50;
    //  An additional ₹2 is charged for every minute spent in the ride. 
    private const double FarePerMin = 2.00;
    //  A service tax of 20% is added to the final amount.
    private const double ServiceTaxRate = 0.2;
    #endregion

    #region State Variables
    private readonly Dictionary<string, Driver> _drivers = new();
    private readonly Dictionary<string, Rider> _riders = new();
    private readonly Dictionary<string, Ride> _rides = new();
    #endregion

    // ADD_DRIVER
    public void AddDriver(string driverId, int xCoordinate, int yCoordinate)
    {
        _drivers[driverId] = new Driver(
            driverId,
            xCoordinate,
            yCoordinate
        );
    }

    // ADD_RIDER
    public void AddRider(string riderId, int xCoordinate, int yCoordinate)
    {
        _riders[riderId] = new Rider(
            riderId,
            xCoordinate,
            yCoordinate
        );
    }

    // MATCH
    public void Match(string riderId)
    {
        throw new NotImplementedException();
    }

    // START_RIDE
    public void StartRide(string rideId, int driverChoice, string riderId)
    {
        throw new NotImplementedException();
    }

    // STOP_RIDE
    public void StopRide(string rideId, int xCoordinate, int yCoordinate, int timeTaken)
    {
        throw new NotImplementedException();
    }

    // BILL
    public void GenerateBill(string rideId)
    {
        throw new NotImplementedException();
    }
}