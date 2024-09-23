using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;

public class MoveObject : MonoBehaviour
{
    public Transform spawnArea;
    private float elapsedTime = 0f;
    public float animationDuration = 0.7f;
    Vector2 randomPoint;



    private void Start()
    {
        randomPoint = new Vector2(Random.Range(-8.5f, 8.5f), Random.Range(-3.5f, 2f));
    }

    private void Update()
    {
        if (spawnArea == null) { return; }
        if (elapsedTime < animationDuration)
        {
            elapsedTime += Time.deltaTime;
        }
        transform.position = Vector3.Lerp(spawnArea.position, randomPoint, elapsedTime / animationDuration);
    }
}
