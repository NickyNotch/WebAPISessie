using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPISessie.Models
{
    public class Sessie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Submitted { get; set; }

        public Sessie(string name)
        {
            this.Name = name;
        }

        public Sessie()
        {

        }
    }
}
