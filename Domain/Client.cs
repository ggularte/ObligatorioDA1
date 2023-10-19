using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain
{
    public class Client
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public DateTime RegisterDate { get; set; }

        public virtual ICollection<Figure> Figures { get; set; }

        public virtual ICollection<Material> Materials { get; set; }

        public virtual ICollection<Model> Models { get; set; }

        public virtual ICollection<Scene> Scenes { get; set; }

        public Client()
        {
            this.RegisterDate = DateTime.Now;
            this.Figures = new List<Figure>();
            this.Materials = new List<Material>();
            this.Models = new List<Model>();
            this.Scenes = new List<Scene>();
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
