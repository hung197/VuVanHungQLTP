using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace demoBackEndQlTp2.Models
{
    public class ThanhPho
    {
        [Key]
        public int MaTp { get; set; }
        [Column(TypeName="nvarchar(150)")]
        [Required]
        public string TenTp { get; set; }
        public List<QuanHuyen> QuanHuyens { get; set; }
    }
}
