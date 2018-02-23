using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Anno1404Warenrechner
{
    class MemoryHelper
    {
        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        public static int ReadAddress(Process process, int address)
        {
            byte[] buffer = new byte[4];
            int bytesRead = 0;
            ReadProcessMemory(process.Handle.ToInt32(), address, buffer, 4, ref bytesRead);
            return BitConverter.ToInt32(buffer, 0);
        }
    }
}