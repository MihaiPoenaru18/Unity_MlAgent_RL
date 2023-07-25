using UnityEngine;

public class DumpsterDetect : MonoBehaviour
{
    public PushTrashAvoidObstacles_Agent agent;
    public int numberOfDempster = 1;

    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("goal_1"))
        {
            numberOfDempster += 2;
            agent.ScoreRewards();
        }
        if (collision.gameObject.CompareTag("goal_2"))
        {
            numberOfDempster += 3;
            agent.ScoreRewards();
        }
        //if (collision.gameObject.CompareTag("goal_3"))
        //{
        //    numberOfDempster += 4;
        //    agent.ScoreRewards();
        //}
    }

    public int GetTheRoad
    {
        get { return numberOfDempster; }
    }
}
