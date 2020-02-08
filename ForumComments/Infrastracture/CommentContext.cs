using ForumComments.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ElifTechProject.Data
{
    public class CommentContext : DbContext
    {
        public CommentContext() : base("Filename=ForumDb")
        {
        }

        public DbSet<Comment> Comments { get; set; }
    }
}
