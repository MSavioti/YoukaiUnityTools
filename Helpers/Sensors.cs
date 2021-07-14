using UnityEngine;

namespace YoukaiFox.Tools.Helpers
{
    public static class Sensors 
    {
        /// <summary>
        /// Generate a number <paramref name="numberOfPoints"/> of points
        /// separated by an even distance between themselves along a surface
        /// of bounds <paramref name="bounds"/> chosen based on the
        /// <paramref name="direction"/> parameter.
        /// <param name="numberOfPoints">If provided value is less than 3, it'll be increased to 3<param/>
        /// </summary>
        public static Vector2[] GetCastingOriginPoints(Bounds bounds, int numberOfPoints, EDirection direction, float offset = 0)
        {
            if (numberOfPoints < 3)
                numberOfPoints = 3;

            Vector2[] castingPoints = new Vector2[numberOfPoints];

            if (direction.IsVertical())
            {
                float initialPoint = bounds.min.x;
                float maxPoint = bounds.max.x;
                float distanceBetweenPoints = (maxPoint - initialPoint) / (numberOfPoints - 1);
                float y = direction == EDirection.Up ? bounds.max.y : bounds.min.y;

                for (int i = 0; i < numberOfPoints; i++)
                {
                    castingPoints[i] = new Vector2(initialPoint, y);
                    initialPoint += distanceBetweenPoints;
                }
            }
            else if (direction.IsHorizontal())
            {
                float initialPoint = bounds.min.y;
                float maxPoint = bounds.max.y;
                float distanceBetweenPoints = (maxPoint - initialPoint) / (numberOfPoints - 1);
                float x = direction == EDirection.Right ? bounds.max.x : bounds.min.x;

                for (int i = 0; i < numberOfPoints; i++)
                {
                    castingPoints[i] = new Vector2(x, initialPoint);
                    initialPoint += distanceBetweenPoints;
                }
            }
            else
            {
                throw new System.NotImplementedException();
            }

            return castingPoints;
        }
    }
}