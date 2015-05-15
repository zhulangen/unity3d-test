using UnityEngine;
using System.Collections;
using Toolbox;
using fastJSON;
using System.Collections.Generic;

public class ZFastJson : MonoBehaviour {

    public class Retclass
    {
        public object ReturnEntity { get; set; }
        public string Name { get; set; }
        public string Field1;
        public int Field2;
        public object obj;
        public string ppp { get { return "sdfas df "; } }
        public System.DateTime date { get; set; }
        public int[] intr;
    }
	// Use this for initialization
	void Start () {
        Retclass rt = new Retclass { Name = "abc" ,Field1="cba",intr=new int[3]{1,23,4}};

        string json = JSON.ToJSON(rt, new JSONParameters { EnableAnonymousTypes = true }); 

        Debug.Log(JSON.Beautify(json));
        rt = JSON.ToObject<Retclass>(json) ;

        Debug.Log("Name:"+rt.Name);


        Dictionary<string, Retclass> r = new Dictionary<string, Retclass>();
        r.Add("11", new Retclass { Field1 = "111", Field2 = 2, date = System.DateTime.Now });
        r.Add("12", new Retclass { Field1 = "111", Field2 = 2, date = System.DateTime.Now });
        var s = fastJSON.JSON.ToJSON(r, new JSONParameters { EnableAnonymousTypes = true });
        Debug.Log("dic:"+fastJSON.JSON.Beautify(s));
        var o = fastJSON.JSON.ToObject<Dictionary<string, Retclass>>(s);
        Debug.Log("Count:"+ o.Count);
      


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
