using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasteTrove.Domain
{
    public class Recipe
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public Guid CategoryId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Category? Category { get; set; }
        public User? User { get; set; }
    }
}
