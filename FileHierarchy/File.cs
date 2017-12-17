using System;

namespace FileHierarchy
{
    [Serializable]
    class File : Entry
    {
        private string _content;
        public File(string name, string content)
            : base(name)
        {
            _content = content;
        }

        public override void Add(Entry file)
        {
            throw new NotImplementedException();
        }
    }
}
