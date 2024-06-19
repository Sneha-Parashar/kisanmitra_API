namespace CrudWebAPICORESP.Model
{
    public class Consultant
    {
        public string consultant_id { get; set; }
        public string certification_number { get; set; }
        public string inserted_by { get; set; }
        public string updated_by { get; set; }
        public DateTime? inserted_date { get; set; }
        public DateTime? updated_date { get; set; }
        public string operationType { get; set; }
        public string old_certification_number { get; set; }
        public string new_certification_number { get; set; }
    }
}
