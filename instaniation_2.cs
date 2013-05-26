using UnityEngine;
using System.Collections;
  
public class instantiation : MonoBehaviour {
	
	public GameObject earth;
	
void Start ()
{
earth = Instantiate(Resources.Load("prefab/--"),new Vector3(0,0,0), Quaternion.identity)as GameObject;
		
}
	void Update() 
	{
		earth = Instantiate(Resources.Load("prefab/--"),new Vector3(1,1,1), Quaternion.identity)as GameObject;
		
    }
}