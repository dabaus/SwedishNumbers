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
        public void TestValidNumbers()
        {
            // Long
            PersonnummerUtils.IsValid("20080903-2386").Should().BeTrue();
            PersonnummerUtils.IsValid("198107249289").Should().BeTrue();
            PersonnummerUtils.IsValid("19021214-9819").Should().BeTrue();
            PersonnummerUtils.IsValid("190910199827").Should().BeTrue();
            PersonnummerUtils.IsValid("191006089807").Should().BeTrue();
            PersonnummerUtils.IsValid("192109099180").Should().BeTrue();
            PersonnummerUtils.IsValid("194510168885").Should().BeTrue();
            PersonnummerUtils.IsValid("189102279800").Should().BeTrue();
            PersonnummerUtils.IsValid("189912299816").Should().BeTrue();

            // Short
            PersonnummerUtils.IsValid("141206-2380").Should().BeTrue();
            PersonnummerUtils.IsValid("7101169295").Should().BeTrue();
            PersonnummerUtils.IsValid("4607137454").Should().BeTrue();
            PersonnummerUtils.IsValid("4607137454").Should().BeTrue();
            PersonnummerUtils.IsValid("900118+9811").Should().BeTrue();
        }
    }
}