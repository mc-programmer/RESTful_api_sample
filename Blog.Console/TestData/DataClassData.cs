using System.Collections;

namespace Blog.Console.TestData;

public class DataClassData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { 8, 3, 11 };
        yield return new object[] { 3, 1, 4 };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}