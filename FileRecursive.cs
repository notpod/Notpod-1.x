using System.Collections.Generic;
using System.IO;
static class FileHelper
{
    public static List<FileInfo> GetFilesRecursive(string b)
    {
        // 1.
        // Store results in the file results list.
        List<FileInfo> result = new List<FileInfo>();

        // 2.
        // Store a stack of our directories.
        Stack<string> stack = new Stack<string>();

        // 3.
        // Add initial directory.
        stack.Push(b);

        // 4.
        // Continue while there are directories to process
        while (stack.Count > 0)
        {
            // A.
            // Get top directory
            string dir = stack.Pop();

            try
            {
                // B
                // Add all files at this directory to the result List.
                
                string[] tmpfiles = Directory.GetFiles(dir, "*.*");

                for (int i = 0; i < tmpfiles.Length; i++)
                {
                    try
                    {
                        result.Add(new System.IO.FileInfo(tmpfiles[i]));
                    }
                    catch
                    {

                    }
                }


                // C
                // Add all directories at this directory.
                foreach (string dn in Directory.GetDirectories(dir))
                {
                    stack.Push(dn);
                }
            }
            catch
            {
                // D
                // Could not open the directory
            }
        }
        return result;
    }
}