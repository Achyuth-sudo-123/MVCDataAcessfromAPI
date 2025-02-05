using System.ComponentModel.DataAnnotations;

namespace MVCDataAcessfromAPI.Models
{
    public class RequestModel
    {
        [Required]
        public int Id { get; set; }
    }
}
