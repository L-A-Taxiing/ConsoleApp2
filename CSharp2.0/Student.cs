using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp2._0
{
    public class Student : IEnumerable
    {
        public static object[] Students =
        {
            new Student(){Name="123"},
            new Student(){Name="234"},
            new Student(){Name="345"},
            new Student(){Name="456"},
            new Student(){Name="567"},
        };
        public string Name { get; set; }

        public IEnumerator GetEnumerator()
        {
            return new Enumrator(this);
        }
    }

    struct Enumrator : IEnumerator
    {
        private object _current;
        private object[] _localStudents;
        private int _index;
        public Enumrator(Student student)
        {
            _localStudents = Student.Students;
            _index = 0;
            _current = _localStudents[_index];
        }
        public object Current => _current;

        public bool MoveNext()
        {
            if (_index >= _localStudents.Length)
            {
                return false;
            }
            _current = _localStudents[_index];
            _index++;
            return true;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
