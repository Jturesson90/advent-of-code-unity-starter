using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventOfCode;
using AdventOfCode.AOCClient;
using HtmlAgilityPack;
using UnityEngine;
using UnityEngine.Networking;

namespace Jturesson.AdventOfCode
{
    public class AdventOfCodeClient
    {
        private readonly IAdventOfCodeCache _cache;
        private readonly IAdventOfCodeSettings _settings;

        public AdventOfCodeClient(IAdventOfCodeCache cache, IAdventOfCodeSettings settings)
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

        public async Task<bool> CanGetDay(int day)
        {
            var uri = $"https://adventofcode.com/{_settings.Year}/day/{day}/input";
            using var www = UnityWebRequest.Get(uri);
            www.SetRequestHeader("Cookie", $"session={_settings.Session}");
            var operation = www.SendWebRequest();
            while (!operation.isDone)
                await Task.Yield();
            var text = www.downloadHandler.text;
            switch (www.result)
            {
                case UnityWebRequest.Result.InProgress:
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.ProtocolError:
                case UnityWebRequest.Result.DataProcessingError:
                    return await Task.FromResult(false);
                case UnityWebRequest.Result.Success:
                    return await Task.FromResult(
                        !text.Equals(string.Empty) && !text.Contains(
                            "Please don't repeatedly request this endpoint before it unlocks!") &&
                        !text.Contains("404 Not Found"));
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public async Task<string> LoadDescription(int day)
        {
            if (_cache.HasDescription(_settings.Year, day))
            {
                return _cache.GetDescription(_settings.Year, day);
            }

            var uri = $"https://adventofcode.com/{_settings.Year}/day/{day}";
            using var www = UnityWebRequest.Get(uri);
            www.SetRequestHeader("Cookie", $"session={_settings.Session}");
            var operation = www.SendWebRequest();
            while (!operation.isDone)
                await Task.Yield();
            var html = www.downloadHandler.text;
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var b = htmlDoc.DocumentNode.SelectSingleNode("//article");
            switch (www.result)
            {
                case UnityWebRequest.Result.InProgress:
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.ProtocolError:
                case UnityWebRequest.Result.DataProcessingError:
                    return await Task.FromResult(string.Empty);
                case UnityWebRequest.Result.Success:
                    _cache.AddDescription(_settings.Year, day, b.InnerText);
                    return await Task.FromResult(b.InnerText);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public async Task<string> LoadDayInput(int day)
        {
            if (_cache.HasInput(_settings.Year, day))
            {
                return _cache.GetInput(_settings.Year, day);
            }

            var uri = $"https://adventofcode.com/{_settings.Year}/day/{day}";
            using var www = UnityWebRequest.Get(uri);
            www.SetRequestHeader("Cookie", $"session={_settings.Session}");
            var operation = www.SendWebRequest();
            while (!operation.isDone)
                await Task.Yield();
            var text = www.downloadHandler.text;
            switch (www.result)
            {
                case UnityWebRequest.Result.InProgress:
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.ProtocolError:
                case UnityWebRequest.Result.DataProcessingError:
                    return await Task.FromResult(string.Empty);
                case UnityWebRequest.Result.Success:
                    _cache.AddInput(_settings.Year, day, text);
                    return await Task.FromResult(text);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}