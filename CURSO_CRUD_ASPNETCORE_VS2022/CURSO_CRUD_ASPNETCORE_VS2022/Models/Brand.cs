﻿using System;
using System.Collections.Generic;

namespace CURSO_CRUD_ASPNETCORE_VS2022.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Beers = new HashSet<Beer>();
        }

        public int BrandId { get; set; }
        public string Name { get; set; } = null!;
        public string Distributor { get; set; } = null!;
        public string Año { get; set; } = null!;

        public virtual ICollection<Beer> Beers { get; set; }
    }
}
