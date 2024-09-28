using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    public GameObject[] allObjects;
    //public List<GameObject> gameObjectList = new List<GameObject>(allObjects);

    public GameObject nearestObject;
    public GameObject goblinHouse;
    public Animator _animator;

    public Transform idleArea;

    float distance;
    float nearestDistance = 10000;
    float movementSpeed = 2f;
    public bool isSearching = true;
    public bool isMoving = false;
    public bool isStoring = false;

    public bool isRight = false;
    public int goldCount;


    private void Start()
    {
    }

    void Update()
    {

        allObjects = GameObject.FindGameObjectsWithTag("gold");

        // GameObject obj = GameObject.FindGameObjectWithTag("gold");
        // allObjects.Add(obj);

        if (isSearching == true &&  allObjects.Length > 0 )
        {
            searchGold();
        }

        if (isMoving == true && nearestObject != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, nearestObject.transform.position, movementSpeed * Time.deltaTime);
            _animator.SetBool("isWalking", true);
            if (nearestObject.transform.position.x - transform.position.x < 0)
            {
                isRight = false;
                Flip();
            }
            else
            {
                isRight = true;
                Flip();
            }
        }

        if (isStoring == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, goblinHouse.transform.position, movementSpeed * Time.deltaTime);
            _animator.SetBool("isWalking", true);
            if (goblinHouse.transform.position.x - transform.position.x < 0)
            {
                isRight = false;
                Flip();
            }
            else {
                isRight = true;
                Flip();
            }
        }

    }

    void Flip()
    {

            Vector3 theScale = transform.localScale;
            theScale.x = isRight? 1:-1;
            transform.localScale = theScale;

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
        
        if (nearestObject != null) { 
            nearestObject.gameObject.tag = "goldToPick"; 
        }
        isSearching = false;
        isMoving = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "goldToPick") {
            isMoving = false;
            isStoring = true;
            goblinHouse.GetComponent<Collider2D>().enabled = true;
            nearestDistance = 100;
            Destroy(other.gameObject);
            for (int i = 0; i < allObjects.Length; i++)
            {
                if (allObjects[i] == null)
                {
                    // allObjects.RemoveAt(i);
                    List<GameObject> gameObjectList = new List<GameObject>(allObjects);
                    gameObjectList.RemoveAll(x => x == null);
                    allObjects = gameObjectList.ToArray();
                }
            }
        }
        
        if (other.gameObject.tag == "goblinHut")
        {
            _animator.SetBool("isWalking", false);
            goblinHouse.GetComponent<Collider2D>().enabled = false;
            isStoring = false;
            isSearching = true;
            goldCount++;
            Debug.Log(goldCount);


        }
    }

}
