using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Globalization;
using System.IO;
using System.Text;

namespace CSVtoRAC2 {
    class Program {
        static void Main(string[] args) {
            if (args.Length == 0)
            {
                Console.Error.WriteLine("Zum Starten des Programms bitte die Meldedatei auf die .exe ziehen.");
                Console.Error.WriteLine("Beliebige Taste zum Beenden drücken.");
                Console.Read();
                return;
            }
            csvReader csv = new csvReader(args[0]);
            List<headerObject> races = csv.GetRaces();

            string time = DateTime.Now.ToString("HH_mm_ss", CultureInfo.CreateSpecificCulture("de-DE"));
            if (Directory.Exists("RaceFiles"))
            {
                if (!Directory.Exists("Backup"))
                {
                    Directory.CreateDirectory("Backup");
                }
                Directory.Move("RaceFiles", "Backup\\RaceFilesBackup_" + time);
            }
            Directory.CreateDirectory("RaceFiles");

            foreach (var race in races)
            {
                var options = new JsonSerializerOptions { WriteIndented = true, };
                var jsonString = JsonSerializer.Serialize<headerObject>(race, options);
                
                File.WriteAllText("RaceFiles\\" + race.getFilename(), jsonString, Encoding.UTF8);
            }

            csvWriter csvWriter = new csvWriter("startgelder.csv");
            csvWriter.WriteFees(csv.StartingFee, csv.GetCompetitorsCount());
        }
    }
}