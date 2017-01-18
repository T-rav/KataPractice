using Heavy_Metal_Bake_Sale;

namespace Heavy_Metal_Bake_Sale_Tests
{
    public class TestInputBuffer : IInputBuffer
    {
        private readonly string _lineToRead;

        public TestInputBuffer(string lineToRead)
        {
            _lineToRead = lineToRead;
        }

        public string ReadLine()
        {
            return _lineToRead;
        }
    }
}