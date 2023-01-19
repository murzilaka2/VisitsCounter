using VisitsCounter.Models;

namespace VisitsCounter.Interfaces
{
    public interface IVisitor
    {
        Task<IEnumerable<Visitor>> GetStatisticsByDate(DateTime startDate, DateTime endDate);
        Task IncrementVisitors();
        Task IncrementViews();
    }
}
