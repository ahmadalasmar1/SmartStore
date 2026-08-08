using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.DAL.Dto.Response
{
    public class CategoryResponseDto
    {
        public int Id { get; set; }//عشان انا بدي ارجع معلومات الكتيجوري كلها
        public string Name { get; set; }

    }
}
