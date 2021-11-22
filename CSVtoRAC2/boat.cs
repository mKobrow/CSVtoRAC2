namespace CSVtoRAC2
{
    public class boat
    {
        public string class_name { get; set; }
        public string id { get; set; }
        public int lane_number { get; set; }
        public string name { get; set; }
        public participant[] participants { get; set; }

        public boat(int lane_number, string name, string class_name = "", string id = "")
        {
            this.class_name = class_name;
            this.id = id;
            this.lane_number = lane_number;
            this.name = name;
            this.participants = new participant[1] {new participant()};
        }
    }
}