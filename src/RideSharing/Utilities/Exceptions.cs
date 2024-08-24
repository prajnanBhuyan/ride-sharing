namespace RideSharing;

class NoDriversAvailableException : Exception
{
    private const string _errorMessage = "NO_DRIVERS_AVAILABLE";
    public NoDriversAvailableException(): base(_errorMessage)
    { }    
}

class InvalidRideException : Exception
{
    private const string _errorMessage = "INVALID_RIDE";
    public InvalidRideException(): base(_errorMessage)
    { }    
}

class RideNotCompletedException : Exception
{
    private const string _errorMessage = "RIDE_NOT_COMPLETED";
    public RideNotCompletedException(): base(_errorMessage)
    { }    
}