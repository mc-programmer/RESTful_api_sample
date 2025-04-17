using Blog.Console;
using Blog.Console.TestData;
using Xunit.Abstractions;

namespace Blog.Test;

public class MathHelperTest(ITestOutputHelper outputHelper)
{
    //[Fact]
    [Theory]
    [InlineData(2, 5, 7)]
    [InlineData(-5, -5, -10)]
    [InlineData(1000, 5000, 6000)]
    public void JamTest(int x, int y, int expected)
    {
        MathHelper mathHelper = new();

        var result = mathHelper.Jam(x, y);

        Assert.Equal(expected, result);
        Assert.IsType<int>(result);
    }

    [Theory]
    [MemberData(nameof(DataForTest.GetData), MemberType = typeof(DataForTest))]
    public void JamTest_Member_Data(int x, int y, int expected)
    {
        MathHelper mathHelper = new();

        var result = mathHelper.Jam(x, y);

        Assert.Equal(expected, result);
        Assert.IsType<int>(result);
    }

    [Theory]
    [Trait("Endpoint", "Ordered")]
    [ClassData(typeof(DataClassData))]
    public void JamTest_Member_Class(int x, int y, int expected)
    {
        MathHelper mathHelper = new();

        var result = mathHelper.Jam(x, y);

        outputHelper.WriteLine("asd !");

        Assert.Equal(expected, result);
        Assert.IsType<int>(result);
    }
}