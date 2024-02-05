using System.Runtime.InteropServices;

namespace SesamNeat.Blazor.Helper;

internal class ShutdownHelper
{
    [DllImport( "libc.so.6", SetLastError = true)] // You may need to change this to "libc.so.6" or "libc.so.7" depending on your platform)
    private static extern int LibcCommand(int cmd, IntPtr arg);
    
    private const int LINUX_REBOOT_CMD_RESTART = 0x01234567;
    private const int LINUX_REBOOT_CMD_POWER_OFF = 0x4321FEDC;
    
    public void Shutdown()
    {
        // LibcCommand(LINUX_REBOOT_CMD_POWER_OFF, IntPtr.Zero);
    }

    public void Reboot()
    {
        // LibcCommand(LINUX_REBOOT_CMD_RESTART, IntPtr.Zero);
    }
    
    
}