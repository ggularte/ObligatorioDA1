using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Material
    {
        public string MaterialOwnerId { get; set; }

        public virtual Client MaterialOwner { get; set; }

        string materialName;

        public String MaterialName
        {
            get
            {
                return materialName;
            }
            set
            {
                MaterialNameValidations(value);
                materialName = value;
            }
        }

        public int ColorValue { get; set; }

        public Color Color
        {
            get { return Color.FromArgb(ColorValue); }
            set { ColorValue = value.ToArgb(); }
        }

        private static void MaterialNameValidations(string materialName)
        {
            if (string.IsNullOrWhiteSpace(materialName))
            {
                throw new InvalidMaterialNameException("El nombre del material no puede estar vacío o contener solo espacios en blanco.");
            }
            if (materialName.Trim() != materialName)
            {
                throw new InvalidMaterialNameException("El nombre del material no puede contener espacios al principio o al final.");

            }
        }
    }
}
