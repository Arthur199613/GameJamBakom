using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMovement : MonoBehaviour
{
    //Drag the wanted Button into the Button slot of this script in unity 
    public Button triggerButton;
    private bool isMoved;

    // Start is called before the first frame update
    void Start()
    {
        isMoved = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerButton.isPressed && !isMoved)
        {
            isMoved = true;
            transform.position = new Vector2(transform.position.x, transform.position.y - 1);
        }

    }
}
