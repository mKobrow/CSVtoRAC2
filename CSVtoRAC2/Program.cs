using System;
using System.Text.Json;
using System.Configuration;
using System.IO;

namespace CSVtoRAC2 {
    class Program {
        static void Main(string[] args) {
            boat testboat = new boat(1, "Max Kobrow");
            race_definition testrace = new race_definition("Rennen 1 Senioren A", "Re1 SMA", 
                ConfigurationManager.AppSettings.Get("wettkampfname"),2000 , "1");

            testrace.addBoat(testboat);

            headerObject testobj = new headerObject(testrace);

            var options = new JsonSerializerOptions { WriteIndented = true, };
            var jsonString = JsonSerializer.Serialize<headerObject>(testobj, options);

            // File.WriteAllText("C:\\Users\\Max Kobrow\\RiderProjects\\CSVtoRAC2\\CSVtoRAC2\\test.rac2", jsonString);
            Console.Write(jsonString);
        }
    }
}