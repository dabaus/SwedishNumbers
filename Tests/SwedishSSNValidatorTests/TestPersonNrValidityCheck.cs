using SwedishSSNValidator;
using FluentAssertions;
using SwedishSSNValidator.ValidityChecks;

namespace SwedishSSNValidatorTests
{
    public class TestPersonNrValidityCheck
    {
        private PersonNrValidityCheck pnrCheck = 
            new PersonNrValidityCheck(
                new LuhnsChecksumValidityCheck(), 
                new DateValidityCheck());

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestValidNumbers()
        {

            // Long
            pnrCheck.IsValid("20080903-2386").Should().BeTrue();
            pnrCheck.IsValid("198107249289").Should().BeTrue();
            pnrCheck.IsValid("19021214-9819").Should().BeTrue();
            pnrCheck.IsValid("190910199827").Should().BeTrue();
            pnrCheck.IsValid("191006089807").Should().BeTrue();
            pnrCheck.IsValid("192109099180").Should().BeTrue();
            pnrCheck.IsValid("194510168885").Should().BeTrue();
            pnrCheck.IsValid("189102279800").Should().BeTrue();
            pnrCheck.IsValid("189912299816").Should().BeTrue();

            // Short
            pnrCheck.IsValid("141206-2380").Should().BeTrue();
            pnrCheck.IsValid("7101169295").Should().BeTrue();
            pnrCheck.IsValid("4607137454").Should().BeTrue();
            pnrCheck.IsValid("4607137454").Should().BeTrue();
            pnrCheck.IsValid("900118+9811").Should().BeTrue();
        }

        [Test]
        public void TestInvalidNumbers()
        {
            pnrCheck.IsValid("201701272394").Should().BeFalse();
            pnrCheck.IsValid("190302299813").Should().BeFalse();
        }
    }
}