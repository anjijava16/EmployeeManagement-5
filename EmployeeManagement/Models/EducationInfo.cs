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

        [Display(Name = "��ʼ����")]
        [Required(ErrorMessage = "��ʼ���ڲ���Ϊ��")]
        [DataType(DataType.Date)]
        public System.DateTime StartTime { get; set; }

        [Display(Name = "��������")]
        [Required(ErrorMessage = "�������ڲ���Ϊ��")]
        [DataType(DataType.Date)]
        public System.DateTime EndTime { get; set; }

        [Display(Name = "������Ϣ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "������Ϣ����Ϊ��")]
        [MaxLength(50)]
        public string Education { get; set; }

        [Display(Name = "�Ƿ�ɾ��")]
        public bool IsDel { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public virtual Employee Employee { get; set; }

    }
}
