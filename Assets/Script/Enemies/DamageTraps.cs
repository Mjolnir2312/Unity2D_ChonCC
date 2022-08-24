using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTraps : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float Damage;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDame(Damage);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
