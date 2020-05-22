namespace NewStudentManagementApp2WebAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Student-Programme")]
    public partial class Student_Programme
    {
        [Key]
        [Column(Order = 0)]
        public int Programme_Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Student_Id { get; set; }
    }
}
