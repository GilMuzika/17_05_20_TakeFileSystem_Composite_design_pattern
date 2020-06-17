using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_05_20_TakeFileSystem_Composite_design_pattern.VModels
{
    /// <summary>
    /// leaf class
    /// </summary>
    public class Leaf : Component
    {
        private string _exceptionMessage;

        public Leaf(string file)
        {
            FileOrDirectory = file;
            LengthOfFileOrDirectory = GetSize();
        }

        public override void AddChild(Component c)
        {
            throw new NotSupportedException("Leaf element cannot add child!");
        }

        public override IList<Component> GetChildren()
        {
            return null;
        }

        public override void RemoveChild(Component c)
        {
            throw new NotSupportedException("Leaf element cannot remove child!");
        }

        public async override Task<string> AllChildrenToString(string space)
        {            
            return await Task.Run(() => { return $"{space}{FileOrDirectory}, size: {FileSizeFormatter.FormatSize(LengthOfFileOrDirectory, _exceptionMessage)}\n" + Environment.NewLine; }); 
        }

        public override long GetSize()
        {
            try
            {
                return new System.IO.FileInfo(FileOrDirectory).Length;
            }
            catch(Exception ex)
            {
                _exceptionMessage = ex.Message;
                return 0;
            }
        }
    }
}
