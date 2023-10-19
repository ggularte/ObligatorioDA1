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
    public class Scene
    {
        public string SceneOwnerId { get; set; }

        public virtual Client SceneOwner { get; set; }

        string sceneName;

        public string SceneName
        {
            get
            {
                return sceneName;
            }
            set
            {
                SceneNameValidations(value);
                sceneName = value;
            }
        }

        public DateTime CreationDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string LastRender { get; set; }

        public double LookAtX { get; set; }
        public double LookAtY { get; set; }
        public double LookAtZ { get; set; }

        public double LookFromX { get; set; }
        public double LookFromY { get; set; }
        public double LookFromZ { get; set; }

        public int FoV { get; set; }

        public string ScenePreviewPath { get; set; }

        public double LensRadius { get; set; }

        public bool Blur { get; set; }

        public virtual ICollection<PositionatedModel> PositionatedModels { get; set; }

        public Scene()
        {
            this.PositionatedModels = new List<PositionatedModel>();
        }

        private static void SceneNameValidations(string SceneName)
        {
            if (string.IsNullOrWhiteSpace(SceneName))
            {
                throw new InvalidSceneNameException("El nombre de la escena no puede estar vacío o contener solo espacios en blanco.");
            }
            if (SceneName.Trim() != SceneName)
            {
                throw new InvalidSceneNameException("El nombre de la escena no puede contener espacios al principio o al final.");

            }
        }
    }
}
