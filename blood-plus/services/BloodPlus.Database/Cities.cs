﻿using System;
using System.Collections.Generic;

namespace BloodPlus.Database
{
    public partial class Cities
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public byte StateId { get; set; }
    }
}
