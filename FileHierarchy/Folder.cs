using System;
using System.Collections.Generic;

namespace FileHierarchy
{
    [Serializable]
    class Folder :Entry
    {
        private List<Entry> _children = new List<Entry>();

        public Folder(string name):base(name)
        {
                
        }

        public override void Add(Entry folder)
        {
            _children.Add(folder);
        }
    }
}
