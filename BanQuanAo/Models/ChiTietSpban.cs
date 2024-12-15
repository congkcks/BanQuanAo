using System;
using System.Collections.Generic;

namespace BanQuanAo.Models;

public partial class ChiTietSpban
{
    public string MaChiTietSp { get; set; } = null!;

    public string? MaSptheoMau { get; set; }

    public string? KichCo { get; set; }

    public int? SoLuong { get; set; }

    public long? DonGiaBan { get; set; }

    public virtual ICollection<ChiTietDh> ChiTietDhs { get; set; } = new List<ChiTietDh>();

    public virtual SptheoMau? MaSptheoMauNavigation { get; set; }
}
