﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneFi.Models.Requests.Notes
{
    public class NotesAddRequest
    {
        [Required]
        [MaxLength]
        public string LectureNotes { get; set; }

        [Required]
        public int LectureId { get; set; }
    }
}
