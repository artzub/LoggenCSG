using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace keypresser {
	class Program {
		static void Main(string[] args) {
			var process = Process.GetProcessesByName("logstalgia").FirstOrDefault();
			if (process != null) {
				while (!process.HasExited) {
					Win32.PostMessage((int)process.MainWindowHandle, Win32.WM_KEYDOWN, 0x0000004E, 0x00310001);
					Win32.PostMessage((int)process.MainWindowHandle, Win32.WM_CHAR, 0x000000F2, 0x00310001);
					Win32.PostMessage((int)process.MainWindowHandle, Win32.WM_KEYUP, 0x0000004E, 0x00310001);
					System.Threading.Thread.Sleep(500);
				}
			}
		}
	}
}
