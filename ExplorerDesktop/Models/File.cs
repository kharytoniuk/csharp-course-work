using System.Diagnostics;
using System.IO;

namespace ExplorerDesktop;

public class File : BaseEntry
{
    public File(string name, string path) 
        : base(name, path)
    {
    }
    
    public void Execute()
    {
        new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = Path,
                UseShellExecute = true
            }
        }.Start();
    }

    public override void Create()
    {
        System.IO.File.Create(Path);
    }

    public override void Delete()
    {
        System.IO.File.Delete(Path);
    }
}