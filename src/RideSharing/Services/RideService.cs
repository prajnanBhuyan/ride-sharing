namespace RideSharing;

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

class RideService
{
    #region Constants
    // Match riders with drivers within a 5km range
    private const double MaxDriverDistance = 5.00;
    // Number of drivers to match with
    private const int MaxDriversToMatch  = 5;
    #endregion

    #region State Variables
    private readonly Dictionary<string, Driver> _drivers = [];
    private readonly Dictionary<string, Rider> _riders = [];
    private readonly Dictionary<string, Ride> _rides = [];
    #endregion

    // ADD_DRIVER
    public void AddDriver(string driverId, int xCoordinate, int yCoordinate)
    {
        _drivers[driverId] = new()
        {
            DriverId = driverId,
            Location = new()
            {
                XCoordinate = xCoordinate,
                YCoordinate = yCoordinate
            },
            IsAvailable = true
        };
    }

    // ADD_RIDER
    public void AddRider(string riderId, int xCoordinate, int yCoordinate)
    {
        _riders[riderId] = new()
        {
            RiderId = riderId,
            Location = new()
            {
                XCoordinate = xCoordinate,
                YCoordinate = yCoordinate
            } 
        };
    }

    // MATCH
    public void Match(string riderId)
    {
        try
        {
            if (_riders.TryGetValue(riderId, out Rider? rider))
            {
                var driversMatched = _drivers.Values
                    .Where(d => d.IsAvailable)
                    .Select(d => new {
                        d.DriverId,
                        Distance = d.Location.CalculateDistance(rider.Location),
                        Driver = d
                    })
                    .Where(d => d.Distance <= MaxDriverDistance)
                    .OrderBy(d => d.Distance)
                    .ThenBy(d => d.DriverId)
                    .Take(MaxDriversToMatch)
                    .Select(d => d.Driver)
                    .ToArray();

                if (driversMatched.Length == 0)
                    throw new NoDriversAvailableException();                    
                
                rider.DriversMatched = driversMatched;
                Console.WriteLine($"DRIVERS_MATCHED {string.Join(" ", driversMatched.Select(d => d.DriverId))}");
            }
        }
        catch(NoDriversAvailableException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    // START_RIDE
    public void StartRide(string rideId, int driverChoice, string riderId)
    {
        try
        {
            if (_riders.TryGetValue(riderId, out Rider? rider)
                && rider.DriversMatched is not null)
            {
                if (_rides.ContainsKey(rideId)
                    || driverChoice > rider.DriversMatched.Length
                    || !rider.DriversMatched[driverChoice-1].IsAvailable)
                    throw new InvalidRideException();
                
                var driver = rider.DriversMatched[driverChoice-1];
                var ride = new Ride()
                {
                    RideId = rideId,
                    Rider = rider,
                    Driver = driver
                };
                ride.StartRide();
                _rides[rideId] = ride;
                Console.WriteLine($"RIDE_STARTED {rideId}");
            }
        }
        catch(InvalidRideException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    // STOP_RIDE
    public void StopRide(string rideId, int xCoordinate, int yCoordinate, int timeTakenInMins)
    {
        try
        {
            if (!_rides.TryGetValue(rideId, out Ride? ride)
                || !ride.IsActive)
                throw new InvalidRideException();

            ride.StopRide(
                new Location() {
                    XCoordinate = xCoordinate,
                    YCoordinate = yCoordinate
                },
                timeTakenInMins
            );
            Console.WriteLine($"RIDE_STOPPED {rideId}");            
        }
        catch(InvalidRideException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    // BILL
    public void GenerateBill(string rideId)
    {
        try
        {
            if (!_rides.TryGetValue(rideId, out Ride? ride))
                throw new InvalidRideException();
            else if (ride.IsActive)
                throw new RideNotCompletedException();
            
            var fare = string.Format("{0:0.00}", ride.CalculateFare());            
            Console.WriteLine($"BILL {ride.RideId} {ride.Driver.DriverId} {fare}");
        }
        catch(Exception e) when (
            e is InvalidRideException
            || e is RideNotCompletedException
        )
        {
            Console.WriteLine(e.Message);
        }
    }
}