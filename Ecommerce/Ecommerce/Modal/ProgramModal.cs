using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Modal
{
    public class ProgramModel
    {
        [Key]
        public int Program_ID { get; set; }
        public string Program_Title { get; set; }
        public string Program_Content { get; set; }






    }
}
