﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabio.Models.Requests.Notes
{
    public class NotesUpdateRequest : NotesAddRequest, IModelIdentifier 
    {
        public int Id { get; set; }

    }
}
