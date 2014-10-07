namespace HSBlacklist.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Location { get; set; }

        [Required]
        [StringLength(100)]
        public string JobTitle { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(15)]
        public string Phone { get; set; }

        public override bool Equals(object obj)
        {
            var comparer = obj as Employee;
            return (this.Email == comparer.Email && 
                this.JobTitle == comparer.JobTitle && 
                this.Id == comparer.Id && 
                this.Location == comparer.Location && 
                this.Name == comparer.Name && 
                this.Phone == comparer.Phone);
        }

    }
}
