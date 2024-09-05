namespace WebAPIDemo.Model
{
    public static class CollegeRepository
    {
        public static IList<Student> students = new List<Student>()
        {
            new Student
            {
                Id = 1,
                Name = "Test 1",
                Email = "Test 1",
                Address = "Test 1"
            },
            new Student
            {
                Id = 2,
                Name = "Test 2",
                Email = "Test 2",
                Address = "Test 2"
            }
        };
    }
}
