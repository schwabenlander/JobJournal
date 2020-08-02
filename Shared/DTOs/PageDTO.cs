using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace JobJournal.Shared.DTOs
{
    public class PageDTO<T>
    {
        public List<T> Items { get; set; }

        public int TotalItems { get; set; }

        public int TotalPages { get; set; }

        public int CurrentPage { get; set; }

        public int ItemsPerPage { get; set; }
    }
}
