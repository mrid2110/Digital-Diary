﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyJournal
{
    public class Notes
    {
        public int NoteId { get; set; }
        public string Title { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public int UserId { get; set; }
        public string Priority { get; set; }
    }
}
