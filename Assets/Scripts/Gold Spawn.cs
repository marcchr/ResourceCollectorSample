using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class GoldSpawn : MonoBehaviour
{
    [SerializeField] private float spawnInterval = 3f;
    [SerializeField] Goblin goblin;
    private float elapsedTime;
    public MoveObject goldPrefab;

    private void Update()
    {
        if (elapsedTime < spawnInterval)
        {
            elapsedTime += Time.deltaTime;
        }
        else
        {
            spawnGold();
            elapsedTime = 0f;
        }
    }

    public void spawnGold()
    {
        var gold = Instantiate(goldPrefab, transform.position, Quaternion.identity);
        gold.spawnArea = transform;
        //goblin.allObjects.Add(gold);
    }

    
}
