using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header ("Attack Parameters")]
    [SerializeField] private float AttackCooldown;
    [SerializeField] private float Range;
    [SerializeField] private int Damage;

    [Header("Collider Parameters")]
    [SerializeField] private float ColliderDistance;
    [SerializeField] private BoxCollider2D BoxCollider;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;

    [Header("Attack Sound")]
    [SerializeField] private AudioClip AttackSound;

    public float currentHealth { get; private set; }
    private float CooldownTime = Mathf.Infinity;

    private Animator Anim;
    private Health PlayerHealth;
    private bool dead;

    private EnemyPatrol enemyPatrol;

    private void Awake()
    {
       
        Anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }


  


    // Update is called once per frame
    private void Update()
    {
        CooldownTime += Time.deltaTime;

        //Attack when player in sight!
        if(PlayerInSight())
        {
            if(CooldownTime >= AttackCooldown && PlayerHealth.currentHealth > 0)
            {
                CooldownTime = 0;
                Anim.SetTrigger("enmattack");
                SoundManager.instance.PlaySound(AttackSound);
            }
        }

        if (enemyPatrol != null)
            enemyPatrol.enabled = !PlayerInSight();
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(BoxCollider.bounds.center + transform.right * Range * transform.localScale.x * ColliderDistance,
            new Vector3(BoxCollider.bounds.size.x * Range, BoxCollider.bounds.size.y, BoxCollider.bounds.size.z), 
            0, Vector2.left, 0, playerLayer);

        if (hit.collider != null)
            PlayerHealth = hit.transform.GetComponent<Health>();

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(BoxCollider.bounds.center + transform.right * Range * transform.localScale.x * ColliderDistance,
            new Vector3(BoxCollider.bounds.size.x * Range, BoxCollider.bounds.size.y, BoxCollider.bounds.size.z));
    }

    private void DamagePlayer()
    {
        if (PlayerInSight())
            PlayerHealth.TakeDame(Damage);
    }

    //public void TakeDamage(float _damage)
    //{
    //    currentHealth = Mathf.Clamp(currentHealth - _damage, 0, EnemyHealth);

    //    //Anim.SetTrigger("hurt");
    //    //if(currentHealth <= 0)
    //    //{
    //    //    EmyDie();
    //    //    Debug.Log("Enemy die");
    //    //}

    //    if (currentHealth > 0)
    //    {
    //        Anim.SetTrigger("Hurt");
    //    }
    //    else
    //    {
    //        if (!dead)
    //        {
    //            Anim.SetTrigger("Die");
    //            dead = true;
    //        }
    //    }
    //}

}
