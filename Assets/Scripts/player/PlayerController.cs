using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 8f; 
    [SerializeField] private float dashSpeed = 15f;
    [SerializeField] private float dashDuration = 0.3f;
    private float dashStartTime = -10f;
    private Vector3 dashDirection;

    private Rigidbody rb;
    private Animator animator;
    private MeleeWeaponHandler meleeWeaponHandler;

    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
        this.animator = GetComponentInChildren<Animator>();
        this.meleeWeaponHandler = GetComponent<MeleeWeaponHandler>();
        this.cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // Handle movement
        bool isDashing = dashStartTime + dashDuration >= Time.time;
        Vector3 desiredMovementDirection = Vector3.zero;
        Vector3 inputVec = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;

        if(!isDashing && inputVec != Vector3.zero && Input.GetKeyDown(KeyCode.Space)) {
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

        // Handle Clicking
        if(Input.GetMouseButtonDown(0)) {
            Ray mouseRay = this.cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;
            if(Physics.Raycast(mouseRay, out raycastHit, 100, LayerMask.GetMask("Ground"))) {
                // deal damage in this direction
                this.meleeWeaponHandler.Hit((raycastHit.point - transform.position).normalized);
                
            }
        }
    }
}
