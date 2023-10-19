using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RandomProvider
    {
        private bool returnFixed = false;
        private Random random = new Random();

        public RandomProvider(bool returnFixed, Random random)
        {
            this.returnFixed = returnFixed;
            this.random = random;
        }

        public double getRandom()
        {
            if (returnFixed)
            {
                return 0.5;
            }
            return random.NextDouble();
        }
    }

    public class GraphicEngine
    {
        private RandomProvider randomProvider;

        public GraphicEngine(RandomProvider randomProvider)
        {
            this.randomProvider = randomProvider;
        }

        public class Sphere
        {
            public Vector3D center;
            public double radius;
            public Vector3D attenuation;
            public string material;
            public double roughness;

            public Sphere(Vector3D center, double radius, Vector3D attenuation, string material, double roughness = 0)
            {
                this.center = center;
                this.radius = radius;
                this.attenuation = attenuation;
                this.material = material;
                this.roughness = roughness;
            }
        }

        public class HitRecord
        {
            public double t;
            public Vector3D intersection;
            public Vector3D normal;
            public Vector3D attenuation;
            public string material;
            public double roughness;

            public HitRecord(double t, Vector3D intersection, Vector3D normal, Vector3D attenuation, string material, double roughness = 0)
            {
                this.t = t;
                this.intersection = intersection;
                this.normal = normal;
                this.attenuation = attenuation;
                this.material = material;
                this.roughness = roughness;
            }
        }

        public class Camera
        {
            public Vector3D _origin;
            public Vector3D _cornerLowerLeft;
            public Vector3D _horizontal;
            public Vector3D _vertical;
            public double _lens_radius;
            Vector3D vectorW;
            Vector3D vectorU;
            Vector3D vectorV;

            public Camera(Vector3D vectorLookFrom, Vector3D vectorLookAt, Vector3D vectorUp, int fieldOfView, double aspectRatio, string version, double aperture = 0.1, double focalDistance = 0)
            {
                double theta = (fieldOfView * Math.PI / 180);
                double heightHalf = Math.Tan((theta / 2));
                double widthHalf = aspectRatio * heightHalf;
                _origin = vectorLookFrom;
                vectorW = vectorLookFrom.Subtract(vectorLookAt).GetUnit();
                vectorU = vectorUp.Cross(vectorW).GetUnit();
                vectorV = vectorW.Cross(vectorU);
                if (version == "old")
                {
                    _cornerLowerLeft = this._origin.Subtract(vectorU.Multiply(widthHalf)).Subtract(vectorV.Multiply(heightHalf)).Subtract(vectorW);
                    _horizontal = vectorU.Multiply(2 * widthHalf);
                    _vertical = vectorV.Multiply(2 * heightHalf);
                }
                else if (version == "new")
                {
                    _lens_radius = aperture / 2;
                    _cornerLowerLeft = this._origin.Subtract(vectorU.Multiply(widthHalf * focalDistance)).Subtract(vectorV.Multiply(heightHalf * focalDistance)).Subtract(vectorW.Multiply(focalDistance));
                    _horizontal = vectorU.Multiply(2 * widthHalf * focalDistance);
                    _vertical = vectorV.Multiply(2 * heightHalf * focalDistance);
                }
            }

            public Ray GetRay(double u, double v, GraphicEngine graphicEngine)
            {
                Vector3D vectorRandom = graphicEngine.GetRandomInUnitSphere().Multiply(_lens_radius);
                Vector3D vectorOffset = vectorU.Multiply(vectorRandom.X).Add(vectorV.Multiply(vectorRandom.Y));
                Vector3D horizontalPosition = _horizontal.Multiply(u);
                Vector3D verticalPosition = _vertical.Multiply(v);
                return new Ray(_origin.Add(vectorOffset), _cornerLowerLeft.Add(horizontalPosition.Add(verticalPosition)).Subtract(_origin).Subtract(vectorOffset));
            }


        }

        public List<List<Vector3D>> SavePixel(int row, int column, Vector3D pixelRGB, int resolutionY, List<List<Vector3D>> pixels)
        {
            int posX = column;
            int posY = resolutionY - row - 1;
            if (posY < resolutionY)
            {
                if (posX == 0)
                {
                    pixels.Add(new List<Vector3D>());
                }
                pixels[posY].Add(pixelRGB);
            }
            else
            {
                throw new Exception("Pixel Overflow Error");
            }
            return pixels;
        }

        public Vector3D ShootRay(Ray ray, int depth, List<Sphere> elements)
        {
            HitRecord hitRecord = null;
            double tMax = Math.Pow(10, 38);
            foreach (Sphere aSphere in elements)
            {
                HitRecord hit = IsSphereHit(aSphere, ray, 0.001, tMax);
                if (hit != null)
                {
                    hitRecord = hit;
                    tMax = hit.t;
                }
            }
            if (hitRecord != null)
            {
                if (depth > 0)
                {
                    Ray newRay = null;
                    if (hitRecord.material == "lambertian")
                    {
                        newRay = LamberitanScatter(ray, hitRecord);
                    }
                    else if (hitRecord.material == "metalic")
                    {
                        newRay = MetalicScatter(ray, hitRecord);
                        if (newRay == null) return new Vector3D(0, 0, 0);
                    }

                    Vector3D color = ShootRay(newRay, depth - 1, elements);
                    Vector3D attenuation = hitRecord.attenuation;
                    return new Vector3D(color.X * attenuation.X, color.Y * attenuation.Y, color.Z * attenuation.Z);
                }
                else
                {
                    return new Vector3D(0, 0, 0);
                }
            }
            else
            {
                Vector3D vectorDirectionUnit = ray.Direction.GetUnit();
                double posY = 0.5 * (vectorDirectionUnit.Y + 1);
                Vector3D colorStart = new Vector3D(1, 1, 1);
                Vector3D colorEnd = new Vector3D(0.5, 0.7, 1.0);
                return colorStart.Multiply(1 - posY).Add(colorEnd.Multiply(posY));
            }
        }

        public static HitRecord IsSphereHit(Sphere aSphere, Ray ray, double tMin, double tMax)
        {
            Vector3D vectorOriginCenter = ray.Origin.Subtract(aSphere.center);
            double a = ray.Direction.Dot(ray.Direction);
            double b = vectorOriginCenter.Dot(ray.Direction) * 2;
            double c = vectorOriginCenter.Dot(vectorOriginCenter) - (aSphere.radius * aSphere.radius);
            double discriminant = (b * b) - (4 * a * c);
            if (discriminant < 0)
            {
                return null;
            }
            else
            {
                double t = ((-1 * b) - Math.Sqrt(discriminant)) / (2 * a);
                Vector3D intersectionPoint = ray.PointAt(t);
                Vector3D normal = intersectionPoint.Subtract(aSphere.center).Divide(aSphere.radius);
                if (t < tMax && t > tMin)
                {
                    return new HitRecord(t, intersectionPoint, normal, aSphere.attenuation, aSphere.material, aSphere.roughness);
                }
                else
                {
                    return null;
                }
            }
        }

        public Vector3D GetRandomInUnitSphere()
        {
            Vector3D vector;
            do
            {
                Vector3D vectorTemp = new Vector3D(randomProvider.getRandom(), randomProvider.getRandom(), randomProvider.getRandom());
                vector = vectorTemp.Multiply(2).Subtract(new Vector3D(1, 1, 1));
            } while (vector.SquaredLength() >= 1);
            return vector;
        }

        public Ray LamberitanScatter(Ray rayIn, HitRecord hitRecord)
        {
            Vector3D newVectorPoint = hitRecord.intersection
                .Add(hitRecord.normal)
                .Add(GetRandomInUnitSphere());
            Vector3D newVector = newVectorPoint.Subtract(hitRecord.intersection);
            return new Ray(hitRecord.intersection, newVector);
        }

        public Ray MetalicScatter(Ray rayIn, HitRecord hitRecord)
        {
            Ray rayScattered = new Ray(new Vector3D(0, 0, 0), new Vector3D(0, 0, 0));
            Vector3D vectorReflected = Reflect(rayIn.Direction.GetUnit(), hitRecord.normal);
            rayScattered.Origin = hitRecord.intersection;
            rayScattered.Direction = vectorReflected.Add(GetRandomInUnitSphere().Multiply(hitRecord.roughness));
            if (rayScattered.Direction.Dot(hitRecord.normal) > 0)
            {
                return rayScattered;
            }
            else
            {
                return null;
            }
        }

        public Vector3D Reflect(Vector3D vectorV, Vector3D vectorN)
        {
            double dotVN = vectorV.Dot(vectorN);
            return vectorV.Subtract(vectorN.Multiply(2 * dotVN));
        }
    }
}
