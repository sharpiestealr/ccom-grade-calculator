using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace delegado
{
    public class Delegado
    {
        public string name;
        public float proactivity;
        public double quality, attitude, dpo, final;
        
        public Delegado(string name, float proactivity, double quality, double attitude, double dpo, double final)
        {
            this.name = name;
            this.proactivity = proactivity;
            this.quality = quality;
            this.attitude = attitude;
            this.dpo = dpo;
            this.final = final;
        }

    }

}
