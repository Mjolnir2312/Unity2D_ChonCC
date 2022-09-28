using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTraps : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected float Damage;


    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDame(Damage);
        }
    }
}
