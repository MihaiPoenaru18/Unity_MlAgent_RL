using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private PushTrashAvoidObstacles_Agent agent;
    [SerializeField]
    private PushTrashBasic_Settings settings;
    public int numberOfCollisionWithTrash = 1;
    [SerializeField]
    private bool randomPositionForAll;
    [SerializeField]
    private bool randomPositionForAllAndCount;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("trash"))
        {
            numberOfCollisionWithTrash++;
            agent.AddReward(-0.5f);
            settings.trash.transform.localPosition = new Vector3(Random.Range(-20f, 18f), -5.61f, Random.Range(1f, 26f));
            agent.ObstaclesPostionOnEpisodeBegin(randomPositionForAllAndCount, randomPositionForAll);
            agent.CalculateDistanceFromTrash(settings.trash.transform.localPosition);

        }

        if (other.gameObject.CompareTag("Obstacles"))
        {
            agent.OnEpisodeBegin();
        }
    }

    public int ReturnNumberOfCollisionWithObstacles
    {
        get { return numberOfCollisionWithTrash; }
    }
}