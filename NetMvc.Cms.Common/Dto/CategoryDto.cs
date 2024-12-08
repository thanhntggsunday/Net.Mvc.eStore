using NetMvc.Cms.Common.Class;

namespace NetMvc.Cms.Common.Dto
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CategoryDto : EntityBaseDto
    {
        public CategoryDto()
        {
            IsIntroducedBoolable = new BooleanDto();
            StatusBoolable = new BooleanDto();
        }

        private bool? _isIntroduced = false;
        public long ID { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }

        
        [StringLength(250)]
        public string MetaTitle { get; set; }

        [StringLength(250)]
        [Display(Name = "Ảnh")]
        public string Images { get; set; }

        [StringLength(250)]
        [Display(Name = "Miêu tả")]
        public string Description { get; set; }

        [Display(Name = "Thứ tự")]
        public int? Order { get; set; }

        public long? ParentID { get; set; }
        

        [StringLength(250)]
        public string MetaKeywords { get; set; }

        [StringLength(250)]
        public string MetaDescription { get; set; }

        [Display(Name = "Trạng thái")]
        public BooleanDto StatusBoolable { get; set; }

        public bool? IsIntroduced
        {
            get
            {
                return _isIntroduced;
            }

            set
            {
                if (value == null)
                {
                    _isIntroduced = false;
                }
                else
                {
                    _isIntroduced = value;
                }
            }
        }

        public BooleanDto IsIntroducedBoolable { get; set; }

    }
}