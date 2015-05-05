using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeEducationInfo.Model
{
    public partial class EducationInfo
    {
        public EducationInfo()
        {
            this.IsDel = false;
        }

        [Required]
        public int Id { get; set; }

        [Display(Name = "开始日期")]
        [Required(ErrorMessage = "开始日期不能为空")]
        [DataType(DataType.Date)]
        public System.DateTime StartTime { get; set; }

        [Display(Name = "结束日期")]
        [Required(ErrorMessage = "结束日期不能为空")]
        [DataType(DataType.Date)]
        public System.DateTime EndTime { get; set; }

        [Display(Name = "教育信息")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "教育信息不能为空")]
        [MaxLength(50)]
        public string Education { get; set; }

        [Display(Name = "是否删除")]
        public bool IsDel { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public virtual Employee Employee { get; set; }

    }
}
