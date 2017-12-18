using System;

namespace FileHierarchy
{
    [Serializable]
    class File : Entry
    {
        public string Content { get; }

        public File(string name, string content)
            : base(name)
        {
            Content = content;
        }

        public override void Add(Entry file)
        {
            throw new NotImplementedException();
        }
    }
}
