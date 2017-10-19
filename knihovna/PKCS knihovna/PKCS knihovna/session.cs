using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net.Pkcs11Interop.Common;
using Net.Pkcs11Interop.HighLevelAPI;

namespace PKCS_knihovna
{
    class session
    {
       

            private Slot _slot = null;

            public bool UserLoggedIn
            {
                get;
                private set;
            }

            public bool UserCanLogin
            {
                get;
                private set;
            }

            public bool UserCanLoginProtected
            {
                get;
                private set;
            }

            public bool UserCanChangePin
            {
                get;
                private set;
            }

            public bool UserCanChangePinProtected
            {
                get;
                private set;
            }

            public bool SoLoggedIn
            {
                get;
                private set;
            }

            public bool SoCanLogin
            {
                get;
                private set;
            }

            public bool SoCanLoginProtected
            {
                get;
                private set;
            }

            public bool SoCanChangePin
            {
                get;
                private set;
            }

            public bool SoCanChangePinProtected
            {
                get;
                private set;
            }

            public bool SoCanSetUserPin
            {
                get;
                private set;
            }

            public bool SoCanSetUserPinProtected
            {
                get;
                private set;
            }

            public bool CanLogout
            {
                get;
                private set;
            }

            public bool CanInitToken
            {
                get;
                private set;
            }

            public bool CanInitTokenProtected
            {
                get;
                private set;
            }

            internal Pkcs11SessionInfo(SessionInfo sessionInfo, bool protectedAuthenticationPath)
            {
                if (sessionInfo == null)
                    throw new ArgumentNullException("sessionInfo");

                switch (sessionInfo.State)
                {
                    case CKS.CKS_RO_PUBLIC_SESSION:
                    case CKS.CKS_RW_PUBLIC_SESSION:

                        UserLoggedIn = false;
                        UserCanLogin = true;
                        UserCanLoginProtected = protectedAuthenticationPath;
                        UserCanChangePin = false;
                        UserCanChangePinProtected = false;
                        SoLoggedIn = false;
                        SoCanLogin = true;
                        SoCanLoginProtected = protectedAuthenticationPath;
                        SoCanChangePin = false;
                        SoCanChangePinProtected = false;
                        SoCanSetUserPin = false;
                        SoCanSetUserPinProtected = false;
                        CanLogout = false;
                        CanInitToken = true;
                        CanInitTokenProtected = protectedAuthenticationPath;

                        break;

                    case CKS.CKS_RO_USER_FUNCTIONS:
                    case CKS.CKS_RW_USER_FUNCTIONS:

                        UserLoggedIn = true;
                        UserCanLogin = false;
                        UserCanLoginProtected = false;
                        UserCanChangePin = true;
                        UserCanChangePinProtected = protectedAuthenticationPath;
                        SoLoggedIn = false;
                        SoCanLogin = false;
                        SoCanLoginProtected = false;
                        SoCanChangePin = false;
                        SoCanChangePinProtected = false;
                        SoCanSetUserPin = false;
                        SoCanSetUserPinProtected = false;
                        CanLogout = true;
                        CanInitToken = false;
                        CanInitTokenProtected = false;

                        break;

                    case CKS.CKS_RW_SO_FUNCTIONS:

                        UserLoggedIn = false;
                        UserCanLogin = false;
                        UserCanLoginProtected = false;
                        UserCanChangePin = false;
                        UserCanChangePinProtected = false;
                        SoLoggedIn = true;
                        SoCanLogin = false;
                        SoCanLoginProtected = false;
                        SoCanChangePin = true;
                        SoCanChangePinProtected = protectedAuthenticationPath;
                        SoCanSetUserPin = true;
                        SoCanSetUserPinProtected = protectedAuthenticationPath;
                        CanLogout = true;
                        CanInitToken = false;
                        CanInitTokenProtected = false;

                        break;
                }
            }
        }
    }

}
}
