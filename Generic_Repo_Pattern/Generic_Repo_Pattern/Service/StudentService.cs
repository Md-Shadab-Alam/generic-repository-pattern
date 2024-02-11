using Generic_Repo_Pattern.Model;
using Generic_Repo_Pattern.Repository;

namespace Generic_Repo_Pattern.Service
{
    public class StudentService : IGenericRepo<Student>
    {
        List<Student> student = new List<Student>();

        public StudentService() {
            //for(int i=0; i<9; i++)
            //{
            //    student.Add(new Student()
            //    {
            //        StudentId = i,
            //        Name = "Stu"+i,
            //        Roll = "100"+i
            //    });
            //}

            student.Add(new Student
            {
                StudentId = 1,
                Name = "Shadab",
                Roll = "101",
                Status = "Good"
            });
            student.Add(new Student
            {
                StudentId = 2,
                Name = "Rishabh",
                Roll = "102",
                Status = "Good"
            });
            student.Add(new Student
            {
                StudentId = 3,
                Name = "Mohit",
                Roll = "103",
                Status = "Excellent"
            });
            student.Add(new Student
            {
                StudentId = 4,
                Name = "Alax",
                Roll = "104",
                Status = "Good"
            });
        }
    


        public List<Student> Delete(int id)
        {
            student.RemoveAll(x => x.StudentId==id);
            return student;
        }

        public List<Student> GetAll()
        {
            return student;
        }

        public Student GetById(int id)
        {
            return student.Where(x => x.StudentId == id).SingleOrDefault();
        }

        public List<Student> Insert(Student item)
        {
            student.Add(item);
            return student;
        }

        public List<Student> Update(Student item)
        {
            var extItem = GetById((int)item.GetType().GetProperty("StdId")?.GetValue(item));

            var properties = typeof(Student).GetProperties();
            foreach(var property in properties)
            {
                property.SetValue(extItem, property.GetValue(item));
            }
            return student;
        }
    }
}
