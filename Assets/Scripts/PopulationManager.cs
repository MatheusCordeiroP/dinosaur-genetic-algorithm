using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulationManager : MonoBehaviour
{
    [SerializeField] GameObject dinoPrefab;
    [SerializeField] Transform spawnPoint;

    [SerializeField] Text GenCount;

    GameManager gm;
    [SerializeField] List<DinoDNA> dinoList;
    int gen;
    bool changeGen;

    float mutationRate;
    float minSize;
    float maxSize;
    float minVision;
    float maxVision;

    private int genTimer;

    bool canGenerate = false;

    private float _timer;
    private void Awake()
    {
        dinoList = new List<DinoDNA>();
        gm = this.gameObject.GetComponent<GameManager>();
        gen = 0;
        _timer = 0f;
        changeGen = false;

        mutationRate = gm.GetMutationRate();
        minSize = gm.GetMinSize();
        maxSize = gm.GetMaxSize();
        minVision = gm.GetMinVision();
        maxVision = gm.GetMaxVision();
    }

    void Update()
    {
        _timer += Time.deltaTime;

        if (changeGen && canGenerate) {
            changeGen = false;
            _timer = 0;
            gen++;
            GenCount.text = gen.ToString();

            if (gen == 1) {
                GenerateFirstPopulation();
            }
            else
            {
                GenerateNextPopulation();
            }
        }
        ChangeGenCheck();
    }

    void ChangeGenCheck()
    {
        if (_timer >= gm.GetGenCD())
        {
            changeGen = true;
            return;
        }
       
        int alvDinos = 0;
        foreach (var dino in dinoList)
        {
            if (dino.alive)
            {
                alvDinos++;
            }
        }

        if (alvDinos == 0)
            changeGen = true;
    }

    void GenerateFirstPopulation()
    {
        GameObject dinossauro;
        DinoDNA dna;
        for (int d = 0; d < gm.GetPopulation(); d++)
        {
            dinossauro = Instantiate(dinoPrefab, spawnPoint.position, Quaternion.identity);
            dna = dinossauro.GetComponent<DinoDNA>();
            dna.GenerateDNA();
            dinoList.Add(dna);
        }
    }

    void GenerateNextPopulation()
    {
        List<DinoDNA> normalList = new List<DinoDNA>(dinoList);
        List<DinoDNA> sortedList = new List<DinoDNA>();
        
        for (int j = 0; j < normalList.Count; j++)
        {
            float maxlifeTime = 0f;
            int bestIndex = 0;

            for (int i = 0; i < dinoList.Count; i++)
            {
                if (maxlifeTime < dinoList[i].lifeTime)
                {
                    maxlifeTime = dinoList[i].lifeTime;
                    bestIndex = i;
                }
            }
            sortedList.Add(dinoList[bestIndex]);
            dinoList.RemoveAt(bestIndex);
        }
        
        if(normalList.Count != 0)
        {
            foreach (DinoDNA dna in normalList)
            {
                if (!dna.alive || !gm.GetSurviving())
                    Destroy(dna.gameObject);
                else
                    dinoList.Add(dna);
            }
        }
        

        int k = 0;
        while(dinoList.Count < gm.GetPopulation())
        {
            if(dinoList.Count < gm.GetPopulation()-1)
            {
                Breed(sortedList[k+1], sortedList[k]);
            }
            Breed(sortedList[k], sortedList[k + 1]);
            k++;
        }
    }

    void Breed(DinoDNA parent1, DinoDNA parent2)
    {
        GameObject breeded = Instantiate(dinoPrefab, spawnPoint.position, Quaternion.identity);
        dinoList.Add(breeded.GetComponent<DinoDNA>().Breed(parent1, parent2));
    }

    public void SetCanGenerate(bool b)
    {
        canGenerate = b;
    }

    public void SetStartGenerations(bool b)
    {
        changeGen = b;
        canGenerate = b;

        if(!b)
        {
            List<DinoDNA> otherList = new List<DinoDNA>(dinoList);
            dinoList.RemoveRange(0, dinoList.Count);
            foreach (DinoDNA dna in otherList)
            {
                    Destroy(dna.gameObject);
            }
            gen = 0;
            _timer = 0f;
        }
    }
}
