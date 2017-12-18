using System;
using System.Collections.Generic;

namespace FileHierarchy
{
    [Serializable]
    class Folder : Entry
    {
        public List<Entry> Children { get; }

        public Folder(string name) : base(name)
        {
            Children = new List<Entry>();
        }

        public override void Add(Entry folder)
        {
            Children.Add(folder);
        }
    }
}
