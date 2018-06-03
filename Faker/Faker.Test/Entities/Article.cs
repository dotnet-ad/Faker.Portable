using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mocker.Entities
{
    public class Article
    {
        public String Title { get; set; }

        public String Description { get; set; }

        public Author Author { get; set; }
    }
}
