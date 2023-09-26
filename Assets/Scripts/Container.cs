using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public abstract class Container: MonoBehaviour
    {
        [SerializeField] protected ContainerType _type;
        [SerializeField] protected float _maxAmount;

        public ContainerType Type => _type;

        protected float _amount;

        public abstract void Use(float amount);

        public abstract void Add(float amount);

        public virtual void AddMax()
        {
            _amount = _maxAmount;
        }

        public void Upgrade(float amount)
        {
            _maxAmount += amount;
            Add(_maxAmount - _amount);
        }
    }
