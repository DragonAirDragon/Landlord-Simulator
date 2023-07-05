using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : MonoBehaviour
{
    public static EnemyControler instance;
    public float speed;
    public Transform pointRun;
    public Transform pointEndWin;
    public Transform pointEndKKK;
    public Rigidbody theRB;
    private Vector3 theDirection;
    public bool start = true;
    public bool win = false;
    public bool loose = false;
    public Animator animator;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            animator.SetBool("isMoving", true);
            theDirection = pointRun.position - transform.position;
            theRB.velocity = theDirection * speed;
            transform.LookAt(new Vector3(pointRun.position.x, transform.position.y, pointRun.position.z));
            if (Vector3.Distance(pointRun.position, transform.position) < 2f)
            {
                start = false;
                theRB.velocity = Vector3.zero;
                animator.SetBool("isMoving", false);
                Manager.instance.window.SetActive(true);
                Manager.instance.GenerateNewParametrs();
            }
        }
        if (win)
        {
            animator.SetBool("isMoving", true);
            theDirection = pointEndWin.position - transform.position;
            theRB.velocity = theDirection * speed;
            transform.LookAt(new Vector3(pointEndWin.position.x, transform.position.y, pointEndWin.position.z));
            if (Vector3.Distance(pointEndWin.position, transform.position) < 2f)
            {
                win = false;
                Destroy(gameObject);
                animator.SetBool("isMoving", false);
            }
        }
        if (loose)
        {
            animator.SetBool("isMoving", true);
            theDirection = pointEndKKK.position - transform.position;
            theRB.velocity = theDirection * speed;
            transform.LookAt(theDirection + transform.position);
            if (Vector3.Distance(pointEndKKK.position, transform.position) < 2f)
            {
                loose = false;
                Destroy(gameObject);
                animator.SetBool("isMoving", false);
            }

        }





    }
}

