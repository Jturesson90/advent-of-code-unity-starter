using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventOfCode.AOCClient;
using Jturesson.AdventOfCode;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace RealInputs
{
    public class Day01Tests
    {
        private const int Day = 1;
        private AdventOfCodeClient _client;

        [SetUp]
        public void Setup()
        {
            var settings = AdventOfCodeSettings.Instance;
            _client = new AdventOfCodeClient(null, settings);
        }

        [UnityTest]
        public async Task PuzzleA()
        {
            var input = await _client.LoadDay(Day);
        }
    }
}