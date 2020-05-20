namespace StudentManagementApp2WebAPI
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Admin")]
    public partial class Admin
    {
        [Key]
        public int Admin_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(50)]
        public string School_Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }
    }
}
