using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSVtoRAC2
{
    public class csvReader
    {
        private List<headerObject> races;
        private List<string[]> data;

        public csvReader (string filename)
        {
            this.races = new List<headerObject>();
            this.data = new List<string[]>();
            string[] lines = File.ReadAllLines(filename, Encoding.Latin1);

            foreach (var line in lines)
            {
                data.Add(line.Split(";"));
            }

            string event_name = data[0][0];
            int i = 4;

            while (i < data.Count)
            {
                int racenumber = Int32.Parse(data[i][0]);
                string name_long = $"Rennen {racenumber} {data[i][1]} Abt. ";
                string name_short = $"Re{racenumber}_{data[i][2]}_";
                int duration = Int32.Parse(data[i][3]);
                
                i += 1;
                int heatNumber = 1;
                
                while (i < data.Count && Int32.Parse(data[i][0]) == racenumber)
                {
                    race_definition rd = new race_definition(
                        name_long+heatNumber, 
                        name_short+heatNumber, 
                        event_name, duration, 
                        racenumber.ToString());
                    
                    int laneNumber = 1;
                    while (i < data.Count && data[i][0] != "")
                    {
                        rd.addBoat(new boat(
                            laneNumber, 
                            $"{data[i][2]} {data[i][1]} ({data[i][4]})", 
                            racenumber.ToString()));
                        laneNumber += 1;
                        i += 1;
                    }
                    races.Add(new headerObject(rd));
                    i += 1;
                    heatNumber += 1;
                }
            }
        }

        public List<headerObject> GetRaces ()
        {
            return races;
        }
    }
}