namespace RideSharing;

class Rider
{
    public required string RiderId { get; init; }
    public required Location Location { get; init; }
    public Driver[]? DriversMatched { get; set; }
}