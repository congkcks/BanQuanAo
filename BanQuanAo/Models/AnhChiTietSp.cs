using System;
using System.Collections.Generic;

namespace BanQuanAo.Models;

public partial class AnhChiTietSp
{
    public string MaAnh { get; set; } = null!;

    public string? MaSptheoMau { get; set; }

    public string TenFileAnh { get; set; } = null!;

    public virtual SptheoMau? MaSptheoMauNavigation { get; set; }
}
