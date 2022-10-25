using FluentAssertions;
using SwedishSSNValidator.ValidityChecks;

namespace SwedishSSNValidatorTests
{
    public class TestOrgNrValidityCheck
    {
        private OrgNrValidityCheck _orgCheck;

        [SetUp]
        public void Setup()
        {
            _orgCheck = new OrgNrValidityCheck(new LuhnsChecksumValidityCheck());
        }

        [Test]
        [TestCase("556614-3185")]
        [TestCase("16556601-6399")]
        [TestCase("262000-1111")]
        [TestCase("857202-7566")]
        public void TestValidNumbers(string pnr)
        {
            _orgCheck.IsValid(pnr).Should().BeTrue();
        }


        [Test]
        public void TestInValidNumbers()
        {
            _orgCheck.IsValid("17101169295").Should().BeFalse();
        }
    }
}
