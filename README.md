# Unity MlAgent with RL in cleaning proccess of green spaces
The current work uses the automatic reinforcement learning system together with the Proximal Policy Optimation algorithm and Imitation Learning(GAIL and BC) through which a simulation prototype
of an intelliogent device is implemented, which can automate the process of waste collection from a green space, 
usign the Unity Engine 3D envirment, and the system manages to achive a success rate hither than 50% following the proccess of testing the neural network resulting from 6 trainings the agent. 

![image](https://github.com/MihaiPoenaru18/Unity_MlAgent_RL/assets/45234856/6e800ffa-b76b-451c-a3ba-c1b96a2767c6)


The process of training is divided into three stages:
### Stage 1 - <b>Push the trash<b>
* The stage is formed of 2 trainings, one with 7 million steps and the other where the neuronal network is reused form first training of 5 million of steps.  
* The agent will receive the reward value of 10 for delivering the garbage into any collection areas.
* If the agent delivers the garbage into the area, located at the shortest distance from the initial position of garbage, will be added a reward value of 15 for these achievements.
* If it fulfills the delivery of garbage in less than 4000 steps the agent will receive the reward of 5.
* The agent will be punishment during an episode with 1/ (maxim steps).
#### The results of this stage with two trainings

![image](https://github.com/MihaiPoenaru18/Unity_MlAgent_RL/assets/45234856/a62b3f58-1b26-4e8a-85f4-c818eca4d069)

                                         The scenario and UML diagram
![image](https://github.com/MihaiPoenaru18/Unity_MlAgent_RL/assets/45234856/b10506aa-733e-4e20-b2b3-c80b8f9f182b)

    The two questions in stage 1: A Cumulative Rewards Chart and B-Policy Loss, With first training(orange), second training(dark blue)
### Stage 2 - <b>Push the trash and avoid obstacles at the same time<b>
* This stage is formed of 2 trainings, one with 7 million steps and other where the neuronal network is reused form the first training. 
* The new attributes for this stage are the type of collisions agent-obstacles, respectively garbage-obstacles
* The agent can make<b> maxim 4 collisions with obstacles for he receives the reward value of 5</b>, if it makes more than 4 collisions the agent doesn’t receive the reward value, but he will receive a punishment value per collisions.
* If the agent pushes the garbage into obstacles, he will be punishment with value of -0.1
* If the garbage has less than <b>4 collisions with obstacles</b>, the agent will receive a reward value of 5.
  
  ![image](https://github.com/MihaiPoenaru18/Unity_MlAgent_RL/assets/45234856/7140197f-ac99-444e-b522-6e1866e06e24)
  
      The two questions in stage 2: A Cumulative Rewards Chart and B-Policy Loss, With first training(red), second training(light blue)
  
### Stage 3 - <b>Agent improvement<b>
* The third stage is like the same second stage, but with the number of collisions lower with two for collision agent-obstacles respectively three for trash-obstacles, to make the agent mission more complex.
* This is formed of two training parts, both ones having a duration of 7 million steps.
* The agent will receive the reward value of 10, if it delivers the garbage in any circumstance
* If the agent delivers the garbage according to the following rules, he will receive the reward value of 40. The Rules are:
  * The number of collisions between agent and obstacles needs to be less than 3. 
  * The number of collisions between agent and obstacles needs to be less than 4.
  * The number of steps the agent needs to make for the delivery of garbage needs to be less than 4000 steps.
  * The garbage needs to be delivered to the closest collection area.
    
![image](https://github.com/MihaiPoenaru18/Unity_MlAgent_RL/assets/45234856/23caceb4-0ffe-41ed-b1e6-58165d591c46)

    The two questions in stage 3: A Cumulative Rewards Chart and B-Policy Loss, With first training(gray), second training( blue)
![image](https://github.com/MihaiPoenaru18/Unity_MlAgent_RL/assets/45234856/f93f4445-6cf1-4299-9994-23d097309d08)

                               For stage 2 and stage 3 the scenario and UML digram are the same

## The test scenario

![image](https://github.com/MihaiPoenaru18/Unity_MlAgent_RL/assets/45234856/184335f2-18ca-4c89-97dc-b2bc444e8b36)


## The results of testing neural network

###### The project was inspired from this [repository](https://github.com/Unity-Technologies/ml-agents)

###### For install all the package and more exemple you can wash this [series of tutorial videos](https://www.youtube.com/watch?v=zPFU30tbyKs&t=364s) or the description from this [repository](https://github.com/Unity-Technologies/ml-agents )



