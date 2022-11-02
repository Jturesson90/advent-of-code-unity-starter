using System.Threading.Tasks;
using AdventOfCode;
using AdventOfCode.AOCClient;
using Jturesson.AdventOfCode;
using NUnit.Framework;
using UnityEngine.Networking;

namespace Client
{
    public class SessionTests
    {
        [Test]
        public async Task SessionId_IsValid()
        {
            // Arrange
            var aocClient = new AdventOfCodeClient(InputsCache.Instance, AdventOfCodeSettings.Instance);
            // Act
            var result = await aocClient.SessionIsValid();
            // Assert*/
            Assert.IsTrue(result);
        }
    }
}