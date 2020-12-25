using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Playables;

public class EnemyHealth : MonoBehaviour
{
    public int enemuMaxhealth;
    public int enemyHealthCount;
    public TextMeshPro txtenemyHealthCount;
    public PlayableDirector enemyTimeLine;
    [SerializeField] private int minHealthCount,maxHealthCount;
    private void Start() {
        enemuMaxhealth = Random.Range(minHealthCount,maxHealthCount);
        enemyHealthCount = enemuMaxhealth;
        txtenemyHealthCount.text = enemyHealthCount.ToString();
    }
    private void OnEnable() {
        EventManager.Instance.OnEnemyHitBullet += OnEnemyCollideWithBullet;
    }
    private void OnDisable() {
        EventManager.Instance.OnEnemyHitBullet -= OnEnemyCollideWithBullet;
    }
    private void Update() {
        txtenemyHealthCount.text = enemyHealthCount.ToString();
        if(enemyHealthCount <=0)
        {
            Destroy(this.gameObject);
        }
    }
    public void OnEnemyCollideWithBullet(int healthDecreaseBy,GameObject gameObject)
    {
        if(gameObject == this.gameObject)
        {
            enemyTimeLine.Play();
            enemyHealthCount -= healthDecreaseBy;
        }
    }

    private void OnDestroy() {
        ScoreManager.Instance.UpdateScore(enemuMaxhealth);
    }

    
}
