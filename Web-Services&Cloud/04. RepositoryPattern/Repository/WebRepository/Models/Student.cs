using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WebRepository.Models
{
    [DataContract]
    public class Student
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        public int Age { get; set; }
    }
}