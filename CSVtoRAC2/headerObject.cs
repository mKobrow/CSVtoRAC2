namespace CSVtoRAC2
{
    public class headerObject
    {
        public race_definition race_definition {get; set;}

        public headerObject (race_definition race_definition) {
            this.race_definition = race_definition;
        }
    }
}