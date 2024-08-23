using System.Collections;

namespace RideSharing;

class Program
{
    private const string CommandDelimiter = " ";
    static void Main(string[] args)
    {
        try
        {
            // var inputFilePath = args[0];
            var inputFilePath = "D:\\Projects\\ride-sharing\\sample_input\\input1.txt";

            if(File.Exists(inputFilePath))
            {
                var rideService = new RideService();
                var sr = new StreamReader(inputFilePath);
                var line = sr.ReadLine();

                while (line != null)
                {
                    // TODO: Process command
                    var commandParts = line.Split(
                        CommandDelimiter,
                        2,
                        StringSplitOptions.RemoveEmptyEntries |
                        StringSplitOptions.TrimEntries);
                    var command = commandParts[0];
                    var commandArgs = commandParts[1].Split(
                        CommandDelimiter,
                        StringSplitOptions.RemoveEmptyEntries |
                        StringSplitOptions.TrimEntries
                    );
                    switch(commandParts[0])
                    {
                        case "ADD_DRIVER":
                            Console.WriteLine($"arguments: {commandParts[1]}");
                            rideService.AddDriver(
                                commandArgs[0],
                                int.Parse(commandArgs[1]),
                                int.Parse(commandArgs[2])
                            );
                            break;
                        case "ADD_RIDER":
                            Console.WriteLine($"arguments: {commandParts[1]}");
                            break;
                        case "MATCH":
                            Console.WriteLine($"arguments: {commandParts[1]}");
                            break;
                        case "START_RIDE":
                            Console.WriteLine($"arguments: {commandParts[1]}");
                            break;
                        case "STOP_RIDE":
                            Console.WriteLine($"arguments: {commandParts[1]}");
                            break;
                        case "BILL":
                            Console.WriteLine($"arguments: {commandParts[1]}");
                            break;
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
        finally
        {
            Console.WriteLine("Executing finally block.");
        }
    }
}