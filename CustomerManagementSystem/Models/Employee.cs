using System.ComponentModel.DataAnnotations;

namespace CustomerManagementSystem
{
    /// <summary>
    /// Employee Model Class
    /// Used to map the database table
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Auto increamented employee ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Name of the Employee
        /// </summary>
        [Required, StringLength(50)]
        public string Name { get; set; }
        /// <summary>
        /// Role of the Employee
        /// </summary>
        [Required, StringLength(50)]
        public string Role { get; set; }
        /// <summary>
        /// Gender of the Employee
        /// </summary>
        [Required, StringLength(1)]
        public string Gender { get; set; }
        /// <summary>
        /// Address of the Employee
        /// </summary>
        [Required, StringLength(50)]
        public string Address { get; set; }
        
    }
}