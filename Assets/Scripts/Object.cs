using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    [SerializeField] float objectSpeed = 1f;
    [SerializeField] private float resetPos = 10.9f;
    [SerializeField] private float startPos = -30.55f;
    // Start is called before the first frame update
    void Start()    
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (GameManager.instance.PlayerActive)
        {
            if (!GameManager.instance.GameOver)
            {
                transform.Translate(Vector3.right * (objectSpeed * Time.deltaTime));

                if (transform.localPosition.x >= resetPos)
                {
                    Vector3 newPos = new Vector3(startPos, transform.position.y, transform.position.z);
                    transform.position = newPos;
                }
            }
        }
        
    }
}
