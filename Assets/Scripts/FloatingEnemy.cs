using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingEnemy : MonoBehaviour
{
    public GameObject player;
    public int speed = 2;
    public int life = 3;
    public float distance = 6.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        Debug.Log(Vector3.Distance(transform.position, player.transform.position));
        if (Vector3.Distance(transform.position, player.transform.position) > distance)
        {
            GetComponent<Rigidbody>().velocity = transform.forward * speed + -transform.right * speed;    
        } else if (Vector3.Distance(transform.position, player.transform.position) < distance)
        {
            GetComponent<Rigidbody>().velocity = -transform.forward * speed + -transform.right * speed;    
        } else 
        {
            GetComponent<Rigidbody>().velocity = -transform.right * speed;
        }
       
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.collider.tag == "Projectile")
        {
            Destroy(other.collider.gameObject);
            life = life - 1;
            if (life == 0) {
                Destroy(gameObject);
            }
        }
    }
}
