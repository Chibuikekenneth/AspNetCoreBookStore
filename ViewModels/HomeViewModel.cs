using System;
using System.Collections.Generic;
using AspNetCoreBookStore.Models;

namespace AspNetCoreBookStore.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Book> bookOfTheWeek;
    }
}