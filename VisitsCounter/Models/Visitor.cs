namespace VisitsCounter.Models
{
    public class Visitor
    {
        public Guid Id { get; set; }
        public int Visitors { get; set; }
        public int Views { get; set; }
        public DateTime Date { get; set; }
    }
}
