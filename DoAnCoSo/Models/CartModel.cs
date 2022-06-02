using DoAnCoSo.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnCoSo.Models
{
    public class CartModel
    {
        public SanPham Product { get; set; }

        public int Quantity { get; set; }
    }
}