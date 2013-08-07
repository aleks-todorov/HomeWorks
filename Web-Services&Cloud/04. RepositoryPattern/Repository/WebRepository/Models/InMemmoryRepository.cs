using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebRepository.Models;
using WebRepositry.Models;

namespace WebRepository.Models
{
    public class InMemmoryRepository : IRepository<Student>
    {
        private List<Student> students = new List<Student>();



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