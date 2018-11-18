using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC2_1.Models
{
   
    public class TypeValid
    {
        [Bind(Exclude = "TypeId")]
        public class EmployeeMetaData
        {
            [ScaffoldColumn(false)]
            public int TypeId { get; set; }

            [DisplayName("Name")]
            [Required(ErrorMessage = "Employee name is required.")]
            [StringLength (50)]
            public string Name { get; set; }

           
            [DisplayName("Model")]
            [Required(ErrorMessage = "Employee name is required.")]
            [StringLength(50)]
            public string Model { get; set; }
            


        }
    }
}