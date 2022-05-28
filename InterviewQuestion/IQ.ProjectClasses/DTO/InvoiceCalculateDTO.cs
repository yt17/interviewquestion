using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQ.ProjectClasses.DTO
{
    public class InvoiceCalculateDTO
    {
        public int UserID { get; set; }
        public List<ProductDTO> Products { get; set; }
    }
}
