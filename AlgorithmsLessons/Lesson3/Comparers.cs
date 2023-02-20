using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3
{

    public enum SortType
    {
        Ascending, // Верх -> Низ
        Descending, // Низ -> Верх
    }

    public class FirstNameComparer : IComparer<Student>
    {

        private SortType _sortType;

        public FirstNameComparer(SortType sortType)
        {
            _sortType = sortType;
        }

        public int Compare(Student? x, Student? y)
        {
            return _sortType == SortType.Ascending ? x.FirstName.CompareTo(y.FirstName) : y.FirstName.CompareTo(x.FirstName);
        }
    }

    public class StudentFIEqualityComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student? x, Student? y)
        {
            return x?.SurName== y?.SurName && x?.FirstName == y?.FirstName;
        }

        public int GetHashCode([DisallowNull] Student obj)
        {
            return obj.GetHashCode();
        }
    }
}
