using System;

namespace FileHierarchy
{
    [Serializable]
    abstract class Entry
    {
        public string Name { get; }

        public Entry(string name)
        {
            Name = name;
        }

        public abstract void Add(Entry entry);
    }
}
