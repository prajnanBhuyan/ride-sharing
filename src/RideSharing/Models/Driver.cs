namespace RideSharing;

class Driver
{
    public required string DriverId { get; init; }
    public required Location Location { get; init; }
    public required bool IsAvailable { get; set; }
}