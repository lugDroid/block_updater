using Siemens.Engineering;
using Siemens.Engineering.HW;
using Siemens.Engineering.HW.Features;
using Siemens.Engineering.Library.MasterCopies;
using Siemens.Engineering.SW;
using Siemens.Engineering.SW.Blocks;
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
        public static Project OpenProject(string ProjectPath, TiaPortal TiaPortalInstance, TextBox log)
        {
            Project projectInstance;
            try
            {
                projectInstance = TiaPortalInstance.Projects.Open(new FileInfo(ProjectPath));
                log.AppendText("Project " + ProjectPath + " opened");
                log.AppendText(Environment.NewLine);
            }
            catch (Exception ex)
            {
                projectInstance = null;
                log.AppendText("Error while opening project: " + ProjectPath + " - " + ex.Message);
                log.AppendText(Environment.NewLine);
            }

            return projectInstance;
        }

        /// <summary>
        /// Search project library for the block required and returns it
        /// </summary>
        /// <param name="libraryFolder">Folder of the project library to search in</param>
        /// <param name="blockName">Name of the block to be search for</param>
        /// <returns>Block if found, null otherwise</returns>
        public static MasterCopy GetMasterCopy(MasterCopyFolder libraryFolder, string blockName, TextBox log)
        {
            // look for block in current folder
            foreach (var masterCopy in libraryFolder.MasterCopies)
            {
                if (masterCopy.Name.Equals(blockName))
                {
                    log.AppendText("Block to be copied found in " + libraryFolder.Name);
                    log.AppendText(Environment.NewLine);
                    return masterCopy;
                }
            }

            // if not in this folder check subfolders
            foreach (var subfolder in libraryFolder.Folders)
            {
                MasterCopy result = GetMasterCopy(subfolder, blockName, log);

                if (result != null)
                    return result;
            }

            log.AppendText("Block to be copied not found");
            log.AppendText(Environment.NewLine);
            return null;
        }

        /// <summary>
        /// Delete block from given folder
        /// </summary>
        /// <param name="blockName">Name of the block to be deleted</param>
        /// <param name="software">Software on which to look for the block</param
        public static void DeleteBlock(string blockName, PlcBlockUserGroup software, TextBox log)
        {
            PlcBlock blockToDelete = null;

            foreach (var block in software.Blocks)
            {
                if (blockName.Equals(block.Name))
                    blockToDelete = block;
            }

            if (blockToDelete != null)
            {
                blockToDelete.Delete();

                log.AppendText("Block " + blockName + " to be deleted found in " + software.Name + " folder");
                log.AppendText(Environment.NewLine);
            }
            else
            {
                log.AppendText("Block " + blockName + " not found in " + software.Name + " folder");
                log.AppendText(Environment.NewLine);

                // if block was not found in current group check subgroups
                foreach (PlcBlockUserGroup group in software.Groups)
                {
                    DeleteBlock(blockName, group, log);
                }
            }
        }

        /// <summary>
        /// Copy block from provided project library to folder in provided plc software object
        /// </summary>
        /// <param name="blockName">Name of the block to be copied</param>
        /// <param name="libraryFolder">Project library folder with origin block</param>
        /// <param name="software">Software to copy the block into</param>
        /// <param name="destFolder">Destination folder on which to copy the block</param>
        /// <returns>True if copied, false otherwise</returns>
        public static bool CopyToFolder(string blockName, MasterCopyFolder libraryFolder, PlcBlockUserGroup software, string destFolder, TextBox log)
        {
            // checks if it's already on the right folder to proceed with the copy
            if (software.Name.Equals(destFolder))
            {
                log.AppendText("Destination folder found");
                log.AppendText(Environment.NewLine);
                // delete block if it already exists
                DeleteBlock(blockName, software, log);
                software.Blocks.CreateFrom(GetMasterCopy(libraryFolder, blockName, log));
                return true;
            }

            // if it's not in the right folder, recursively check subfolders
            foreach (var group in software.Groups)
            {
                log.AppendText("Checking " + software.Name + " subfolders");
                log.AppendText(Environment.NewLine);
                if (CopyToFolder(blockName, libraryFolder, group, destFolder, log))
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
        /// 
        /// </summary>
        /// <param name="software"></param>
        /// <returns></returns>
        public static List<string> readBlocks(PlcBlockUserGroup software)
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
                blocks.AddRange(readBlocks(group));
            }

            return blocks;
        }
    }
}
