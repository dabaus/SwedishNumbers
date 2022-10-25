using SwedishSSNValidator;
using FluentAssertions;
using SwedishSSNValidator.ValidityChecks;

namespace SwedishSSNValidatorTests
{
    public class TestPersonNrValidityCheck
    {
        private readonly PersonNrValidityCheck _pnrCheck = new (
                 new LuhnsChecksumValidityCheck(), 
                 new DateValidityCheck());


        [Test]
        [TestCase("20080903-2386")]
        [TestCase("198107249289")]
        [TestCase("19021214-9819")]
        [TestCase("190910199827")]
        [TestCase("191006089807")]
        [TestCase("192109099180")]
        [TestCase("194510168885")]
        [TestCase("189102279800")]
        [TestCase("189912299816")]
        public void TestValidLongNumbers(string pnr)
        {
            _pnrCheck.IsValid(pnr).Should().BeTrue();
        }

        [Test]
        [TestCase("141206-2380")]
        [TestCase("7101169295")]
        [TestCase("4607137454")]
        [TestCase("900118+9811")]
        public void TestShortNumbers(string pnr)
        {
            _pnrCheck.IsValid(pnr).Should().BeTrue();
        }

        [Test]
        [TestCase("201701272394")]
        [TestCase("190302299813")]
        public void TestInvalidNumbers(string pnr)
        {
            _pnrCheck.IsValid(pnr).Should().BeFalse();
        }
    }
}