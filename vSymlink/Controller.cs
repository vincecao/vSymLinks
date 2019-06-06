using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mklinkGUI
{
    public class Controller
    {
        private Form1 form;
        public Controller()
        {
            form = new Form1(this);
        }

        internal Form getForm()
        {
            return form;
        }

        public bool isFile(string source)
        {
            return (Path.GetExtension(source) != "");
        }

        public void linkFile(string source, string targetPath)
        {
            
            var arg = "\"" + targetPath + "\" \"" + source + "\"";
            //var arg = @"C:\Users\qq234\Desktop\1.PNG C:\Users\qq234\Pictures\Capture.PNG";

            ProcessStartInfo ProcessInfo = new ProcessStartInfo("cmd.exe", "/c mklink " + arg);
            Process.Start(ProcessInfo);
        }

        public void linkFile(string source)
        {
            System.IO.Directory.CreateDirectory(Path.GetDirectoryName(source) + "\\SymbolicLinks\\");
            var arg = "\"" + Path.GetDirectoryName(source) + "\\SymbolicLinks\\" + Path.GetFileName(source) + "\" \"" + source + "\"";
            
            //var arg = "\"" + @"C:\Users\qq234\Desktop\" + Path.GetFileName(source) + "\" \"" + source + "\"";
            //var arg = @"C:\Users\qq234\Desktop\1.PNG C:\Users\qq234\Pictures\Capture.PNG";

            ProcessStartInfo ProcessInfo = new ProcessStartInfo("cmd.exe", "/c mklink " + arg);
            Process.Start(ProcessInfo);
        }

        public void linkDir(string sourceDir)
        {
            System.IO.Directory.CreateDirectory(Path.GetDirectoryName(sourceDir) + "\\SymbolicLinks\\");
            var arg = "/D \"" + Path.GetDirectoryName(sourceDir) + "\\SymbolicLinks\\" + Path.GetFileName(sourceDir) + "\" \"" + sourceDir + "\"";

            //var arg = "/D \"" + sourceDir + "-Symb\" \"" + sourceDir + "\"";
            //var arg = @"C:\Users\qq234\Desktop\1.PNG C:\Users\qq234\Pictures\Capture.PNG";

            ProcessStartInfo ProcessInfo = new ProcessStartInfo("cmd.exe", "/c mklink " + arg);
            Process.Start(ProcessInfo);
        }
    }
}
