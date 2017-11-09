using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Genetics
{
    public class FishSpawner : MonoBehaviour
    {
        public GameObject fishPrefab;

        List<Individual> currentPopulation;

        public void SpawnPopulation(List<Genotype> genoTypes)
        {
            currentPopulation = new List<Individual>();

            for (int i = 0; i < genoTypes.Count; i++)
            {
                var fishGo = Instantiate(fishPrefab);
                var individual = fishGo.GetComponent<Individual>();
                individual.SetGenotype(genoTypes[i]);
                currentPopulation.Add(individual);

                fishGo.transform.position = new Vector3(i * 5.5f, 0, i);
            }

        }

        public void EndSimulation()
        {
            foreach (var individual in currentPopulation)
            {
                float fitness = individual.body.transform.position.y;
                individual.m_Genotype.fitness = fitness;

                Destroy(individual.gameObject);
            }
        }

    }
}