using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCreationAndMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateTileRow", 0f, 0.7f);
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void CreateTileRow()
    {
        

        for(int i = 0; i < 5; i++)
        {
            int chanceOfTileCreationBottom = Random.Range(1, 6); 
            int chanceOfTileCreationTop = Random.Range(1, 6);

            int chanceOfStopperCreation = Random.Range(1, 6);


            if (chanceOfTileCreationBottom > 1)
            {
                GameObject instTileBottom = Instantiate(GameObject.Find("tile")); // bottom tile creation
                instTileBottom.transform.position = new Vector3((i * 2) - 4, 0, 5);
                instTileBottom.AddComponent<MovingPanels>();

                if (chanceOfStopperCreation == 1)
                {
                    GameObject instStopperBottom = Instantiate(GameObject.Find("stopper"));
                    instStopperBottom.name = "stopperClone";
                    instStopperBottom.transform.position = instTileBottom.transform.position;
                    instStopperBottom.AddComponent<MovingPanels>();
                }

            }

            if (chanceOfTileCreationTop > 1)
            {
                GameObject instTileTop = Instantiate(GameObject.Find("tile")); // top tile creation
                instTileTop.transform.position = new Vector3((i * 2) - 4, 4.34f, 5);
                instTileTop.AddComponent<MovingPanels>();

                if (chanceOfStopperCreation == 2)
                {
                    GameObject instStopperTop = Instantiate(GameObject.Find("stopper"));
                    instStopperTop.name = "stopperClone";
                    instStopperTop.transform.position = instTileTop.transform.position;
                    instStopperTop.AddComponent<MovingPanels>();
                }

            }
            
        }
    }
}
