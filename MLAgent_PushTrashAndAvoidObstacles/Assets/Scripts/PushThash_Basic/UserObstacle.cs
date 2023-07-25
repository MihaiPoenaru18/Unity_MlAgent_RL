using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserObstacle : MonoBehaviour
{
    public float speed = 20;
    private float horizontalInput;
    private float verticalInput;
    [SerializeField]
    private PushTrashAvoidObstacles_Agent agent;
    [SerializeField]
    private PushTrashBasic_Settings settings;
    public int numberOfCollisionWithTrash = 1;


    //private void OnCollisionEnter(Collision other)
    //{
    //    if (other.gameObject.CompareTag("trash"))
    //    {
    //        numberOfCollisionWithTrash++;
    //        agent.AddReward(-0.02f);
    //        settings.trash.transform.localPosition = new Vector3(Random.Range(-20f, 18f), -5.61f, Random.Range(1f, 26f));
    //    }
        
    //}
    public int ReturnNumberOfCollisionWithObstacles
    {
        get { return numberOfCollisionWithTrash; }
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right*Time.deltaTime*speed*verticalInput);
       // transform.Translate(Vector3.up*Time.deltaTime* speed*horizontalInput);

    }
}
