using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
     private Animator _playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        _playerAnimator = GetComponent<Animator>();
         _playerAnimator.SetFloat("Speed", 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
