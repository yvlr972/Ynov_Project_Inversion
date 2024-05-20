using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovements : MonoBehaviour
{
    [Header("Car Movements")]
    [SerializeField]
    private float _forwardSpeed;
    [SerializeField]
    private float _lateralSpeed;
    [SerializeField]
    private float _jumpForce;
    [SerializeField]
    private float _gravityForce;
    [SerializeField]
    private float _acceleration = 10;
    [SerializeField]
    private Rigidbody _rb;

    [Header("Car Tilt animations")]
    [SerializeField]
    private CarTiltAnimations _tiltAnim;

    private int _numberOfColliderUnder = 0;

    private float _jumpTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float forwardDelta = _forwardSpeed * Time.deltaTime;
        float lateralDelta = _lateralSpeed * Time.deltaTime;

        Vector3 currentSpeed = _rb.velocity;

        Vector3 tempSpeed = currentSpeed;

        //mouvement avant
        tempSpeed = transform.forward * _forwardSpeed;

        //On conserve la vitesse verticale
        tempSpeed.y = _rb.velocity.y;

        // Mouvement horizontal
        if (Input.GetKey(KeyCode.RightArrow))
        {
            tempSpeed += transform.right * _lateralSpeed;
            _tiltAnim.setTiltRight();
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            tempSpeed += -transform.right * _lateralSpeed;
            _tiltAnim.setTiltLeft();
        }

        _rb.velocity = Vector3.Lerp(_rb.velocity, tempSpeed, _acceleration * Time.deltaTime);

        //Gravite
        if (_rb.velocity.y < -1)
            _rb.AddForce(Physics.gravity * Time.deltaTime * _gravityForce);


        //Mouvement de saut
        if (Input.GetKeyDown(KeyCode.Space) && /*isGrounded()*/ (_numberOfColliderUnder > 0))
        {
            _jumpTimer = 0.0f;
            _rb.AddForce(new Vector3(0, 30*_jumpForce, 0));
        }
        else if (Input.GetKey(KeyCode.Space) && (_jumpTimer < 0.2f))
        {
            _jumpTimer += Time.deltaTime;
            _rb.AddForce(new Vector3(0, _jumpForce, 0));
        }
        /*else if (Input.GetKeyUp(KeyCode.Space) && (_jumpTimer < 0.4f))
        {
            _jumpTimer += Time.deltaTime;
            _rb.AddForce(new Vector3(0, _jumpForce, 0));
        }*/
        else if (Input.GetKeyUp(KeyCode.Space) && (_jumpTimer > 0.2f))
        {
            _rb.AddForce(Physics.gravity * Time.deltaTime * _gravityForce);
        }
        else
        {
            _rb.AddForce(Physics.gravity * Time.deltaTime * _gravityForce);
        }


        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            _tiltAnim.setNormal();
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        _numberOfColliderUnder++;

    }


    private void OnTriggerExit(Collider other)
    {
        _numberOfColliderUnder--;
    }


    private bool isGrounded()
    {
        // Verifier si le joueur est au sol en utilisant une sphere de rayon 0,1 unite
        // centree sur la position du joueur et dirigee vers le bas
        RaycastHit hit;
        Vector3 position = transform.position;
        position.y += 1.0f;
        bool isGrounded = Physics.SphereCast(position, 0.1f, Vector3.down, out hit, 0.2f);
        return isGrounded;
    }


}

