using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace demoBackEndQlTp2.Models
{
    public class QuanHuyen
    {
        [Key]
        public int MaQuanHuyen { get; set; }
        [Column(TypeName="nvarchar(150)")]
        [Required]
        public string TenQuanHuyen { get; set; }
        [Required]
        public int MaTp { get; set; }
        [ForeignKey("MaTp")]
        public ThanhPho ThanhPho { get; set; }
        public List<XaPhuong> xaPhuongs { get; set; }
    }
}
