﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_CheckPoint : MonoBehaviour {

    public Material mt_Blue;
    public Material mt_Red;

    private Renderer _Renderer;
    private PT_LevelManager levelManagerReference;
    // Use this for initialization
    void Start () {
        _Renderer = gameObject.GetComponent<Renderer>();
        _Renderer.material = mt_Red;
        levelManagerReference = GameObject.Find("LevelManager").GetComponent<PT_LevelManager>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {

        //print(_Renderer.material.name);
        if(other.gameObject.tag =="Player")
        {
            if (_Renderer.material.name == mt_Red.name + " (Instance)")
            {
                //reset all the checkpoints to red
                GameObject[] respawns = GameObject.FindGameObjectsWithTag("Checkpoint");

                foreach(GameObject checkpoint in respawns)
                {
                    checkpoint.GetComponent<Renderer>().material = mt_Red;
                }

                //print("Change");
                _Renderer.material = mt_Blue;
                levelManagerReference.lastGoodCheckpoint = transform;
            }
        }

    }
}
