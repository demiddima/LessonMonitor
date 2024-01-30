


using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LessonMonitorAPICore8.Models
{
    public class User
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(18,70)]
        public int Age { get; set; }

        [Description("Test Method")]
        public void Test([Description("First parament")] string value) 
        { 

        }

    }






}
