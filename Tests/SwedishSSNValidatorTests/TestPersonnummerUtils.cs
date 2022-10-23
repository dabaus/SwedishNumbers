using SwedishSSNValidator;
using FluentAssertions;

namespace SwedishSSNValidatorTests
{
    public class TestPersonnummerUtils
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestMyPnrIsValid()
        {
            PersonnummerUtils.IsValid("198711021934").Should().BeTrue();
            PersonnummerUtils.IsValid("8711021934").Should().BeTrue();
            PersonnummerUtils.IsValid("871102-1934").Should().BeTrue();
        }
    }
}