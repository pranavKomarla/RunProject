using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPanels : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(5f * Vector3.back * Time.deltaTime);
        if(transform.position.z < -47)
        {
            Destroy(this.gameObject); 
        }

        
    }
}
