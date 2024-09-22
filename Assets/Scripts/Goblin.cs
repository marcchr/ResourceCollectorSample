using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    public GameObject[] allObjects;
    public GameObject nearestObject;
    public GameObject goblinHouse;

    float distance;
    float nearestDistance = 10000;
    float movementSpeed = 2f;
    public bool isSearching = true;
    public bool isStoring = false;

    public int goldCount;


    private void Start()
    {

    }

    void Update()
    {
        searchGold();

        while (isSearching == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, nearestObject.transform.position, movementSpeed * Time.deltaTime);
        }

        while (isStoring == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, goblinHouse.transform.position, movementSpeed * Time.deltaTime);
        }

    }

    public void searchGold()
    {
        allObjects = GameObject.FindGameObjectsWithTag("gold");

        for (int i = 0; i < allObjects.Length; i++)
        {
            distance = Vector3.Distance(this.transform.position, allObjects[i].transform.position);

            if (distance < nearestDistance)
            {
                nearestObject = allObjects[i];
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isSearching = false;
        isStoring = true;
        goldCount++;
        Debug.Log(goldCount);
        Destroy(other.gameObject);
    }

}
