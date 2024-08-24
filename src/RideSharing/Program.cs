namespace RideSharing;

class Program
{
    private const string CommandDelimiter = " ";
    static void Main(string[] args)
    {
        try
        {
            var inputFilePath = args[0];

            if(File.Exists(inputFilePath))
            {
                var rideService = new RideService();
                var sr = new StreamReader(inputFilePath);
                var line = sr.ReadLine();

                while (line != null)
                {
                    var commandParts = line.Split(
                        CommandDelimiter,
                        2,
                        StringSplitOptions.RemoveEmptyEntries |
                        StringSplitOptions.TrimEntries
                    );
                    
                    if (commandParts.Length != 0
                        && Enum.TryParse(commandParts[0], out Command command))
                    {
                        var commandArgs = commandParts[1].Split(
                            CommandDelimiter,
                            StringSplitOptions.RemoveEmptyEntries |
                            StringSplitOptions.TrimEntries
                        );
                        switch (command)
                        {
                            case Command.ADD_DRIVER:
                                rideService.AddDriver(
                                    commandArgs[0],
                                    int.Parse(commandArgs[1]),
                                    int.Parse(commandArgs[2])
                                );
                                break;
                            case Command.ADD_RIDER:
                                rideService.AddRider(
                                    commandArgs[0],
                                    int.Parse(commandArgs[1]),
                                    int.Parse(commandArgs[2])
                                );
                                break;
                            case Command.MATCH:
                                rideService.Match(
                                    commandArgs[0]
                                );
                                break;
                            case Command.START_RIDE:
                                rideService.StartRide(
                                    commandArgs[0],
                                    int.Parse(commandArgs[1]),
                                    commandArgs[2]
                                );
                                break;
                            case Command.STOP_RIDE:
                                rideService.StopRide(
                                    commandArgs[0],
                                    int.Parse(commandArgs[1]),
                                    int.Parse(commandArgs[2]),
                                    int.Parse(commandArgs[3])

                                );
                                break;
                            case Command.BILL:
                                rideService.GenerateBill(
                                    commandArgs[0]
                                );
                                break;
                        }
                    }
                    
                    // Read next command
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            else
            {
                Console.WriteLine("INPUT_FILE_NOT_FOUND");
            }
        }
        catch(Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
    }
}