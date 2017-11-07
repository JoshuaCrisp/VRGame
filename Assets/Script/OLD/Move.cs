using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public float bounceSpeed = 0.002f;

    public bool itemBounceUp = false;

	//public float lifetime;
	public float speed;


    void Start()
    {
        StartCoroutine("itemBounce", 0.8f);
		//Destroy (gameObject, lifetime);
    }

    void Update()
    {
        Vector3 myTransform = transform.position;

        if (itemBounceUp == true)
        {
            myTransform.y += bounceSpeed;
            transform.position = myTransform;
        }

        else if (itemBounceUp == false)
        {
            myTransform.y -= bounceSpeed;
            transform.position = myTransform;
        }

        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    IEnumerator itemBounce(float repeatAfter)
    {
        int i;
        for (i = 1; i > 0; i++)
        {
            if (itemBounceUp)
            {
                itemBounceUp = false;
                yield return new WaitForSeconds(repeatAfter);
            }
            else if (itemBounceUp == false)
            {
                itemBounceUp = true;
                yield return new WaitForSeconds(repeatAfter);
            }
        }
    }
}
