using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject sledgePickup;
    public ParticleSystem sledgeParticles;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player" || collision.gameObject.tag == "Player")
            {
            Destroy(sledgePickup);
            sledgeParticles.enableEmission = false;
            Debug.Log("Item collected!");
            }
        }
    }
