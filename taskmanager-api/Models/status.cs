namespace taskmanager_api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class status
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Column("status")]
        [StringLength(1)]
        public string status1 { get; set; }

        [StringLength(10)]
        public string desc_status { get; set; }
    }
}
