using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WriteCSVRaport : MonoBehaviour
{
    private string filename = "";

    public List<ModelRaport> mylist = new List<ModelRaport>
    {
        new ModelRaport(){
        Episods = -1,
        NumberOfCollisionAgentObstacles = -1,
        NumberOfCollisionTrashObstacles = -1,
        NumberOfCondition = -1,
        ShortRoadCorrect = false
    }
    };

    void Start()
    {
        filename = Application.dataPath + $"/raport_ShortRoad_Testare_RewardMOdificat_MaxStep3000_FaraReinitializareaScenei_faraconditia.csv";
    }

    public void WriteRaportCSV(bool IsFirstRaport, int Episods, int NumberOfCollisionAgentObstacles, int NumberOfCollisionTrashObstacles, int NumberOfStepsForToFinishEpisod, float FinalReward, bool AllRewards, int NumberOfCondition, bool ShortRoadCorrect)
    {
        mylist.Add(new ModelRaport()
        {
            Episods = Episods,
            NumberOfCollisionAgentObstacles = NumberOfCollisionAgentObstacles,
            NumberOfCollisionTrashObstacles = NumberOfCollisionTrashObstacles,
            NumberOfStepsForToFinishEpisod = NumberOfStepsForToFinishEpisod,
            FinalReward = FinalReward,
            FinishEpisod = AllRewards,
            NumberOfCondition = NumberOfCondition,
            ShortRoadCorrect = ShortRoadCorrect
        });
        if (mylist.Count > 0)
        {
            using (TextWriter tw = new StreamWriter(filename, IsFirstRaport))
            {

                tw.WriteLine("Episod,NumberCollisionAgentObstacles,NumberOfCollisionTrashObstacles,NumberOfStepsForToFinishEpisod,FinalReward,FinishEpisod,NumberOfCondition,ShortRoadCorrect");

                tw.Close();
                using (TextWriter w = new StreamWriter(filename, true))
                {
                    for (int i = 1; i < mylist.Count; i++)
                    {
                        w.WriteLine(mylist[i].Episods + "," + mylist[i].NumberOfCollisionAgentObstacles + "," +
                            mylist[i].NumberOfCollisionTrashObstacles + "," + mylist[i].NumberOfStepsForToFinishEpisod  + "," + mylist[i].FinalReward + "," + mylist[i].FinishEpisod
                            + ","+mylist[i].NumberOfCondition + "," + mylist[i].ShortRoadCorrect);
                    }
                }

            }
        }
    }
}
