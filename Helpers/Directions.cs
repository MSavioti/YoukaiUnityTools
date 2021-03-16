using UnityEngine;

namespace YoukaiFox.Tools.Helpers
{
    /// <summary>
    /// Basic class to help handling directions.
    /// </summary>
    public static class Directions 
    {
        public static readonly Vector2 UpRight = new Vector2(1, 1).normalized;
        public static readonly Vector2 UpLeft = new Vector2(-1, 1).normalized;
        public static readonly Vector2 DownRight = new Vector2(1, -1).normalized;
        public static readonly Vector2 DownLeft = new Vector2(-1, -1).normalized;

        public enum Direction
        {
            None, Up, Right, Forward, Down, Left, Back
        }

        public static Direction GetOppositeDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.None:
                    return Direction.None;
                case Direction.Up:
                    return Direction.Down;
                case Direction.Right:
                    return Direction.Left;
                case Direction.Forward:
                    return Direction.Back;
                case Direction.Down:
                    return Direction.Up;
                case Direction.Left:
                    return Direction.Right;
                case Direction.Back:
                    return Direction.Forward;
                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }
    
        public static Vector3 ToVector3(this Direction self)
        {
            switch (self)
            {
                case Direction.None:
                    return Vector3.zero;
                case Direction.Up:
                    return Vector3.up;
                case Direction.Right:
                    return Vector3.right;
                case Direction.Forward:
                    return Vector3.forward;
                case Direction.Down:
                    return Vector3.down;
                case Direction.Left:
                    return Vector3.left;
                case Direction.Back:
                    return Vector3.back;
                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        public static bool IsHorizontal(this Direction self)
        {
            return (self == Direction.Right) || (self == Direction.Left);
        }

        public static bool IsVertical(this Direction self)
        {
            return (self == Direction.Up) || (self == Direction.Down);
        }
    }
}