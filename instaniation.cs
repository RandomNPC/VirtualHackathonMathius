using UnityEngine;
using System.Collections;
  
public class instantiation : MonoBehaviour {
	public GameObject earth;
	
void Start ()
{
Instantiate(earth,new Vector3(0,0,0), Quaternion.identity);
		
}
	void Update() 
	{
		Instantiate(earth, new Vector3(1,1,1), Quaternion.identity);
		
    }
}