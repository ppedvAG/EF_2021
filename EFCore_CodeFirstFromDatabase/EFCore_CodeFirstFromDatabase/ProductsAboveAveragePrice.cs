using System;
using System.Collections.Generic;

#nullable disable

namespace EFCore_CodeFirstFromDatabase
{
    public partial class ProductsAboveAveragePrice
    {
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
    }
}
