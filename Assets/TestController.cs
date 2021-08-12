using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
    Animator anim = new Animator();
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        anim.SetBool("flapDown", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetBool("flapDown", false);
            anim.SetBool("flapUp", true);
        } else if(Input.GetKeyUp(KeyCode.W))
        {
            anim.SetBool("flapUp", false);
            anim.SetBool("flapDown", true);
        }


        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetBool("flapDown", false);
            anim.SetBool("flapUp", false);
            anim.SetBool("hurt", true);
        }

    }
}
