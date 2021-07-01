using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerAnimation : MonoBehaviour
{
    private Animator m_Animator;
    private Rigidbody2D m_Rb;

    private string m_CurrentAnimation = "";
    
    private enum FacingDirection
    {
        FacingRight,
        FacingLeft,
        FacingUp,
        FacingDown
    }
    
    private enum AnimNames
    {
        walkingright,
        walkingleft,
        walkingup,
        walkingdown,
        idleRight,
        idleLeft,
        idleUp,
        idleDown
    }

    private FacingDirection m_FacingDirection;
        
    // Start is called before the first frame update
    void Awake()
    {
        m_Animator = GetComponent<Animator>();
        m_Rb = GetComponent<Rigidbody2D>();
        m_FacingDirection = FacingDirection.FacingDown;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        if (m_Rb.velocity == Vector2.zero)
        {
            if (m_FacingDirection == FacingDirection.FacingRight)
            {
                ChangeAnimation("idleRight");
            }
            else if (m_FacingDirection == FacingDirection.FacingLeft)
            {
                ChangeAnimation("idleLeft");
            }
            else if (m_FacingDirection == FacingDirection.FacingUp)
            {
                ChangeAnimation("idleUp");
            }
            else if (m_FacingDirection == FacingDirection.FacingDown)
            {
                ChangeAnimation("idleDown");
            }
            
        }
        if (m_Rb.velocity.x > 0.1f)
        {
            ChangeAnimation(AnimNames.walkingright.ToString());
            m_FacingDirection = FacingDirection.FacingRight;
        }
        if (m_Rb.velocity.x < -0.1f)
        {
            ChangeAnimation(AnimNames.walkingleft.ToString());
            m_FacingDirection = FacingDirection.FacingLeft;
        }
        if (m_Rb.velocity.y > 0.1f)
        {
            ChangeAnimation(AnimNames.walkingup.ToString());
            m_FacingDirection = FacingDirection.FacingUp;
        }
        if (m_Rb.velocity.y < -0.1f)
        {
            ChangeAnimation(AnimNames.walkingdown.ToString());
            m_FacingDirection = FacingDirection.FacingDown;
        }
    }

    private void ChangeAnimation(string animationName)
    {
        if (m_CurrentAnimation == animationName.ToString()) return;

        m_CurrentAnimation = animationName.ToString();
        m_Animator.Play(animationName.ToString());
        
    }
}
