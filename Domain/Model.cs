using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Model
    {
        public string ModelOwnerId { get; set; }

        public virtual Client ModelOwner { get; set; }

        string modelName;

        public string ModelName
        {
            get
            {
                return modelName;
            }
            set
            {
                ModelNameValidations(value);
                modelName = value;
            }
        }

        public string ModelFigureName { get; set; }
        public string ModelFigureOwnerId { get; set; }

        public virtual Figure ModelFigure { get; set; }

        public string ModelMaterialName { get; set; }
        public string ModelMaterialOwnerId { get; set; }

        public virtual Material ModelMaterial { get; set; }

        public string ModelPreviewPath { get; set; }

        private static void ModelNameValidations(string modelName)
        {
            if (string.IsNullOrWhiteSpace(modelName))
            {
                throw new InvalidModelNameException("El nombre del modelo no puede estar vacío o contener solo espacios en blanco.");
            }
            if (modelName.Trim() != modelName)
            {
                throw new InvalidModelNameException("El nombre del modelo no puede contener espacios al principio o al final.");

            }
        }
    }
}
