using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_05_20_TakeFileSystem_Composite_design_pattern.VModels
{

    /// <summary>
    /// Composite And Builder Design Pattern With A Tree
    /// https://www.c-sharpcorner.com/article/composite-design-pattern/
    /// </summary>
    public abstract class Component
    {
        public string FileOrDirectory { get; protected set; }

        public long LengthOfFileOrDirectory { get; set; }

        public abstract void AddChild(Component c);

        public abstract void RemoveChild(Component c);

        public abstract IList<Component> GetChildren();

        public abstract Task<string> AllChildrenToString(string space);

        public abstract long GetSize();
    }
}
