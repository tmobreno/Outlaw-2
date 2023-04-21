using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    enum CanMove { yes, no };
    CanMove canMove;

    [HideInInspector]
    public bool dead;

    // movement
    public Rigidbody2D rb;
    public float moveSpeed;

    private Animator anim;

    // player
    public bool p2;

    // bullets
    public GameObject projectile;
    private float timer;
    public float shotTimer, walkTimer;

    // menus
    public GameObject pauseM, mainM, gamesM;
    private bool paused;

    private void Start()
    {
        anim = GetComponent<Animator>();
        canMove = CanMove.yes;
    }

    void Update()
    {
        // p2
        if (p2 == true && canMove == CanMove.yes && paused == false)
        {
            // Moving
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (Time.time > walkTimer)
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Walk", transform.position);
                    walkTimer = Time.time + 0.2f;
                }
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
                anim.SetInteger("Direction", 0);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (Time.time > walkTimer)
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Walk", transform.position);
                    walkTimer = Time.time + 0.2f;
                }
                transform.position += Vector3.right * -moveSpeed * Time.deltaTime;
                anim.SetInteger("Direction", 0);
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                if (Time.time > walkTimer)
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Walk", transform.position);
                    walkTimer = Time.time + 0.2f;
                }
                transform.position += Vector3.up * moveSpeed * Time.deltaTime;
                anim.SetInteger("Direction", 1);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                if (Time.time > walkTimer)
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Walk", transform.position);
                    walkTimer = Time.time + 0.2f;
                }
                transform.position += Vector3.up * -moveSpeed * Time.deltaTime;
                anim.SetInteger("Direction", 2);
            }
            else
            {
                anim.SetInteger("Direction", 3);
            }

            // Shooting
            if (Input.GetKey(KeyCode.RightShift) && Input.GetKey(KeyCode.UpArrow))
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/Fire", transform.position);
                Quaternion rot = Quaternion.Euler(new Vector3(0, 180, 50));
                Vector2 vec = new Vector2(this.transform.position.x - 0.6f, this.transform.position.y + 0.3f);
                GameObject g = Instantiate(projectile, vec, rot);
                g.GetComponent<projectileMove>().playerBul = 2;
                StartCoroutine(restartMove(shotTimer, false));
            }
            else if (Input.GetKey(KeyCode.RightShift) && Input.GetKey(KeyCode.DownArrow))
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/Fire", transform.position);
                Quaternion rot = Quaternion.Euler(new Vector3(0, 180, -50));
                Vector2 vec = new Vector2(this.transform.position.x - 0.6f, this.transform.position.y - 0.3f);
                GameObject g = Instantiate(projectile, vec, rot);
                g.GetComponent<projectileMove>().playerBul = 2;
                StartCoroutine(restartMove(shotTimer, false));
            }
            else if (Input.GetKey(KeyCode.RightShift))
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/Fire", transform.position);
                Quaternion rot = Quaternion.Euler(new Vector3(0, 180, 0));
                Vector2 vec = new Vector2(this.transform.position.x - 0.6f, this.transform.position.y + 0.1f);
                GameObject g = Instantiate(projectile, vec, rot);
                g.GetComponent<projectileMove>().playerBul = 2;
                StartCoroutine(restartMove(shotTimer, false));
            }
        }

        // p1
        else if (p2 == false && canMove == CanMove.yes && paused == false)
        {
            // Moving
            if (Input.GetKey(KeyCode.D))
            {
                if (Time.time > walkTimer)
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Walk", transform.position);
                    walkTimer = Time.time + 0.2f;
                }
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
                anim.SetInteger("Direction", 0);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                if (Time.time > walkTimer)
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Walk", transform.position);
                    walkTimer = Time.time + 0.2f;
                }
                transform.position += Vector3.right * -moveSpeed * Time.deltaTime;
                anim.SetInteger("Direction", 0);
            }
            else if (Input.GetKey(KeyCode.W))
            {
                if (Time.time > walkTimer)
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Walk", transform.position);
                    walkTimer = Time.time + 0.2f;
                }
                transform.position += Vector3.up * moveSpeed * Time.deltaTime;
                anim.SetInteger("Direction", 1);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                if (Time.time > walkTimer)
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Walk", transform.position);
                    walkTimer = Time.time + 0.2f;
                }
                transform.position += Vector3.up * -moveSpeed * Time.deltaTime;
                anim.SetInteger("Direction", 2);
            }
            else
            {
                anim.SetInteger("Direction", 3);
            }

            // Shooting
            if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.W))
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/Fire", transform.position);
                Quaternion rot = Quaternion.Euler(new Vector3(0, 0, 50));
                Vector2 vec = new Vector2(this.transform.position.x + 0.6f, this.transform.position.y + 0.3f);
                GameObject g =  Instantiate(projectile, vec, rot);
                g.GetComponent<projectileMove>().playerBul = 1;
                StartCoroutine(restartMove(shotTimer, false));
            }
            else if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.S))
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/Fire", transform.position);
                Quaternion rot = Quaternion.Euler(new Vector3(0, 0, -50));
                Vector2 vec = new Vector2(this.transform.position.x + 0.6f, this.transform.position.y - 0.3f);
                GameObject g = Instantiate(projectile, vec, rot);
                g.GetComponent<projectileMove>().playerBul = 1;
                StartCoroutine(restartMove(shotTimer, false));
            }
            else if (Input.GetKey(KeyCode.Space))
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/Fire", transform.position);
                Quaternion rot = Quaternion.Euler(new Vector3(0, 0, 0));
                Vector2 vec = new Vector2(this.transform.position.x + 0.6f, this.transform.position.y + 0.1f);
                GameObject g = Instantiate(projectile, vec, rot);
                g.GetComponent<projectileMove>().playerBul = 1;
                StartCoroutine(restartMove(shotTimer, false));
            }
        }

        // Pause Menu
        if (Input.GetKeyDown(KeyCode.Escape) && p2 == false)
        {
            if (paused == false)
            {
                PauseGame();
            }
            else if (paused == true)
            {
                ResumeGame();
            }
        }
    }


    public IEnumerator restartMove(float time, bool death)
    {
        if (death == false)
        {
            anim.SetInteger("Direction", 5);
        } else
        {
            anim.SetInteger("Direction", 4);
        }
        canMove = CanMove.no;
        yield return new WaitForSeconds(time);
        if (dead == false)
        {
            canMove = CanMove.yes;
        }
    }

    public IEnumerator death(float time)
    {
        dead = true;
        yield return new WaitForSeconds(time);
        dead = false;
    }

    void PauseGame()
    {
        paused = true;
        pauseM.SetActive(true);
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        paused = false;
        pauseM.SetActive(false);
        Time.timeScale = 1;
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("gameScene");
    }
    public void loadMainMenu()
    {
        Time.timeScale = 0;
        pauseM.SetActive(false);
        mainM.SetActive(true);
    }
    public void startGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("gameScene");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void gamesMenu()
    {
        pauseM.SetActive(false);
        mainM.SetActive(false);
        gamesM.SetActive(true);
    }
    public void back()
    {
        pauseM.SetActive(false);
        mainM.SetActive(true);
        gamesM.SetActive(false);
    }

    // HINA GAME

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "orb")
        {
            Destroy(collision.gameObject);
            FMODUnity.RuntimeManager.PlayOneShot("event:/Fire", transform.position);
            FindObjectOfType<spawnOrb>().score += 1;
        }
    }
}
