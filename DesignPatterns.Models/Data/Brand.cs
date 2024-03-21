﻿using System;
using System.Collections.Generic;

namespace DesignPatterns.Models.Data
{
    public partial class Brand
    {
        public Brand()
        {
            Beers = new HashSet<Beer>();
        }

        public Guid BrandId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Beer> Beers { get; set; }
    }
}
