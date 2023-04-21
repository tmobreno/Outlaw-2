using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileMove : MonoBehaviour
{
    public float speed, shotTimer;
    public int playerBul;
    private statStorage stats;

    private void Start()
    {
        shotTimer = FindObjectOfType<playerController>().shotTimer;
        stats = FindObjectOfType<statStorage>();
        Destroy(this.gameObject, 5f);
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "wall")
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Bounce", transform.position);
            this.transform.rotation = Quaternion.Euler(new Vector3(0, this.transform.rotation.eulerAngles.y, -this.transform.rotation.eulerAngles.z));
        }
        if (collision.tag == "p1" && playerBul == 2 && collision.GetComponent<playerController>().dead == false)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Kill", transform.position);
            collision.GetComponent<playerController>().StartCoroutine(collision.GetComponent<playerController>().death(shotTimer));
            collision.GetComponent<playerController>().StartCoroutine(collision.GetComponent<playerController>().restartMove(shotTimer, true));
            stats.p2score += 1;
            Destroy(this.gameObject);
        }
        if (collision.tag == "p2" && playerBul == 1 && collision.GetComponent<playerController>().dead == false)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Kill", transform.position);
            collision.GetComponent<playerController>().StartCoroutine(collision.GetComponent<playerController>().death(shotTimer));
            collision.GetComponent<playerController>().StartCoroutine(collision.GetComponent<playerController>().restartMove(shotTimer, true));
            stats.p1score += 1;
            Destroy(this.gameObject);
        }
        if (collision.tag == "destruc")
        {
            StartCoroutine(destroy(collision));
        }
        if (collision.tag == "nondestruc")
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Bounce", transform.position);
            Destroy(this.gameObject);
        }
    }

    IEnumerator destroy(Collider2D collision)
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Kill", transform.position);
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        collision.GetComponent<SpriteRenderer>().enabled = false;
        collision.GetComponent<BoxCollider2D>().enabled = false;
        collision.GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(1f);
        Destroy(collision.gameObject);
        Destroy(this.gameObject);
    }
}
