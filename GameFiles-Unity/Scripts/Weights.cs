using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weights : MonoBehaviour
{
    
    private Rigidbody2D weightRb;
    private Vector3 offset;

    private Vector3 startPos;
    private bool resetSettings;
    private bool collisionDone;  //to make the object inactive after use once

    // Start is called before the first frame update
    void Start()
    {
        weightRb = GetComponent<Rigidbody2D>();
        weightRb.mass = GenerateRandomMAss();
        startPos = transform.position;
        
    }


    // Update is called once per frame
    void Update()
    {
        WeightsReset();
        Debug.Log("Mouse Control :" + collisionDone);
        
        if (resetSettings)
        {
            weightRb.gravityScale = 0;
            transform.position = startPos;


        }
        
        


    }

    //Getting Random mass
    private float GenerateRandomMAss()
    {
        List<float> massList = new List<float>() { 5f, 10f, 15f, 20f };
        int randomIndex = Random.Range(0, massList.Count);
        float randomMass = massList[randomIndex];
        return randomMass;


    }
    
    //Mouse drag settings
    void OnMouseDown()
    {
        resetSettings = false;
        
        offset = transform.position - GetMousePos();
    }

    void OnMouseDrag()
    {
        weightRb.gravityScale = 1;
        transform.position = GetMousePos() + offset;


    }
    private Vector3 GetMousePos()
    {
        
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        if (!collisionDone)
        {
            return Camera.main.ScreenToWorldPoint(mousePos);

        }
        else
        {
            return (new Vector3(0, 0, 0));
        
        }
    }
   

    void WeightsReset()
    {
        
        if (transform.position.y < -5.5f)
        {
            resetSettings = true;
            
        
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.CompareTag("Plate1") || collision.gameObject.CompareTag("Plate2") )
        {
            collisionDone = true;

        
        }
    
    }

   
    
    
}



