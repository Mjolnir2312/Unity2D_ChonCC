using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float Speed;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform Player;
    [SerializeField] private float AheadDistance;
    [SerializeField] private float CameraSpeed;
    private float lookaHead;


    private void Update()
    {
        //transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX,transform.position.y, transform.position.z),
        //    ref velocity, Speed * Time.deltaTime);

        transform.position = new Vector3(Player.position.x, transform.position.y, transform.position.z);
        lookaHead = Mathf.Lerp(lookaHead, (AheadDistance * Player.localScale.x), Time.deltaTime * CameraSpeed);
    }


}
