using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 8f; 

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVec = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        this.rb.velocity = inputVec * speed;
    }
}
