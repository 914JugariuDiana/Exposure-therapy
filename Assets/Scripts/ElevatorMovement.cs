using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ElevatorMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 100f;
    [SerializeField]
    public Transform bottomPoint, topPoint;
    private bool movingDown = false;

    public AudioSource audioSource;

    public GameObject wall1;
    public GameObject wall2;
    public GameObject wallFront;

    private bool blockedWalls = true;

    // Start is called before the first frame update
    void Start()
    {
        playCitySound();
    }

    void fixedUpdate()
    {
        if (movingDown)
        {
            if (bottomPoint != null)
            {
                if (transform.position != bottomPoint.position) {
                    transform.position = Vector3.MoveTowards(transform.position, bottomPoint.position, speed * Time.deltaTime);
                }
            }
        }
        else
        {
            if (topPoint != null)
            {
                if (transform.position != topPoint.position)
                {
                    transform.position = Vector3.MoveTowards(transform.position, topPoint.position, speed * Time.deltaTime);
                }
            }
        }
    }

    private void blockWalls()
    {
        blockedWalls = true;
        wall1.GetComponent<Collider>().enabled = true;
        wall2.GetComponent<Collider>().enabled = true;
        wallFront.GetComponent<Collider>().enabled = true;
    }

    private void unblockWalls()
    {
        blockedWalls = false;
        wall1.GetComponent<Collider>().enabled = false;
        wall2.GetComponent<Collider>().enabled = false;
        wallFront.GetComponent<Collider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        double scaledValueVolume = (100 - transform.position.y) / (100 - 0.21);
        audioSource.volume = (float)scaledValueVolume;

        double scaledValueTransparence = (110 - transform.position.y) / (110 - 0.21);
        this.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, (float)scaledValueTransparence);
        
        if (transform.position.y <= 0.5f && blockedWalls == true)
        {
            unblockWalls();
        }
        
        if (transform.position.y > 0.5f &&  blockedWalls == false) 
        {
            blockWalls();
        }

        if (Input.GetKey(KeyCode.E))
        {
            movingDown = false;
            fixedUpdate();
        }

        if (Input.GetKey(KeyCode.Q))
        {
            movingDown = true;
            fixedUpdate();
        }
    }

    private void playCitySound()
    {
        audioSource.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }

    private void activateDeactivateWalls()
    {
        wall1.GetComponent<Renderer>().material.color = Color.red;
        wall2.GetComponent<Renderer>().material.color = Color.red;
        wallFront.GetComponent<Renderer>().material.color = Color.red;

        wall1.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0f);
        wall2.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0f);
        wallFront.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0f);
    }
}
