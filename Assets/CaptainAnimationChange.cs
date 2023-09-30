using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CaptainAnimationChange : MonoBehaviour
{
    public Animator CaptainAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name=="CaptainRoom")
        {
            CaptainAnimator.SetBool("isidle",false);
        }
        else
        {
            CaptainAnimator.SetBool("isidle",true);
        }
    }
}
