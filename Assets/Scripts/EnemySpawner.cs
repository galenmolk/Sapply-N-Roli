using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using GGJ;

public class EnemySpawner : MonoBehaviour
{
    public Enemy prefab;

    public Enemy enemyInstance;

    public float maxSpeedBoost;

    public float respawnDelayMin;
    public float respawnDelayMax;

    private void Start() {
        Spawn();
    }

    private void HandleDie()
    {
         StartCoroutine(RespawnAfterDelay());
    }

    private IEnumerator RespawnAfterDelay()
    {
        yield return new WaitForSeconds(Random.Range(respawnDelayMin, respawnDelayMax));
        
        enemyInstance.transform.position = transform.position;
        enemyInstance.gameObject.SetActive(true);
        enemyInstance.transform.DOScale(1f, 1f);
        enemyInstance.coll.enabled = true;
                Debug.Log("max speed boost: " + maxSpeedBoost);
                Debug.Log("adding: " + (Saply.Instance.sequenceIndex / Saply.Instance.winIndex) + " times boost");

        enemyInstance.speed = enemyInstance.startingSpeed + (((float)Saply.Instance.sequenceIndex / Saply.Instance.winIndex) * maxSpeedBoost);
        Debug.Log("Respawned with speed: " + enemyInstance.speed);
    }

    private void Spawn()
    {
        enemyInstance = Instantiate(prefab, transform.position, Quaternion.identity, transform);
        enemyInstance.onDie.AddListener(HandleDie);
    }
}
