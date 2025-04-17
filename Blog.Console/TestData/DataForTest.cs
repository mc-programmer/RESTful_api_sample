namespace Blog.Console.TestData;

public static class DataForTest
{
    public static List<object[]> GetData()
    {
        List<object[]> asd = new List<object[]>();

        asd.Add(new object[] { 5, 5, 10 });
        asd.Add(new object[] { 25, 33, 58 });

        return asd;
    }
}