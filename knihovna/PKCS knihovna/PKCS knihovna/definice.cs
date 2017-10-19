using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKCS_knihovna
{
    class definice
    {
        #region Slot definition

        [Category("06. Slot manufacturer")]
        [DisplayName("Attribute value:")]
        public string SlotManufacturer
        {
            get;
            set;
        }

        [Category("06. Slot manufacturer")]
        [DisplayName("Present in URI:")]
        public bool SlotManufacturerPresent
        {
            get;
            set;
        }

        [Category("07. Slot description")]
        [DisplayName("Attribute value:")]
        public string SlotDescription
        {
            get;
            set;
        }

        [Category("07. Slot description")]
        [DisplayName("Present in URI:")]
        public bool SlotDescriptionPresent
        {
            get;
            set;
        }

        [Category("08. Slot ID")]
        [DisplayName("Attribute value:")]
        public ulong? SlotId
        {
            get;
            set;
        }

        [Category("08. Slot ID")]
        [DisplayName("Present in URI:")]
        public bool SlotIdPresent
        {
            get;
            set;
        }

        #endregion

        #region Token definition

        [Category("09. Token manufacturer")]
        [DisplayName("Attribute value:")]
        public string Manufacturer
        {
            get;
            set;
        }

        [Category("09. Token manufacturer")]
        [DisplayName("Present in URI:")]
        public bool ManufacturerPresent
        {
            get;
            set;
        }

        [Category("10. Token model")]
        [DisplayName("Attribute value:")]
        public string Model
        {
            get;
            set;
        }

        [Category("10. Token model")]
        [DisplayName("Present in URI:")]
        public bool ModelPresent
        {
            get;
            set;
        }

        [Category("11. Token serial number")]
        [DisplayName("Attribute value:")]
        public string Serial
        {
            get;
            set;
        }

        [Category("11. Token serial number")]
        [DisplayName("Present in URI:")]
        public bool SerialPresent
        {
            get;
            set;
        }

        [Category("12. Token label")]
        [DisplayName("Attribute value:")]
        public string Token
        {
            get;
            set;
        }

        [Category("12. Token label")]
        [DisplayName("Present in URI:")]
        public bool TokenPresent
        {
            get;
            set;
        }

        #endregion

        #region Token PIN definition

        [Category("13. Token PIN value")]
        [DisplayName("Attribute value:")]
        public string PinValue
        {
            get;
            set;
        }

        [Category("13. Token PIN value")]
        [DisplayName("Present in URI:")]
        public bool PinValuePresent
        {
            get;
            set;
        }

        [Category("14. Token PIN source")]
        [DisplayName("Attribute value:")]
        public string PinSource
        {
            get;
            set;
        }

        [Category("14. Token PIN source")]
        [DisplayName("Present in URI:")]
        public bool PinSourcePresent
        {
            get;
            set;
        }

        #endregion

        #region Object definition

        [Category("15. Object type (CKA_CLASS)")]
        [DisplayName("Attribute value:")]
        public CKO? Type
        {
            get;
            set;
        }

        [Category("15. Object type (CKA_CLASS)")]
        [DisplayName("Present in URI:")]
        public bool TypePresent
        {
            get;
            set;
        }

        [Category("16. Object label (CKA_LABEL)")]
        [DisplayName("Attribute value:")]
        public string Object
        {
            get;
            set;
        }

        [Category("16. Object label (CKA_LABEL)")]
        [DisplayName("Present in URI:")]
        public bool ObjectPresent
        {
            get;
            set;
        }

        [Category("17. Object identifier (CKA_ID)")]
        [DisplayName("Attribute value:")]
        public string Id
        {
            get;
            set;
        }

        [Category("17. Object identifier (CKA_ID)")]
        [DisplayName("Present in URI:")]
        public bool IdPresent
        {
            get;
            set;
        }

        #endregion

        public Pkcs11Uri(Pkcs11Library pkcs11Library, Pkcs11Slot pkcs11Slot, Pkcs11ObjectInfo pkcs11ObjectInfo)
        {
            if (pkcs11Library != null)
            {
                // Module definition
                this.ModulePath = pkcs11Library.Info.LibraryPath;
                this.ModulePathPresent = true;
                this.ModuleName = null;
                this.ModuleNamePresent = false;

                // Library definition
                this.LibraryManufacturer = pkcs11Library.Info.ManufacturerId;
                this.LibraryManufacturerPresent = false;
                this.LibraryDescription = pkcs11Library.Info.LibraryDescription;
                this.LibraryDescriptionPresent = false;
                this.LibraryVersion = pkcs11Library.Info.LibraryVersion;
                this.LibraryVersionPresent = false;
            }

            if (pkcs11Slot != null)
            {
                // Slot definition
                this.SlotManufacturer = pkcs11Slot.SlotInfo.ManufacturerId;
                this.SlotManufacturerPresent = false;
                this.SlotDescription = pkcs11Slot.SlotInfo.SlotDescription;
                this.SlotDescriptionPresent = false;
                this.SlotId = pkcs11Slot.SlotInfo.SlotId;
                this.SlotIdPresent = false;

                if (pkcs11Slot.TokenInfo != null)
                {
                    // Token definition
                    this.Manufacturer = pkcs11Slot.TokenInfo.ManufacturerId;
                    this.ManufacturerPresent = false;
                    this.Model = pkcs11Slot.TokenInfo.Model;
                    this.ModelPresent = false;
                    this.Serial = pkcs11Slot.TokenInfo.SerialNumber;
                    this.SerialPresent = true;
                    this.Token = pkcs11Slot.TokenInfo.Label;
                    this.TokenPresent = true;

                    // Token PIN definition
                    this.PinValue = null;
                    this.PinSourcePresent = false;
                    this.PinSource = null;
                    this.PinSourcePresent = false;
                }
                }
}
