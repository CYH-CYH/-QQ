using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;//只有窗体程序里面可以应用Forms吗？
using System.Runtime.InteropServices;
namespace Client
{
    class TextBox_tm:TextBox
    {
        
            [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
            static extern IntPtr LoadLibrary(string lpFileName);
            protected override CreateParams CreateParams
        {
            get
            {
                CreateParams prams = base.CreateParams;
                if (LoadLibrary("msftedit.dll") != IntPtr.Zero)
                {
                    prams.ExStyle |= 0x020;
                    prams.ClassName = "RICHEDIT50W";
                }
                return prams;
            }
        }
    }
}
