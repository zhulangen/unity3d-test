using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SmartURL sl = new SmartURL();
        sl.rawString = "http://www.cnblogs.com/rchen/archive/2005/06/23/179627.html";
        sl.test();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
