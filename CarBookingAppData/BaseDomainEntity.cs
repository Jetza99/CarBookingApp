﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookingAppData
{
    public abstract class BaseDomainEntity
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
