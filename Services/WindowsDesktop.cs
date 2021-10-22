using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace New_Desktop
{

    public class WindowDesktop : IDisposable
    {
        #region DLLs

        [DllImport("user32.dll", EntryPoint = "CloseDesktop", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseDesktop(IntPtr handle);

        [DllImport("user32.dll")]
        private static extern IntPtr CreateDesktop(string lpszDesktop, IntPtr lpszDevice, IntPtr pDevmode,
                                                   int dwFlags, long dwDesiredAccess, IntPtr lpsa);

        [DllImport("kernel32.dll")]
        private static extern bool CreateProcess(
            string lpApplicationName,
            string lpCommandLine,
            IntPtr lpProcessAttributes,
            IntPtr lpThreadAttributes,
            bool bInheritHandles,
            int dwCreationFlags,
            IntPtr lpEnvironment,
            string lpCurrentDirectory,
            ref STARTUPINFO lpStartupInfo,
            ref PROCESS_INFORMATION lpProcessInformation
            );

        [DllImport("user32.dll")]
        private static extern bool EnumDesktops(IntPtr hwinsta, EnumDesktopProc lpEnumFunc, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern bool EnumDesktopWindows(IntPtr hDesktop, EnumDesktopWindowsProc lpfn, IntPtr lParam);

        [DllImport("kernel32.dll")]
        public static extern int GetCurrentThreadId();

        [DllImport("kernel32.dll")]
        public static extern int GetLastError();

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool GetUserObjectInformation(IntPtr hObj, int nIndex, [Out] byte[] pvInfo, uint nLength, out uint lpnLengthNeeded);

        [DllImport("user32.dll")]
        private static extern IntPtr GetProcessWindowStation();

        [DllImport("user32.dll")]
        public static extern IntPtr GetThreadDesktop(int dwThreadId);

        [DllImport("user32.dll")]
        private static extern IntPtr OpenDesktop(string lpszDesktop, int dwFlags, bool fInherit, int dwDesiredAccess);

        [DllImport("user32.dll")]
        internal static extern IntPtr OpenInputDesktop(int dwFlags, bool fInherit, int dwDesiredAccess);

        [DllImport("User32", CharSet = CharSet.Auto, ExactSpelling = true)]
        internal static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndParent);

        [DllImport("User32.dll")]
        internal static extern bool SetProcessWindowStation(IntPtr hWinSta);

        [DllImport("user32.dll")]
        public static extern bool SetThreadDesktop(IntPtr hDesktop);

        [DllImport("user32.dll")]
        private static extern bool SwitchDesktop(IntPtr hDesktop);

        #endregion

        #region Enumerator
        [Flags]
        internal enum DESKTOP_ACCESS_MASK : uint
        {
            DESKTOP_NONE = 0,
            DESKTOP_READOBJECTS = 0x0001,
            DESKTOP_CREATEWINDOW = 0x0002,
            DESKTOP_CREATEMENU = 0x0004,
            DESKTOP_HOOKCONTROL = 0x0008,
            DESKTOP_JOURNALRECORD = 0x0010,
            DESKTOP_JOURNALPLAYBACK = 0x0020,
            DESKTOP_ENUMERATE = 0x0040,
            DESKTOP_WRITEOBJECTS = 0x0080,
            DESKTOP_SWITCHDESKTOP = 0x0100,

            GENERIC_ALL = (DESKTOP_READOBJECTS | DESKTOP_CREATEWINDOW | DESKTOP_CREATEMENU |
                            DESKTOP_HOOKCONTROL | DESKTOP_JOURNALRECORD | DESKTOP_JOURNALPLAYBACK |
                            DESKTOP_ENUMERATE | DESKTOP_WRITEOBJECTS | DESKTOP_SWITCHDESKTOP),
        }
        #endregion

        # region Struct

        [StructLayout(LayoutKind.Sequential)]
        private struct STARTUPINFO
        {
            public int cb;
            public string lpReserved;
            public string lpDesktop;
            public string lpTitle;
            public int dwX;
            public int dwY;
            public int dwXSize;
            public int dwYSize;
            public int dwXCountChars;
            public int dwYCountChars;
            public int dwFillAttribute;
            public int dwFlags;
            public short wShowWindow;
            public short cbReserved2;
            public IntPtr lpReserved2;
            public IntPtr hStdInput;
            public IntPtr hStdOutput;
            public IntPtr hStdError;
        }

        public struct PROCESS_INFORMATION
        {
            public long hProcess;
            public long hThread;
            public long dwProcessId;
            public long dwThreadId;
        }

        # endregion //End of Strcut

        #region Dispose
        public void Dispose()
        {
            SwitchToOrginal();
            ((IDisposable)this).Dispose();
        }

        /// <summary>
        /// Implemented Dispose method from IDisposable
        /// </summary>
        /// <param name="fDisposing"></param>
        protected virtual void Dispose(bool fDisposing)
        {
            if (fDisposing)
            {
                // free up resources
                //BspVariable1 = null;
                CloseDesktop(DesktopPtr);
            }
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); //Suppress garbage collector
        }
        #endregion

        #region Variables

        private const int UOI_FLAGS = 1;
        private const int UOI_NAME = 2;
        private const int UOI_TYPE = 3;
        private const int UOI_USER_SID = 4;

        private const int NORMAL_PRIORITY_CLASS = 0x00000020;
        IntPtr _hOrigDesktop;
        public IntPtr DesktopPtr;
        private string _sMyDesk;
        public string DesktopName
        {
            get
            {
                return (_sMyDesk);
            }
            set
            {
                _sMyDesk = value;
            }
        }

        private static StringCollection _sc;

        #endregion

        #region Constructors
        public WindowDesktop()
        {
            _sMyDesk = string.Empty;
        }

        public WindowDesktop(string sDesktopName)
        {
            _hOrigDesktop = GetCurrentDesktopPtr();
            _sMyDesk = sDesktopName;
            DesktopPtr = CreateMyDesktop();
        }
        #endregion

        # region Delegates

        private delegate bool EnumDesktopProc(string lpszDesktop, IntPtr lParam);

        private delegate bool EnumDesktopWindowsProc(IntPtr desktopHandle, IntPtr lParam);

        # endregion

        #region Methods
        public void show()
        {
            SetThreadDesktop(DesktopPtr);
            SwitchDesktop(DesktopPtr);
        }

        public void SwitchToOrginal()
        {
            SwitchDesktop(_hOrigDesktop);
            SetThreadDesktop(_hOrigDesktop);
        }

        private IntPtr CreateMyDesktop()
        {
            return CreateDesktop(_sMyDesk, IntPtr.Zero, IntPtr.Zero, 0, (long)DESKTOP_ACCESS_MASK.GENERIC_ALL, IntPtr.Zero);
        }

        public bool CreateProcess(string path, string desktopName)
        {
            // start the process.
            STARTUPINFO si = new STARTUPINFO();
            si.lpDesktop = DesktopName;
            //int hCurrentThread = GetCurrentThreadId();
            //IntPtr ptr = GetThreadDesktop(GetCurrentThreadId());
            PROCESS_INFORMATION pi = new PROCESS_INFORMATION();


            return CreateProcess(null, path, IntPtr.Zero, IntPtr.Zero, true, NORMAL_PRIORITY_CLASS, IntPtr.Zero, null, ref si, ref pi);
        }

        private static bool DesktopProc(string lpszDesktop, IntPtr lParam)
        {
            // add the desktop to the collection.
            _sc.Add(lpszDesktop);

            return true;
        }

        public IntPtr GetCurrentDesktopPtr()
        {
            return GetThreadDesktop(GetCurrentThreadId());
        }

        public static StringCollection GetDesktops()
        {
            //define and initialize local variables
            IntPtr windowStation = GetProcessWindowStation();

            //be sure the handle is valid
            if (windowStation == IntPtr.Zero)
            { return null; }

            // lock the object. thread safety and all.
            lock (_sc = new StringCollection())
            {
                bool result = EnumDesktops(windowStation, new EnumDesktopProc(DesktopProc), IntPtr.Zero);

                //something went wrong.
                if (!result)
                { return null; }
            }

            return _sc;
        }

        public static StringCollection GetDesktopWindows(WindowDesktop wd)
        {
            //define and intialize local variables
            //be sure the handle is valid
            if (wd.DesktopPtr == IntPtr.Zero)
            {
                return null;
            }

            //lock the object thread safety and all
            lock (_sc = new StringCollection())
            {
                bool result = EnumDesktopWindows(wd.DesktopPtr, new EnumDesktopWindowsProc(WindowProc), IntPtr.Zero);

                //an error ocurred
                if (!result)
                {
                    return null;
                }
            }

            return _sc;
        }

        private static bool WindowProc(IntPtr desktopHandle, IntPtr lParam)
        {
            // add the desktop to the collection.
            _sc.Add(desktopHandle.ToString());

            return true;
        }

        #endregion

    }

}
