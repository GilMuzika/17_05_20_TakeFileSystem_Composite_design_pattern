using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_05_20_TakeFileSystem_Composite_design_pattern.VModels
{
    public class Branch : Component
    {      

        public Branch(string directory)
        {
            FileOrDirectory = directory;
        }

        private IList<Component> _children = new List<Component>();

        public override void AddChild(Component c)
        {
            _children.Add(c);
        }

        public override IList<Component> GetChildren()
        {
            return _children;
        }

        public override void RemoveChild(Component c)
        {
            _children.Remove(c);
        }

        public async override Task<string> AllChildrenToString(string space)
        {
            space += $" ";
            return await Task.Run(async() => 
            {

                string toReturn = string.Empty;

                toReturn += space + FileOrDirectory + "\n" + Environment.NewLine;
                foreach (Component s in _children)
                {                    
                    toReturn += space + await s.AllChildrenToString(space) + "\n" + Environment.NewLine;
                }

                return toReturn;
            });
        }
    }
}
