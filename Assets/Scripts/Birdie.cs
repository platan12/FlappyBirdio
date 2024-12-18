using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Birdie : MonoBehaviour
{
    public float fixedSpeed = 5f; // Força del salt

    private Rigidbody2D rb;
    private bool Dead = false;
    public TMP_Text ScoreText;
    private int score = 0;
  

    void Start()
    {
        // Obtenim el Rigidbody de l'objecte
        rb = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        if (!Dead)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Estableix la velocitat directament
                rb.velocity = new Vector2(rb.velocity.x, fixedSpeed);
            }
        }

        if (Dead)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                string currentSceneName = SceneManager.GetActiveScene().name;
                
                SceneManager.LoadScene(currentSceneName);
            }
        }

        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject[] pipes = GameObject.FindGameObjectsWithTag("PIPE");
        GameObject generator = GameObject.FindGameObjectWithTag("Generator");

        // Iterar sobre tots els objectes i cridar la funció StopPipes
        foreach (GameObject pipe in pipes)
        {
            // Comprovar si el pipe té el component Pipes
            Pipes pipeScript = pipe.GetComponent<Pipes>();
            if (pipeScript != null)
            {
                // Executar la funció StopPipes de cada objecte que té el component Pipes
                pipeScript.StopPipes();
            }
        }

        generator.GetComponent<Generator>().stopSpawn();
        Dead = true;
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger("DeadBird");
    }
    
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PIPE")
        {
            score++;
            ScoreText.text = "Score: " + score;
        }
        
    }
    

}
