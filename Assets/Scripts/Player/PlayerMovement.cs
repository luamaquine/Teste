using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float velocity;

    private InputActions m_InputActions;
    private Vector2 m_Direction;

    private Rigidbody2D m_Rb;
    
    // Start is called before the first frame update
    void Awake()
    {
        m_InputActions = new InputActions();
        m_Rb = GetComponent<Rigidbody2D>();

        m_InputActions.Player.Movement.performed += ctx => m_Direction = ctx.ReadValue<Vector2>();
        m_InputActions.Player.Movement.canceled += ctx => m_Direction = Vector2.zero;
    }

    private void OnEnable()
    {
        m_InputActions.Enable();
    }

    private void OnDisable()
    {
        m_InputActions.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        m_Rb.velocity = m_Direction * velocity;
    }
}
