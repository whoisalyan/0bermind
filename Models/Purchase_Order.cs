namespace Obermind.Models
{
    public class Purchase_Order
    {
        public int Id { get; set; }

        public bool is_draft { get; set; }

        public DateTime Order_Time { get; set; }

        //Customer ID foreign key
        public virtual customer customer { get; set; }

        public Purchase_Order()
        {

        }

    }
}
