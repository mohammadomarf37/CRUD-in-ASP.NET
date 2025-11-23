using System.ComponentModel.DataAnnotations;

namespace data.Models
{
    public class Student
    {
        [Key]
        public int std_id { get; set; }
        public string std_name { get; set; }
        public string std_class { get; set; }
        public string std_section { get; set; }
    }
}
