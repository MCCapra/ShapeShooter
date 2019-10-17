using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private Vector3 playerPos;
    private int enemyType; //int to represent the type of enemy this is.
    [SerializeField]
    private float speed;

    [SerializeField]
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(playerPos);
        Destroy(this.gameObject, 25);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed;
    }

    public Vector3 PlayerPosition
    {
        get { return playerPos; }
        set { playerPos = value; }
    }

    public int Type
    {
        get { return enemyType; }
        set { enemyType = value; }
    }

    public GameObject Player
    {
        get { return player; }
        set { player = value; }
    }



    private void OnCollisionEnter(Collision collision)
    {
        switch(enemyType)
        {
            case 1:
                if(collision.gameObject.transform.tag == "CubeBullet")
                {
                    Destroy(this.gameObject);
                }
                break;
            case 2:
                if(collision.gameObject.transform.tag == "SphereBullet")
                {
                    Destroy(this.gameObject);
                    Debug.Log("Hit Sphere");
                }
                break;
            case 3:
                if(collision.gameObject.transform.tag == "CylinderBullet")
                {
                    Destroy(this.gameObject);
                    Debug.Log("Hit Cylinder");
                }
                break;
            default:
                break;
        }

        //Detect player
        if(collision.gameObject.transform.tag == "Player")
        {
            Destroy(this.gameObject);
            player.GetComponent<CameraMovement>().CanShoot = false;
        }
    }
}
