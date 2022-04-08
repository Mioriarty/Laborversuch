using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyCameraController : MonoBehaviour
{
    [SerializeField]
    private Transform focus;

    [SerializeField]
    private float stickiness = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = focus.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 moveDir = focus.position - this.transform.position;

        this.transform.Translate(moveDir * this.stickiness * Time.fixedDeltaTime);
    }
}
