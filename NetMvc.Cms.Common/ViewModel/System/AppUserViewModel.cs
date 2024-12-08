using System;
using System.Collections.Generic;
using System.Web;
using NetMvc.Cms.Common.Dto;

namespace NetMvc.Cms.Common.ViewModel.System
{
    public class AppUserViewModel : TransactionalInformation
    {
        public string Id { get; set; }

        public string FullName { get; set; }

        public string Address { get; set; }

        public string Avatar { get; set; }

        public DateTime? BirthDay { get; set; }

        public bool? Status { get; set; }

        public string Gender { get; set; }

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public DateTime? LockoutEndDateUtc { get; set; }

        public bool LockoutEnabled { get; set; }

        public int AccessFailedCount { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Department { get; set; }
        public string Position { get; set; }

        public string StrGender { get; set; }

        public string StrBirthDay { get; set; }

        public string Country { get; set; }
        public string CountryRegionCode { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }

        public List<AppUserDto> UserDTOs { get; set; }

        public ICollection<string> Roles { get; set; }

        public HttpPostedFileBase FileAttach { get; set; }
        public string FileContentType { get; set; }
    }
}