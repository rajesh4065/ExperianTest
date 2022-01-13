namespace ExperianCalculator.Services.UnitTests
{
    using ExperianCalculator.Services.Interfaces;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Xunit;

    public class CommonServiceTests
    {
        private readonly ICommonService _commonService;

        public CommonServiceTests(ICommonService commonService)
        {
            _commonService = commonService;
        }

        [Theory]
        [ClassData(typeof(CalculatorTestDataForCommonService))]
        public void JoinDenominationsToStringShouldReturnExpectedResult(List<string> inputDenominations, string expectedOutput)
        {
            // act
            string actualOutput = _commonService.JoinDenominationsToString(inputDenominations);

            // assert
            Assert.Equal(expectedOutput, actualOutput);
        }
    }

    public class CalculatorTestDataForCommonService : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
           new object[] { new List<string>() { "£10", "£2", "£2", "50p" }, $"1x£10{Environment.NewLine}2x£2{Environment.NewLine}1x50p" },
           new object[] { new List<string>() { "£20", "£5", "£1", "5p", "2p", "1p" }, $"1x£20{Environment.NewLine}1x£5{Environment.NewLine}1x£1{Environment.NewLine}1x5p{Environment.NewLine}1x2p{Environment.NewLine}1x1p" },
            new object[] { new List<string>() { "£100", "£50", "£20", "£10" }, $"1x£100{Environment.NewLine}1x£50{Environment.NewLine}1x£20{Environment.NewLine}1x£10" },
            new object[] { new List<string>() { "50p", "20p", "10p", "5p", "1p" }, $"1x50p{Environment.NewLine}1x20p{Environment.NewLine}1x10p{Environment.NewLine}1x5p{Environment.NewLine}1x1p" }
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

