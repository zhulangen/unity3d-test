using UnityEngine;
using System.Collections;
using Toolbox;
public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        int[] temp = new int[10];
	    for(int i=0;i<10;i++)
        {
            temp[i] = i;
        }

        GRandomer.RandomArrayUnique<int>(temp);

        foreach(int a in temp)
        {
            Debug.Log("a:"+a);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
