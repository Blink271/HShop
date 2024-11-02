using HShop.Data;
using HShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HShop.Controllers
{
    public class HangHoaController : Controller
    {
        private readonly Hshop2023Context db;
        public HangHoaController(Hshop2023Context context)
        {
            db = context;
        }
        public IActionResult Index(int? loai)
        {
            var hanghoas = db.HangHoas.AsQueryable();
            if (loai.HasValue)
            {
                hanghoas = hanghoas.Where(p => p.MaLoai == loai.Value);
            }

            var result = hanghoas.Select(p => new HangHoaVM
            {
                MaHH = p.MaHh,
                TenHH = p.TenHh,
                Hinh = p.Hinh ?? "",
                DonGia = p.DonGia ?? 0,
                MotaNgan = p.MoTaDonVi ?? "",
                TenLoai = p.MaLoaiNavigation.TenLoai
            });
             
            return View(result);
        }

        public IActionResult Search(string? query)
        {
            var hanghoas = db.HangHoas.AsQueryable();
            if (query != null)
            {
                hanghoas = hanghoas.Where(p => p.TenHh.Contains(query));
            }

            var result = hanghoas.Select(p => new HangHoaVM
            {
                MaHH = p.MaHh,
                TenHH = p.TenHh,
                Hinh = p.Hinh ?? "",
                DonGia = p.DonGia ?? 0,
                MotaNgan = p.MoTaDonVi ?? "",
                TenLoai = p.MaLoaiNavigation.TenLoai
            });

            return View(result);
        }

        public IActionResult Detail(int? id)
        {
            var data = db.HangHoas
                .Include(p => p.MaLoaiNavigation)
                .SingleOrDefault(p => p.MaHh == id);
            if(data == null)
            {
                TempData["Message"] = $"Không tìn thấy sản phẩm có mã {id}";
                return Redirect("/404");
            }
            var result = new ChiTietHangHoaVM
            {
                MaHH = data.MaHh,
                TenHH = data.TenHh,
                DonGia = data.DonGia ?? 0,
                ChiTiet = data.MoTa ?? "",
                Hinh = data.Hinh ?? "",
                MotaNgan = data.MoTaDonVi ?? "",
                TenLoai = data.MaLoaiNavigation.TenLoai,
                SoLuongTon = 10,
                DiemDanhGia = 5
            };
            return View(result);
        }
    }
}
