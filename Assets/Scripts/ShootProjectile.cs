using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    public GameObject projectile;

    public float launchSpeed = 1500f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) 
        {
            GameObject projectileInstance = Instantiate(projectile, transform.position, transform.rotation);
            projectileInstance.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 100f, launchSpeed));
            Destroy(projectileInstance, 1);
        }
    }
}
