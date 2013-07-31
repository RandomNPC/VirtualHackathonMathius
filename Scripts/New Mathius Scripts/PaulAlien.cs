using UnityEngine;
using System.Collections;

public class PaulAlien : MonoBehaviour {
	
	public TextMesh equation;
	public int answer;
	
	private PaulScore ps;
	
	// Use this for initialization
	void Start () {
		equation = gameObject.GetComponentInChildren(typeof(TextMesh)) as TextMesh;
		equation.renderer.material.color = Color.magenta;
		answer = 0;
		//generateEquation();
		createEquation();
		ps = GameObject.Find ("MathiusEarthCam").GetComponent("PaulScore") as PaulScore;
	}
	
	void generateEquation(){
		
		//EquationGenerator eq = new EquationGenerator(EquationGenerator.ADDITION | EquationGenerator.SUBTRACTION | EquationGenerator.DIVISION);
		
		answer = (int)Random.Range(0,9);
		int temp = (int)Random.Range(0,10);
	
		
		switch(Mathf.FloorToInt(Random.Range(0,4))){
			case 0: //addition		
				equation.text = "x + " + temp + " = " + (answer+temp);
				break;
			case 1: //subtract
				if(answer >= temp){
					equation.text = "x - " + temp + " = " + (answer-temp);
				}
				else{
					equation.text = temp + " - x = " + (temp-answer);
				}
				break;
			case 2: //multiplication
				if(temp<1) temp = (int)Random.Range(1,9);
				switch((int)Random.Range(0,2)){
					case 0:
						equation.text = temp + " * x = " + (temp*answer);		
						break;
					case 1:
					case 2:
						equation.text = "x * " + temp + " = " + (temp*answer);
						break;
					default:
						break;
				}
				break;
			case 3: // division
			case 4:
					while(true){
						if(!answer.Equals(0) && !temp.Equals(0)) break;
						answer = (int)Random.Range(0,9);
						temp = (int)Random.Range(0,9);
					}
					equation.text = (temp*answer) + " / x = " + temp;
				
				break;
			default:
				print ("CANT MAKE UP MY MIND");
				break;
		}
	}
	
	void createEquation(){
		EquationGenerator eg = new EquationGenerator(EquationGenerator.ADDITION | 
													 EquationGenerator.SUBTRACTION |
													 EquationGenerator.MULTIPLICATION |
													 EquationGenerator.DIVISION,
													 EquationGenerator.MIXED
													);
		equation.text = eg.Equation();
		answer = eg.answer();
	}
	
	
	void OnCollisionTrigger(Collider obj){
		print ("DING");
	}
	
	public void alien_shot(char num){
		string num_shot = char.GetNumericValue(num).ToString();
		string number = answer.ToString();
		if(number.Equals(num_shot)){
			ps.correct_answer();
			Destroy(gameObject);
		}else{
			ps.wrong_answer();
		}
	}
}
