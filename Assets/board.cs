using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class board : MonoBehaviour {
    private GameObject crate;
    public Vector3 destination;
    private bool inputGiven;
    public float speed;
    // Use this for initialization
    void Start () {
        crate = GameObject.Find("crate1");
        inputGiven = false;
        speed = 0.5f;
    }

    // Update is called once per frame
    void Update () {
        //crate.transform.Rotate( 0, 0,100 * Time.deltaTime); rotation du crate

        if (Input.GetMouseButton(0) && !inputGiven)
        {
            inputGiven = true;

            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            destination.z = 10;

            Debug.Log(destination);

            /*

            Debug.Log(Input.mousePosition);
            Debug.Log(crate.transform.position);
            Debug.Log(Camera.main.WorldToScreenPoint(crate.transform.position));


            crate.transform.position = Camera.main.ScreenToWorldPoint(pos);
            */

            /*var ray: Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray))
                Instantiate(particle, transform.position, transform.rotation);*/
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

        Debug.Log(destination);

        if (Vector3.Distance(crate.transform.position, destination) <= 0.1)
        {
            inputGiven = false;
        }

         
        return true;

    }

}



