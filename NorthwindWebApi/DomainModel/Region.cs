﻿using System;
using System.Collections.Generic;

#nullable disable

namespace NorthwindWebApi.DomainModel
{
    public partial class Region
    {
        public Region()
        {
            Territories = new HashSet<Territory>();
        }

        public short RegionId { get; set; }
        public string RegionDescription { get; set; }

        public virtual ICollection<Territory> Territories { get; set; }
    }
}
