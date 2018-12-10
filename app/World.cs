using System;
using System.Collections.Generic;

namespace app
{
    public class World
    {
        private List<Hitable> entities = new List<Hitable>();

        public World(params Hitable[] list)
        {
            entities.AddRange(list);
        }

        public bool Hit(Ray ray, float tMin, float tMax, ref HitRecord hitRecord)
        {            
            float closestSoFar = tMax;
            bool hitAnything = false;
            foreach (var entity in entities)
            {
                if (entity.DoesIntersect(ray, tMin, closestSoFar, ref hitRecord))
                {
                    hitAnything = true;
                    closestSoFar = hitRecord.t;
                }
            }
            return hitAnything;
        }
    }
}