
namespace WOW.WoodmenIllustrationService.SharedModels
{
    public class RaterResponse
    {
        public decimal Rate1 { get; set; }
        public decimal Rate2 { get; set; }

        public override string ToString()
        {
            return string.Format("Rate1: {0}, Rate2: {1}", Rate1, Rate2);
        }
    }
}