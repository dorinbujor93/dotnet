
namespace Strategy
{
    using System;
    using Filtered;
    public static class Program
    {
        public static void Main()
        {
            string smallFile = "small_file_.txt";
            string bigFile = "big_file_.txt";

            var enc = new FileEncryptor(smallFile, new InMemoryEncrypt());
            var bigEnc = new FileEncryptor(smallFile, new ComplexEncrypt());
        }
    }
}
