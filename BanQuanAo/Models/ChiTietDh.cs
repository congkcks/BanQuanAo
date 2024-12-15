using System;
using System.Collections.Generic;

namespace BanQuanAo.Models;

public partial class ChiTietDh
{
    public string MaDonHang { get; set; } = null!;

    public string MaChiTietSp { get; set; } = null!;

    public int? SoLuongMua { get; set; }

    public long? DonGiaBan { get; set; }

    public virtual ChiTietSpban MaChiTietSpNavigation { get; set; } = null!;

    public virtual DonHang MaDonHangNavigation { get; set; } = null!;
}
