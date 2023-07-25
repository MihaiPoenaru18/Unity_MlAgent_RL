using System.Collections.Generic;
using UnityEngine;

public class PushTrashBasic_Settings : MonoBehaviour
{

    public List<GameObject> Trees;

    public List<GameObject> bushes;

    public List<GameObject> benches;

    public List<Obstacle> obstacles;

    public GameObject trash;
        
    public string TagObstacles;

    public float AgentRunSpeed = 50f;

    public MeshRenderer floorMeshRenderer;

    public Material WinMaterial;

    public Material LoseMaterial;

}
