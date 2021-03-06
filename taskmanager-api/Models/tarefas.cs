namespace taskmanager_api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tarefas
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string nome { get; set; }

        [Required]
        [StringLength(50)]
        public string categoria { get; set; }

        public bool feito { get; set; }

        public int userid { get; set; }
    }
}
