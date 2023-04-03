namespace Basic.Test
{
    public class FromDecimal
    {

        [Theory]
        [InlineData("20","16","14")]
        [InlineData("30","16","1E")]
        [InlineData("41","16","29")]
        public void FromDecimal_WhenValid_ReturnsResult(string inputNum, string newBase, string result)
        {
            Program program = new();

            var act = program.FromDecimal(inputNum, newBase);

            Assert.Equal(result, act.ToString());
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("AA", "12")]
        [InlineData("26", " ")]
        [InlineData("AA", " ")]
        public void FromDecimal_WhenInvalid_ThrowsException(string inputNum, string newBase)
        {
            Program program = new();

            Assert.Throws<FormatException>(() => program.FromDecimal(inputNum, newBase));
        }

        [Theory]
        [InlineData("12","22")]
        [InlineData("104","0")]
        [InlineData("210","1")]
        public void FromDecimal_WhenBaseOutOfRange_ReturnsErrorMessage(string inputNum, string newBase)
        {
            Program program = new();
            var expected = "New Base should be between 2 and 20";

            var act = program.FromDecimal(inputNum,newBase);

            Assert.Equal(expected, act);
        }

        [Theory]
        [InlineData(1,'1')]
        [InlineData(9,'9')]
        [InlineData(10,'A')]
        [InlineData(16,'G')]
        [InlineData(19,'J')]
        public void ReValue_WhenValid_ReturnsResult(int value, char expected)
        {
            Program program = new();

            var act = program.ReValue(value);

            Assert.Equal(expected, act);
        }

        [Theory]
        [InlineData("12", "21")]
        [InlineData("A1","1A")]
        [InlineData("352","253")]
        public void Reverse_WhenValid_ReturnsResult(string value, string expected)
        {
            Program program = new();

            var act = program.Reverse(value);

            Assert.Equal(expected, act);
        }

    }
}