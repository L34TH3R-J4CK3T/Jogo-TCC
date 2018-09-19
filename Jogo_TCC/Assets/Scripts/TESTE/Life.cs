﻿using System;
using UnityEngine;
using UnityEngine.Events;


    public class Life : MonoBehaviour, IDataPersister
    {
        [Serializable]
        public class HealthEvent : UnityEvent<Life>
        { }

        [Serializable]
        public class DamageEvent : UnityEvent<AplicaDano, Life>
        { }

        [Serializable]
        public class HealEvent : UnityEvent<int, Life>
        { }

        public int startingLife = 5;
        public bool invulnerableAfterDamage = true;
        public float invulnerabilityDuration = 3f;
        public bool disableOnDeath = false;
        [Tooltip("An offset from the obejct position used to set from where the distance to the damager is computed")]
        public Vector2 centreOffset = new Vector2(0f, 1f);
        public HealthEvent OnHealthSet;
        public DamageEvent OnTakeDamage;
        public DamageEvent OnDie;
        public HealEvent OnGainHealth;
        [HideInInspector]
        public DataSettings dataSettings;

        protected bool m_Invulnerable;
        protected float m_InulnerabilityTimer;
        protected int m_CurrentHealth;
        protected Vector2 m_DamageDirection;
        protected bool m_ResetHealthOnSceneReload;

        public int CurrentHealth
        {
            get { return m_CurrentHealth; }
        }

        void OnEnable()
        {
            PersistentDataManager.RegisterPersister(this);
            m_CurrentHealth = startingLife;

            OnHealthSet.Invoke(this);

            DisableInvulnerability();
        }

        void OnDisable()
        {
            PersistentDataManager.UnregisterPersister(this);
        }

        void Update()
        {
            if (m_Invulnerable)
            {
                m_InulnerabilityTimer -= Time.deltaTime;

                if (m_InulnerabilityTimer <= 0f)
                {
                    m_Invulnerable = false;
                }
            }
        }

        public void EnableInvulnerability(bool ignoreTimer = false)
        {
            m_Invulnerable = true;
            //technically don't ignore timer, just set it to an insanly big number. Allow to avoid to add more test & special case.
            m_InulnerabilityTimer = ignoreTimer ? float.MaxValue : invulnerabilityDuration;
        }

        public void DisableInvulnerability()
        {
            m_Invulnerable = false;
        }

        public Vector2 GetDamageDirection()
        {
            return m_DamageDirection;
        }

        public void TakeDamage(AplicaDano damager, bool ignoreInvincible = false)
        {
            if ((m_Invulnerable && !ignoreInvincible) || m_CurrentHealth <= 0)
                return;

            //we can reach that point if the damager was one that was ignoring invincible state.
            //We still want the callback that we were hit, but not the damage to be removed from health.
            if (!m_Invulnerable)
            {
                m_CurrentHealth -= damager.damage;
                OnHealthSet.Invoke(this);
            }

            m_DamageDirection = transform.position + (Vector3)centreOffset - damager.transform.position;

            OnTakeDamage.Invoke(damager, this);

            if (m_CurrentHealth <= 0)
            {
                OnDie.Invoke(damager, this);
                m_ResetHealthOnSceneReload = true;
                EnableInvulnerability();
                if (disableOnDeath) gameObject.SetActive(false);
            }
        }

        public void GainHealth(int amount)
        {
            m_CurrentHealth += amount;

            if (m_CurrentHealth > startingLife)
                m_CurrentHealth = startingLife;

            OnHealthSet.Invoke(this);

            OnGainHealth.Invoke(amount, this);
        }

        public void SetHealth(int amount)
        {
            m_CurrentHealth = amount;

            OnHealthSet.Invoke(this);
        }

        public DataSettings GetDataSettings()
        {
            return dataSettings;
        }

        public void SetDataSettings(string dataTag, DataSettings.PersistenceType persistenceType)
        {
            dataSettings.dataTag = dataTag;
            dataSettings.persistenceType = persistenceType;
        }

        public Data SaveData()
        {
            return new Data<int, bool>(CurrentHealth, m_ResetHealthOnSceneReload);
        }

        public void LoadData(Data data)
        {
            Data<int, bool> healthData = (Data<int, bool>)data;
            m_CurrentHealth = healthData.value1 ? startingLife : healthData.value0;
            OnHealthSet.Invoke(this);
        }


    }
