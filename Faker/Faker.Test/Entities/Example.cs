using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mocker.Entities
{
    public class Example
    {
        public String Sentence { get; set; }

        public bool Bool { get; set; }

        public int Integer { get; set; }

        public long Timestamp { get; set; }

        public double Double { get; set; }

        public float Float { get; set; }

        public byte Byte { get; set; }

        public byte[] ByteArray { get; set; }

        public float[,] FloatArray { get; set; }

        public DateTime DateTime { get; set; }

        public Example Child { get; set; }

        public List<Author> List { get; set; }

        public IEnumerable<Article> Enumerable { get; set; }

        public Stack<Author> Stack { get; set; }

        public ObservableCollection<Author> ObservableCollection { get; set; }

        public Dictionary<String,Author> Dictionnary { get; set; }
    }
}
