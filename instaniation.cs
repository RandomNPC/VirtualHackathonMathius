using UnityEngine;
using System.Collections;
  
public class instantiation : MonoBehaviour {
	
	public GameObject earth;
	
void Start ()
{
Instantiate(Resources.Load("prefab/--"),new Vector3(0,0,0), Quaternion.identity);
		
}
	void Update() 
	{
		Instantiate(Resources.Load("prefab/--"),new Vector3(1,1,1), Quaternion.identity);
		
    }
}