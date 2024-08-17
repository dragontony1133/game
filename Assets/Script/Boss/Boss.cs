using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Boss : MonoBehaviour
{
    // Start is called before the first frame update

    
    public Transform player;
    public bool isFlipped = true;
    private Vector3 initLocalScale;
    public void LookAtPlayer()
    {
        if (transform.position.x > player.position.x && isFlipped ) 
        {
            Vector3 newLocalScale = initLocalScale;
            transform.localScale = newLocalScale;

        }
       else  if (transform.position.x < player.position.x && !isFlipped)
        {
            Vector3 newLocalScale = initLocalScale;
            newLocalScale.x *=-1;
            transform.localScale = newLocalScale;
            // transform.Rotate(0f, 180f, 0f);
            // isFlipped = true;
        }






    }
    void Start() {

        initLocalScale =  transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        LookAtPlayer(); 
    }
}
