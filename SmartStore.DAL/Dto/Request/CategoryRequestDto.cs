using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.DAL.Dto.Request
{
    public class CategoryRequestDto
    {
        [StringLength(100,MinimumLength =3)]
        public string Name { get; set; }

    }
}
