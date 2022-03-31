using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 8f; 
    [SerializeField] private float dashSpeed = 15f;
    [SerializeField] private float dashDuration = 0.3f;
    private float dashStartTime = -10f;
    private Vector2 dashDirection;

    private Rigidbody2D rb;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isDashing = dashStartTime + dashDuration >= Time.time;
        Vector2 desiredMovementDirection = Vector3.zero;
        Vector2 inputVec = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        if(!isDashing && inputVec != Vector2.zero && Input.GetKeyDown(KeyCode.Space)) {
            dashStartTime = Time.time;
            isDashing = true;
            dashDirection = inputVec;
        }

        if(isDashing) {
            this.rb.velocity = dashDirection * dashSpeed;
            desiredMovementDirection = dashDirection;
        } else {
            this.rb.velocity = inputVec * speed;
            desiredMovementDirection = inputVec;
        }
        

        this.animator.SetBool("isMoving", desiredMovementDirection.sqrMagnitude > 0.001f);
        this.animator.SetFloat("angle", Vector2.SignedAngle(desiredMovementDirection, Vector2.up));
    }
}
