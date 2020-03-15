using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoDNA : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameManager gameManager;
    [SerializeField] private Animator anim;

    [SerializeField] public int[]   action =    { 0, 0, 0, 0, 0, 0, 0 };
    //Act 1 = Walk, Act 2 = Down1, Act 3 = Down2, Act 4 = Jump1, Act 5 = Jump 2;
    [SerializeField] public float[] force =     { 0, 0 };
    [SerializeField] public float[] timeDown =  { 0, 0 };
    [SerializeField] public float   size;
    [SerializeField] public float   visionDistance;
    [SerializeField] public float   visionChange;

    public float   lifeTime = 0;
    public bool    alive = true;
    public bool    grounded;
    public bool    seeSomethingUp;
    public bool    seeSomethingForward;
    public bool    seeSomethingDown;

    [SerializeField] private GameObject eyes;
    [SerializeField] private GameObject lookingUp;
    [SerializeField] private GameObject lookingForward;
    [SerializeField] private GameObject lookingDown;

    private void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        alive = true;
    }

    void Start()
    {
        alive = true;
        this.gameObject.transform.localScale *= size;
        rb.mass = size;
    }

    void Update()
    {
        if(alive)
            lifeTime += Time.deltaTime;

        LookAround(visionDistance);
        Act();
    }
    
    public void LookAround(float distance)
    {
        if (!alive) return;

        distance *= size;

        Debug.DrawRay(eyes.transform.position, lookingUp.transform.position - eyes.transform.position, new Color(255,0,0));
        Debug.DrawRay(eyes.transform.position, lookingForward.transform.position - eyes.transform.position, new Color(255, 0, 0));
        Debug.DrawRay(eyes.transform.position, lookingDown.transform.position - eyes.transform.position, new Color(255, 0, 0));

        //verifica se o raio atirado pra cima retorna algo
        if (Physics2D.Raycast(eyes.transform.position, (lookingUp.transform.position - eyes.transform.position), distance, 1 << LayerMask.NameToLayer("Danger")))
        {
            seeSomethingUp = true;
        }
        else
        {
            seeSomethingUp = false;
        }
        //verifica se o raio atirado pra frente retorna algo
        if (Physics2D.Raycast(eyes.transform.position, (lookingForward.transform.position - eyes.transform.position), distance, 1<< LayerMask.NameToLayer("Danger")))
        {
            seeSomethingForward = true;
        }
        else
        {
            seeSomethingForward = false;
        }
        //verifica se o raio atirado pra baixo retorna algo
        if (Physics2D.Raycast(eyes.transform.position, (lookingDown.transform.position - eyes.transform.position), distance, 1 << LayerMask.NameToLayer("Danger")))
        {
            seeSomethingDown = true;
        }
        else
        {
            seeSomethingDown = false;
        }
    }

    public void Act()
    {
        if (!seeSomethingUp && !seeSomethingForward && !seeSomethingDown)
        {
            if (action[0] == 1) //Walk && ChangeVisionRange
            {
                LookAround(visionDistance + visionChange);
            }
            if (action[0] == 2) //Down 1
            {
                WalkingDown(timeDown[0]);
            }
            if (action[0] == 3) //Down 2
            {
                WalkingDown(timeDown[1]);
            }
            if (action[0] == 4) //Jump 1
            {
                Jump(force[0]);
            }
            if (action[0] == 5) //Jump 2
            {
                Jump(force[1]);
            }
        }
        else if (seeSomethingUp && !seeSomethingForward && !seeSomethingDown)
        {
            if (action[1] == 1) //Walk && ChangeVisionRange
            {
                LookAround(visionDistance + visionChange);
            }
            if (action[1] == 2) //Down 1
            {
                WalkingDown(timeDown[0]);
            }
            if (action[1] == 3) //Down 2
            {
                WalkingDown(timeDown[1]);
            }
            if (action[1] == 4) //Jump 1
            {
                Jump(force[0]);
            }
            if (action[1] == 5) //Jump 2
            {
                Jump(force[1]);
            }
        }
        else if (seeSomethingForward && !seeSomethingUp && !seeSomethingDown)
        {
            if (action[2] == 1) //Walk && ChangeVisionRange
            {
                LookAround(visionDistance + visionChange);
            }
            if (action[2] == 2) //Down 1
            {
                WalkingDown(timeDown[0]);
            }
            if (action[2] == 3) //Down 2
            {
                WalkingDown(timeDown[1]);
            }
            if (action[2] == 4) //Jump 1
            {
                Jump(force[0]);
            }
            if (action[2] == 5) //Jump 2
            {
                Jump(force[1]);
            }
        }
        else if (seeSomethingDown && !seeSomethingUp && !seeSomethingForward)
        {
            if (action[3] == 1) //Walk && ChangeVisionRange
            {
                LookAround(visionDistance + visionChange);
            }
            if (action[3] == 2) //Down 1
            {
                WalkingDown(timeDown[0]);
            }
            if (action[3] == 3) //Down 2
            {
                WalkingDown(timeDown[1]);
            }
            if (action[3] == 4) //Jump 1
            {
                Jump(force[0]);
            }
            if (action[3] == 5) //Jump 2
            {
                Jump(force[1]);
            }
        }
        else if (seeSomethingUp && seeSomethingForward)
        {
            if (action[4] == 1) //Walk && ChangeVisionRange
            {
                LookAround(visionDistance + visionChange);
            }
            if (action[4] == 2) //Down 1
            {
                WalkingDown(timeDown[0]);
            }
            if (action[4] == 3) //Down 2
            {
                WalkingDown(timeDown[1]);
            }
            if (action[4] == 4) //Jump 1
            {
                Jump(force[0]);
            }
            if (action[4] == 5) //Jump 2
            {
                Jump(force[1]);
            }
        }
        else if (seeSomethingUp && seeSomethingDown)
        {
            if (action[5] == 1) //Walk && ChangeVisionRange
            {
                LookAround(visionDistance + visionChange);
            }
            if (action[5] == 2) //Down 1
            {
                WalkingDown(timeDown[0]);
            }
            if (action[5] == 3) //Down 2
            {
                WalkingDown(timeDown[1]);
            }
            if (action[5] == 4) //Jump 1
            {
                Jump(force[0]);
            }
            if (action[5] == 5) //Jump 2
            {
                Jump(force[1]);
            }
        }
        else if (seeSomethingForward && seeSomethingDown)
        {
            if (action[6] == 1) //Walk && ChangeVisionRange
            {
                LookAround(visionDistance + visionChange);
            }
            if (action[6] == 2) //Down 1
            {
                WalkingDown(timeDown[0]);
            }
            if (action[6] == 3) //Down 2
            {
                WalkingDown(timeDown[1]);
            }
            if (action[6] == 4) //Jump 1
            {
                Jump(force[0]);
            }
            if (action[6] == 5) //Jump 2
            {
                Jump(force[1]);
            }
        }
    }

    private void Jump(float jumpForce)
    {
        if(grounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            grounded = false;
        }
    }

    private void WalkingDown(float delay)
    {
        //Crouching
        anim.SetBool("isRunning", false);
        Invoke("StandStraight", delay);
    }

    private void StandStraight()
    {
        //Get Up from Crouching Anim
        anim.SetBool("isRunning", true);
    }

    private void Die()
    {
        //Generation Timer
        alive = false;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            grounded = true;
        }
        if (col.gameObject.layer == LayerMask.NameToLayer("Danger"))
        {
            alive = false;
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public DinoDNA GenerateDNA()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        visionDistance = Random.Range(gameManager.GetMinVision(), gameManager.GetMaxVision());
        visionChange = Random.Range(0.5f, 0.5f);
        size = Random.Range(gameManager.GetMinSize(), gameManager.GetMaxSize());

        for (int i = 0; i < action.Length; i++)
        {
            action[i] = Random.Range(1, 5);
        }
        for (int j = 0; j < 2; j++)
        {
            force[j] = Random.Range(0, 10f);
            timeDown[j] = Random.Range(0, 10f);
        }

        return this;
    }

    public DinoDNA Breed(DinoDNA parent1, DinoDNA parent2)
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (Random.Range(0, 100) < gameManager.GetMutationRate())
        {
            GenerateDNA();
        }
        else
        {
            int r = Random.Range(0, 160);
            if (r <= 50)
            {
                visionChange = parent1.visionChange;
            }
            else if (r > 50 && r <= 100)
            {
                visionChange = parent2.visionChange;
            }
            else if (r > 100 && r <= 150)
            {
                visionChange = (parent1.visionChange + parent2.visionChange) / 2;
            }
            else
            {
                visionChange = Random.Range(0.5f, 0.5f);
            }

            r = Random.Range(0, 160);
            if (r <= 50)
            {
                visionDistance = parent1.visionDistance;
            }
            else if (r > 50 && r <= 100)
            {
                visionDistance = parent2.visionDistance;
            }
            else if (r > 100 && r <= 150)
            {
                visionDistance = (parent1.visionDistance + parent2.visionDistance) / 2;
            }
            else
            {
                visionDistance = Random.Range(gameManager.GetMinVision(), gameManager.GetMaxVision());
            }

            r = Random.Range(0, 160);
            if (r <= 50)
            {
                size = parent1.size;
            }
            else if (r > 50 && r <= 100)
            {
                size = parent2.size;
            }
            else if (r > 100 && r <= 150)
            {
                size = (parent1.size + parent2.size) / 2;
            }
            else
            {
                size = Random.Range(gameManager.GetMinSize(), gameManager.GetMaxSize());
            }
            rb.mass = size;

            for (int i = 0; i < action.Length; i++)
            {
                r = Random.Range(0, 110);
                if (r <= 50)
                {
                    action[i] = parent1.action[i];
                }
                else if (r > 50 && r <= 100)
                {
                    action[i] = parent2.action[i];
                }
                else
                {
                    action[i] = Random.Range(1, 5);
                }
            }

            for (int i = 0; i < force.Length; i++)
            {
                r = Random.Range(0, 160);
                if (r <= 50)
                {
                    force[i] = parent1.force[i];
                }
                else if (r > 50 && r <= 100)
                {
                    force[i] = parent2.force[i];
                }
                else if (r > 100 && r <= 150)
                {
                    force[i] = (parent1.force[i] + parent2.force[i]) / 2;
                }
                else
                {
                    force[i] = Random.Range(0, 10f);
                }
            }

            for (int i = 0; i < timeDown.Length; i++)
            {
                r = Random.Range(0, 160);
                if (r <= 50)
                {
                    timeDown[i] = parent1.timeDown[i];
                }
                else if (r > 50 && r <= 100)
                {
                    timeDown[i] = parent2.timeDown[i];
                }
                else if (r > 100 && r <= 150)
                {
                    timeDown[i] = (parent1.timeDown[i] + parent2.timeDown[i]) / 2;
                }
                else
                {
                    timeDown[i] = Random.Range(0, 10f);
                }
            }
        }
        return this;
    }
}
