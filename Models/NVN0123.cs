using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NVN123.Models
{
    [Table("NVN")]
    public class NVN
    {
        [Key]
        [Display(Name="ID")]
        public String NVNID { get; set; }
        [Display(Name="Họ và tên")]
        public string NVNName { get; set; }
        public string Genre { get; set; }
    }
}