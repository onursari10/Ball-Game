using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ballScript : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] float speed;
    float yon = 0.5f;

    [SerializeField] gameManager gm;

    int hit = 10;


    public GameObject yer;

    MeshRenderer color;

    [SerializeField] GameObject renk;


    bool sag, sol;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        color = GetComponent<MeshRenderer>();

        
    }

    
    void Update()
    {
        ballMove();
        ballMove2();


        if (gameObject.transform.position.y < -2.0f)
        {
            ballFall();
        }
        
    }

    void ballMove()
    {
        
        rb.AddForce(Vector3.forward * speed * Time.deltaTime);
        if (speed == 0)
        {
            speed = 0;
        }
        else
        {
            speed += 1.2f * Time.deltaTime;
        }
       
    }

    void ballMove2()
    {
        //rb.AddForce(Vector3.right * yon * speed * Time.deltaTime);
        Vector3 sag_git =  new Vector3(1,transform.position.y,transform.position.z);
        Vector3 sol_git = new Vector3(-1, transform.position.y, transform.position.z);

        if (Input.touchCount > 0 )
        {
            Touch parmak = Input.GetTouch(0);
            if (parmak.deltaPosition.x > 30)
            {
                sag = true;
                sol = false;
            }

            if (parmak.deltaPosition.x < -30)
            {
                sag = false;
                sol = true;
            }

            if (sag == true)
            {
                transform.position = Vector3.Lerp(transform.position, sag_git,yon * Time.deltaTime);
            }

            if (sol == true)
            {
                transform.position = Vector3.Lerp(transform.position, sol_git, yon * Time.deltaTime);
            }
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bonus"))
        {
            
            transform.localScale = transform.localScale + new Vector3(0.01f, 0.01f, 0.01f);
            gm.plusScore(hit);
            Destroy(other.gameObject);
           
        }

        if (other.CompareTag("finish"))
        {
            speed = 0;
            gm.theEnd();
        }

        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag=="colorGround")
        {
            renk.SetActive(true);
            color.material.color = other.gameObject.GetComponent<MeshRenderer>().material.color;
            StartCoroutine(sure());
        }
    }

    IEnumerator sure()
    {
        yield return new WaitForSeconds(1);
        renk.SetActive(false);
    }

   public void ballFall()
    {
        gm.gameOver();
    }

}
