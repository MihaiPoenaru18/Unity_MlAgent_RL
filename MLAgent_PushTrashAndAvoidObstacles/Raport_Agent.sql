SELECT TOP (1000) [Episods]
      ,[NumberOfCollisionAgentObstacles]
      ,[NumberOfCollisionTrashObstacles]
      ,[NumberOfStepsForToFinishEpisod]
      ,[FinalReward]
      ,[AllRewards]
      ,[FinishEp]
      ,[ShortRoadCorrect]
  FROM [PatientsDb].[dbo].[raport_ 615ep]

  Select NumberOfStepsForToFinishEpisod as ['Numarul de pași necesari pentru îndeplinierea misiuni/Episod']
  from [raport_ 615ep]
  where FinishEp = 1  
   
   Select Max(NumberOfStepsForToFinishEpisod) as ['Numarul de pași necesari pentru îndeplinierea misiuni/Episod']
  from [raport_ 615ep]
  where FinishEp = 1  

  Select AVG(NumberOfCollisionAgentObstacles) as ['mediu de coliziuni dintre agent și obstacole '], AVG(NumberOfCollisionTrashObstacles) as [' mediu de coliziuni dintre gunoi și obstacole'], AVG(NumberOfStepsForToFinishEpisod) as['media de pași pe care agentul i-a făcut pentru finalizarea misiuni ']
  from [raport_ 615ep]
  where FinishEp = 1 
  
  Select COUNT(Episods) as ['numărul de episoade în care agentul a îndeplinit misiunea cumulând toate recompensele ']
  from [raport_ 615ep]
  where AllRewards = 1  

  Select AVG(FinalReward) as ['media de recompense pentru cele 615 episoade ']
  from [raport_ 615ep]

  Select COUNT(Episods) as [numărul de episoade în care agentul a ales drumul cel mai scurt dintre gunoi și una dintre zonele de tomberon]
  from [raport_ 615ep]
  where ShortRoadCorrect = 1 

  Select COUNT(Episods) 
  from [raport_ 615ep]
  where FinishEp = 1

  Select COUNT(Episods) 
  from [raport_ 615ep]
  where FinishEp = 0
  
   Select NumberOfStepsForToFinishEpisod as [Numarul de pași necesari pentru îndeplinierea misiuni]
  from [raport_ 615ep]
  where ShortRoadCorrect = 1 

  Select COUNT(Episods) 
  from [raport_ 615ep]
  where ShortRoadCorrect = 1 

  Select COUNT(Episods) 
  from [raport_ 615ep]
  where ShortRoadCorrect = 0

 Select  NumberOfCollisionAgentObstacles as[ Coliziuni Agent obstacole cand drumul a fost ales corect/ episod]
  from [raport_ 615ep]
  where ShortRoadCorrect = 1 

  Select NumberOfCollisionAgentObstacles as [Coliziuni Agent obstacole cand drumul a fost ales gresit/ episod]
  from [raport_ 615ep]
  where ShortRoadCorrect = 0

  Select NumberOfCollisionAgentObstacles as[Coliziuni Agent obstacole/episod]
 from [raport_ 615ep]
 where  FinishEp = 1

 Select NumberOfCollisionTrashObstacles as[Coliziuni Agent obstacole/episod]
 from [raport_ 615ep]
 where  FinishEp = 1