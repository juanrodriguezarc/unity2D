using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    GravityController _gc;
    Rigidbody2D _rb;
    [SerializeField] float _speed = 200.0f;
    Vector2 _move;
    Vector2 smoothVel;
    private bool isGrounded = false;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        _gc = GameObject.FindGameObjectWithTag("Circle").GetComponent<GravityController>();
    }

    void Update()
    {
        Vector3 moveDir = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0).normalized;
        Vector3 magnitude = moveDir * _speed;
        _move = Vector2.SmoothDamp(moveDir, magnitude, ref smoothVel, .15f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _gc.Attract(_rb);

        var pos = transform.TransformDirection(_move);

        if(isGrounded)
            _rb.MovePosition(_rb.position + (new Vector2(pos.x, pos.y) * Time.fixedDeltaTime));


        RaycastHit2D hit = Physics2D.Raycast(_rb.position, -_rb.transform.up, Mathf.Infinity);

        if(hit.collider)
        {
             Debug.Log("Collition: "+ hit.collider.tag + hit.distance.ToString());
            Debug.DrawRay(_rb.position, -_rb.transform.up * 3, Color.green);
        }


    }


    void OnCollisionEnter2D(Collision2D col)
    {
        isGrounded = true;
    }




}
