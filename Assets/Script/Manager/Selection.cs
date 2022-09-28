using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selection : MonoBehaviour
{
    [SerializeField] private RectTransform[] Option;
    [SerializeField] private AudioClip ChangeSound;
    [SerializeField] private AudioClip InteractSound;
    private RectTransform rect;
    private int currentPosition;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            ChangePosition(-1);
        if (Input.GetKeyDown(KeyCode.DownArrow))
            ChangePosition(1);

        if (Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.KeypadEnter))
            Interact();
    }
    private void ChangePosition(int _change)
    {
        currentPosition += _change;

        if (_change != 0)
            SoundManager.instance.PlaySound(ChangeSound);

        if (currentPosition < 0)
            currentPosition = Option.Length - 1;
        else if (currentPosition > Option.Length - 1)
            currentPosition = 0;

        rect.position = new Vector3(rect.position.x, Option[currentPosition].position.y, 0);
    }

    private void Interact()
    {
        SoundManager.instance.PlaySound(InteractSound);

        Option[currentPosition].GetComponent<Button>().onClick.Invoke();
    }
}
