using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ModelLayer.ViewModel
{
    public class StudentVM
    {
        public Student student { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> departmentList { get; set; }
    }
}
