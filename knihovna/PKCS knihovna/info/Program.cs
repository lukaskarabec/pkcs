using System;
using Net.Pkcs11Interop.Common;
using Net.Pkcs11Interop.HighLevelAPI;
using RutokenPkcs11Interop;


namespace info
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Library initialization");
                using (var pkcs11 = new Pkcs11(Settings.RutokenEcpDllDefaultPath, Settings.OsLockingDefault))
                {
                    Console.WriteLine("Checking tokens available");
                    Slot slot = Helpers.GetUsableSlot(pkcs11);

                    Console.WriteLine("Token initialization");
                    slot.InitToken(SampleConstants.SecurityOfficerPin, SampleConstants.TokenStdLabel);

                    Console.WriteLine("Opening RW session");
                    using (Session session = slot.OpenSession(false))
                    {
                        Console.WriteLine("SO authentication");
                        session.Login(CKU.CKU_SO, SampleConstants.SecurityOfficerPin);

                        try
                        {
                            Console.WriteLine("User PIN initialization");
                            session.InitPin(SampleConstants.NormalUserPin);

                            Console.WriteLine("Initialization has been completed successfully");
                        }
                        finally
                        {
                          
                            session.Logout();
                        }
                    }
                }
            }
           
        }
    }
}
