using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerSelect : MonoBehaviour {

	private GameObject[] animal;
	private int animalIndex;
	private List<string> ColorList = new List<string> {
		"Red",
		"Blue",
		"Pink",
		"Green",
		"White",
		"Black"
		};

	[Space(10)]
	[Tooltip("Assign: the game object where the animal are parented to")]
	public Transform animal_parent;
	public Dropdown dropdownAnimal;

	public Material m_ObjectRenderer;

	void Start() {

		int count = animal_parent.childCount;
		animal = new GameObject[count];
		List<string> animalList = new List<string>();

		for(int i = 0; i < count; i++)
		{
			animal[i] = animal_parent.GetChild(i).gameObject;
			string n = animal_parent.GetChild(i).name;
			animalList.Add(n);
			// animalList.Add(n.Substring(0, n.IndexOf("_")));

			if(i==0) animal[i].SetActive(true);
			else animal[i].SetActive(false);
		}
		//dropdownAnimal = GetComponent<Dropdown>();
		dropdownAnimal.AddOptions(ColorList);
		//dropdownFacialExp.value = 1;

		// Bounds b = animal[0].transform.GetChild(0).GetChild(0).GetComponent<Renderer>().bounds;
	}

	void Update() {

		if(Input.GetKeyDown("right")) { 
			ChangeColorRight();
			 }
		else if(Input.GetKeyDown("left")) {
			 ChangeColorLeft(); 
			 }
		ChangeColor();
	}

	void ChangeColorLeft() {
		if(dropdownAnimal.value <= 0)
			{ dropdownAnimal.value = dropdownAnimal.options.Count - 1;}
		else
			{ dropdownAnimal.value--;}
		
		ChangeColor();
		
	}

	void ChangeColorRight() {
		if(dropdownAnimal.value >= dropdownAnimal.options.Count - 1)
			{dropdownAnimal.value = 0;}
		else
			{dropdownAnimal.value++;}

		ChangeColor();
	}

	void ChangeColor() {
		//GameObject r = GameObject.FindGameObjectWithTag("Player");
		

		
		Color c = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		if (dropdownAnimal.options[dropdownAnimal.value].text == "Red") {
			c = new Color(0.9811321f, 0.3979869f, 0.3924528f, 0.5019608f);
		} else if (dropdownAnimal.options[dropdownAnimal.value].text == "Green") {
			c = new Color(0.3057371f, 0.8301887f, 0.2459238f, 0.5019608f);
		} else if (dropdownAnimal.options[dropdownAnimal.value].text == "Pink") {
			c = new Color(0.9310009f, 0.484158f, 0.9433962f, 0.5019608f);
		} else if (dropdownAnimal.options[dropdownAnimal.value].text == "Blue") {
			c = new Color(0.2267888f, 0.4107119f, 0.8773585f, 0.5019608f);
		} else if (dropdownAnimal.options[dropdownAnimal.value].text == "Yellow") {
			c = new Color(0.77248f, 0.8773585f, 0.2267888f, 0.5019608f);
		}
		else if (dropdownAnimal.options[dropdownAnimal.value].text == "White") {
			c = new Color(1.0f, 1.0f, 1.0f, 0.4705882f);
		}
		else if (dropdownAnimal.options[dropdownAnimal.value].text == "Black") {
			c = new Color(0.03951583f, 0.0445089f, 0.09433959f, 0.4705882f);
		}
		m_ObjectRenderer.color = c;
		GameObject.FindGameObjectWithTag("Rabbit").GetComponent<Renderer>().material = m_ObjectRenderer;
		//r.GetComponent<Renderer>().material.color = c;
	}
	
}