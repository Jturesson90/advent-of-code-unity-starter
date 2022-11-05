using System;
using System.Collections;
using System.Collections.Generic;
using AdventOfCode.AOCClient;
using UnityEngine;

namespace AdventOfCode
{
    public class AdventOfCodeHelper : MonoBehaviour
    {
        [SerializeField] private AdventOfCodeSettings settings;

        private void Awake()
        {
            settings = AdventOfCodeSettings.Instance;
        }
    }
}