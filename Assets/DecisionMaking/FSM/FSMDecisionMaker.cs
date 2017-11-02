using System.Collections;
using System.Collections.Generic;
using AI.Movement;
using AI.FSM;
using UnityEngine;

namespace AI.DecisionTree
{

    public class FSMDecisionMaker : DecisionMaker
    {
        public Animator aiAnimator;
        public float minDistance = 1f;

        private void Start()
        {
            Agent myAgent = GetComponent<Agent>();

            var seekBe = myAgent.GetComponent<SeekBehaviour>();
            var fleeBe = myAgent.GetComponent<FleeBehaviour>();
            var shootAction = myAgent.GetComponent<ShootAction>();

            var goToBaseState = aiAnimator.GetBehaviour<GoToBaseState>();
            goToBaseState.m_agent = myAgent;
            goToBaseState.seekBe = seekBe;
            goToBaseState.fleeBe = fleeBe;

            var attackState = aiAnimator.GetBehaviour<AttackEnemyState>();
            attackState.m_agent = myAgent;
            attackState.seekBe = seekBe;
            attackState.fleeBe = fleeBe;
            attackState.shootAction = shootAction;

            var getHealth = aiAnimator.GetBehaviour<GetHealthState>();
            getHealth.m_agent = myAgent;
            getHealth.seekBe = seekBe;
            getHealth.fleeBe = fleeBe;

            var runAwayState = aiAnimator.GetBehaviour<RunAwayState>();
            runAwayState.m_agent = myAgent;
            runAwayState.seekBe = seekBe;
            runAwayState.fleeBe = fleeBe;

            MakeDecision();

        }

        public override void MakeDecision()
        {
            bool isClose = false;
            float closestEnemyInstance = float.MaxValue;

            var allAgents = FindObjectsOfType<Agent>();
            foreach (var agent in allAgents)
            {
                if (agent != GetComponent<Agent>() && agent.GetComponent<HealthState>().team != GetComponent<HealthState>().team)
                {
                    if ((agent.transform.position - this.transform.position).sqrMagnitude < minDistance * minDistance
                        && (agent.transform.position - this.transform.position).sqrMagnitude < closestEnemyInstance)
                    {
                        closestEnemyInstance = (agent.transform.position - this.transform.position).sqrMagnitude;
                    }
                }
            }
            aiAnimator.SetFloat("closestEnemyDistance", closestEnemyInstance);

            aiAnimator.SetBool("EnemyClose", isClose);

            aiAnimator.SetInteger("MyHealth", (int)GetComponent<HealthState>().health);

            aiAnimator.SetInteger("healthPickups", (int)FindObjectsOfType<HealthPickup>().Length);

        }
    }

}
