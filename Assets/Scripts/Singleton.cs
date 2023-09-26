using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        private static T _instance;
        public static T Instance => _instance;

        protected virtual void Awake()
        {
            if (_instance == null)
            {
                _instance = (T)this;
            }
            else
            {
                Debug.LogError("Multiple instances of " + name);
            }
        }

        protected virtual void OnDestroy()
        {
            _instance = null;
        }
    }
