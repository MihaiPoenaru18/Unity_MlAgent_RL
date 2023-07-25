using Unity.MLAgents;
using UnityEngine;

public class ObstacolesGroup : MonoBehaviour
{
    public PushTrashBasic_Settings settings;
    [SerializeField]
    private PushTrashAvoidObstacles_Agent agent;

    public int CountNumberOfCollisionWithTrash()
     {
        int count = 0;
        foreach (var obstacle in settings.obstacles) 
        {
            if(obstacle.ReturnNumberOfCollisionWithObstacles > 1 )
            {
                count++;
            }
        }
       
        return count;
    }
}
