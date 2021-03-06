﻿using Net.Pkcs11Interop.HighLevelAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace PKCS_knihovna
{
    class key
    {
        public bool CkaPrivate
        {
            get;
            internal set;
        }

        public ulong CkaClass
        {
            get;
            internal set;
        }

        public ulong CkaKeyType
        {
            get;
            internal set;
        }

        public string CkaLabel
        {
            get;
            internal set;
        }

        public byte[] CkaId
        {
            get;
            internal set;
        }

        internal Pkcs11KeyInfo(System.Runtime.Remoting.ObjectHandle objectHandle, List<ObjectAttribute> objectAttributes, ulong? storageSize)
        {
            ObjectHandle = objectHandle;
            ObjectAttributes = objectAttributes;
            StorageSize = storageSize;
        }
    }
}
   