using System.ComponentModel.DataAnnotations;

namespace rescunetAPI.Models.DTO
{
    public class CustomerDTO
    {
        public int IdCustomer { get; set; }
        [Required]
        [MaxLength(32)]
        public string UserName { get; set; }
        public int Balance { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
