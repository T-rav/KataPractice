using System.Collections.Generic;
using Heavy_Metal_Bake_Sale;

namespace Heavy_Metal_Bake_Sale_Tests
{
    public class TestOutputBuffer : IOutputBuffer
    {
        public List<string> Buffer { get;  }

        public TestOutputBuffer()
        {
            Buffer = new List<string>();
        }

        public void WriteLine(string output)
        {
            Buffer.Add(output);
        }
    }
}