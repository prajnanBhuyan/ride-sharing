namespace RideSharing;

class Location
{
    public required int XCoordinate {get; init; }
    public required int YCoordinate {get; init; }

    public double CalculateDistance(Location other)
    {
        return Math.Sqrt(
            Math.Pow(other.XCoordinate - XCoordinate, 2) +
            Math.Pow(other.YCoordinate - YCoordinate, 2)
        );
    }
}