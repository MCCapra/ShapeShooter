using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 mousePos;

    [SerializeField]
    private float rotSpeed, moveSpeed;

    [SerializeField]
    private GameObject sphereBullte, cubeBullet, cylBullet, currBulletState;

    [SerializeField]
    private float h, v, pitch, yaw;

    private int bulletState;

    public bool CanShoot;
    // Start is called before the first frame update
    void Start()
    {
        mousePos = new Vector3(0.0f, 0.0f, 0.0f);
        Cursor.lockState = CursorLockMode.Locked;

        bulletState = currBulletState.GetComponent<ChangeMissile>().curMissileInd;
        CanShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        bulletState = currBulletState.GetComponent<ChangeMissile>().curMissileInd;

        h = Input.GetAxis("Mouse X") * rotSpeed;
        v = Input.GetAxis("Mouse Y") * rotSpeed;

        pitch -= v;
        yaw += h;

        transform.rotation = Quaternion.Euler(pitch, yaw, 0 );
        
        
        //Movement
        Movement();

        //Shoot
        Shoot();
    }

    void Movement()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.position = transform.position + transform.forward * moveSpeed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position = transform.position - transform.forward * moveSpeed;
        }
        
        if(Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position - transform.right * moveSpeed;
        }

        if(Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + transform.right * moveSpeed;
        }
    }

    void Shoot()
    {
        if(Input.GetMouseButtonDown(0) && CanShoot)
        {
            switch (bulletState)
            {
                case 0:
                    Instantiate(cubeBullet, transform.position, transform.rotation);
                    break;
                case 1:
                    Instantiate(sphereBullte, transform.position, transform.rotation);
                    break;
                case 2:
                    Instantiate(cylBullet, transform.position, transform.rotation);
                    break;
                default:
                    break;

            }
        }

    }
}
