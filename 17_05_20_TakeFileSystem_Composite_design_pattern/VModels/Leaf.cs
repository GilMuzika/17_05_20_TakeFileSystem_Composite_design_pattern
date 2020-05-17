using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_05_20_TakeFileSystem_Composite_design_pattern.VModels
{
    public class Leaf : Component
    {         

        public Leaf(string file)
        {
            FileOrDirectory = file;
        }

        public override void AddChild(Component c)
        {
            throw new NotSupportedException("Leaf elemnt cannot add child!");
        }

        public override IList<Component> GetChildren()
        {
            return null;
        }

        public override void RemoveChild(Component c)
        {
            throw new NotSupportedException("Leaf elemnt cannot remove child!");
        }

        public async override Task<string> AllChildrenToString(string space)
        {
            return await Task.Run(() => { return space + FileOrDirectory + "\n" + Environment.NewLine; }); 
        }
    }
}
