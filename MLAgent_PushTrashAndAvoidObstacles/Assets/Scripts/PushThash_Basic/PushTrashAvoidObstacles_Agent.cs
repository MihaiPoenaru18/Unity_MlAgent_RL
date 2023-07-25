using System;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;
using static WriteCSVRaport;
using Random = UnityEngine.Random;

public class PushTrashAvoidObstacles_Agent : Agent
{
    public DumpsterDetect dumpsterDetect;
    [SerializeField]
    private PushTrashBasic_Settings settings;
    public GameObject trash;
    public GameObject dumpsterUp;
    public GameObject dumpsterDown;
    //public GameObject dumpster3;
    public ObstacolesGroup obstacles;
    [SerializeField]
    private bool randomPositionForAll;
    [SerializeField]
    private bool randomPositionForAllAndCount;
    private float startTime;
    private float time;
    private int numberOfCollisionWithObstacles = 1;
    [SerializeField]
    private WriteCSVRaport _writeCSVRaport;
    private float distanceFromTrashToDumspterUp = 1;
    private float distanceFromTrashToDumspterDown = 1;
    //private float distanceFromTrashToDumspter3 = 1; 
    private bool FinishEpisod = false;
    private int numberOfAddRewars = 1;
    private bool ShortRoadCorrect = false;
    private bool isFirstRaportTest = true;
    //public UserObstacle userObstacle;
    private bool firstInitial = true;

    public override void OnEpisodeBegin()
    {
        ObstaclesPostionOnEpisodeBegin(randomPositionForAllAndCount, randomPositionForAll);
        DumpsterPostionOnEpisodeBegin();
        firstInitial = true;
        //userObstacle.transform.localPosition = new Vector3(Random.Range(-20f, 18f), -5.598742f, Random.Range(-10f, 31.9f));
        trash.transform.localPosition = new Vector3(Random.Range(-25.3f, 28.3f), -3f, Random.Range(0.5f, 37.7f));
        transform.localPosition = new Vector3(Random.Range(-25.3f, 28.8f), -6.094f, Random.Range(0.5f, 37.7f));
        ResetNumberOfCollisionWithTrash();
        CalculateDistanceFromTrash(trash.transform.localPosition);
    }

    public void CalculateDistanceFromTrash(Vector3 distanceTrash)
    {
        distanceFromTrashToDumspterUp = Vector3.Distance(distanceTrash, dumpsterUp.transform.localPosition);
        distanceFromTrashToDumspterDown = Vector3.Distance(distanceTrash, dumpsterDown.transform.localPosition);
        //distanceFromTrashToDumspter3 = Vector3.Distance(distanceTrash, dumpster3.transform.localPosition);
    }

    private void ResetNumberOfCollisionWithTrash()
    {
        foreach (var obstacle in settings.obstacles)
        {
            obstacle.numberOfCollisionWithTrash = 1;
        }
        dumpsterDetect.numberOfDempster = 1;
        numberOfCollisionWithObstacles = 1;
        //userObstacle.numberOfCollisionWithTrash = 1;
        numberOfAddRewars = 1;
        ShortRoadCorrect = false;
        FinishEpisod = false;
    }

    private void DempstersScaleChange()
    {
        dumpsterUp.transform.localScale = new Vector3(Random.Range(0.95f, 1.24f), 0.2585344f, Random.Range(3, 5));
        dumpsterDown.transform.localScale = new Vector3(Random.Range(0.95f, 1.24f), 0.2585344f, Random.Range(3, 5));
        //dumpster3.transform.localScale = new Vector3(Random.Range(0.95f, 1.24f), 0.2585344f, Random.Range(3, 5));
    }

    private void DumpsterPostionOnEpisodeBegin()
    {
        var positionOfDempster = Random.Range(0, 5);
        switch (positionOfDempster)
        {
            //left and right up
            case 0:
                dumpsterUp.transform.localPosition = /*new Vector3(Random.Range(-39.3f, -36.3f), -6.005016f, 20.2f);*/ new Vector3(-45.5f, -6.005016f, 22.5f);
                dumpsterUp.transform.localRotation = Quaternion.Euler(0, 0, 0);
                dumpsterDown.transform.localPosition = /*new Vector3(Random.Range(36, 39.3f), -6.005016f, 20.2f);*/ new Vector3(49.1f, -6.005016f, 22.5f);
                dumpsterDown.transform.localRotation = Quaternion.Euler(0, 0, 0);
                //dumpster3.transform.localPosition = /*new Vector3(0f, -6.005016f, Random.Range(54, 57.2f));*/ new Vector3(1f, -6.005016f, 62.5f);
                //dumpster3.transform.localRotation = Quaternion.Euler(0, 90, 0);
                DempstersScaleChange();
                break;
            //up and down right 
            case 1:
                dumpsterUp.transform.localPosition = /*new Vector3(0f, -6.005016f, Random.Range(54, 57.2f));*/ new Vector3(1f, -6.005016f, 62.5f);
                dumpsterUp.transform.localRotation = Quaternion.Euler(0, 90, 0);
                dumpsterDown.transform.localPosition = /*new Vector3(0f, -6.005016f, Random.Range(-17.2f, -14.9f));*/ new Vector3(1f, -6.005016f, -21.45f);
                dumpsterDown.transform.localRotation = Quaternion.Euler(0, 90, 0);
                //dumpster3.transform.localPosition = /*new Vector3(Random.Range(36, 39.3f), -6.005016f, 20.2f);*/ new Vector3(49.1f, -6.005016f, 22.5f);
                //dumpster3.transform.localRotation = Quaternion.Euler(0, 0, 0);
                DempstersScaleChange();
                break;
            // left and down right 
            case 2:
                dumpsterUp.transform.localPosition = /*new Vector3(Random.Range(-39.3f, -36.3f), -6.005016f, 20.2f);*/ new Vector3(-45.5f, -6.005016f, 22.5f);
                dumpsterUp.transform.localRotation = Quaternion.Euler(0, 0, 0);
                dumpsterDown.transform.localPosition = /*new Vector3(0.3f, -6.005016f, Random.Range(-17.2f, -14.9f));*/ new Vector3(1f, -6.005016f, -21.45f);
                dumpsterDown.transform.localRotation = Quaternion.Euler(0, 90, 0);
                //dumpster3.transform.localPosition = /*new Vector3(Random.Range(36, 39.3f), -6.005016f, 20.2f);*/ new Vector3(49.1f, -6.005016f, 22.5f);
                //dumpster3.transform.localRotation = Quaternion.Euler(0, 0, 0);
                DempstersScaleChange();
                break;
            //right and up  left 
            case 3:
                dumpsterUp.transform.localPosition = /*new Vector3(Random.Range(-39.3f, -36.3f), -6.005016f, 20.2f);*/ new Vector3(-45.5f, -6.005016f, 22.5f);
                dumpsterUp.transform.localRotation = Quaternion.Euler(0, 0, 0);
                dumpsterUp.transform.localPosition = /*new Vector3(0f, -6.005016f, Random.Range(54, 57.2f));*/ new Vector3(1f, -6.005016f, 62.5f);
                dumpsterUp.transform.localRotation = Quaternion.Euler(0, 90, 0);
                //dumpster3.transform.localPosition = /*new Vector3(Random.Range(36, 39.3f), -6.005016f, 20.2f);*/  new Vector3(-49.6f, -6.005016f, 22.5f);
                //dumpster3.transform.localRotation = Quaternion.Euler(0, 0, 0);
                DempstersScaleChange();
                break;
            // right and up down ok
            default:
                dumpsterDown.transform.localPosition = /*new Vector3(Random.Range(36, 39.3f), -6.005016f, 20.2f);*/ new Vector3(49.1f, -6.005016f, 22.5f);
                dumpsterDown.transform.localRotation = Quaternion.Euler(0, 0, 0);
                dumpsterUp.transform.localPosition = /*new Vector3(0f, -6.005016f, Random.Range(54, 57.2f));*/ new Vector3(1f, -6.005016f, 62.5f);
                dumpsterUp.transform.localRotation = Quaternion.Euler(0, 90, 0);
                //dumpster3.transform.localPosition = new Vector3(1f, -6.005016f, -21.45f);
                //dumpster3.transform.localRotation = Quaternion.Euler(0, 90, 0);
                DempstersScaleChange();
                break;
        }
    }
  
    public void ObstaclesPostionOnEpisodeBegin(bool activateRandomPositionForAllAndNumber, bool activateRandomPositionForAll)
    {

        if (activateRandomPositionForAllAndNumber && !activateRandomPositionForAll)
        {
            int numberOfBush = Random.Range(1, 7);
            int numberOfBenches = Random.Range(1, 9);
            int numberOfTrees = Random.Range(1, 9);
            for (int i = 0; i < settings.bushes.Count; i++)
            {
                if (i < numberOfBush)
                {
                    settings.bushes[i].transform.localPosition = new Vector3(/*Random.Range(-25.3f, 28.8f)*/Random.Range(-33, 27.5f), 16.45f, Random.Range(-8.3f, 41.3f)) /*Random.Range(0.5f, 37.7f))*/;
                }
                else
                {
                    settings.bushes[i].transform.localPosition = new Vector3(Random.Range(-33, 37), -4.2f, Random.Range(-8.3f, 41.3f));
                }
            }
            for (int i = 0; i < settings.Trees.Count; i++)
            {
                if (i < numberOfTrees)
                {
                    settings.Trees[i].transform.localPosition = new Vector3(/*Random.Range(-25.3f, 28.8f)*/Random.Range(-33, 37), 10f, Random.Range(-8.3f, 41.3f))/*Random.Range(0.5f, 37.7f))*/;
                }
                else
                {
                    settings.Trees[i].transform.localPosition = new Vector3(Random.Range(-33, 37), -4.2f, Random.Range(-8.3f, 41.3f));
                }
            }
            for (int i = 0; i < settings.benches.Count; i++)
            {
                if (i < numberOfBenches)
                {
                    var randomPositionForBenches = Random.Range(0, 3);
                    settings.benches[i].transform.localPosition = new Vector3(/*Random.Range(-25.3f, 28.8f)*/Random.Range(-33, 37), 17.3f, Random.Range(-8.3f, 41.3f))/*Random.Range(0.5f, 37.7f))*/;
                    switch (randomPositionForBenches)
                    {
                        case 0:
                            settings.benches[i].transform.localRotation = Quaternion.Euler(-90, 90, 0);
                            break;
                        case 1:
                            settings.benches[i].transform.localRotation = Quaternion.Euler(-90, 0, 0);
                            break;
                        case 2:
                            settings.benches[i].transform.localRotation = Quaternion.Euler(-90, -90, 0);
                            break;
                        case 3:
                            settings.benches[i].transform.localRotation = Quaternion.Euler(0, 0, 0);
                            break;
                    }
                }
                else
                {
                    settings.benches[i].transform.localPosition = new Vector3(/*Random.Range(-25.3f, 28.8f)*/Random.Range(-33, 37), -4.2f, Random.Range(-8.3f, 41.3f))/*Random.Range(0.5f, 37.7f))*/;

                }
            }

            if (activateRandomPositionForAll && !activateRandomPositionForAllAndNumber)
            {
                foreach (var bush in settings.bushes)
                {
                    bush.transform.localPosition = new Vector3(/*Random.Range(-25.3f, 28.8f)*/Random.Range(-33, 37), 16.45f, Random.Range(-8.3f, 41.3f)) /*Random.Range(0.5f, 37.7f))*/;
                }

                foreach (var tree in settings.Trees)
                {
                    tree.transform.localPosition = new Vector3(/*Random.Range(-25.3f, 28.8f)*/Random.Range(-33, 37), 10f, Random.Range(-8.3f, 41.3f))/*Random.Range(0.5f, 37.7f))*/;
                }

                foreach (var bench in settings.benches)
                {
                    var randomPositionForBenches = Random.Range(0, 3);
                    bench.transform.localPosition = new Vector3(/*Random.Range(-25.3f, 28.8f)*/Random.Range(-33, 37), 17.3f, Random.Range(-8.3f, 41.3f))/*Random.Range(0.5f, 37.7f))*/;
                    switch (randomPositionForBenches)
                    {
                        case 0:
                            bench.transform.localRotation = Quaternion.Euler(-90, 90, 0);
                            break;
                        case 1:
                            bench.transform.localRotation = Quaternion.Euler(-90, 0, 0);
                            break;
                        case 2:
                            bench.transform.localRotation = Quaternion.Euler(-90, -90, 0);
                            break;
                        case 3:
                            bench.transform.localRotation = Quaternion.Euler(0, 0, 0);
                            break;
                    }
                }
            }
        }
    }

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        float moveX = actionBuffers.ContinuousActions[0];
        float moveZ = actionBuffers.ContinuousActions[1];
        transform.localPosition += new Vector3(moveX, 0, moveZ) * Time.deltaTime * settings.AgentRunSpeed;

        if (transform.localPosition.y < -8)
        {
            UnScoreReward(false);
        }
        AddReward(-1f / MaxStep);
        if (StepCount > MaxStep - 8)
        {
            _writeCSVRaport.WriteRaportCSV(isFirstRaportTest, CompletedEpisodes + 1, numberOfCollisionWithObstacles - 1, obstacles.CountNumberOfCollisionWithTrash(), StepCount, GetCumulativeReward(), FinishEpisod, 0, false);
            isFirstRaportTest = false;
        }
        //if (firstInitial)
        //{
        //    obstacles.CountNumberOfCollisionWithTrash();
        //    //firstInitial = false;
        //}
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> continousActions = actionsOut.ContinuousActions;
        continousActions[0] = Input.GetAxisRaw("Horizontal");
        continousActions[1] = Input.GetAxisRaw("Vertical");
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(trash.transform.localPosition);
        sensor.AddObservation(dumpsterUp.transform.localPosition);
        sensor.AddObservation(dumpsterDown.transform.localPosition);
        foreach (var bush in settings.bushes)
        {
            sensor.AddObservation(bush);
        }
        foreach (var tree in settings.Trees)
        {
            sensor.AddObservation(tree);
        }
        foreach (var bench in settings.benches)
        {
            sensor.AddObservation(bench);
        }
    }

    public void ScoreRewards()
    {
        //AddReward(10f);
        var reward = Math.Min(Math.Abs(distanceFromTrashToDumspterUp), Math.Abs(distanceFromTrashToDumspterDown));
        AddReward(1/reward);

        if (numberOfCollisionWithObstacles - 1 < 3)
        {
            numberOfAddRewars++;
        }
        if (obstacles.CountNumberOfCollisionWithTrash() < 4)
        {
            numberOfAddRewars++;
        }
        if (StepCount < 2500)
        {
            numberOfAddRewars++;
        }
        if (dumpsterDetect.GetTheRoad - 1 == 2 && distanceFromTrashToDumspterUp < distanceFromTrashToDumspterDown) 
        {
            numberOfAddRewars++;
            ShortRoadCorrect = true;
        }
        if (dumpsterDetect.GetTheRoad - 1 == 3 && distanceFromTrashToDumspterUp > distanceFromTrashToDumspterDown) 
        {
            numberOfAddRewars++;
            ShortRoadCorrect = true;
        }
        
        if (numberOfAddRewars == 5)
        {
            AddReward(40f);
            FinishEpisod = true;
        }
        _writeCSVRaport.WriteRaportCSV(isFirstRaportTest, CompletedEpisodes + 1, numberOfCollisionWithObstacles - 1, obstacles.CountNumberOfCollisionWithTrash(), StepCount, GetCumulativeReward(), FinishEpisod, numberOfAddRewars - 1, ShortRoadCorrect);
        isFirstRaportTest = false;
        settings.floorMeshRenderer.material = settings.WinMaterial;
        EndEpisode();
    }

    public void UnScoreReward(bool NegReward)
    {
        AddReward(-0.5f);
        numberOfCollisionWithObstacles++;
        settings.floorMeshRenderer.material = settings.LoseMaterial;
        if (!NegReward)
        {
            EndEpisode();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(settings.TagObstacles) || other.gameObject.CompareTag("User"))
        {
            UnScoreReward(true);
        }
    }
}
