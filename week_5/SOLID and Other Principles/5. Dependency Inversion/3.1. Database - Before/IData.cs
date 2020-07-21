using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_and_Other_Principles._5._Dependency_Inversion._3._1._Database___Before
{
    interface IData
    {
        IEnumerable<int> CourseIds();
        IEnumerable<string> CourseNames();
        IEnumerable<string> Search(string substring);
        string GetCourseById(int id);
    }
}