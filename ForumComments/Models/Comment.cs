using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumComments.Models
{
    public class Comment : IEntity
    {
        public int Id { get; set; }
        public bool IsPositive { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string Country { get; set; }
        public DateTime TimeOfCreation { get; set; }
    }
}