using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBehavior : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    private PopulationManager pm;

    private void Awake()
    {
        pm = GameObject.Find("GameManager").GetComponent<PopulationManager>();
    }

    void Update()
    {
        this.gameObject.transform.position += new Vector3(-1 * speed * Time.deltaTime, 0, 0);
        if(this.transform.position.x <= -15)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "GameManager")
        {
            pm.SetCanGenerate(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "GameManager")
        {
            pm.SetCanGenerate(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "GameManager")
        {
            pm.SetCanGenerate(true);
        }
    }
}
