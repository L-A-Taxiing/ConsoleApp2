namespace Homework
{
    public class Student
    {
        public int age;

        public int Roles { get; set; }

        private int _weight = 100;

        public  void grow(Student student) { student.age++; }
    }
}