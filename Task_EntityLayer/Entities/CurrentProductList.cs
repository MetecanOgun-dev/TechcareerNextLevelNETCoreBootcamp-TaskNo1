using System;
using System.Collections.Generic;

namespace Task_EntityLayer.Entities
{
    public partial class CurrentProductList
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
    }
}
