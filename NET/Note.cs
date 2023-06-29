using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneFi.Models.Domain.Notes
{
    public class Note
    {
        public int Id { get; set; }

        public string LectureNotes { get; set; }

        public List<LookUp> Tags { get; set; }

        public int LecturedId { get; set; }
        
        public int CreatedBy { get; set; }
    }
}
