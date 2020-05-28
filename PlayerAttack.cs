using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBtwAttack <= 0)
        {

            if (Input.GetKey(KeyCode.Space))
            {
                playerAnim.SetTrigger("punch");
                timeBtwAttack = startTimeBtwAttack;
            }
            
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }

    }
}
