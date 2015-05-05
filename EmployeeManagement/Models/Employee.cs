using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeEducationInfo.Model
{
    public class Employee
    {
        public Employee()
        {
            this.IsDel = false;
            this.EducationInfo = new HashSet<EducationInfo>();
        }

        [Required]
        public int Id { get; set; }

        [Display(Name = "用户名")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "用户名不能为空")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Display(Name = "年龄")]
        [Range(0, 100, ErrorMessage = "年龄范围0-100")]
        public Nullable<int> Age { get; set; }

        [Display(Name = "工龄")]
        [Range(0, 100, ErrorMessage = "工龄范围0-100")]
        public Nullable<int> Seniority { get; set; }

        [Display(Name = "是否删除")]
        public bool IsDel { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        [Display(Name = "教育信息")]
        public virtual ICollection<EducationInfo> EducationInfo { get; set; }

    }
}
