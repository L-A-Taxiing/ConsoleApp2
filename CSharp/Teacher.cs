namespace CSharp
{
    internal class Teacher
    {
        public static explicit operator Teacher(Student student)
        {
            return new Teacher();

        }

    }
}