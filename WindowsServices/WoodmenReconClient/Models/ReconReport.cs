using System;
using System.Collections.Generic;

namespace WOW.WoodmenReconClient.Models
{
    public class ReconReport : IEquatable<ReconReport>
    {
        public string Hostname { get; set; }
        public string ReportName { get; set; }
        public DateTime ReportCreateDateUtc { get; set; }

        public Guid ReportId { get; private set; }

        public List<ReconReportDataItem> DataItems { get; set; }

        public ReconReport()
        {
            ReportId = Guid.NewGuid();
            DataItems = new List<ReconReportDataItem>();
        }

        public bool Equals(ReconReport other)
        {
            if(other == null)
            {
                return false;
            }
            
            // Hostname
            if(!Hostname.Equals(other.Hostname))
            {
                return false;
            }

            // Reportname
            if(!ReportName.Equals(other.ReportName))
            {
                return false;
            }
            
            // Skip the create date; we're interested in the data

            if (DataItems != null && other.DataItems == null)
            {
                return false;
            }

            if (DataItems == null && other.DataItems != null)
            {
                return false;
            }

            if (DataItems.Count != other.DataItems.Count)
            {
                return false;
            }

            // At this point, this lists have the same number of items
            // so we'll use one index.
            // We're also assuming that similar data items are in the lists
            // in the same order
            for(int x = 0; x < DataItems.Count; x++)
            {
                if(!DataItems[x].Equals(other.DataItems[x]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}