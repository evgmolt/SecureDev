using DebetCards.Models;

namespace DebetCards.Report
{
    public class ReporterToConsole : IReporter<CardForReport>
    {
        public void CreateReport(IEnumerable<CardForReport> cards)
        {
            foreach (CardForReport card in cards)
            {
                Console.WriteLine(
                    card.Name + " " +
                    card.CardNumber + " " +
                    card.ValidUntil + " " +
                    card.CVC);
            };
        }
    }
}
