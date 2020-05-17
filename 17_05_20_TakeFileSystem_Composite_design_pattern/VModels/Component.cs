using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_05_20_TakeFileSystem_Composite_design_pattern.VModels
{
    public abstract class Component
    {
        public string FileOrDirectory { get; set; }

        public abstract void AddChild(Component c);

        public abstract void RemoveChild(Component c);

        public abstract IList<Component> GetChildren();

        public abstract Task<string> AllChildrenToString(string space);
    }
}
