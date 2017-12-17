using System;

namespace FileHierarchy
{
    [Serializable]
    abstract class Entry
    {
        protected string Name { get; }

        public Entry(string name)
        {
            Name = name;
        }

        public string GetName()
        {
            return Name;
        }

        public abstract void Add(Entry entry);
    }
}
