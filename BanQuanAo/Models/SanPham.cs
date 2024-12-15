using System;
using System.Collections.Generic;

namespace BanQuanAo.Models;

public partial class SanPham
{
    public string MaSanPham { get; set; } = null!;

    public string TenSanPham { get; set; } = null!;

    public string? MaPhanLoai { get; set; }

    public long? GiaNhap { get; set; }

    public long? DonGiaBanNhoNhat { get; set; }

    public long? DonGiaBanLonNhat { get; set; }

    public bool? TrangThai { get; set; }

    public string? MoTaNgan { get; set; }

    public string? AnhDaiDien { get; set; }

    public bool? NoiBat { get; set; }

    public string? MaPhanLoaiPhu { get; set; }

    public virtual PhanLoai? MaPhanLoaiNavigation { get; set; }

    public virtual PhanLoaiPhu? MaPhanLoaiPhuNavigation { get; set; }

    public virtual ICollection<SptheoMau> SptheoMaus { get; set; } = new List<SptheoMau>();
}
