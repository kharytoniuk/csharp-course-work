using System.Diagnostics;

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
}