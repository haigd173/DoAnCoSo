using DoAnCoSo.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnCoSo.Models
{
    public class HomeModel
    {
        public List<SanPham> listSanPham { get; set; }
        public List<DanhMucSanPham> listDanhMucSanPham { get; set; }
    }
}