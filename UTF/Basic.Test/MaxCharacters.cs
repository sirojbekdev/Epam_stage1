namespace Basic.Test
{
    public class MaxCharacters
    {
        [Theory]
        [InlineData("AAAd222FFFF666661", 4)]
        [InlineData("22251aAAAAAa222222", 5)]
        [InlineData("BbbbBb222222b", 3)]
        [InlineData("222222a", 0)]
        [InlineData("111333aa", 2)]
        [InlineData("aAaA", 0)]
        [InlineData("222222", 0)]
        public void MaxNumberOfLetter_WhenValid_ReturnsResult(string value, int expected)
        {
            Program program = new();

            var act = program.MaxNumberOfLetter(value);

            Assert.Equal(expected, act);
        }

        [Theory]
        [InlineData("AAAddddddFFFF666661", 5)]
        [InlineData("22251aAAAAAa222222", 6)]
        [InlineData("BbbbBb222222b", 6)]
        [InlineData("aaa99ssss", 2)]
        [InlineData("aaa9ssss", 0)]
        [InlineData("1259", 0)]
        [InlineData("aaadddwssss", 0)]
        public void MaxNumberOfDigit_WhenValid_ReturnsResult(string value, int expected)
        {
            Program program = new();

            var act = program.MaxNumberOfDigit(value);

            Assert.Equal(expected, act);
        }
    }
}
