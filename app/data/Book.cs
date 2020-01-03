using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }

        [Required]
        public string Title { set; get; }

        public DateTimeOffset DateOfPublication { set; get; }

        public int AuthorId { set; get; }

        public Author Author { get; set; }

        public List<SalesInvoice> SalesInvoices { get; set; }

    }
}