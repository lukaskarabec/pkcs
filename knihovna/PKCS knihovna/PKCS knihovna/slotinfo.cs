using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKCS_knihovna
{
    class slotinfo
    {
        public ulong SlotId
        {
            get;
            private set;
        }

        public string SlotDescription
        {
            get;
            private set;
        }

        public string ManufacturerId
        {
            get;
            private set;
        }

        public ulong Flags
        {
            get;
            private set;
        }

        public bool TokenPresent
        {
            get;
            private set;
        }

        public bool RemovableDevice
        {
            get;
            private set;
        }

        public bool HardwareSlot
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

        internal Pkcs11SlotInfo(SlotInfo slotInfo)
        {
            SlotId = slotInfo.SlotId;
            SlotDescription = slotInfo.SlotDescription;
            ManufacturerId = slotInfo.ManufacturerId;
            Flags = slotInfo.SlotFlags.Flags;
            TokenPresent = slotInfo.SlotFlags.TokenPresent;
            RemovableDevice = slotInfo.SlotFlags.RemovableDevice;
            HardwareSlot = slotInfo.SlotFlags.HardwareSlot;
            HardwareVersion = slotInfo.HardwareVersion;
            FirmwareVersion = slotInfo.FirmwareVersion;
        }
    }
}
