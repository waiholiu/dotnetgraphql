using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app
{
    public class SalesInvoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }

        [Required]
        public int Price { set; get; }

        public DateTimeOffset DateOfSale { set; get; }

        [Required]
        public string CustomerName { set; get; }

        public Book Book { get; set; }

        public int BookId { get; set; }

    }
}