﻿using System;
using UnityEngine;
using UnityEngine.Events;

namespace GrowSystem
{
    public class Timer : MonoBehaviour
    {
        public float currentTime;
        public float maxTime;
        public UnityEvent timeReachedEvent;

        private void Start()
        {
            currentTime = maxTime;
        }

        private void Update()
        {
            currentTime -= Time.deltaTime;
            timeReachedEvent.Invoke();
        }
    }
}