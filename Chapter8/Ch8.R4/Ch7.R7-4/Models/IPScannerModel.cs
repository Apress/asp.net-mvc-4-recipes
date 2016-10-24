using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ch8.R4.Models
{
    public class IPScannerModel
    {
        public IPRange RangeToScan
        {
            get;
            set;
        }

        private List<string> _IpList = null;
        public List<string> IpList
        {
            get
            {
                if (null==_IpList)
                {
                    _IpList = new List<string>();
                }
                return _IpList;
            }
            set
            {
                _IpList = value;
            }
        }
    }

    public class IPRange
    {
        [Required]
        [DisplayName("Start Address")]
        [RegularExpression(ipAddressRegEx,
      ErrorMessage = "Must be a valid IP Address.")]
        public string StartAddress
        {
            get;
            set;
        }
        [Required]
        [DisplayName("End Address")]
        [RegularExpression(ipAddressRegEx,
      ErrorMessage = "Must be a valid IP Address.")]
        public string EndAddress
        {
            get;
            set;
        }
        private const string ipAddressRegEx = @"^(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])$";
    }

}