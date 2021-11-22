using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSVtoRAC2
{
    public class csvWriter
    {
        private string filename;
        
        public csvWriter(string filename)
        {
            this.filename = filename;
        }

        public void WriteFees(int fee, Dictionary<string, int> competitorsCount)
        {
            List<string> lines = new List<string>();
            lines.Add("Verein;Anzahl Sportler;Startgeld");
            foreach (var count in competitorsCount)
            {
                lines.Add($"{count.Key};{count.Value};{count.Value*fee}€");
            }
            
            File.WriteAllLines(filename, lines, Encoding.UTF8);
        }
    }
}