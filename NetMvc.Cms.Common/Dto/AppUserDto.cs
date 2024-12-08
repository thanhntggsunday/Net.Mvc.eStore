using System;
using System.ComponentModel.DataAnnotations;

namespace NetMvc.Cms.Common.Dto
{
    public class AppUserDto
    {
        public string Id { get; set; }

        [Display(Name = "Họ và tên")]
        public string FullName { get; set; }

        [Display(Name = "Địa chỉ")]

        public string Address { get; set; }

        [Display(Name = "Avatar")]
        public string Avatar { get; set; }

        [Display(Name = "Ngày sinh")]
        public DateTime? BirthDay { get; set; }

        public bool? Status { get; set; }

        [Display(Name = "Giới tính")]
        public string Gender { get; set; }

        public string Email { get; set; }

        [Display(Name = "Xác nhận email")]
        public bool EmailConfirmed { get; set; }

        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public DateTime? LockoutEndDateUtc { get; set; }

        public bool LockoutEnabled { get; set; }

        public int AccessFailedCount { get; set; }

        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Display(Name = "Phòng ban")]
        public string Department { get; set; }

        [Display(Name = "Vị trí")]
        public string Position { get; set; }

        [Display(Name = "Quốc gia")]
        public string Country { get; set; }

        [Display(Name = "Mã quốc gia")]
        public string CountryRegionCode { get; set; }
        [Display(Name = "Thành phố")]
        public string City { get; set; }
        [Display(Name = "Mã bưu điện")]
        public string Postcode { get; set; }
    }
}