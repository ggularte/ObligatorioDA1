using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Figure
    {
        public string FigureOwnerId { get; set; }

        public virtual Client FigureOwner { get; set; }

        string figureName;

        public string FigureName
        {
            get { return figureName; }
            set
            {
                FigureNameValidations(value);
                figureName = value;
            }
        }

        double radio;

        public double Radio
        {
            get { return radio; }
            set
            {
                FigureRadioValidations(value);
                radio = value;
            }
        }

        private static void FigureNameValidations(string figureName)
        {
            if (string.IsNullOrWhiteSpace(figureName))
            {
                throw new InvalidFigureNameException("El nombre de la figura no puede estar vacío o contener solo espacios en blanco.");
            }
            if (figureName.Trim() != figureName)
            {
                throw new InvalidFigureNameException("El nombre de la figura no puede contener espacios al principio o al final.");
            }
        }

        private static void FigureRadioValidations(double radio)
        {
            if (radio <= 0)
            {
                throw new InvalidFigureRadioException("El radio de la figura debe ser mayor que cero.");
            }
        }

        public override string ToString()
        {
            return $"{this.FigureName} (Radio: {this.Radio})";
        }
    }
}
