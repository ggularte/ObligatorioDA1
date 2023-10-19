using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Ray
    {
        private Vector3D _origin;
        private Vector3D _direction;

        public Ray(Vector3D vectorOrigin, Vector3D vectorDirection)
        {
            _origin = vectorOrigin;
            _direction = vectorDirection;
        }

        public Vector3D Origin
        {
            get { return _origin; }
            set { _origin = value; }
        }

        public Vector3D Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }

        public Vector3D PointAt(double iPosX)
        {
            return _origin.Add(_direction.Multiply(iPosX));
        }
    }
}
