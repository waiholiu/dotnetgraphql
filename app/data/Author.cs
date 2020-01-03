using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app
{


    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }

        [Required]
        public string Name { set; get; }

        public DateTimeOffset DateOfBirth { set; get; }


        public List<Book> Books { get; set; }

    }
}
