using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmAI : MonoBehaviour
{

    public GameObject player;
    float speed = 4;
    float radius = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        if(Vector3.Distance(transform.position, player.transform.position) <= radius)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.position = new Vector3(-5f, 0f, -10f);
        }
    }
}
