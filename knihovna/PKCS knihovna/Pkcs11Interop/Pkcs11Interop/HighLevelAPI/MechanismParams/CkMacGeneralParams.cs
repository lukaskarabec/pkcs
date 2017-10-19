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
    /// Parameters for the general-length MACing mechanisms (DES, DES3, CAST, CAST3, CAST128 (CAST5), IDEA, CDMF and AES), the general length HMACing mechanisms (MD2, MD5, SHA-1, SHA-256, SHA-384, SHA-512, RIPEMD-128 and RIPEMD-160) and the two SSL 3.0 MACing mechanisms (MD5 and SHA-1)
    /// </summary>
    public class CkMacGeneralParams : IMechanismParams
    {
        /// <summary>
        /// Platform specific CkMacGeneralParams
        /// </summary>
        private HighLevelAPI40.MechanismParams.CkMacGeneralParams _params40 = null;

        /// <summary>
        /// Platform specific CkMacGeneralParams
        /// </summary>
        private HighLevelAPI41.MechanismParams.CkMacGeneralParams _params41 = null;

        /// <summary>
        /// Platform specific CkMacGeneralParams
        /// </summary>
        private HighLevelAPI80.MechanismParams.CkMacGeneralParams _params80 = null;

        /// <summary>
        /// Platform specific CkMacGeneralParams
        /// </summary>
        private HighLevelAPI81.MechanismParams.CkMacGeneralParams _params81 = null;

        /// <summary>
        /// Initializes a new instance of the CkMacGeneralParams class.
        /// </summary>
        /// <param name='macLength'>Length of the MAC produced, in bytes</param>
        public CkMacGeneralParams(ulong macLength)
        {
            if (Platform.UnmanagedLongSize == 4)
            {
                if (Platform.StructPackingSize == 0)
                    _params40 = new HighLevelAPI40.MechanismParams.CkMacGeneralParams(Convert.ToUInt32(macLength));
                else
                    _params41 = new HighLevelAPI41.MechanismParams.CkMacGeneralParams(Convert.ToUInt32(macLength));
            }
            else
            {
                if (Platform.StructPackingSize == 0)
                    _params80 = new HighLevelAPI80.MechanismParams.CkMacGeneralParams(macLength);
                else
                    _params81 = new HighLevelAPI81.MechanismParams.CkMacGeneralParams(macLength);
            }
        }
        
        #region IMechanismParams

        /// <summary>
        /// Returns managed object that can be marshaled to an unmanaged block of memory
        /// </summary>
        /// <returns>A managed object holding the data to be marshaled. This object must be an instance of a formatted class.</returns>
        public object ToMarshalableStructure()
        {
            if (Platform.UnmanagedLongSize == 4)
                return (Platform.StructPackingSize == 0) ? _params40.ToMarshalableStructure() : _params41.ToMarshalableStructure();
            else
                return (Platform.StructPackingSize == 0) ? _params80.ToMarshalableStructure() : _params81.ToMarshalableStructure();
        }
        
        #endregion
    }
}
