using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Model
{
    public class Car
    {
        [Key]
        public Guid ID { get; set; }

        public string Name { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

    }
}
