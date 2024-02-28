using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate2 : MonoBehaviour
{
    private float plate2Weights = 0;
    [SerializeField] public float totalWeight = 0;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TotalWeight();
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Weights"))
        {

            plate2Weights = collision.gameObject.GetComponent<Rigidbody2D>().mass;
            collision.gameObject.GetComponent<Rigidbody2D>().mass = 0.001f;
            


        }

    }


    void TotalWeight()
    {

        totalWeight += plate2Weights;
        plate2Weights = 0;


    }
}
