using Generic_Repo_Pattern.Model;
using Generic_Repo_Pattern.Repository;

namespace Generic_Repo_Pattern.Service
{
    public class TeacherService : IGenericRepo<Teacher>
    {
        List<Teacher> teachers = new List<Teacher>();
        public TeacherService() { 
            for(int i=1; i<=9; i++)
            {
                teachers.Add(new Teacher()
                {
                    TeacherId = i,
                    Name= "te"+i,
                    subject = "sub"+i
                });   
            }
        }
        public List<Teacher> Delete(int id)
        {
            teachers.RemoveAll(x => x.TeacherId == id);
            return teachers;
        }

        public List<Teacher> GetAll()
        {
            return teachers;
        }

        public Teacher GetById(int id)
        {
            return teachers.Where(x => x.TeacherId == id).SingleOrDefault();

        }

        public List<Teacher> Insert(Teacher item)
        {
            teachers.Add(item);
            return teachers;

        }

        public List<Teacher> Update(Teacher item)
        {
            var extItem = GetById((int)item.GetType().GetProperty("StdId")?.GetValue(item));

            var properties = typeof(Teacher).GetProperties();
            foreach (var property in properties)
            {
                property.SetValue(extItem, property.GetValue(item));
            }
            return teachers;
        }
    }

}
