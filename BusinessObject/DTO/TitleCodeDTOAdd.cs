using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{
    public class TitleCodeDTOAdd
    {
        public int? Titlecodenumber { get; set; }

        public int? Classid { get; set; }

        public int? TeacherSubjectId { get; set; }

        public int? totalMark { get; set; }
    }
}
