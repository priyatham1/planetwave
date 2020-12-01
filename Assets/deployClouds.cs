using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deployClouds : MonoBehaviour
{
    public GameObject cloudPrefab;
    public float respawnTime = 1;
    private Vector2 screenBounds;

    // Use this for initialization
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(cloudWave());
    }
    private void spawnEnemy()
    {
        GameObject a = Instantiate(cloudPrefab) as GameObject;
        a.transform.position = new Vector2(screenBounds.x, Random.Range(-screenBounds.y, 0));
    }
    IEnumerator cloudWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            spawnEnemy();
        }
    }
}
