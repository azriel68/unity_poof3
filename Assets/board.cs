using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class board : MonoBehaviour {
    private GameObject crate;
    private AudioSource cratesound1;
    private cameraShake cameraShake;
    private ParticleSystem fx_fire_a;
    public Vector3 destination;
    private bool inputGiven;
    public float speed;
    // Use this for initialization
    void Start () {
        crate = GameObject.Find("crate1");

        cratesound1 = GetComponent<AudioSource>();

        cameraShake = new cameraShake();

        fx_fire_a = GetComponent<ParticleSystem>();

            inputGiven = false;
        speed = 0.5f;
    }

    // Update is called once per frame
    void Update () {
        //crate.transform.Rotate( 0, 0,100 * Time.deltaTime); rotation du crate

        if (Input.GetMouseButton(0) && !inputGiven)
        {

            if (Input.mousePosition.x < Screen.width / 2)
            {
                crate = GameObject.Find("crate2");

            }
            else
            {
                crate = GameObject.Find("crate1");
            }

            fx_fire_a.Play();

            inputGiven = true;

            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            destination.z = 10;

            Debug.Log(destination);

        }

        this.move();

    }

    public bool move()
    {
        if (!inputGiven) return false;
        
        if( Mathf.Abs(destination.x - crate.transform.position.x)>0.1f)
        {

            crate.transform.position = Vector3.MoveTowards(crate.transform.position, new Vector3( destination.x, crate.transform.position.y, destination.z), speed);

        }
        else
        {
            crate.transform.position = Vector3.MoveTowards(crate.transform.position, new Vector3(crate.transform.position.x, destination.y, destination.z), speed);

        }

        if (!cratesound1.isPlaying)
        {
            cratesound1.Play();
            
        }

        StopAllCoroutines();
        StartCoroutine(cameraShake.shake(0.05f, 0.1f));

        //GameObject dust = Instantiate(Resources.Load("dust")) as GameObject;

        Debug.Log(destination);

        if (Vector3.Distance(crate.transform.position, destination) <= 0.1)
        {
            inputGiven = false;
            if (cratesound1.isPlaying) cratesound1.Stop();
            //StartCoroutine(cameraShake.shake(0.1f, 0.2f));
        }

         
        return true;

    }

}



