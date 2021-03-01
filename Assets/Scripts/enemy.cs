using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public float rotationSpeed;

    public GameObject dust;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, rotationSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);


            GameManager.instance.GameOver();
        } 
        else if (collision.gameObject.tag == "Ground")
        {
            GameManager.instance.IncrementScore();


            GameObject dustEffect = Instantiate(dust, transform.position, Quaternion.identity);

            gameObject.SetActive(false);
            Destroy(dustEffect, 2f);
            Destroy(gameObject, 2f);

            

            



        }
    }

}
