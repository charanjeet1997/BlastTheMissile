using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstantiate : MonoBehaviour
{
    public List<Vector2> edgePoints;
    public float enemyInstantiateInterval;
    public Camera mainCamera;
    public GameObject enemyPrefab;
    public Transform enemyHolder;
    private void Start()
    {
        edgePoints = new List<Vector2>()
        {
            mainCamera.ScreenToWorldPoint(new Vector2(0,Screen.height)),
            mainCamera.ScreenToWorldPoint(new Vector2(Screen.width,0)),
            mainCamera.ScreenToWorldPoint(new Vector2(Screen.width,Screen.height)),
            mainCamera.ScreenToWorldPoint(new Vector2(Screen.width,Screen.height/2)),
            mainCamera.ScreenToWorldPoint(new Vector2(0,Screen.height/2)),
            mainCamera.ScreenToWorldPoint(new Vector2(Screen.width/2,Screen.height)),
            mainCamera.ScreenToWorldPoint(new Vector2(Screen.width/2,0)),
        };

        StartCoroutine(EnemyInstantiateAtEdgePoint());
    }


    IEnumerator EnemyInstantiateAtEdgePoint()
    {
        yield return new WaitForSeconds(enemyInstantiateInterval);
        if (GameManager.instance.player != null)
        {
            GameObject enemy = Instantiate(enemyPrefab, edgePoints[Random.Range(0, edgePoints.Count - 1)], Quaternion.identity);
            enemy.transform.parent = enemyHolder;
            StartCoroutine(EnemyInstantiateAtEdgePoint());
        }
    }
}
