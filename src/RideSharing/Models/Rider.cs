namespace RideSharing;

class Rider
{
    private required string _riderId;
    private required Location _location;
    private Driver[] _driversWithinRadius;

    public Rider(string riderId, int xCoordinate, int yCoordinate) {
        this._riderId = riderId;
        this._location = new Location(xCoordinate, yCoordinate);
    }
}