﻿using System.Collections.Generic;
using api_dictionary.Domain.Common;

namespace api_dictionary.Domain.Entities
{
    public class District : AuditableEntity
    {
        public District()
        {
            Villages = new List<Village>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }


        public IList<Village> Villages { get; set; }

    }
}
