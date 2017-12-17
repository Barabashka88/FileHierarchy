using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHierarchy
{
    [Serializable]
    abstract class Entry
    {
        protected string Name;
        
        public Entry(string name)
        {
            Name = name;
        }

        public abstract void Add(Entry entry);
    }
}
