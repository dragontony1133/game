using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Boss : MonoBehaviour
{
    // Start is called before the first frame update

    
    public Transform player;
    public bool isFlipped = false;
    public void LookAtPlayer()
    {
        if (transform.position.x > player.position.x && isFlipped ) 
        {
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false ;
        }
       else  if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }






    }

    // Update is called once per frame
    void Update()
    {
        LookAtPlayer(); 
    }
}
