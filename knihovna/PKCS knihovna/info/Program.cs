﻿using System;
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
                // Инициализировать библиотеку
                Console.WriteLine("Library initialization");
                using (var pkcs11 = new Pkcs11(Settings.RutokenEcpDllDefaultPath, Settings.OsLockingDefault))
                {
                    // Получить доступный слот
                    Console.WriteLine("Checking tokens available");
                    Slot slot = Helpers.GetUsableSlot(pkcs11);

                    // Инициализировать токен
                    Console.WriteLine("Token initialization");
                    slot.InitToken(SampleConstants.SecurityOfficerPin, SampleConstants.TokenStdLabel);

                    // Открыть RW сессию в первом доступном слоте
                    Console.WriteLine("Opening RW session");
                    using (Session session = slot.OpenSession(false))
                    {
                        // Выполнить аутентификацию Администратора
                        Console.WriteLine("SO authentication");
                        session.Login(CKU.CKU_SO, SampleConstants.SecurityOfficerPin);

                        try
                        {
                            // Инициализировать PIN-код Пользователя
                            Console.WriteLine("User PIN initialization");
                            session.InitPin(SampleConstants.NormalUserPin);

                            Console.WriteLine("Initialization has been completed successfully");
                        }
                        finally
                        {
                            // Сбросить права доступа как в случае исключения,
                            // так и в случае успеха.
                            // Сессия закрывается автоматически.
                            session.Logout();
                        }
                    }
                }
            }
            catch (Pkcs11Exception ex)
            {
                Console.WriteLine($"Operation failed [Method: {ex.Method}, RV: {ex.RV}]");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Operation failed [Message: {ex.Message}]");
            }
        }
    }
}
