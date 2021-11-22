using System.Runtime.CompilerServices;

namespace CSVtoRAC2
{
    public class headerObject
    {
        public race_definition race_definition {get; set;}

        public headerObject (race_definition raceDefinition) {
            this.race_definition = raceDefinition;
        }

        public string getFilename ()
        {
            return race_definition.name_short + ".rac2";
        }
    }
}