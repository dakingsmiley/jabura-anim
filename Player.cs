using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator playerAnim;

    [SerializeField]
    private float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }
    // Update is called once per frame
    private void Update()
    {

    }
    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        
        HandleMovement(horizontal);

    }

    private void HandleMovement(float horizontal)
    {
        rb.velocity = new Vector2(horizontal * movementSpeed, rb.velocity.y); //x = -1, y = 0;

        playerAnim.SetFloat("speed", Mathf.Abs(horizontal));
    }

}
