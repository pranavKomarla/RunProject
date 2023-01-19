using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class movingBall : MonoBehaviour
{

    Rigidbody rb;
    
    bool normalGravity;
    
    public GameObject mainCamera;

    public GameObject canvas; 

    float time = 0f;

    public Light pointLight; 
   
    Quaternion to;
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        normalGravity = true;

        to = Quaternion.Euler(0, 0, 0);


        Time.timeScale = 1; 
        Physics.gravity = new Vector3(0, -9.8f, 0);

        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if (transform.position.z != -27)
        // transform.position = new Vector3(transform.position.x, transform.position.y, -27); 

        if(normalGravity)
            pointLight.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        else
            pointLight.transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);

        time -= Time.deltaTime;


        if(transform.position.y < -2 || transform.position.y > 5.5)
        {
            canvas.SetActive(true);
            //Time.timeScale = 0; 
        }


        if(normalGravity)
        {
            if (Input.GetKey(KeyCode.A))
                rb.AddForce(3f * Vector3.left, ForceMode.Force);

            if (Input.GetKey(KeyCode.D))
                rb.AddForce(3f * Vector3.right, ForceMode.Force);

            if (Input.GetKeyDown(KeyCode.W) && transform.position.y < 0.7)
            {
                rb.AddForce(5f * Vector3.up, ForceMode.Impulse);
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.D))
                rb.AddForce(3f * Vector3.left, ForceMode.Force);

            if (Input.GetKey(KeyCode.A))
                rb.AddForce(3f * Vector3.right, ForceMode.Force);

            if (Input.GetKeyDown(KeyCode.W) && transform.position.y > 3.3)
            {
                rb.AddForce(5f * Vector3.down, ForceMode.Impulse);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && normalGravity == true && time < 0)
        {
            Physics.gravity = new Vector3(0, 9.8f, 0);
            time = 5f; 
            normalGravity = false;

            mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, 2.38f, mainCamera.transform.position.z);  

            to = Quaternion.Euler(0, 0, 180);
        }

        else if (Input.GetKeyDown(KeyCode.Space) && normalGravity == false && time < 0)
        {
            Physics.gravity = new Vector3(0, -9.8f, 0);
            time = 5f; 
            normalGravity = true;

            mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, 1.83f, mainCamera.transform.position.z);

            to = Quaternion.Euler(0, 0, 0);
        }
        

        mainCamera.transform.rotation = Quaternion.Lerp(mainCamera.transform.rotation, to, Time.deltaTime * 3f);


    }

    public void RestartTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
        print("The button is working");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "stopperClone")
        {
            canvas.SetActive(true);
            Time.timeScale = 0;
        }
    }


}
