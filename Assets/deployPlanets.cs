using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deployPlanets : MonoBehaviour
{
    public GameObject[] planetPrefabs;
    public float respawnTime = 1;
    private Vector2 screenBounds;

    // Use this for initialization
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(planetWave());
    }
    private void spawnEnemy()
    {
        GameObject a = Instantiate(planetPrefabs[Random.Range(0, planetPrefabs.Length)]) as GameObject;
        a.transform.position = new Vector2(screenBounds.x, Random.Range(-screenBounds.y, 0));
    }
    IEnumerator planetWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            spawnEnemy();
        }
    }
}
