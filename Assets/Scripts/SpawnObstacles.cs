using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public GameObject ptero;
    public GameObject[] trees;
    public Transform treeSpawner;
    public Transform[] pteroSpawner;
    private GameManager _gm;
    private float _treeTimer = 0f;
    private float _pteroTimer = 0f;

    private bool isActive;

    private void Awake()
    {
        isActive = false;
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void Update()
    {
        if (!isActive)
            return;

        _treeTimer += Time.deltaTime;
        _pteroTimer += Time.deltaTime;

        if (_treeTimer >= _gm.GetTreeRate())
        {
            Instantiate(trees[Random.Range(0, trees.Length)], treeSpawner.position, Quaternion.identity);
            _treeTimer = 0f;
        }

        if (_pteroTimer >= _gm.GetPteroRate())
        {
            int i = Random.Range(0, pteroSpawner.Length);
            Instantiate(ptero, pteroSpawner[i].position, Quaternion.identity);
            _pteroTimer = 0f;
        }
    }

    public void SetIsActive(bool b)
    {
        isActive = b;
    }
}
