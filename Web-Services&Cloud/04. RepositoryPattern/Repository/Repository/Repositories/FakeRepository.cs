using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    class FakeRepository : IRepository<Student>
    {
        List<Student> students;

        public void Add(Student item)
        {
            students.Add(item);
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
}
