using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    // public List<GameObject> allObjects;
    public GameObject[] allObjects;
    public GameObject nearestObject;
    public GameObject goblinHouse;

    float distance;
    float nearestDistance = 10000;
    float movementSpeed = 2f;
    public bool isSearching = true;
    public bool isMoving = false;
    public bool isStoring = false;

    public int goldCount;


    private void Start()
    {
    }

    void Update()
    {
        allObjects = GameObject.FindGameObjectsWithTag("gold");

        /*
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("gold"))
        {
            allObjects.Add(obj);
        }
        */

        if (isSearching == true &&  allObjects.Length > 0 )
        {
            searchGold();
        }

        // if (Input.GetKeyDown(KeyCode.Space)) { searchGold(); }
        if (isMoving == true && nearestObject != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, nearestObject.transform.position, movementSpeed * Time.deltaTime);
        }

        if (isStoring == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, goblinHouse.transform.position, movementSpeed * Time.deltaTime);
        }

    }

    public void searchGold()
    {
        for (int i = 0; i < allObjects.Length; i++)
        {
            distance = Vector3.Distance(this.transform.position, allObjects[i].transform.position);

            if (distance < nearestDistance)
            {
                nearestObject = allObjects[i];
                nearestDistance = distance;
            }
        }
        isSearching = false;
        isMoving = true;
        if (nearestObject != null) { nearestObject.gameObject.tag = "goldToPick"; }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "goldToPick") {
            isMoving = false;
            isStoring = true;
            goblinHouse.GetComponent<Collider2D>().enabled = true;
            Destroy(other.gameObject);
        }
        
        if (other.gameObject.tag == "goblinHut")
        {
            goblinHouse.GetComponent<Collider2D>().enabled = false;
            isStoring = false;
            isSearching = true;
            goldCount++;
            Debug.Log(goldCount);


        }
    }

}
