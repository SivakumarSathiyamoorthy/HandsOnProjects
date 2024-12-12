using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Student
    {
        [Key]
        public int StuId { get; set; }
        [Required]
        [MaxLength(30)]
        public String? StuName { get; set; }   
        public String? StuCity { get; set; }
        [Required]
        public int StuDepID { get; set; }
        [ForeignKey("StuDepID")]
        public Department? department { get; set; }
        
    }
}
