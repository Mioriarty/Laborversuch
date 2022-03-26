using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 8f; 

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
        Vector2 inputVec = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        this.rb.velocity = inputVec.normalized * speed;

        this.animator.SetBool("isMoving", inputVec.sqrMagnitude > 0.001f);
        this.animator.SetFloat("angle", Vector2.SignedAngle(inputVec, Vector2.up));
    }
}
