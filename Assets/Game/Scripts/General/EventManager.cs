using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;
    private void Awake() {
        Instance = this;
    }
    public List<Action> OnEnemyHitPlayer;
    public Action<int,GameObject> OnEnemyHitBullet;

    public void OnEnemyHitPlayerInvoke()
    {
        for (int eventIndex = 0; eventIndex < OnEnemyHitPlayer.Count; eventIndex++)
        {
            OnEnemyHitPlayer[eventIndex]();
        }
    }

    public void OnEnemyHitBulletInvoke(int value,GameObject gameObject)
    {
        OnEnemyHitBullet(value,gameObject);
    }
}
