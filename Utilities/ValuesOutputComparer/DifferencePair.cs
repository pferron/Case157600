
namespace WOW.Illustration.Utilities.ValuesOutputComparer
{
    public class DifferencePair
    {
        public DifferencePair(string name, string iew, string lpa)
        {
            Name = name;
            IEW = iew;
            LPA = lpa;
        }

        public string Name { get; private set; }

        public string IEW { get; private set; }

        public string LPA { get; private set; }
    }
}
