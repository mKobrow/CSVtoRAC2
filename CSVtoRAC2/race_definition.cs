using System.Collections.Generic;

namespace CSVtoRAC2
{
    public class race_definition
    {
        public string name_long {get; set;}
        public string name_short {get; set;}
        public string event_name {get; set;}
        public string duration_type {get; set;}
        public int duration {get; set;}
        public string race_type  {get; set;}
        public string race_id {get; set;}
        public int split_value {get; set;}
        public int team_size {get; set;}
        public int time_cap {get; set;}
        public List<boat> boats {get; set;}
        public race_definition (string name_long, string name_short, string? event_name, int duration, string race_id) {
            this.name_long = name_long;
            this.name_short = name_short;

            if (event_name == null) {
                this.event_name = "";
            } else {
                this.event_name = event_name;
            }
            
            this.duration_type = "meters";
            this.duration = duration;
            this.race_type = "individual";
            this.race_id = race_id;
            this.split_value = 500;
            this.team_size = 1;
            this.time_cap = 0;
            this.boats = new List<boat>();
        }

        public void addBoat (boat boat) {
            this.boats.Add(boat);
        }
    }
}