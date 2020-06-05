using System;

namespace PuzzleGame
{
    public struct ObjectStruct
    {
        public int id { get; private set; }
        public ObjectType objectType { get; private set; }
        public Type factoryType { get; private set; }

        public ObjectStruct(int id, ObjectType objectType, Type factoryType)
        {
            this.id = id;
            this.objectType = objectType;
            this.factoryType = factoryType;
        }
    }
}
