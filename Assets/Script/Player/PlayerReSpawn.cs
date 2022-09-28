using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReSpawn : MonoBehaviour
{
    [Header("Checkpoint Sound")]
    [SerializeField] private AudioClip CheckpointSound;
    [Header("Respawn Sound")]
    [SerializeField] private AudioClip RespawnSound;
    private Transform currentCheckpoint;
    private Health playerHealth;
    private UIManager uiManager;

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
        uiManager = FindObjectOfType<UIManager>();
    }


    public void CheckRespawn()
    {
        if(currentCheckpoint == null)
        {
            uiManager.GameOver();

            return;
        }

        playerHealth.Respawn();
        SoundManager.instance.PlaySound(RespawnSound);
        transform.position = currentCheckpoint.position;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform;
            SoundManager.instance.PlaySound(CheckpointSound);
            collision.GetComponent<Collider2D>().enabled = false;
        }
    }
}
