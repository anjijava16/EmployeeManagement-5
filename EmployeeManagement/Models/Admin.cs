using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeEducationInfo.Model
{
    public class Admin
    {
        public Admin()
        {
            this.IsDel = false;
        }

        [Required]
        public int Id { get; set; }

        [Display(Name = "用户名")]
        [MaxLength(50)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "用户名不能为空")]
        public string Name { get; set; }

        [Display(Name = "密码")]
        [MaxLength(50)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "密码不能为空")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public int ErrorTime { get; set; }

        [Display(Name = "是否删除")]
        public bool IsDel { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

    }
}
