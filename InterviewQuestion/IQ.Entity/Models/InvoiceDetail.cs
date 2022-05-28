using System;
using System.Collections.Generic;

#nullable disable

namespace IQ.Entity.Models
{
    public partial class InvoiceDetail
    {
        public int InvoiceDetailtId { get; set; }
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public decimal ProductPrice { get; set; }

        public virtual Invoice Invoice { get; set; }
        public virtual Product Product { get; set; }
    }
}
