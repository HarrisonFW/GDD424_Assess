using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class WaveManager : MonoBehaviour
{
    //Lets hear for ChatGPT

    //also remeber to explain all methods/fucntions

    public GameObject enemyPrefab;
    public Transform[] spawnPoints;

    public float spawnDelay = 1f;

    public int currentWave = 0;
    private int enemiesRemaining = 0;

    public TextMeshProUGUI waveText;
    public TextMeshProUGUI enemiesLeftText;
    public TextMeshProUGUI notificationText;

    public PlayerHEALTH playerHealth;

    public void Start()
    {
        notificationText.text = "";
        StartNextWave();
    }

    public void StartNextWave()
    {
        currentWave++;
        waveText.text = "Wave " + currentWave;

        notificationText.text = "Health restored!";
        playerHealth.HealToFull();

        int enemiesToSpawn = currentWave;
        enemiesRemaining = enemiesToSpawn;
        enemiesLeftText.text = enemiesRemaining + " enemies left.";

        StartCoroutine(SpawnEnemies(enemiesToSpawn));

        StartCoroutine(ClearNotificationAfterDelay(2f));
    }

    IEnumerator SpawnEnemies(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

            EnemyHEALTH enemyHealth = enemy.GetComponent<EnemyHEALTH>();
            if(enemyHealth != null)
            {
                enemyHealth.waveManager = this;
            }

            yield return new WaitForSeconds(spawnDelay);
        }
    }

    public void OnEnemyKilled()
    {
        enemiesRemaining--;
        enemiesLeftText.text = enemiesRemaining + " enemies left.";

        if (enemiesRemaining <= 0)
        {
            StartCoroutine(NextWaveAfterDelay(2f));
        }
    }

    IEnumerator NextWaveAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        StartNextWave();
    }

    IEnumerator ClearNotificationAfterDelay(float time)
    {
        yield return new WaitForSeconds(time);
        notificationText.text = "";
    }
}
