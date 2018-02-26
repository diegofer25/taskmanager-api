namespace taskmanager_api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class usuarios
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(100)]
        public string nome { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [StringLength(32)]
        public string senha { get; set; }

        [StringLength(255)]
        public string foto { get; set; }
    }
}
