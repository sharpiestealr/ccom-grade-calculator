using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redacao
{
    public class Article
    {
        public bool committee;
        public double grammar, writing;

        public Article(bool committee, double grammar, double writing)
        {
            this.committee = committee;
            this.grammar = grammar;
            this.writing = writing;
        }
    }
}
