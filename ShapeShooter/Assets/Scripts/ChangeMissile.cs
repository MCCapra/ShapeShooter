using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMissile : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> missiles; //List of different Missiles.

    public int curMissileInd; //Index of the Current Missile.


    public Camera camera; //For making it look not shit
    // Start is called before the first frame update
    void Start()
    {

        curMissileInd = 0;

        missiles[curMissileInd].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

        TurnOffShape();

        curMissileInd += (int)Input.mouseScrollDelta.y;

        if(curMissileInd > 2)
        {
            curMissileInd = 0;
        }

        if(curMissileInd < 0)
        {
            curMissileInd = 2;
        }

        missiles[curMissileInd].SetActive(true);
        missiles[curMissileInd].transform.LookAt(camera.transform);
    }

    void TurnOffShape()
    {
        missiles[curMissileInd].SetActive(false);
    }
}
