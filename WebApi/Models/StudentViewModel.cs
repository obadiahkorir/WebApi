using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public AddressViewModel Address { get; set; }
        public StandardViewModel Standard { get; set; }
    }

    public class StandardViewModel
    {
        public int StandardId { get; set; }
        public string Name { get; set; }

        public ICollection<StudentViewModel> Students { get; set; }
    }

    public class AddressViewModel
    {
        public int StudentId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}