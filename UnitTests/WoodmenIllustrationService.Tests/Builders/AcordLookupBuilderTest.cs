using Microsoft.CSharp.RuntimeBinder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WOW.Illustration.Model.ACORD;
using WOW.WoodmenIllustrationService.Builders;

namespace WoodmenIllustrationService.Tests.Builders
{
    [TestClass]
    public class AcordLookupBuilderTest
    {
        public class BogusType
        {
            public BogusTypeTC tc { get; set; }

            public string Value { get; set; }
        }

        public enum BogusTypeTC
        {
            OLI_UNKNOWN = 0,
            OLI_OTHER = 2147483647
        }


        [TestMethod]
        public void TestBoolean()
        {
            var boolLookup = AcordLookupBuilder.BuildBoolean(true);

            Assert.AreEqual(boolLookup.Value, "True", true);
        }

        [TestMethod]
        public void TestBuildFromTC_Boolean()
        {
            var tc = OLI_LU_BOOLEAN_TC.OLI_BOOL_TRUE;

            var boolLookup = AcordLookupBuilder.BuildFromTC<OLI_LU_BOOLEAN, OLI_LU_BOOLEAN_TC>(tc);

            Assert.AreEqual(boolLookup.Value, "True", true);
        }

        [TestMethod]
        [ExpectedException(typeof(RuntimeBinderException))]
        public void TestBuildFromTC_Incompatible1()
        {
            var tc = OLI_LU_STATE_TC.OLI_USA_TN;

            var boolLookup = AcordLookupBuilder.BuildFromTC<OLI_LU_BOOLEAN, OLI_LU_STATE_TC>(tc);
        }

        [TestMethod]
        [ExpectedException(typeof(RuntimeBinderException))]
        public void TestBuildFromTC_Incompatible2()
        {
            var tc = OLI_LU_BOOLEAN_TC.OLI_BOOL_TRUE;

            var stateLookup = AcordLookupBuilder.BuildFromTC<OLI_LU_STATE, OLI_LU_BOOLEAN_TC>(tc);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestBuildFromTC_InvalidTCType()
        {
            var tc = BogusTypeTC.OLI_UNKNOWN;

            var boolLookup = AcordLookupBuilder.BuildFromTC<BogusType, BogusTypeTC>(tc);
        }

        [TestMethod]
        public void TestBuildFromTC_StateValid()
        {
            var tc = OLI_LU_STATE_TC.OLI_USA_TN;

            var stateLookup = AcordLookupBuilder.BuildFromTC<OLI_LU_STATE, OLI_LU_STATE_TC>(tc);

            Assert.AreEqual(stateLookup.Value, "Tennessee", true);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestBuildFromTC_StateInvalid()
        {
            var tc = (OLI_LU_STATE_TC)(-1);

            var stateLookup = AcordLookupBuilder.BuildFromTC<OLI_LU_STATE, OLI_LU_STATE_TC>(tc);
        }

        [TestMethod]
        public void TestBuildFromTCInt_Boolean()
        {
            var tc = OLI_LU_BOOLEAN_TC.OLI_BOOL_TRUE;

            var boolLookup = AcordLookupBuilder.BuildFromTC<OLI_LU_BOOLEAN>((int)tc);

            Assert.AreEqual(boolLookup.Value, "True", true);
        }

        [TestMethod]
        public void TestBuildFromTCInt_StateValid()
        {
            var tc = OLI_LU_STATE_TC.OLI_USA_TN;

            var stateLookup = AcordLookupBuilder.BuildFromTC<OLI_LU_STATE>((int)tc);

            Assert.AreEqual(stateLookup.Value, "Tennessee", true);
        }

        [TestMethod]
        public void TestBuildFromTCInt_SecondaryTypeValid()
        {
            var tc = TC_ILLUSSECTYPE_TC.ILL_SEC_COV_TXNAMT;

            var secondaryType = AcordLookupBuilder.BuildFromTC<TC_ILLUSSECTYPE>((int)tc);

            Assert.AreEqual(secondaryType.Value, "Specified Amount of Coverage Change", true);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestBuildFromTCInt_StateInvalid()
        {
            var tc = (OLI_LU_STATE_TC)(-1);

            var stateLookup = AcordLookupBuilder.BuildFromTC<OLI_LU_STATE>((int)tc);
        }

        [TestMethod]
        public void TestBuildFromWowString_StateValid()
        {
            var acordObject = AcordLookupBuilder.BuildFromWowString<OLI_LU_STATE>("TN");

            Assert.AreEqual(acordObject.tc, OLI_LU_STATE_TC.OLI_USA_TN);
            Assert.AreEqual(acordObject.Value, "Tennessee", true);
        }

        [TestMethod]
        public void TestBuildFromWowString_StateInvalid()
        {
            var acordObject = AcordLookupBuilder.BuildFromWowString<OLI_LU_STATE>("XY");

            Assert.AreEqual(acordObject.tc, OLI_LU_STATE_TC.OLI_UNKNOWN);
            Assert.AreEqual(acordObject.Value, "XY", true);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void TestBuildFromWowString_StateNull()
        {
            var acordObject = AcordLookupBuilder.BuildFromWowString<OLI_LU_STATE>(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestBuildFromWowString_InvalidTCType()
        {
            var acordObject = AcordLookupBuilder.BuildFromWowString<BogusType>(string.Empty);
        }
    }
}
