namespace Domain.Checkout
{
    public class BasketProduct
    {
        public int BasketId { get; set; }

        public int ProductId { get; set; }

        public int Count { get; set; }
    }
}
