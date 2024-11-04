using HShop.Data;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HShop.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Vui lòng nhập Tên đăng nhập*")]
        [MaxLength(20, ErrorMessage = "Tối đã 20 ký tự")]
        public string MaKh { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Vui lòng nhập Mật khẩu*")]
        [DataType(DataType.Password)]
        public string? MatKhau { get; set; }

        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "Vui lòng nhập Họ tên*")]
        [MaxLength(50, ErrorMessage = "Tối đã 50 ký tự")]
        public string HoTen { get; set; }

        [Display(Name = "Giới tính")]
        public bool GioiTinh { get; set; } = true;

        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime NgaySinh { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Địa chỉ*")]
        [Display(Name = "Địa chỉ")]
        [MaxLength(60, ErrorMessage = "Tối đã 60 ký tự")]
        public string? DiaChi { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Số điện thoại*")]
        [Display(Name = "Số điện thoại")]
        [MaxLength(24, ErrorMessage = "Tối đã 24 ký tự")]
        [RegularExpression(@"0[98753]\d{8}", ErrorMessage = "Chưa đúng định dạng SĐT")]
        public string? DienThoai { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Email*")]
        [EmailAddress(ErrorMessage ="Chưa đúng định dạng email")]
        public string Email { get; set; }

        [Display(Name = "Avatar")]
        public string? Hinh { get; set; }
    }
}
