using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] EnemyHealthText enemyHealthText;
    [SerializeField] int startingHP = 5;
    [Tooltip("Adds amount to maxHitPoints when enemy dies")]
    [SerializeField] int difficultyRamp = 1;
    int currentHitPoints = 0;
    public int CurrentHitPoints { get { return currentHitPoints; } }

    Enemy enemy;
    void OnEnable()
    {
        currentHitPoints = startingHP;

    }
    void Start()
    {
        enemy = GetComponent<Enemy>();
        enemyHealthText.UpdateHealthText(startingHP);

    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        enemyHealthText.UpdateHealthText(currentHitPoints);
    }

    void ProcessHit()
    {
        currentHitPoints--;
        if (currentHitPoints <= 0)
        {
            gameObject.SetActive(false);
            startingHP += difficultyRamp;
            enemy.RewardGold();
        }
    }
}
