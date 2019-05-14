using Siemens.Engineering.SW.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyBlocks
{
    /// <summary>
    /// Represents a TIA Portal library folder
    /// Can contain subfolders and plc blocks
    /// /// </summary>
    class Folder
    {
        public Folder(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
        public List<Folder> SubFolders { get; set; }
        public List<PlcBlock> Blocks { get; set; }
    }
}
