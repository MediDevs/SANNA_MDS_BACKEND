using MDS.Infrastructure.DbUtility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MDS.DbContext.Entities
{
    public class Post : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public long BlogId { get; set; }
        public Blog Blog { get; set; }

        [Required]
        [ForeignKey("AuthorNavigation")]
        public long AuthorId { get; set; }
        public Author AuthorNavigation { get; set; }
    }
}
