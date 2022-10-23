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
        public void TestValidNumbers()
        {
            _orgCheck.IsValid("556614-3185").Should().BeTrue();
            _orgCheck.IsValid("16556601-6399").Should().BeTrue();
            _orgCheck.IsValid("262000-1111").Should().BeTrue();
            _orgCheck.IsValid("857202-7566").Should().BeTrue();
        }


        [Test]
        public void TestInValidNumbers()
        {
            _orgCheck.IsValid("17101169295").Should().BeFalse();
        }
    }
}
