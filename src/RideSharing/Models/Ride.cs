namespace RideSharing;

class Ride
{
    public Ride
    {
        private required string _rideId;
        private required Rider _rider;
        private required Driver _driver;
        private required Location _startLocation;
        private required Location _destination;
        private required int _timeTakenInMins;

    }
}