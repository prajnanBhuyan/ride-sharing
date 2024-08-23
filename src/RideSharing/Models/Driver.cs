namespace RideSharing;

class Driver
{
    private required string _driverId;
    private required Location _location;
    private bool _isAvailable;

    public Driver(string driverId, int xCoordinate, int yCoordinate) {
        this._driverId = driverId;
        this._location = new Location(xCoordinate, yCoordinate);
    }
}