using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator _playerAnimator;
    private Rigidbody _playerRigidbody;

    public float walkSpeed;
    public float runSpeed;

    private float _currentSpeed;
    private float _horizontal;
    private float _vertical;

    private Vector3 _direction;

    public GameObject dialogue;
    public bool isPlayerInDialogue = false;
    public static bool isPlayerInQte = false;
    public static bool isPlayerInfirst = false;

    public GameObject mainCam;
    [SerializeField]
    float mainCamRotation;
    


    // Start is called before the first frame update
    void Start()
    {
        GameObject parentObj = GameObject.Find("Dialogue");
        GameObject bbb = parentObj.transform.Find("DialogueAndPointer").gameObject;
        dialogue = bbb ;
        _playerAnimator = GetComponent<Animator>();
        _playerRigidbody = GetComponent<Rigidbody>();
        mainCam = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        mainCamRotation = mainCam.transform.rotation.eulerAngles.y;
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        if (dialogue.activeInHierarchy==true&&isPlayerInfirst==false)
        {
            isPlayerInDialogue = true;
            _playerAnimator.SetFloat("Speed", 0);
        }
        else
        {
            isPlayerInDialogue = false;
        }
        if(isPlayerInQte==true)
        {
             _playerAnimator.SetFloat("Speed", 0);
        }
        if(isPlayerInfirst==true)
        {
             _playerAnimator.SetFloat("Speed", 0);
        }
    }

    private void FixedUpdate()
    {
        if(isPlayerInDialogue==false&&isPlayerInQte ==false&&isPlayerInfirst==false)
        {
            _direction = new Vector3(_horizontal, 0, _vertical).normalized;
            
            //rotation refix:
            _direction = Quaternion.Euler(0f,mainCamRotation,0f) * _direction;

            //when get input
            if (_direction.magnitude > 0)
            {
                //rotation
                transform.rotation = Quaternion.LookRotation(_direction, Vector3.up);

                //movement
                Vector3 p = transform.position;
                p += _direction * walkSpeed * Time.deltaTime;

                //rigidbody movement     
                _playerRigidbody.MovePosition(p);
            }

            _currentSpeed = new Vector3(_vertical, 0, _horizontal).magnitude * walkSpeed;
           // Debug.Log($"currentSpeed = {_currentSpeed}");

            _playerAnimator.SetFloat("Speed", _currentSpeed);
        }
       
    }

    
}
