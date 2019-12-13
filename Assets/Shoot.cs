using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float force;
    public GameObject bulletPrefab;
    public Transform initialPosition;
    public bool canShoot;
    public Vector3 direction;
    public Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        canShoot = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {

            canShoot = true;
        }
        else
        {
            canShoot = false;
        }
    }

    private void FixedUpdate()
    {
        if(canShoot)
        {
            direction = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            direction = direction - gameObject.transform.position;
            direction.Normalize();
            Shooting(direction);
        }
    }

    public void Shooting(Vector3 distance)
    {
        GameObject aux = Instantiate(bulletPrefab, initialPosition.position, initialPosition.rotation);
        aux.GetComponent<Rigidbody>().AddForce(distance * force);
    }
}
