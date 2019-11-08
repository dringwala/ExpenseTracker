using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TrackerDB.Entities
{
    public class StoreDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; }
        public string StoreAddress { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string Website { get; set; }
        public string Tags { get; set; }


    }
}
