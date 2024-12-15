using BanQuanAo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList;
using System.Diagnostics;

namespace BanQuanAo.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly QlbanHangQuanAoContext _context;

		public HomeController(ILogger<HomeController> logger, QlbanHangQuanAoContext context)
		{
			_logger = logger;
			_context = context;
		}

		public IActionResult Index(int? page)
		{
			var PhanLoaiChinh = _context.PhanLoais.ToList();
			var danhsachphanloaiphu= _context.PhanLoaiPhus.ToList();
			var danhsachmenu=new List<PhanTong>();
			foreach(var item in PhanLoaiChinh)
			{
				var phantong = new PhanTong();
				phantong.PhanLoaiChinh = item;
				phantong.DanhSachPhanLoaiPhu = danhsachphanloaiphu.Where(p => p.MaPhanLoai == item.MaPhanLoai).ToList();
				danhsachmenu.Add(phantong);
			}
			ViewBag.DanhSachMenu = danhsachmenu;
			int pageSize = 6;
			int pageNumber = (page ?? 1);
			var sanpham = _context.SanPhams.ToList();
			ViewBag.HienThi = sanpham;
			return View();
		}
		[Route("/{id}")]
		public IActionResult ChiTietSanPham(string id)
		{
			var PhanLoaiChinh = _context.PhanLoais.ToList();
			var danhsachphanloaiphu = _context.PhanLoaiPhus.ToList();
			var danhsachmenu = new List<PhanTong>();
			foreach (var item in PhanLoaiChinh)
			{
				var phantong = new PhanTong();
				phantong.PhanLoaiChinh = item;
				phantong.DanhSachPhanLoaiPhu = danhsachphanloaiphu.Where(p => p.MaPhanLoai == item.MaPhanLoai).ToList();
				danhsachmenu.Add(phantong);
			}
			ViewBag.DanhSachMenu = danhsachmenu;
			var sanpham = _context.SanPhams.Where(p => p.MaSanPham ==id).FirstOrDefault();
			return View(sanpham);
		}
		public IActionResult PhanLoaiAPI(string danhsachchinh)
		{
			var maphanloai = (from p in _context.PhanLoais
							  where p.PhanLoaiChinh == danhsachchinh
							  select p.MaPhanLoai).FirstOrDefault();
			var danhsach= _context.SanPhams.Where(p => p.MaPhanLoai == maphanloai).ToList();
		    return PartialView("SanPham",danhsach);
		}
		public IActionResult PhanLoaiPhuAPI(string danhsachphu)
		{
			var maphanloai = (from p in _context.PhanLoaiPhus
							  where p.TenPhanLoaiPhu == danhsachphu
							  select p.MaPhanLoaiPhu).FirstOrDefault();
			var danhsach = _context.SanPhams.Where(p => p.MaPhanLoaiPhu == maphanloai).ToList();
			return PartialView("SanPham", danhsach);
		}
		public IActionResult GetPagedProducts(int ? page,int? pageSize)
		{
			int pageNumber = (page ?? 1);
			int size = (pageSize ?? 6);

			var sanpham = _context.SanPhams.OrderBy(p => p.TenSanPham).ToPagedList(pageNumber, size);
			return PartialView("SanPham", sanpham);
			
		}
		[Route("/12")]

      public IActionResult ThemSanPham()
       {
        var PhanLoaiChinh = _context.PhanLoais.ToList();
        var danhsachphanloaiphu = _context.PhanLoaiPhus.ToList();
        var danhsachmenu = new List<PhanTong>();

        foreach (var item in PhanLoaiChinh)
        {
            var phantong = new PhanTong();
            phantong.PhanLoaiChinh = item;
            phantong.DanhSachPhanLoaiPhu = danhsachphanloaiphu.Where(p => p.MaPhanLoai == item.MaPhanLoai).ToList();
            danhsachmenu.Add(phantong);
        }
        ViewBag.DanhSachMenu = danhsachmenu;

        // Chuyển đổi thành SelectList
        ViewBag.MaPhanLoai = new SelectList(PhanLoaiChinh, "MaPhanLoai", "PhanLoaiChinh");
        ViewBag.MaPhanLoaiPhu = new SelectList(danhsachphanloaiphu, "MaPhanLoaiPhu", "TenPhanLoaiPhu");

        return View();
       }
		[HttpPost]
		public IActionResult ThemSanPham(SanPham sanpham)
		{
			if (ModelState.IsValid)
			{
				_context.SanPhams.Add(sanpham);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			var PhanLoaiChinh = _context.PhanLoais.ToList();
			var danhsachphanloaiphu = _context.PhanLoaiPhus.ToList();
			var danhsachmenu = new List<PhanTong>();

			foreach (var item in PhanLoaiChinh)
			{
				var phantong = new PhanTong();
				phantong.PhanLoaiChinh = item;
				phantong.DanhSachPhanLoaiPhu = danhsachphanloaiphu.Where(p => p.MaPhanLoai == item.MaPhanLoai).ToList();
				danhsachmenu.Add(phantong);
			}
			ViewBag.DanhSachMenu = danhsachmenu;

			// Chuyển đổi thành SelectList
			ViewBag.MaPhanLoai = new SelectList(PhanLoaiChinh, "MaPhanLoai", "PhanLoaiChinh");
			ViewBag.MaPhanLoaiPhu = new SelectList(danhsachphanloaiphu, "MaPhanLoaiPhu", "TenPhanLoaiPhu");
			return View(sanpham);
		}

        public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
