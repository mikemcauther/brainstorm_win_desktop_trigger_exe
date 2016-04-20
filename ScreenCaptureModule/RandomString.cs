using System;
using System.Linq;

namespace ScreenCaptureModule
{
    class RandomString
    {
        public string rs()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Random r = new Random();
            var results = new String(
                  Enumerable.Repeat(chars, 8)
                  .Select(s => s[r.Next(s.Length)])
                  .ToArray());
            return results;
        }
    }
}
