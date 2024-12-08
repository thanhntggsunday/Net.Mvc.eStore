using System;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace NetMvc.Cms.Common
{
    public class BaseClass : IDisposable
    {
        // Flag: Has Dispose already been called?
        /// <summary>
        /// Defines the disposed.
        /// </summary>
        private bool disposed = false;

        // Instantiate a SafeHandle instance.
        /// <summary>
        /// Defines the handle.
        /// </summary>
        private SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public bool Disposed { get => disposed; set => disposed = value; }

        // Public implementation of Dispose pattern callable by consumers.
        /// <summary>
        /// The Dispose.
        /// </summary>
        public void Dispose()
        {
            try
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            catch (Exception ex)
            {
                // Log4NetLogger.log.Error("Error Dispose: " + ex.Message);
            }
        }

        // Protected implementation of Dispose pattern.
        /// <summary>
        /// The Dispose.
        /// </summary>
        /// <param name="disposing">The disposing<see cref="bool"/>.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (Disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            Disposed = true;
        }
    }
}