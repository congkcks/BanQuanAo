using System;
using System.Collections.Generic;

namespace BanQuanAo.Models;

public partial class SptheoMau
{
    public string MaSptheoMau { get; set; } = null!;

    public string MaSanPham { get; set; } = null!;

    public string MaMau { get; set; } = null!;

    public virtual ICollection<AnhChiTietSp> AnhChiTietSps { get; set; } = new List<AnhChiTietSp>();

    public virtual ICollection<ChiTietSpban> ChiTietSpbans { get; set; } = new List<ChiTietSpban>();

    public virtual MauSac MaMauNavigation { get; set; } = null!;

    public virtual SanPham MaSanPhamNavigation { get; set; } = null!;
}
