using Serilog;
using Serilog.Sinks.Graylog;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("GrayLogs setting up ...");
        GrayLogSetup();
        Console.WriteLine("Graylogs settings is completed.");

        Log.Error("Test log error message");
        Log.Error("Test log error message template {TemplateName}", "CustomTemplate" );

        try
        {
            int a = 0;
            int b = 15 / a;
            
        }
        catch (System.Exception ex)
        {
            Log.Error(ex, "An error occureted");
        }

        string stars = new string('*', 20);

        Console.WriteLine($"\n\n{stars} Logs Completed! {stars}");

        Console.ReadLine();
    }

    static void GrayLogSetup()
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Graylog(new GraylogSinkOptions
            {
                Facility = "GrapLogClientApp",
                SerializerSettings = new Newtonsoft.Json.JsonSerializerSettings
                {
                    DateFormatString = "yyyy-MM-dd"
                },
                HostnameOrAddress = "localhost",
                Port = 12201,
                TransportType = Serilog.Sinks.Graylog.Core.Transport.TransportType.Udp
            })
            .CreateLogger();
    }
}