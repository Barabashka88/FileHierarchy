using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
