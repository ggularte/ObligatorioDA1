using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MetalicMaterial : Material
    {
        double difuminated;
        public double Difuminated
        {
            get { return difuminated; }

            set
            {
                MaterialDifuminationValidations(value);
                difuminated = value;
            }
        }

        private static void MaterialDifuminationValidations(double difuminated)
        {
            if (difuminated < 0)
            {
                throw new InvalidMaterialDifuminatedException("El valor del difuminado debe ser mayor de 0.");
            }
        }

        public override string ToString()
        {
            return $"{this.MaterialName} (Difuminado: {this.difuminated})";
        }
    }
}
