using AdventOfCode;
using NUnit.Framework;

namespace Client
{
    public class InputCacheTests
    {
        [Test]
        public void CanAddAndRemove()
        {
            // Arrange
            var cache = InputsCache.Instance;
            cache.AddInput(1514, 2, "hej");
            var hej = cache.GetInput(1514, 2);
            Assert.AreEqual(hej, "hej");
            cache.DeleteInput(1514, 2);
            var f = cache.HasInput(1514, 2);
            Assert.IsFalse(f);
        }
    }
}