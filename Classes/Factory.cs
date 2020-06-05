using System;

namespace PuzzleGame
{
    public static class BaseObjectFacotry
    {
        public static dynamic Create(Type type)
        {
            return (BaseObject)Activator.CreateInstance(type);
        }
    }
}