using Siemens.Engineering;
using Siemens.Engineering.HW;
using Siemens.Engineering.HW.Features;
using Siemens.Engineering.Library.MasterCopies;
using Siemens.Engineering.SW;
using Siemens.Engineering.SW.Blocks;
using Siemens.Engineering.SW.Tags;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace CopyBlocks
{
    public static class BlockManagement
    {   
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static TiaPortal StartTIA(object sender, EventArgs e)
        {
            return new TiaPortal(TiaPortalMode.WithUserInterface);
        }

        /// <summary>
        /// Open existing TIA Portal project
        /// </summary>
        /// <param name="ProjectPath"></param>
        public static Project OpenProject(string ProjectPath, TiaPortal TiaPortalInstance)
        {
            Project projectInstance;
            try
            {
                projectInstance = TiaPortalInstance.Projects.Open(new FileInfo(ProjectPath));
                Globals.Log("Project " + ProjectPath + " opened");
            }
            catch (Exception ex)
            {
                projectInstance = null;
                Globals.Log("Error while opening project: " + ProjectPath + " - " + ex.Message);
            }

            return projectInstance;
        }

        /// <summary>
        /// Search project library for the block required and returns it
        /// </summary>
        /// <param name="libraryFolder">Folder of the project library to search in</param>
        /// <param name="blockName">Name of the block to be search for</param>
        /// <returns>Block if found, null otherwise</returns>
        public static MasterCopy GetMasterCopy(MasterCopyFolder libraryFolder, string blockName)
        {
            // look for block in current folder
            foreach (var masterCopy in libraryFolder.MasterCopies)
            {
                if (masterCopy.Name.Equals(blockName))
                {
                    Globals.LogVerbose("Block to be copied found in " + libraryFolder.Name);
                    return masterCopy;
                }
            }

            // if not in this folder check subfolders
            foreach (var subfolder in libraryFolder.Folders)
            {
                MasterCopy result = GetMasterCopy(subfolder, blockName);

                if (result != null)
                    return result;
            }

            Globals.LogVerbose("Block to be copied not found");

            return null;
        }

        /// <summary>
        /// Delete block from given folder
        /// Overloaded to accept PlcBlockUserGroup argument
        /// </summary>
        /// <param name="blockName">Name of the block to be deleted</param>
        /// <param name="software">Software on which to look for the block</param
        public static bool DeleteBlock(string blockName, PlcBlockUserGroup software)
        {
            PlcBlock blockToDelete = null;

            foreach (PlcBlock block in software.Blocks)
            {
                if (blockName.Equals(block.Name))
                    blockToDelete = block;
            }

            if (blockToDelete != null)
            {
                blockToDelete.Delete();

                Globals.Log("Block " + blockName + " to be deleted found in " + software.Name + " folder");

                return true;
            }
            else
            {
                Globals.LogVerbose("Block " + blockName + " not found in " + software.Name + " folder");

                // if block was not found in current group check subgroups
                foreach (PlcBlockUserGroup group in software.Groups)
                {
                    if (DeleteBlock(blockName, group))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Delete block from given folder
        /// Overloaded to accept PlcBlockSystemGroup argument
        /// </summary>
        /// <param name="blockName">Name of the block to be deleted</param>
        /// <param name="software">Software on which to look for the block</param
        public static bool DeleteBlock(string blockName, PlcBlockSystemGroup software)
        {
            PlcBlock blockToDelete = null;

            foreach (PlcBlock block in software.Blocks)
            {
                if (blockName.Equals(block.Name))
                    blockToDelete = block;
            }

            if (blockToDelete != null)
            {
                blockToDelete.Delete();

                Globals.Log("Block " + blockName + " to be deleted found in " + software.Name + " folder");

                return true;
            }
            else
            {
                Globals.LogVerbose("Block " + blockName + " not found in " + software.Name + " folder");

                // if block was not found in current group check subgroups
                foreach (PlcBlockUserGroup group in software.Groups)
                {
                    if (DeleteBlock(blockName, group))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Copy block from provided project library to folder in provided plc software object
        /// Overloaded to accept PlcBlockUserGroup argument
        /// </summary>
        /// <param name="blockName">Name of the block to be copied</param>
        /// <param name="libraryFolder">Project library folder with origin block</param>
        /// <param name="software">Software to copy the block into</param>
        /// <param name="destFolder">Destination folder on which to copy the block</param>
        /// <returns>True if copied, false otherwise</returns>
        public static bool CopyBlockToFolder(string blockName, MasterCopyFolder libraryFolder, PlcBlockUserGroup software, string destFolder)
        {
            // checks if it's already on the right folder to proceed with the copy
            if (software.Name.Equals(destFolder))
            {
                Globals.LogVerbose("Destination folder found");

                // delete block if it already exists
                DeleteBlock(blockName, software);

                // create new block from library
                software.Blocks.CreateFrom(GetMasterCopy(libraryFolder, blockName));
                Globals.Log("Block copied successfully");
                return true;
            }

            // if it's not in the right folder, recursively check subfolders
            foreach (var group in software.Groups)
            {
                Globals.LogVerbose("Checking " + software.Name + " subfolders");
                if (CopyBlockToFolder(blockName, libraryFolder, group, destFolder))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Copy block from provided project library to folder in provided plc software object
        /// Overloaded to accept PlcBlockSystemGroup argument
        /// </summary>
        /// <param name="blockName">Name of the block to be copied</param>
        /// <param name="libraryFolder">Project library folder with origin block</param>
        /// <param name="software">Software to copy the block into</param>
        /// <param name="destFolder">Destination folder on which to copy the block</param>
        /// <returns>True if copied, false otherwise</returns>
        public static bool CopyBlockToFolder(string blockName, MasterCopyFolder libraryFolder, PlcBlockSystemGroup software, string destFolder)
        {
            // if software is of PlcBlockSystemGroup it means it's on the PLC blocks root folder
            // library blocks to be copied to root folder are inside 'PLC' folder
            // checks if library block is to be copied to root
            if (destFolder.Equals("PLC"))
            {
                Globals.LogVerbose("Destination folder found");

                // delete block if it already exists
                DeleteBlock(blockName, software);

                // create new block from library
                software.Blocks.CreateFrom(GetMasterCopy(libraryFolder, blockName));
                Globals.Log("Block copied successfully");
                return true;
            }

            // if library block is not to be copied to root, recursively check subfolders
            foreach (var group in software.Groups)
            {
                Globals.LogVerbose("Checking " + software.Name + " subfolders");
                if (CopyBlockToFolder(blockName, libraryFolder, group, destFolder))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Read project library master copies folder
        /// </summary>
        /// <param name="masterCopiesFolder"></param>
        /// <param name="path"></param>
        /// <returns>String containing the block name and parent folder - Folder/BlockName</returns>
        public static List<string> ReadProjectLibrary(MasterCopyFolder masterCopiesFolder, string path)
        {
            // check we have some master copies folder to work with
            if (masterCopiesFolder == null)
                throw new ArgumentNullException(nameof(masterCopiesFolder), "Parameter is null");

            var masterCopies = new List<string>();

            // Add new elements to list
            foreach (var mCopy in masterCopiesFolder.MasterCopies)
            {
                path = masterCopiesFolder.Name + "/" + mCopy.Name;
                masterCopies.Add(path);
            }

            // Check for elements in subfolders and add them to the list too
            foreach (var subfolder in masterCopiesFolder.Folders)
            {
                masterCopies.AddRange(ReadProjectLibrary(subfolder, path));
            }

            return masterCopies;
        }

        /// <summary>
        /// Get software object from provided DeviceItem
        /// </summary>
        /// <param name="device"></param>
        /// <returns>PlcSoftware object</returns>
        public static PlcSoftware GetSoftwareFrom(DeviceItem device)
        {
            SoftwareContainer softwareContainer = ((IEngineeringServiceProvider)device).GetService<SoftwareContainer>();
            if (softwareContainer != null)
            {
                return softwareContainer.Software as PlcSoftware;
            }

            return null;
        }

        /// <summary>
        /// Reads the blocks in the provided software group
        /// Overloaded to accept PlcBlockUserGroup argument
        /// </summary>
        /// <param name="software"></param>
        /// <returns>List with all found block names</returns>
        public static List<string> ReadPlcBlocks(PlcBlockUserGroup software)
        {
            var blocks = new List<string>();

            // get blocks in current folder/group
            foreach (var block in software.Blocks)
            {
                // add them to list
                string blockType = block.GetType().ToString();
                blockType = blockType.Substring(blockType.LastIndexOf('.') + 1);

                blocks.Add(block.Name + " - " + blockType + " - " + block.Number);
            }

            // get also blocks in subfolders
            foreach (var group in software.Groups)
            {
                blocks.AddRange(ReadPlcBlocks(group));
            }

            return blocks;
        }

        /// <summary>
        /// Reads the blocks in the provided software group
        /// Overloaded to accept PlcBlockSystemGroup argument
        /// </summary>
        /// <param name="software"></param>
        /// <returns>List with all found block namesturns>
        public static List<string> ReadPlcBlocks(PlcBlockSystemGroup software)
        {
            var blocks = new List<string>();
            
            // get blocks in current folder/group
            foreach (var block in software.Blocks)
            {
                // add them to list
                string blockType = block.GetType().ToString();
                blockType = blockType.Substring(blockType.LastIndexOf('.') + 1);

                blocks.Add(block.Name + " - " + blockType + " - " + block.Number);
            }

            // get also blocks in subfolders
            foreach (var group in software.Groups)
            {
                blocks.AddRange(ReadPlcBlocks(group));
            }

            return blocks;
        }

        /// <summary>
        /// Copy provided tag table from project library to provided destination folder in plc
        /// </summary>
        public static bool CopyTagTableToFolder(string tagTableName, MasterCopyFolder libraryFolder, PlcTagTableGroup tagGroup, string destFolder)
        {
            // check if it's already on the right folder to proceed with the copy
            if (tagGroup.Name.Equals(destFolder))
            {
                Globals.LogVerbose("Destination folder found");
                // delete existing tag table if already exists
                DeleteTagTable(tagTableName, tagGroup);

                // create new tag table from project library
                tagGroup.TagTables.CreateFrom(GetMasterCopy(libraryFolder, tagTableName));
                Globals.Log("Tag table copied successfully");
                return true;
            }

            // if it's not in the right folder, recursively check subfolders
            foreach (PlcTagTableGroup group in tagGroup.Groups)
            {
                Globals.Log("Checking " + group.Name + " subfolders");
                if (CopyTagTableToFolder(tagTableName, libraryFolder, group, destFolder))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Delete provided tag table from plc code
        /// </summary>
        /// <param name="tagTableName"></param>
        /// <param name="tagGroup"></param>
        /// <param name="log"></param>
        public static void DeleteTagTable(string tagTableName, PlcTagTableGroup tagGroup)
        {
            PlcTagTable tagTableToDelete = null;

            foreach (PlcTagTable tagTable in tagGroup.TagTables)
            {
                if (tagTableName.Equals(tagTable.Name))
                    tagTableToDelete = tagTable;
            }

            if (tagTableToDelete != null)
            {
                tagTableToDelete.Delete();

                Globals.Log("Tag table " + tagTableName + " to be deleted found in " + tagGroup.Name + " tag table folder");
            }
            else
            {
                Globals.LogVerbose("Tag table " + tagTableName + " not found in " + tagGroup.Name + " tag table folder");

                // if tag table was not found in current group check subfolders
                foreach (PlcTagTableGroup group in tagGroup.Groups)
                {
                    DeleteTagTable(tagTableName, group);
                }
            }
        }

    }
}
