using api_task.IRepositry;
using api_task.Models;
using api_task.Models.Data;

namespace api_task.Repositry
{
    public class DepartmentRepositry : IDepartmentRepositry
    {


        ApplicationDbContext context;
        public DepartmentRepositry(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Add(Department department)
        {
            context.Departments.Add(department);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var Department = GetById(id);
            if(Department!=null)
            {
                context.Departments.Remove(Department);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Department> GetAll()
        {
            return context.Departments.ToList();
        }
        public Department GetById(int id)
        {
            return context.Departments.Find(id);
        
        }

        public bool Update(Department department)
        {
            var _department = GetById(department.Id);

            if (_department != null) {

                _department.Name = department.Name;
                context.SaveChanges();
                return true;
            }

            else return false;

        }
    }
}
