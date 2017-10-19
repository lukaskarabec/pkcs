/*
 *  Copyright 2012-2017 The Pkcs11Interop Project
 *
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License.
 */

/*
 *  Written for the Pkcs11Interop project by:
 *  Jaroslav IMRICH <jimrich@jimrich.sk>
 */

using System;
using Net.Pkcs11Interop.Common;

namespace Net.Pkcs11Interop.HighLevelAPI.MechanismParams
{
    /// <summary>
    /// Parameters for the CKM_CMS_SIG mechanism
    /// </summary>
    public class CkCmsSigParams : IMechanismParams, IDisposable
    {
        /// <summary>
        /// Flag indicating whether instance has been disposed
        /// </summary>
        private bool _disposed = false;

        /// <summary>
        /// Platform specific CkCmsSigParams
        /// </summary>
        private HighLevelAPI40.MechanismParams.CkCmsSigParams _params40 = null;

        /// <summary>
        /// Platform specific CkCmsSigParams
        /// </summary>
        private HighLevelAPI41.MechanismParams.CkCmsSigParams _params41 = null;

        /// <summary>
        /// Platform specific CkCmsSigParams
        /// </summary>
        private HighLevelAPI80.MechanismParams.CkCmsSigParams _params80 = null;

        /// <summary>
        /// Platform specific CkCmsSigParams
        /// </summary>
        private HighLevelAPI81.MechanismParams.CkCmsSigParams _params81 = null;

        /// <summary>
        /// Initializes a new instance of the CkCmsSigParams class.
        /// </summary>
        /// <param name='certificateHandle'>Object handle for a certificate associated with the signing key</param>
        /// <param name='signingMechanism'>Mechanism to use when signing a constructed CMS SignedAttributes value</param>
        /// <param name='digestMechanism'>Mechanism to use when digesting the data</param>
        /// <param name='contentType'>String indicating complete MIME Content-type of message to be signed or null if the message is a MIME object</param>
        /// <param name='requestedAttributes'>DER-encoded list of CMS Attributes the caller requests to be included in the signed attributes</param>
        /// <param name='requiredAttributes'>DER-encoded list of CMS Attributes (with accompanying values) required to be included in the resulting signed attributes</param>
        public CkCmsSigParams(ObjectHandle certificateHandle, ulong? signingMechanism, ulong? digestMechanism, string contentType, byte[] requestedAttributes, byte[] requiredAttributes)
        {
            if (Platform.UnmanagedLongSize == 4)
            {
                uint? uintSigningMechanism = (signingMechanism == null) ? null : (uint?)Convert.ToUInt32(signingMechanism.Value);
                uint? uintDigestMechanism = (digestMechanism == null) ? null : (uint?)Convert.ToUInt32(digestMechanism.Value);

                if (Platform.StructPackingSize == 0)
                    _params40 = new HighLevelAPI40.MechanismParams.CkCmsSigParams(certificateHandle.ObjectHandle40, uintSigningMechanism, uintDigestMechanism, contentType, requestedAttributes, requiredAttributes);
                else
                    _params41 = new HighLevelAPI41.MechanismParams.CkCmsSigParams(certificateHandle.ObjectHandle41, uintSigningMechanism, uintDigestMechanism, contentType, requestedAttributes, requiredAttributes);
            }
            else
            {
                if (Platform.StructPackingSize == 0)
                    _params80 = new HighLevelAPI80.MechanismParams.CkCmsSigParams(certificateHandle.ObjectHandle80, signingMechanism, digestMechanism, contentType, requestedAttributes, requiredAttributes);
                else
                    _params81 = new HighLevelAPI81.MechanismParams.CkCmsSigParams(certificateHandle.ObjectHandle81, signingMechanism, digestMechanism, contentType, requestedAttributes, requiredAttributes);
            }
        }
        
        #region IMechanismParams

        /// <summary>
        /// Returns managed object that can be marshaled to an unmanaged block of memory
        /// </summary>
        /// <returns>A managed object holding the data to be marshaled. This object must be an instance of a formatted class.</returns>
        public object ToMarshalableStructure()
        {
            if (this._disposed)
                throw new ObjectDisposedException(this.GetType().FullName);

            if (Platform.UnmanagedLongSize == 4)
                return (Platform.StructPackingSize == 0) ? _params40.ToMarshalableStructure() : _params41.ToMarshalableStructure();
            else
                return (Platform.StructPackingSize == 0) ? _params80.ToMarshalableStructure() : _params81.ToMarshalableStructure();
        }
        
        #endregion
        
        #region IDisposable
        
        /// <summary>
        /// Disposes object
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        /// <summary>
        /// Disposes object
        /// </summary>
        /// <param name="disposing">Flag indicating whether managed resources should be disposed</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    // Dispose managed objects
                    if (_params40 != null)
                    {
                        _params40.Dispose();
                        _params40 = null;
                    }

                    if (_params41 != null)
                    {
                        _params41.Dispose();
                        _params41 = null;
                    }

                    if (_params80 != null)
                    {
                        _params80.Dispose();
                        _params80 = null;
                    }

                    if (_params81 != null)
                    {
                        _params81.Dispose();
                        _params81 = null;
                    }
                }
                
                // Dispose unmanaged objects

                _disposed = true;
            }
        }
        
        /// <summary>
        /// Class destructor that disposes object if caller forgot to do so
        /// </summary>
        ~CkCmsSigParams()
        {
            Dispose(false);
        }
        
        #endregion
    }
}
