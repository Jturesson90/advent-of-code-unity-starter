using System;
using System.Collections;
using System.Collections.Generic;
using AdventOfCode.AOCClient;
using UnityEngine;

namespace AdventOfCode
{
    public class InputsCache : ScriptableObject, IInputsCache
    {
        [SerializeField] private SerializableDictionary<int, SerializableDictionary<int, string>> cache;

        private static InputsCache _instance;

        public static IInputsCache Instance
        {
            get
            {
                if (_instance != null) return _instance;
                _instance = CreateInstance<InputsCache>();
                _instance.hideFlags = HideFlags.HideAndDontSave;
                _instance.cache = new SerializableDictionary<int, SerializableDictionary<int, string>>();
                return _instance;
            }
        }

        public void AddInput(int year, int day, string input)
        {
            if (!cache.ContainsKey(year))
                cache.Add(year, new SerializableDictionary<int, string>());
            if (cache[year].ContainsKey(day))
            {
                cache[year][day] = input;
            }
            else
            {
                cache[year].Add(day, input);
            }
        }

        public bool HasInput(int year, int day)
        {
            var yearCache = cache.ContainsKey(year) ? cache[year] : null;
            return yearCache != null && yearCache.ContainsKey(day);
        }

        public void UpdateInput(int year, int day)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteInput(int year, int day)
        {
            if (cache.ContainsKey(year) && cache[year].ContainsKey(day))
                cache[year].Remove(day);
        }

        public void DeleteYear(int year)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new System.NotImplementedException();
        }

        private void AddInputToCache(int year, int day)
        {
        }

        private bool InputExistsInCache(int year, int day)
        {
            var yearCache = cache.ContainsKey(year) ? cache[year] : null;
            return yearCache != null && yearCache.ContainsKey(day);
        }

        public string GetInput(int year, int day)
        {
            var yearCache = cache.ContainsKey(year) ? cache[year] : null;
            if (yearCache == null)
                throw new ArgumentException($"No cached inputs for year {year} found.");
            if (!yearCache.ContainsKey(day))
                throw new ArgumentException($"Input for {year} day {day} not found in cache");
            return yearCache[day];
        }

        public void OnBeforeSerialize()
        {
            throw new NotImplementedException();
        }

        public void OnAfterDeserialize()
        {
            throw new NotImplementedException();
        }
    }
}