using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WOW.MobileRaterService.Models
{
    [Table("QuoteRequests")]
    public class QuoteRequest
    {
        [Key]        
        public Guid ID { get; set; }
        public string SalesRepCode { get; set; }
        public string State { get; set; }
        public string UserAgent { get; set; }
        public DateTime AccessDateTime { get; set; }
        public string RaterInputModelType { get; set; }
        public int Age { get; set; }
        public string RatingClass { get; set; }
        public string Gender { get; set; }
        public decimal? Dues { get; set; }
        public string PaymentMode { get; set; }
        public string BillType { get; set; }
        public decimal? FaceAmount { get; set; }
        public bool? Workplace { get; set; }
        public bool Tobacco { get; set; }
        public bool? AD { get; set; }
        public int? OtherAge { get; set; }
        public bool? OtherTobacco { get; set; }
        public decimal? OtherFaceAmount { get; set; }
        public string OtherRatingClass { get; set; }
        public string Disability { get; set; }
        public bool? LikedQuote { get; set; }
        public string LifeAD { get; set; }
        public bool? AioGir { get; set; }
        public decimal? AioGirAmount { get; set; }
        public string AppWaiverRider { get; set; }
        public int? PayorAge { get; set; }
        public string WaiverOfPremium { get; set; }
        public string WaiverOfMonthlyDeduction { get; set; }
        public decimal? FlatExtra { get; set; }
    }
}