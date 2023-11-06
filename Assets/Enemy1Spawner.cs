using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Spawner : MonoBehaviour
{
    // SerializedField makes variable "public" to Unity editor
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform player;
    private Vector3 originalPos;
    private float timer = 2f; // 2 second delay before enemy respawn
    private void Start()
    {
        originalPos = enemyPrefab.transform.position;
    }

    private void Update()
    {
        //Debug.Log(enemyPrefab.activeSelf);
        if (!enemyPrefab.GetComponent<Renderer>().enabled)
        {
            timer -= Time.deltaTime;
            if (timer < 0) {
                timer = 2;
                enemyPrefab.transform.position = originalPos;
                enemyPrefab.GetComponent<Renderer>().enabled = true;
            }
        }

        if (DidCollideWithPlayer()) {
            
            enemyPrefab.GetComponent<Renderer>().enabled = false;
        }
    }

    private bool DidCollideWithPlayer() {
        return Vector3.Distance(player.position, enemyPrefab.transform.position) < 0.3f;
    }
}
