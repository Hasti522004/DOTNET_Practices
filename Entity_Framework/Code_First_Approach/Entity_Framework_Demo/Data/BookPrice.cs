﻿namespace Entity_Framework_Demo.Data
{
    public class BookPrice
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public decimal Amount { get; set; }
        public int CurrencyId { get; set; }

        // Navigation Properties
        public Books Book { get; set; }
        public Currency Currency { get; set; }
    }
}
