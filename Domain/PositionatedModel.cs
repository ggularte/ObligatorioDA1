using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PositionatedModel
    {
        public int PositionatedModelId { get; set; }

        public double PositionX { get; set; }

        public double PositionY { get; set; }

        public double PositionZ { get; set; }

        public string ModelName { get; set; }
        public string ModelOwnerId { get; set; }

        public virtual Model BaseModel { get; set; }
    }
}
