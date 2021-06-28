using System;
using System.ComponentModel.DataAnnotations;

namespace BasicWebApi.Data
{
    public class PersonEntity
    {
        public DateTime CreatedDateTime { get; set; }
        public DateTime ModifiedDateTime {get;set;}

        [Key]
        public string Name { get; set; }
        public int Age { get; set; }
    }
}