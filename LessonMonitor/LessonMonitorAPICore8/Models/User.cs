


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

    internal class DescriptionAttribute : Attribute
    {
        public DescriptionAttribute(string text)
        {
            Text = text;
        }

        public string Text { get; }
    }

    public class RequiredAttribute : Attribute
    {
        public RequiredAttribute(int minValue, int maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }

        public int MinValue { get; }

        public int MaxValue { get; }
    }

    internal class RangeAttribute : Attribute
    {
    }



}
