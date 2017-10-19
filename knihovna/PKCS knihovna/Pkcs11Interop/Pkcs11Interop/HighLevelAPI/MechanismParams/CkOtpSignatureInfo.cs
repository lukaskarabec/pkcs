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
using System.Collections.Generic;
using Net.Pkcs11Interop.Common;

namespace Net.Pkcs11Interop.HighLevelAPI.MechanismParams
{
    /// <summary>
    /// Parameters returned by all OTP mechanisms in successful calls to Sign method
    /// </summary>
    public class CkOtpSignatureInfo : IDisposable
    {
        /// <summary>
        /// Flag indicating whether instance has been disposed
        /// </summary>
        private bool _disposed = false;

        /// <summary>
        /// Platform specific CkOtpSignatureInfo
        /// </summary>
        private HighLevelAPI40.MechanismParams.CkOtpSignatureInfo _params40 = null;

        /// <summary>
        /// Platform specific CkOtpSignatureInfo
        /// </summary>
        private HighLevelAPI41.MechanismParams.CkOtpSignatureInfo _params41 = null;

        /// <summary>
        /// Platform specific CkOtpSignatureInfo
        /// </summary>
        private HighLevelAPI80.MechanismParams.CkOtpSignatureInfo _params80 = null;

        /// <summary>
        /// Platform specific CkOtpSignatureInfo
        /// </summary>
        private HighLevelAPI81.MechanismParams.CkOtpSignatureInfo _params81 = null;

        /// <summary>
        /// Flag indicating whether high level list of OTP parameters left this instance
        /// </summary>
        private bool _paramsLeftInstance = false;

        /// <summary>
        /// List of OTP parameters
        /// </summary>
        private List<CkOtpParam> _params = new List<CkOtpParam>();

        /// <summary>
        /// List of OTP parameters
        /// </summary>
        public IList<CkOtpParam> Params
        {
            get
            {
                if (this._disposed)
                    throw new ObjectDisposedException(this.GetType().FullName);

                // Since now it is the caller's responsibility to dispose parameters
                _paramsLeftInstance = true;
                return _params.AsReadOnly();
            }
        }

        /// <summary>
        /// Initializes a new instance of the CkOtpSignatureInfo class.
        /// </summary>
        /// <param name='signature'>Signature value returned by all OTP mechanisms in successful calls to Sign method</param>
        public CkOtpSignatureInfo(byte[] signature)
        {
            if (Platform.UnmanagedLongSize == 4)
            {
                if (Platform.StructPackingSize == 0)
                {
                    _params40 = new HighLevelAPI40.MechanismParams.CkOtpSignatureInfo(signature);

                    IList<HighLevelAPI40.MechanismParams.CkOtpParam> hlaParams = _params40.Params;
                    for (int i = 0; i < hlaParams.Count; i++)
                        _params.Add(new CkOtpParam(hlaParams[i]));
                }
                else
                {
                    _params41 = new HighLevelAPI41.MechanismParams.CkOtpSignatureInfo(signature);

                    IList<HighLevelAPI41.MechanismParams.CkOtpParam> hlaParams = _params41.Params;
                    for (int i = 0; i < hlaParams.Count; i++)
                        _params.Add(new CkOtpParam(hlaParams[i]));
                }
            }
            else
            {
                if (Platform.StructPackingSize == 0)
                {
                    _params80 = new HighLevelAPI80.MechanismParams.CkOtpSignatureInfo(signature);

                    IList<HighLevelAPI80.MechanismParams.CkOtpParam> hlaParams = _params80.Params;
                    for (int i = 0; i < hlaParams.Count; i++)
                        _params.Add(new CkOtpParam(hlaParams[i]));
                }
                else
                {
                    _params81 = new HighLevelAPI81.MechanismParams.CkOtpSignatureInfo(signature);

                    IList<HighLevelAPI81.MechanismParams.CkOtpParam> hlaParams = _params81.Params;
                    for (int i = 0; i < hlaParams.Count; i++)
                        _params.Add(new CkOtpParam(hlaParams[i]));
                }
            }
        }

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

                    if (_paramsLeftInstance == false)
                    {
                        for (int i = 0; i < _params.Count; i++)
                        {
                            if (_params[i] != null)
                            {
                                _params[i].Dispose();
                                _params[i] = null;
                            }
                        }
                    }
                }
                
                // Dispose unmanaged objects

                _disposed = true;
            }
        }
        
        /// <summary>
        /// Class destructor that disposes object if caller forgot to do so
        /// </summary>
        ~CkOtpSignatureInfo()
        {
            Dispose(false);
        }
        
        #endregion
    }
}
