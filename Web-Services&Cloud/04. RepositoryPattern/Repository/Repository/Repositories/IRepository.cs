using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{

    public class Student { }

    public class DBStudentRepo : IRepository<Student>
    {

        public void Add(Student item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> All()
        {
            throw new NotImplementedException();
        }

        public Student Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Student item)
        {
            throw new NotImplementedException();
        }
    }


    public interface IRepository<T>
    {
        void Add(T item);
        void Delete(int id);
        IEnumerable<T> All();
        T Get(int id);
        void Update(int id, T item);
    }
}
