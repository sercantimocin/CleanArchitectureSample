using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Chekout
{
    public class BasketProduct
    {
        public int BasketId { get; set; }

        public int ProductId { get; set; }

        public int Count { get; set; }
    }
}
