using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventOfCode;
using AdventOfCode.AOCClient;
using UnityEngine;
using UnityEngine.Networking;

namespace Jturesson.AdventOfCode
{
    public class AdventOfCodeClient
    {
        private readonly IInputsCache _cache;
        private readonly IAdventOfCodeSettings _settings;

        public AdventOfCodeClient(IInputsCache cache, IAdventOfCodeSettings settings)
        {
            _cache = cache;
            _settings = settings;
        }

        public async Task<bool> SessionIsValid()
        {
            var uri = "https://adventofcode.com/2021/day/10/input";
            using var www = UnityWebRequest.Get(uri);
            www.SetRequestHeader("Cookie", $"session={_settings.Session}");
            var operation = www.SendWebRequest();
            while (!operation.isDone)
                await Task.Yield();
            switch (www.result)
            {
                case UnityWebRequest.Result.InProgress:
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.ProtocolError:
                case UnityWebRequest.Result.DataProcessingError:
                    return await Task.FromResult(false);
                case UnityWebRequest.Result.Success:
                    return await Task.FromResult(true);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public async Task<string> LoadDay(int day)
        {
            if (_cache.HasInput(_settings.Year, day))
            {
                return _cache.GetInput(_settings.Year, day);
            }
            else
            {
                return "";
            }
        }
    }
}