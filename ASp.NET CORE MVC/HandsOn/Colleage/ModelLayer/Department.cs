using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Department
    {
        [Key]
        public int DepId { get; set; }
        [Required]
        [MaxLength(50)]
        public String? DepName { get; set; }

    }
}
