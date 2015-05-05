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

        [Display(Name = "�û���")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "�û�������Ϊ��")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Display(Name = "����")]
        [Range(0, 100, ErrorMessage = "���䷶Χ0-100")]
        public Nullable<int> Age { get; set; }

        [Display(Name = "����")]
        [Range(0, 100, ErrorMessage = "���䷶Χ0-100")]
        public Nullable<int> Seniority { get; set; }

        [Display(Name = "�Ƿ�ɾ��")]
        public bool IsDel { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        [Display(Name = "������Ϣ")]
        public virtual ICollection<EducationInfo> EducationInfo { get; set; }

    }
}
