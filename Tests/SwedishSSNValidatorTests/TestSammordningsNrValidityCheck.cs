using FluentAssertions;
using SwedishSSNValidator.ValidityChecks;

namespace SwedishSSNValidatorTests
{
    public class TestSammordningsNrValidityCheck
    {
        private readonly SammordningsNrValidityCheck _snrCheck = new (
            new LuhnsChecksumValidityCheck(),
            new SammordningsNrDateValidityCheck(
                new DateValidityCheck()
            ));


        [Test]
        public void TestValidNumbers()
        {
            _snrCheck.IsValid("190910799824").Should().BeTrue();
        }
    }
}
