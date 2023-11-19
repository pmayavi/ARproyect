using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FloatingEnemy : MonoBehaviour
{
    public GameObject player;
    public int speed = 2;
    public int life = 3;
    public float distance = 6.0f;
    public int movement = 1; // o -1 para moverse en sentido contrario.

    // Variables cambio de material cuando se golpea    
    public Material normalMaterial;
    public Material hitMaterial;
    public float hitDuration = 0.5f;
    private float hitTime = 0.0f;

    private Renderer bodyRenderer;
    public string childName = "PM3D_Sphere3D2";

    // Variable del sistema de partículas
    public ParticleSystem explosionParticles;

    // Start is called before the first frame update
    void Start()
    {
        Transform bodyTransform = transform.Find("PM3D_Sphere3D2");

        if (bodyTransform != null)
        {
            bodyRenderer = bodyTransform.GetComponent<Renderer>();
        } 
        else 
        {
            bodyRenderer = transform.GetComponent<Renderer>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Movimiento Circular alrededor del player manteniendo una distancia estable
        transform.LookAt(player.transform, Vector3.up);
        transform.Rotate(0, 0, 180);

        Debug.Log(Vector3.Distance(transform.position, player.transform.position));
        if (Vector3.Distance(transform.position, player.transform.position) > distance)
        {
            GetComponent<Rigidbody>().velocity = transform.forward * speed + transform.right * speed * movement;    
        } 
        else if (Vector3.Distance(transform.position, player.transform.position) < distance)
        {
            GetComponent<Rigidbody>().velocity = -transform.forward * speed + transform.right * speed * movement;    
        } 
        else 
        {
            GetComponent<Rigidbody>().velocity = transform.right * speed * movement ;
        }

        // Cambiar de color cuando se golpea
        if (Time.time - hitTime < hitDuration && hitTime != 0)
        {
            // Gradually return to normal color over hitDuration
            bodyRenderer.material.Lerp(hitMaterial, normalMaterial, (Time.time - hitTime) / hitDuration);
        }
        else if (bodyRenderer.material != normalMaterial)
        {
            // Reset material when the hitDuration is over
            bodyRenderer.material = normalMaterial;
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.collider.tag == "Projectile")
        {
            bodyRenderer.material = hitMaterial;
            hitTime = Time.time;

            Destroy(other.collider.gameObject);
            life = life - 1;
            if (life == 0) {
                GetComponent<Renderer>().enabled = false;
                GetComponent<Collider>().enabled = false;
                if (explosionParticles != null)
                {
                    // Activate the particle system
                    explosionParticles.Play();
                }
                FindObjectOfType<UI>().PickItem();
                Destroy(gameObject, 1f);
            }
        }
    }
}
