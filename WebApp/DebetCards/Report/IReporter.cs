using DebetCards.Models;

namespace DebetCards.Report
{
    public interface IReporter<T>
    {
        public void CreateReport(IEnumerable<T> items);
    }
}
