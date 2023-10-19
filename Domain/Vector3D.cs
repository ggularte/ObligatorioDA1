using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Vector3D
    {
        private double _x;
        private double _y;
        private double _z;

        public Vector3D(double x, double y, double z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        public double X
        {
            get { return _x; }
            set { _x = value; }
        }

        public double Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public double Z
        {
            get { return _z; }
            set { _z = value; }
        }

        public int Red
        {
            get { return Math.Abs((int)Math.Round(_x * 255)); }
        }

        public int Green
        {
            get { return Math.Abs((int)Math.Round(_y * 255)); }
        }

        public int Blue
        {
            get { return Math.Abs((int)Math.Round(_z * 255)); }
        }

        public Vector3D Add(Vector3D other)
        {
            return new Vector3D(_x + other.X, _y + other.Y, _z + other.Z);
        }

        public Vector3D Subtract(Vector3D other)
        {
            return new Vector3D(_x - other.X, _y - other.Y, _z - other.Z);
        }

        public Vector3D Multiply(double scalar)
        {
            return new Vector3D(_x * scalar, _y * scalar, _z * scalar);
        }

        public Vector3D Divide(double scalar)
        {
            return new Vector3D(_x / scalar, _y / scalar, _z / scalar);
        }

        public void AddTo(Vector3D other)
        {
            _x += other.X;
            _y += other.Y;
            _z += other.Z;
        }

        public void SubtractFrom(Vector3D other)
        {
            _x -= other.X;
            _y -= other.Y;
            _z -= other.Z;
        }

        public void ScaleUpBy(double scalar)
        {
            _x *= scalar;
            _y *= scalar;
            _z *= scalar;
        }

        public void ScaleDownBy(double scalar)
        {
            _x /= scalar;
            _y /= scalar;
            _z /= scalar;
        }

        public Vector3D GetUnit()
        {
            return Divide(Length());
        }

        public double Dot(Vector3D other)
        {
            return _x * other.X + _y * other.Y + _z * other.Z;
        }

        public Vector3D Cross(Vector3D other)
        {
            double x = _y * other.Z - _z * other.Y;
            double y = _z * other.X - _x * other.Z;
            double z = _x * other.Y - _y * other.X;
            return new Vector3D(x, y, z);
        }

        public double Length()
        {
            return Math.Sqrt(SquaredLength());
        }

        public double SquaredLength()
        {
            return _x * _x + _y * _y + _z * _z;
        }
    }
}
