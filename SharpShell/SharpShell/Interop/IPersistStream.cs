using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace SharpShell.Interop
{
    /// <summary>
    /// Enables the saving and loading of objects that use a simple serial stream for their storage needs.
    /// </summary>
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("00000109-0000-0000-C000-000000000046")]
    public interface IPersistStream : IPersist
    {
        #region IPersist Overrides

        [PreserveSig]
        new int GetClassID(out Guid pClassID);
        
        #endregion
        
        [PreserveSig]
        int IsDirty();

        /// <summary>
        /// Initializes an object from the stream where it was saved previously.
        /// </summary>
        /// <param name="pStm">An IStream pointer to the stream from which the object should be loaded.</param>
        /// <returns>This method can return the following values. S_OK, E_OUTOFMEMORY, E_FAIL.</returns>
        [PreserveSig]
        int Load(IStream pStm);

        /// <summary>
        /// Saves an object to the specified stream.
        /// </summary>
        /// <param name="pStm">An IStream pointer to the stream into which the object should be saved.</param>
        /// <param name="fClearDirty">Indicates whether to clear the dirty flag after the save is complete. If TRUE, the flag should be cleared. If FALSE, the flag should be left unchanged.</param>
        /// <returns>This method can return the following values. S_OK, STG_E_CANTSAVE, STG_E_MEDIUMFULL.</returns>
        [PreserveSig]
        int Save(IStream pStm, bool fClearDirty);

        /// <summary>
        /// Retrieves the size of the stream needed to save the object.
        /// </summary>
        /// <param name="pcbSize">The size in bytes of the stream needed to save this object, in bytes.</param>
        /// <returns>This method returns S_OK to indicate that the size was retrieved successfully.</returns>
        [PreserveSig]
        int GetSizeMax(out UInt64 pcbSize);
    }
}