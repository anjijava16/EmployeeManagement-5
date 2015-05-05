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

        [Display(Name = "�û���")]
        [MaxLength(50)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "�û�������Ϊ��")]
        public string Name { get; set; }

        [Display(Name = "����")]
        [MaxLength(50)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "���벻��Ϊ��")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public int ErrorTime { get; set; }

        [Display(Name = "�Ƿ�ɾ��")]
        public bool IsDel { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

    }
}
