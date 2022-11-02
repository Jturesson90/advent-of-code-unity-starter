using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AdventOfCode
{
    public interface IInputsCache
    {
        public void AddInput(int year, int day, string input);
        public bool HasInput(int year, int day);
        public string GetInput(int year, int day);
        public void UpdateInput(int year, int day);
        public void DeleteInput(int year, int day);
        public void DeleteYear(int year);
        public void DeleteAll();
    }
}