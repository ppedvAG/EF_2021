using System;
using System.Collections.Generic;

#nullable disable

namespace EFCore_CodeFirstFromDatabase.Model
{
    public partial class CurrentProductList
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
