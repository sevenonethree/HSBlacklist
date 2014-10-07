namespace HSBlacklist.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employees")]
    public partial class Employee1
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string JobTitle { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
