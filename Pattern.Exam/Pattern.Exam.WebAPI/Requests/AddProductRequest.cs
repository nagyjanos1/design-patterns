using System.ComponentModel.DataAnnotations;

namespace Pattern.Exam.WebAPI.Requests
{
    public class AddProductRequest
    {
        [Required]
        public Guid AccountId { get; set; }
        [Required]
        public Guid ProductId { get; set; }
    }
}
