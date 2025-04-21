using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableScreenShare : MonoBehaviour
{
    public Transform player;

    private BoxCollider2D collider;

    private bool isInside = false;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space") && isInside) {
            TriggerShareScreen();
        }
    }

    void TriggerShareScreen() {
        print("shareScreen");
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        isInside = true;
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        isInside = false;
    }
}
