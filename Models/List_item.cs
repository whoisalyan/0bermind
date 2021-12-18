namespace Obermind.Models
{
    public class List_item
    {
        public int Id { get; set; }


        //Order ID Foreign Key
        public virtual Purchase_Order Purchase_Order { get; set; }


        //Product ID Foreign Key
        public virtual Products Products { get; set; }



        public int quantity { get; set; }

        public List_item()
        {

        }
    }
}
