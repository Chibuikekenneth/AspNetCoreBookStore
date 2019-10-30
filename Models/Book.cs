using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreBookStore.Models
{
    public class Book
    {
        public int BookId {  get; set; }
        public String Name { get; set; }
        public string ShortDescription { get; set; }
    }
}
