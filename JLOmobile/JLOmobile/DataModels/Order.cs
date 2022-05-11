using System;
using System.Collections.Generic;
using System.Text;

namespace JLOmobile.DataModels
{
    public class Order
    {
        public Order() { }

        public Order(int id, DateTime pickup) 
        {
            Id = id;
            Pickup = pickup;
        }
        public int Id { get; set; }
        public DateTime Pickup { get; set; }
    }
}
