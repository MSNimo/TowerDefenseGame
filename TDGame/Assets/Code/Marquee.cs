using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Marquee : MonoBehaviour {

    private Text waveTicker;
    private Vector3 velocity;
    private Vector3 _pos;

    void Start() {

        _pos = transform.position;
        velocity = new Vector3 (5,0,0);
        waveTicker = GetComponent<Text>();
        waveTicker.text = "------------------W-------------------------------------W--------------------------------------W-------------------------------------------------W-----------------------------------------------W";
    }

    private void Update() {

        Vector3 deltapos = velocity * Time.deltaTime;
        _pos -= deltapos;
        transform.position = _pos;
    }
}
