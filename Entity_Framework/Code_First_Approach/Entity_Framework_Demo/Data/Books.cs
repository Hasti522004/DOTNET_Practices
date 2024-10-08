﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Entity_Framework_Demo.Data
{
    public class Books
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int NoOfPages { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int LanguageId { get; set; }

        //navigation Property
        public Language Language { get; set; }
        public ICollection<BookPrice> BookPrices { get; set; } = new List<BookPrice>();

    }
}
