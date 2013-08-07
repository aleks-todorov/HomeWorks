using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebRepository.Models;
using WebRepositry.Models;

namespace WebRepository.Controllers
{
    public class ValuesController : ApiController
    {
        IRepository<Student> studentRepo;

        public ValuesController()
        {
            studentRepo = new InMemmoryRepository();
        }

        public ValuesController(InMemmoryRepository repository)
        {
            this.studentRepo = repository;
        }

        //public IEnumerable<Student> Get()
        //{
        //    return this.studentRepo.All();
        //}

        //public IEnumerable<string> Get()
        //{
        //    studentRepo.Add(new Student());

        //    return this.studentRepo.All();
        //}
    }
}