using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI.Movement;

namespace AI.BT
{

    public class BTDM : DecisionMaker
    {
        // Blackboard Area
        public Agent currentEnemy;

        Task rootTask;

	    // Use this for initialization
	    void Start ()
        {
            // Build the tree from game objects

            rootTask = GetComponentInChildren<Task>();
            BuildTree(rootTask);
	    }

        public void BuildTree(Task parentTask)
        {
            parentTask.m_Agent = GetComponent<Agent>();
            parentTask.btdm = this;

            if (parentTask.transform.childCount > 0)
            {
                // This is a composite task
                Composite composite = parentTask as Composite;
                composite.children = new List<Task>();

                foreach (Transform child in composite.transform)
                {
                    Task childTask = child.GetComponent<Task>();
                    composite.children.Add(childTask);
                    BuildTree(childTask);
                }
            }
        }

        public override void MakeDecision()
        {
            // Traverse the tree and execute behaviours
            rootTask.Run();

        }
    }

}
