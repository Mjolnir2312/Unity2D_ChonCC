using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int iFramesCoolDown;
    private SpriteRenderer spriteRed;

    [Header("Death and Hurt Sound")]
    [SerializeField] private AudioClip DeathSound;
    [SerializeField] private AudioClip HurtSound;


    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRed = GetComponent<SpriteRenderer>();
    }

    public void TakeDame(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        
        if(currentHealth > 0)
        {
            anim.SetTrigger("Hurt");
            StartCoroutine(Invulnerability());
            SoundManager.instance.PlaySound(HurtSound);
        }
        else
        {
            if(!dead)
            {
                anim.SetTrigger("Die");

                //Player
                if(GetComponent<PlayerController>() != null)
                    GetComponent<PlayerController>().enabled = false;

                //Enemy
                if (GetComponent<EnemyPatrol>() != null)
                    GetComponent<EnemyPatrol>().enabled = false;

                if (GetComponent<Enemy>() != null)
                    GetComponent<Enemy>().enabled = false;

                dead = true;
                SoundManager.instance.PlaySound(DeathSound);
            }
            
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            TakeDame(1);
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(9, 10, true);
        for(int i = 0; i < iFramesCoolDown; i++)
        {
            spriteRed.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (iFramesCoolDown * 2));
            spriteRed.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (iFramesCoolDown * 2));
        }
        Physics2D.IgnoreLayerCollision(9, 10, false);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }


}
