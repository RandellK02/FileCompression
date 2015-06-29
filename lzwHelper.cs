using System;
using System.IO;
using System.Collections;
using System.IO.Compression;

namespace FileCompression
{
	/// <summary>
	/// Summary description for lzwHelper.
	/// </summary>
	public class lzwHelper
	{
		public lzwHelper(){ }
		
		public class Compress
		{

			public Compress() { }

            public static void CompressFolder(string dir){
                string zipPath = dir + ".zip";
                ZipFile.CreateFromDirectory(dir, zipPath);
            }
		}

		public class Decompress
		{
            public Decompress() { }

            public static void DecompressFolder(string dir)
            {
                string zipPath = dir + ".zip";
                string parentDir = System.IO.Directory.GetParent(dir).FullName;
                if (File.Exists(zipPath))
                {
                    if (!System.IO.Directory.Exists(parentDir + @"\Extract"))
                    {
                        System.IO.Directory.CreateDirectory(parentDir + @"\Extract");
                        ZipFile.ExtractToDirectory(zipPath, parentDir + @"\Extract");
                    }
                    else { ZipFile.ExtractToDirectory(zipPath, parentDir + @"\Extract"); }
                }
            }
		}
	}
}
