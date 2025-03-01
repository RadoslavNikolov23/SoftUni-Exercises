namespace P01_StudentSystem.Common
{
    public static class ValidationLength
    {
        public static class StudentValidation
        {
            public const int maxLenghtName = 100;
            public const int maxLenghtPhoneNumber = 10;
        }

        public static class CourseValidation
        {
            public const int maxLenghName = 80;
            public const int maxLenghDescription = 1000;
        } 
        
        public static class ResourceValidation
        {
            public const int maxLenghName = 50;
           public const int maxLenghURL = 2000;
        }   

        public static class HomeworkValidation
        {
            public const int maxLengContent = 2000;
          // public const int maxLenghURL = 2000;
        }
    }
}
