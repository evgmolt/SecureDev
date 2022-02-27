using System.ComponentModel.DataAnnotations.Schema;

namespace DebetCards.Models
{
    public class Card
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("cardnumber")]
        public long CardNumber { get; set; }
        [Column("cvc")]
        public int CVC { get; set; }
        [Column("validuntilmonth")]
        public int ValidUntilMonth { get; set; }
        [Column("validuntilyear")]
        public int ValidUntilYear { get; set; }

        public override string ToString()
        {
            return Id.ToString() + " " + 
                   Name.ToString() + " " + 
                   CardNumber.ToString() + " " +
                   CVC.ToString() + " " +
                   ValidUntilMonth.ToString().PadLeft(2, '0') + "/" +
                   ValidUntilYear.ToString();
        }
    }
}
