using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowProjectile : DamageTraps
{
    [SerializeField] private float Speed;
    [SerializeField] private float ResetTime;
    private float lifeTime;

    public void ActivateProjectile()
    {
        lifeTime = 0;
        gameObject.SetActive(true);
    }

    private void Update()
    {
        float movementSpeed = Speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);

        lifeTime += Time.deltaTime;
        if (lifeTime > ResetTime)
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        gameObject.SetActive(false);
    }
}
