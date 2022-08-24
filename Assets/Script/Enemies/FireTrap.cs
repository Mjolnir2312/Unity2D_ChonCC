using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    [Header ("Firetrap Damage")]
    [SerializeField] private float damage;

    [Header("Firetrap Timers")]
    [SerializeField] private float ActivationDelay;
    [SerializeField] private float ActivationTime;
    private Animator anim;
    private SpriteRenderer spriteRed;

    [Header("SFX")]
    [SerializeField] private AudioClip FiretrapSound;

    private bool triggered;
    private bool active;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRed = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(!triggered)
            {
                StartCoroutine(activeFiretrap());
            }
            if(active)
            {
                collision.GetComponent<Health>().TakeDame(damage);
            }
        }
    }

    private IEnumerator activeFiretrap()
    {
        //turn the sprite red when the player trigger the trap
        triggered = true;
        spriteRed.color = Color.red;

        //wait for delay
        yield return new WaitForSeconds(ActivationDelay);
        SoundManager.instance.PlaySound(FiretrapSound);
        spriteRed.color = Color.white;
        active = true;
        anim.SetBool("activated", true);

        //wait until seconds
        yield return new WaitForSeconds(ActivationTime);
        active = false;
        triggered = false;
        anim.SetBool("activated", false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
