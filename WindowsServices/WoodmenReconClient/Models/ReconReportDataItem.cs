
using System;

namespace WOW.WoodmenReconClient.Models
{
    public class ReconReportDataItem : IEquatable<ReconReportDataItem>
    {
        public string DataName { get; set; }
        public string DataValue { get; set; }

        public bool Equals(ReconReportDataItem other)
        {
            if(other == null)
            {
                return false;
            }

            if(!DataName.Equals(other.DataName))
            {
                return false;
            }

            if (!DataValue.Equals(other.DataValue))
            {
                return false;
            }

            return true;
        }
    }
}