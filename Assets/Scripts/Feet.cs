using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feet : MonoBehaviour
{
    public LayerMask layerMask;
    public bool isGround;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (((1 << collision.gameObject.layer) & layerMask) != 8)
        {
            isGround = true;
        
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isGround = false;
    }



}
