using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
    public AIPath aiPath;
    private Animator anim;

    // Update is called once per frame
    void Update()
    {
        if(aiPath.desiredVelocity.x >= 1.01f)
        {
            //transform.localScale = new Vector3(-1f, 1f, 0f);
            anim.SetBool("MoveLeft", true);
        }
        else if(aiPath.desiredVelocity.x <= -0.01f)
        {
            //transform.localScale = new Vector3(1f, 1f, 0f);
            anim.SetBool("MoveRight", true);
        }
        //else
        //{

        //}


    }
}
