namespace NewStudentManagementApp2WebAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Grade
    {
        [Key]
        [Column(Order = 0)]
        public int Exam_Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Student_Id { get; set; }

        [Column("Grade")]
        public int Grade1 { get; set; }

        public virtual Exam Exam { get; set; }

        public virtual Student Student { get; set; }
    }
}
