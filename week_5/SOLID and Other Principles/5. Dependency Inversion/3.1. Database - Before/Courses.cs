namespace DependencyInversionDatabaseBefore
{
    public class Courses

    {
        private IData _db;

        Courses(IData db)
        {
            _db = db;
        }
        public void PrintAll()
        {
            var courses = _db.CourseNames();

            // print courses
        }

        public void PrintIds()
        {
            var courses = _db.CourseIds();

            // print courses
        }

        public void PrintById(int id)
        {
            var courses = _db.GetCourseById(id);

            // print courses
        }

        public void Search(string substring)
        {
            var courses = _db.Search(substring);

            // print courses
        }
    }
}
