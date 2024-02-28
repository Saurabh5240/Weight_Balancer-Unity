using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScaleBalance : MonoBehaviour
{

    
    [SerializeField] private Plate1 plate1;
    [SerializeField] private Plate2 plate2;
    private float weight1=0;
    private float weight2=0;
    private int compareWeight=0;
    private float turnSpeed = 10f;
    private int rotateSide = 0;

    //Equation Comparison 
    public TextMeshProUGUI eqnText;
    public TextMeshProUGUI balancedText;

    // Start is called before the first frame update
    void Start()
    {
        eqnText.text = "Weight Comparison is : LeftSide: 0  =  RightSide: 0    ";
        balancedText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        weight1 = plate1.totalWeight;
        weight2 = plate2.totalWeight;
        RotateScalePlatform();
        UpdateEquation();
    }
    void RotateScalePlatform()
    {

        
        compareWeight = (int)(weight1 - weight2 );
        Debug.Log(compareWeight);


        if (compareWeight==0 && transform.rotation.z * Mathf.Rad2Deg >0 )
        {
            transform.Rotate(-1 * Vector3.forward * turnSpeed * Time.deltaTime);

            if (transform.rotation.z * Mathf.Rad2Deg < 0)
            {

                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                balancedText.gameObject.SetActive(true);

            }


        }
        if (compareWeight== 0  && transform.rotation.z * Mathf.Rad2Deg < 0)
        {
            transform.Rotate(Vector3.forward * turnSpeed * Time.deltaTime);

            if (transform.rotation.z * Mathf.Rad2Deg > 0)
            {

                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                balancedText.gameObject.SetActive(true);

            }



        }
        if (compareWeight > 1)
        {
            transform.Rotate(1 * Vector3.forward * turnSpeed * Time.deltaTime);
            
            if (transform.rotation.z * Mathf.Rad2Deg > 4)
            {

                transform.rotation = Quaternion.Euler(0f, 0f, 8f);


            }
            balancedText.gameObject.SetActive(false);
        }
        if (compareWeight < -1)
        {
            transform.Rotate(-1 * Vector3.forward * turnSpeed * Time.deltaTime);

            if (transform.rotation.z * Mathf.Rad2Deg < -4)
            {

                transform.rotation = Quaternion.Euler(0f, 0f, -8f);


            }
            balancedText.gameObject.SetActive(false);
        }
        

        

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);



    }

    private void UpdateEquation()
    {
        int leftWeight = (int)weight1;
        int rightWeight = (int)weight2;
        if (compareWeight > 1)
        {
            eqnText.text = "Weight Comparison is -> LeftSide: "+ leftWeight +"kg >  RightSide: "+ rightWeight +" kg";


        }
        if (compareWeight < 1)
        {
            eqnText.text = "Weight Comparison is -> LeftSide: " + leftWeight + "kg <  RightSide: " + rightWeight + " kg";


        }
        if (compareWeight == 0)
        {
            eqnText.text = "Weight Comparison is -> LeftSide: " + leftWeight + "Kg =  RightSide: " + rightWeight + "kg";
            

        }

        
    }

}
