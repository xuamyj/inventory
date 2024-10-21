using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;
using Naninovel;

public class PlayerController : MonoBehaviour
{
    /* ---- MOVEMENT ---- */
    public InputAction LeftAction;
    public InputAction RightAction;
    public InputAction DownAction;
    public InputAction UpAction;

    public float speed;

    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;

    /* ---- NANINOVEL ---- */
    public bool IsInputBlocked;

    async void RunInitalize()
    {
        await RuntimeInitializer.InitializeAsync();
    }

    // Start is called before the first frame update
    void Start()
    {
        /* ---- MOVEMENT ---- */

        // QualitySettings.vSyncCount = 0;
        // Application.targetFrameRate = 10;

        LeftAction.Enable();
        RightAction.Enable();
        DownAction.Enable();
        UpAction.Enable();

        rigidbody2d = GetComponent<Rigidbody2D>();

        /* ---- NANINOVEL ---- */
        IsInputBlocked = false;
        RunInitalize();
    }

    // Update is called once per frame
    void Update()
    {
        /* ---- MOVEMENT ---- */

        // UnityEngine.Debug.Log("Hi");
        // UnityEngine.Debug.Log(Keyboard.current);
        // UnityEngine.Debug
        // Changed to "Both"
        // added Input System Package, but maybe doesn't do anything
        // added EventSystem and clicked twice, but maybe doesn't do anything

        horizontal = 0.0f;
        if (LeftAction.IsPressed())
        {
            horizontal = -speed;
        }
        else if (RightAction.IsPressed())
        {
            horizontal = speed;
        }
        // UnityEngine.Debug.Log("keyboard horizontal: " + horizontal);

        vertical = 0.0f;
        if (DownAction.IsPressed())
        {
            vertical = -speed;
        }
        else if (UpAction.IsPressed())
        {
            vertical = speed;
        }
        // UnityEngine.Debug.Log("keyboard vertical: " + vertical);
    }

    void FixedUpdate()
    {
        if (!IsInputBlocked)
        {
            Vector2 position = rigidbody2d.position; // transform.position;
            position.x = position.x + horizontal * Time.deltaTime;
            position.y = position.y + vertical * Time.deltaTime;
            // transform.position = position;
            rigidbody2d.MovePosition(position);
        }
    }
}

