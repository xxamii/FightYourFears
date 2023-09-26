using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class Damager : MonoBehaviour
    {
        [SerializeField] private float _amount;

        private void OnTriggerEnter2D(Collider2D other)
        {
            DealDamage(other);
        }

        protected virtual void DealDamage(Collider2D other)
        {
            Health toDamage = other.GetComponent<Health>();

            if (toDamage != null)
            {
                toDamage.Use(_amount);
            }
        }
    }
