using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net.Pkcs11Interop.HighLevelAPI;
namespace PKCS_knihovna
{
    class token
    {
        public string Label
        {
            get;
            private set;
        }

        public string ManufacturerId
        {
            get;
            private set;
        }

        public string Model
        {
            get;
            private set;
        }

        public string SerialNumber
        {
            get;
            private set;
        }

        public ulong Flags
        {
            get;
            private set;
        }

        public bool Rng
        {
            get;
            private set;
        }

        public bool WriteProtected
        {
            get;
            private set;
        }

        public bool LoginRequired
        {
            get;
            private set;
        }

        public bool UserPinInitialized
        {
            get;
            private set;
        }

        public bool RestoreKeyNotNeeded
        {
            get;
            private set;
        }

        public bool ClockOnToken
        {
            get;
            private set;
        }

        public bool ProtectedAuthenticationPath
        {
            get;
            private set;
        }

        public bool DualCryptoOperations
        {
            get;
            private set;
        }

        public bool TokenInitialized
        {
            get;
            private set;
        }

        public bool SecondaryAuthentication
        {
            get;
            private set;
        }

        public bool UserPinCountLow
        {
            get;
            private set;
        }

        public bool UserPinFinalTry
        {
            get;
            private set;
        }

        public bool UserPinLocked
        {
            get;
            private set;
        }

        public bool UserPinToBeChanged
        {
            get;
            private set;
        }

        public bool SoPinCountLow
        {
            get;
            private set;
        }

        public bool SoPinFinalTry
        {
            get;
            private set;
        }

        public bool SoPinLocked
        {
            get;
            private set;
        }

        public bool SoPinToBeChanged
        {
            get;
            private set;
        }

        public ulong MaxSessionCount
        {
            get;
            private set;
        }

        public ulong SessionCount
        {
            get;
            private set;
        }

        public ulong MaxRwSessionCount
        {
            get;
            private set;
        }

        public ulong RwSessionCount
        {
            get;
            private set;
        }

        public ulong MaxPinLen
        {
            get;
            private set;
        }

        public ulong MinPinLen
        {
            get;
            private set;
        }

        public ulong TotalPublicMemory
        {
            get;
            private set;
        }

        public ulong FreePublicMemory
        {
            get;
            private set;
        }

        public ulong TotalPrivateMemory
        {
            get;
            private set;
        }

        public ulong FreePrivateMemory
        {
            get;
            private set;
        }

        public string HardwareVersion
        {
            get;
            private set;
        }

        public string FirmwareVersion
        {
            get;
            private set;
        }

        public string UtcTime
        {
            get;
            private set;
        }
        /*atributy prevzaty z pkcs interop - informace o kartě
         * 
         */
        internal Pkcs11TokenInfo(TokenInfo tokenInfo)
        {
            Label = tokenInfo.Label;
            ManufacturerId = tokenInfo.ManufacturerId;
            Model = tokenInfo.Model;
            SerialNumber = tokenInfo.SerialNumber;
            Flags = tokenInfo.TokenFlags.Flags;
            Rng = tokenInfo.TokenFlags.Rng;
            WriteProtected = tokenInfo.TokenFlags.WriteProtected;
            LoginRequired = tokenInfo.TokenFlags.LoginRequired;
            UserPinInitialized = tokenInfo.TokenFlags.UserPinInitialized;
            RestoreKeyNotNeeded = tokenInfo.TokenFlags.RestoreKeyNotNeeded;
            ClockOnToken = tokenInfo.TokenFlags.ClockOnToken;
            ProtectedAuthenticationPath = tokenInfo.TokenFlags.ProtectedAuthenticationPath;
            DualCryptoOperations = tokenInfo.TokenFlags.DualCryptoOperations;
            TokenInitialized = tokenInfo.TokenFlags.TokenInitialized;
            SecondaryAuthentication = tokenInfo.TokenFlags.SecondaryAuthentication;
            UserPinCountLow = tokenInfo.TokenFlags.UserPinCountLow;
            UserPinFinalTry = tokenInfo.TokenFlags.UserPinFinalTry;
            UserPinLocked = tokenInfo.TokenFlags.UserPinLocked;
            UserPinToBeChanged = tokenInfo.TokenFlags.UserPinToBeChanged;
            SoPinCountLow = tokenInfo.TokenFlags.SoPinCountLow;
            SoPinFinalTry = tokenInfo.TokenFlags.SoPinFinalTry;
            SoPinLocked = tokenInfo.TokenFlags.SoPinLocked;
            SoPinToBeChanged = tokenInfo.TokenFlags.SoPinToBeChanged;
            MaxSessionCount = tokenInfo.MaxSessionCount;
            SessionCount = tokenInfo.SessionCount;
            MaxRwSessionCount = tokenInfo.MaxRwSessionCount;
            RwSessionCount = tokenInfo.RwSessionCount;
            MaxPinLen = tokenInfo.MaxPinLen;
            MinPinLen = tokenInfo.MinPinLen;
            TotalPublicMemory = tokenInfo.TotalPublicMemory;
            FreePublicMemory = tokenInfo.FreePublicMemory;
            TotalPrivateMemory = tokenInfo.TotalPrivateMemory;
            FreePrivateMemory = tokenInfo.FreePrivateMemory;
            HardwareVersion = tokenInfo.HardwareVersion;
            FirmwareVersion = tokenInfo.FirmwareVersion;
            UtcTime = tokenInfo.UtcTimeString;
        }
    } }

