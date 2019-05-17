using Siemens.Engineering;
using Siemens.Engineering.Library.MasterCopies;
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
            }
            catch (Exception ex)
            {
                projectInstance = null;
                log.AppendText("Error while opening project: " + ProjectPath + " - " + ex.Message);
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
                    log.AppendText(Environment.NewLine + "Block to be copied found in " + libraryFolder.Name);
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

            log.AppendText(Environment.NewLine + "Block to be copied not found");
            return null;
        }

        /// <summary>
        /// Delete block from given folder
        /// </summary>
        /// <param name="blockName">Name of the block to be deleted</param>
        /// <param name="software">Software on which to look for the block</param
        public static void DeleteBlock(string blockName, PlcBlockUserGroup software)
        {
            PlcBlock blockToDelete = null;

            foreach (var block in software.Blocks)
            {
                if (blockName.Equals(block.Name))
                    blockToDelete = block;
            }

            if (blockToDelete != null)
                blockToDelete.Delete();
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
                log.AppendText(Environment.NewLine + "Destination folder found");
                // delete block if it already exists
                DeleteBlock(blockName, software);
                software.Blocks.CreateFrom(GetMasterCopy(libraryFolder, blockName, log));
                return true;
            }

            // if it's not in the right folder, recursively check subfolders
            foreach (var group in software.Groups)
            {
                log.AppendText(Environment.NewLine + "Checking " + software.Name + " subfolders");
                if (CopyToFolder(blockName, libraryFolder, group, destFolder, log))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Read project library master copies folder and returns list
        /// </summary>
        /// <param name="masterCopiesFolder"></param>
        /// <param name="path"></param>
        /// <returns>Dictionary containing the objects and the parent folder</returns>
        public static Dictionary<string, MasterCopy> ReadProjectLibrary(MasterCopyFolder masterCopiesFolder, string path)
        {
            // check we have some master copies folder to work with
            if (masterCopiesFolder == null)
                throw new ArgumentNullException(nameof(masterCopiesFolder), "Parameter is null");

            var masterCopies = new Dictionary<string, MasterCopy>();

            // Add new elements to list
            foreach (var mCopy in masterCopiesFolder.MasterCopies)
            {
                path = masterCopiesFolder.Name + "/" + mCopy.Name;
                masterCopies.Add(path, mCopy);
            }

            // Check for elements in subfolders and add them to the list too
            foreach (var subfolder in masterCopiesFolder.Folders)
            {
                masterCopies = masterCopies.Concat(ReadProjectLibrary(subfolder, masterCopiesFolder.Name + "/"))
                    .ToLookup(x => x.Key, x => x.Value)
                    .ToDictionary(x => x.Key, g => g.First());
                //masterCopies.AddRange(ReadProjectLibrary(subfolder, path));
            }

            return masterCopies;
        }
    }
}
