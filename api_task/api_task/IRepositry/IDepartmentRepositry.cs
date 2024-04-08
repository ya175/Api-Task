using api_task.Models;

namespace api_task.IRepositry
{
    public interface IDepartmentRepositry
    {
        public List<Department> GetAll();

        public Department GetById(int id);


        public bool Delete(int id);

        public void Add(Department department);
        public bool Update(Department department);

    }
}
