namespace DependencyInversionDatabaseBefore
{
    public class Courses

    {  
        private Data myData;

        public Courses(Data myData)
        {
            this.myData = myData;
        }


        public void PrintAll()
        {
            var courses = myData.CourseNames();

            // print courses
        }

        public void PrintIds()
        {
            var courses = myData.CourseIds();

            // print courses
        }

        public void PrintById(int id)
        {
            var courses = myData.GetCourseById(id);

            // print courses
        }

        public void Search(string substring)
        {
            var courses = myData.Search(substring);

            // print courses
        }
    }
}
