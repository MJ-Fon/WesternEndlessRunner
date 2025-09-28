using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    bool isPressed = false;
    public float Speed = 5f;
    public GameObject Player;

    // Update is called once per frame
    void Update()
    {
        if (isPressed)
        {
            Player.transform.Translate(Speed, 0, 0);
        }

        // Keyboard input
        // float horizontal = 0f;
        //if (Input.GetKey(KeyCode.A))
        //   horizontal = -1f;
        // if (Input.GetKey(KeyCode.D))
        //   horizontal = 1f;
        float horizontal = 0f;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            horizontal = -1f;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            horizontal = 1f;

        if (horizontal != 0)
        {
            Player.transform.Translate(horizontal * Speed * Time.deltaTime, 0, 0);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }
}
