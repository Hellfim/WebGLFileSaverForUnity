using System;
using System.Runtime.InteropServices;

namespace WebGLFileSaverPlugin.Core
{
    public class WebGLFileSaver
    {
        [DllImport("__Internal")]
        private static extern void init();

        [DllImport("__Internal")]
        private static extern void SaveByteArray(Byte[] array, Int32 byteLength, String name, String MIMEType);

        [DllImport("__Internal")]
        private static extern Boolean IsFileSaveSupported();

        private static Boolean _isInitialized;

        public static Boolean IsFileSaveAvailable
        {
            get
            {
                EnsurePluginInitialized();
                return IsFileSaveSupported();
            }
        }

        public static void SaveFile(Byte[] content, String fileName, String MIMEType = "text/plain;charset=utf-8")
        {
            EnsurePluginInitialized();

            SaveByteArray(content, content.Length, fileName, MIMEType);
        }

        private static void EnsurePluginInitialized()
        {
            if (_isInitialized)
            {
                return;
            }

            init();
            _isInitialized = true;
        }
    }
}