using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
    private Animator _anim = new Animator();
    // Start is called before the first frame update
    private void Start()
    {
        _anim = this.GetComponent<Animator>();
        _anim.SetBool("flapDown", true);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _anim.SetBool("flapDown", false);
            _anim.SetBool("flapUp", true);
        } 
        else if(Input.GetKeyUp(KeyCode.W))
        {
            _anim.SetBool("flapUp", false);
            _anim.SetBool("flapDown", true);
        }


        if (Input.GetKeyDown(KeyCode.D))
        {
            _anim.SetBool("flapDown", false);
            _anim.SetBool("flapUp", false);
            _anim.SetBool("hurt", true);
        }

    }
}
