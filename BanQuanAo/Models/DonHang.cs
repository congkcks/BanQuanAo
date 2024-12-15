using System;
using System.Collections.Generic;

namespace BanQuanAo.Models;

public partial class DonHang
{
    public string MaDonHang { get; set; } = null!;

    public DateOnly? NgayDatHang { get; set; }

    public string? MaNguoiDung { get; set; }

    public string? DiaChiGiaoHang { get; set; }

    public string? PtthanhToan { get; set; }

    public string? TinhTrang { get; set; }

    public string TenNguoiNhanHang { get; set; } = null!;

    public string SoDienThoaiNhanHang { get; set; } = null!;

    public long? TongTien { get; set; }

    public byte? GiamGia { get; set; }

    public string? GhiChu { get; set; }

    public virtual ICollection<ChiTietDh> ChiTietDhs { get; set; } = new List<ChiTietDh>();

    public virtual NguoiDung? MaNguoiDungNavigation { get; set; }
}
