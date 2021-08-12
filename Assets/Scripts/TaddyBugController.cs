using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaddyBugController : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator animator;
    float angle;

    public float maxHeight;
    public float flapVelocity;
    public float relativeVelocityX;
    public GameObject sprite;
    bool isDead;

    public bool IsDead()
    {
        return isDead;
    }
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = sprite.GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && transform.position.y < maxHeight)
        {
            Flap();
        }

        ApplyAngle();
        animator.SetBool("flapUp", angle >= 0.0f);
        animator.SetBool("flapDown", angle < 0.0f);
        animator.SetBool("hurt", isDead);
    }

    public void Flap()
    {
        if (isDead)
        {
            return;
        }

        if(rb2d.isKinematic)
        {
            return;
        }
        rb2d.velocity = new Vector2(0.0f, flapVelocity);
    }

    void ApplyAngle()
    {
        float targetAngle;

        if (isDead)
        {
            targetAngle = -90.0f;
        }
        else
        {
            targetAngle = Mathf.Atan2(rb2d.velocity.y * 0.1f, relativeVelocityX) * Mathf.Rad2Deg;
        }
        angle = Mathf.Lerp(angle, targetAngle, Time.deltaTime * 10.0f);

        sprite.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, angle);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(isDead)
        {
            return;
        }
        isDead = true;
    }

    public void SetSteerActive(bool active)
    {
        rb2d.isKinematic = !active;
    }
}
