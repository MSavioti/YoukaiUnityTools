using UnityEngine;

namespace YoukaiFox.Tools.Helpers
{
    public enum EDirection
    {
        Up, Down, Right, Left, Forward, Backward, None
    }

    public enum EDirectionAxis
    {
        X, Y, Z
    }

    public static class Direction
    {
        public static EDirection FlipDirection(this EDirection direction)
        {
            switch (direction)
            {
                case EDirection.Right:
                    return EDirection.Left;
                case EDirection.Left:
                    return EDirection.Right;
                case EDirection.Up:
                    return EDirection.Down;
                case EDirection.Down:
                    return EDirection.Up;
                case EDirection.Forward:
                    return EDirection.Backward;
                case EDirection.Backward:
                    return EDirection.Forward;
                default:
                    return EDirection.None;
            }
        }

        public static bool IsHorizontal(this EDirection direction)
        {
            return (direction == EDirection.Right) || (direction == EDirection.Left);
        }

        public static bool IsVertical(this EDirection direction)
        {
            return (direction == EDirection.Up) || (direction == EDirection.Down);
        }

        public static bool IsZAxis(this EDirection direction)
        {
            return (direction == EDirection.Forward) || (direction == EDirection.Backward);
        }

        public static Vector2 ToVector2(this EDirection direction)
        {
            switch (direction)
            {
                case EDirection.Right:
                    return Vector2.right;
                case EDirection.Left:
                    return Vector2.left;
                case EDirection.Up:
                    return Vector2.up;
                case EDirection.Down:
                    return Vector2.down;
                default:
                    return Vector2.zero;
            }
        }

        public static Vector3 ToVector3(this EDirection direction)
        {
            switch (direction)
            {
                case EDirection.Right:
                    return Vector3.right;
                case EDirection.Left:
                    return Vector3.left;
                case EDirection.Up:
                    return Vector3.up;
                case EDirection.Down:
                    return Vector3.down;
                case EDirection.Forward:
                    return Vector3.forward;
                case EDirection.Backward:
                    return Vector3.back;
                default:
                    return Vector3.zero;
            }
        }

        /// <summary>
        /// Get a EDirection from a Vector2.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="priorityAxis">Decides which direction has more priority when axis values
        /// fall between more than one, like x = 1, y = 1 could be either UP or RIGHT.</param>
        /// <returns></returns>
        public static EDirection DirectionFromVector2(Vector2 vector, EDirectionAxis priorityAxis)
        {
            if (priorityAxis == EDirectionAxis.X)
            {
                if (vector.x > 0f)
                    return EDirection.Right;
                if (vector.x < 0f)
                    return EDirection.Left;
            }
            else if (priorityAxis == EDirectionAxis.Y)
            {
                if (vector.y > 0f)
                    return EDirection.Up;
                if (vector.y < 0f)
                    return EDirection.Down;
            }

            return EDirection.None;
        }

        public static bool Is2D(this EDirection self)
        {
            return self.IsHorizontal() || self.IsVertical();
        }

        public static bool Is3D(this EDirection self)
        {
            return self.IsHorizontal() || self.IsVertical() || self.IsZAxis();
        }

        public static EDirection Direction2dFromFloat(this float self, EDirectionAxis priorityAxis) 
        {
            if (self > 0f)
            {
                if (priorityAxis == EDirectionAxis.X)
                    return EDirection.Right;
                if (priorityAxis == EDirectionAxis.Y)
                    return EDirection.Up;
            }
            
            if (self < 0f)
            {
                if (priorityAxis == EDirectionAxis.X)
                    return EDirection.Left;
                if (priorityAxis == EDirectionAxis.Y)
                    return EDirection.Down;
            }

            return EDirection.None;
        }

        public static bool IsPositiveAxisValue(this EDirection self)
        {
            return self == EDirection.Up || self == EDirection.Right || self == EDirection.Forward;
        }
    }
}
