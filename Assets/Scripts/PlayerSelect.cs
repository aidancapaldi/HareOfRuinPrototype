/* Scripted by Omabu - omabuarts@gmail.com */
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
		"Green"
		};

	[Space(10)]
	[Tooltip("Assign: the game object where the animal are parented to")]
	public Transform animal_parent;
	public Dropdown dropdownAnimal;

	Material m_ObjectRenderer;

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
		GameObject r = GameObject.FindGameObjectWithTag("RabbitMat");

		Color c = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		if (dropdownAnimal.options[dropdownAnimal.value].text == "Red") {
			c = new Color(1.0f, 0f, 0f, 1.0f);
		} else if (dropdownAnimal.options[dropdownAnimal.value].text == "Green") {
			c = new Color(0f, 1.0f, 0f, 1.0f);
		} else if (dropdownAnimal.options[dropdownAnimal.value].text == "Pink") {
			c = new Color(1.0f, 0f, 0.9362135f, 1.0f);
		} else if (dropdownAnimal.options[dropdownAnimal.value].text == "Blue") {
			c = new Color(0f, 0f, 1.0f, 1.0f);
		} else if (dropdownAnimal.options[dropdownAnimal.value].text == "Yellow") {
			c = new Color(1.0f, 1.0f, 0f, 1.0f);
		}
		r.GetComponent<Renderer>().material.color = c;
	}
	
}