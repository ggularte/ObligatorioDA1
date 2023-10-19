using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class LambertianMaterial:Material
    {
        public override string ToString()
        {
            return $"{this.MaterialName}";
        }
    }
}
