﻿using SwedishSSNValidator;
using FluentAssertions;

namespace SwedishSSNValidatorTests
{
    public class TestSammordningNrValidityCheck
    {
        private SammordningsNrValidityCheck _snrCheck;

        [SetUp]
        public void Setup()
        {
            _snrCheck= new SammordningsNrValidityCheck(
                            new LuhnsChecksumValidityCheck(),
                            new SammordningsNrDateCheck(
                                 new DateValidityCheck()
                            ));
        }

        [Test]
        public void TestValidNumbers()
        {
            _snrCheck.IsValid("190910799824").Should().BeTrue();
        }
    }
}
