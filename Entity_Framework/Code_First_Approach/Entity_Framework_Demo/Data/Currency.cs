﻿namespace Entity_Framework_Demo.Data
{
    public class Currency
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        // Navigation Property
        public ICollection<BookPrice> BookPrices { get; set; } = new List<BookPrice>();
    }
}
