﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniro.DataAccess.Models.DataAccess
{
    public class EmailSubscriber
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string SubsriptionType { get; set; }
    }
}
