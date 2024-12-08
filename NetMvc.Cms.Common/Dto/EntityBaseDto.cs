using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace NetMvc.Cms.Common.Dto
{
    public class EntityBaseDto
    {
        private bool? _status = false;

        [Display(Name = "Ngày tạo")]
        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        [Display(Name = "Người tạo")]
        public string CreatedBy { get; set; }

        [Display(Name = "Ngày update")]
        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        [Display(Name = "Người update")]
        public string ModifiedBy { get; set; }

        public bool? Status {
            get
            {
                return _status;
            }

            set
            {
                if (value == null)
                {
                    _status = false;
                }
                else
                {
                    _status = value;
                }
            }
        }
      

        [StringLength(10)]
        [Display(Name = "Mã ngôn ngữ")]
        public string LanguageCode { get; set; }

        [Display(Name = "Trạng thái")]
        public string StrStatus { get; set; }

        [Display(Name = "Ngày tạo")]
        public string StrCreatedDate
        {
            get
            {
                if (CreatedDate == null)
                {
                    return DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                else
                {
                    return CreatedDate.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
            }
        }

        [Display(Name = "Ngày update")]
        public string StrModifiedDate
        {
            get
            {
                if (CreatedDate == null)
                {
                    return DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                else
                {
                    return CreatedDate.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
            }
        }

    }
}