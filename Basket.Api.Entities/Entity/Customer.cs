using Basket.Api.Core.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Basket.Api.Entities.Entity
{
    public class Customer:IEntity
    {

        public Guid CustomerId { get; set; } 
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string Email { get;  set; }
        public Cart Cart { get;  set; }
        public List<Cart> Carts { get; set; }

        //public Customer(string firstName, string lastName, string email)
        //{
        //    FirstName = firstName;
        //    LastName = lastName;
        //    Email = email;
        //    Carts = new List<Cart>();
        //}
    }


}
