using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class MenuController : MonoBehaviour {
	public GameObject menuItemPrefab;
	public GameObject menuItemPrefab2;
	public Dictionary<GameObject, Action> menuItems = new Dictionary<GameObject, Action>();
	public Dictionary<GameObject, Action> menuItems2 = new Dictionary<GameObject, Action>();
	private Dictionary<GameObject, Action> currentMenu = null;

	Vector2 positionOfFirstMenuItem = new Vector2 (-7.16f, -0.73f);
	// Use this for initialization
	void Start () {
		menuItems.Add (Instantiate(menuItemPrefab), ()=>{ //make individual menu item objects later
			Debug.Log("Menu Item 1-1 Pressed");
		}); 
		menuItems.Add (Instantiate(menuItemPrefab), ()=>{
			Debug.Log("Menu Item 1-2 Pressed");

		});
		menuItems.Add (Instantiate(menuItemPrefab), ()=>{
			Debug.Log("Menu Item 1-3 Pressed");

		});
		menuItems.Add (Instantiate(menuItemPrefab), ()=>{
			Debug.Log("Menu Item 1-4 Pressed");
			switchMenus(menuItems2);

		});
		menuItems2.Add (Instantiate(menuItemPrefab2), ()=>{ 
			Debug.Log("Menu Item 2-1 Pressed");
		}); 
		menuItems2.Add (Instantiate(menuItemPrefab2), ()=>{
			Debug.Log("Menu Item 2-2 Pressed");

		});
		menuItems2.Add (Instantiate(menuItemPrefab2), ()=>{
			Debug.Log("Menu Item 2-3 Pressed");

		});
		menuItems2.Add (Instantiate(menuItemPrefab2), ()=>{
			Debug.Log("Menu Item 2-4 Pressed");
			switchMenus(menuItems);

		});
		switchMenus (menuItems);

	}
	public void doMenuAction(GameObject menuItem) {
		currentMenu [menuItem] ();
	}
	public void switchMenus(Dictionary<GameObject, Action> menuToSwitchTo){

		float delayOfAnimation = 0;
		if (currentMenu != null) {
			foreach (GameObject menuItem in currentMenu.Keys) {
				MenuItemController menuItemController = menuItem.GetComponent<MenuItemController> ();
				menuItemController.StopAllCoroutines ();
				menuItemController.acceptingMouseActions = false;
				StartCoroutine (menuItemController.hideWithDelay (delayOfAnimation));

				delayOfAnimation += 0.15f; //amount of time between starting each movement (for cascading effect)
			}
			delayOfAnimation *= 0.4f; //overlap

		}


		Vector2 menuItemPosition = positionOfFirstMenuItem;
		foreach (GameObject menuItem in menuToSwitchTo.Keys) 
		{
			MenuItemController menuItemController = menuItem.GetComponent<MenuItemController> ();
			menuItemController.init (menuItemPosition, this);
			menuItem.transform.position = menuItemController.hidePosition;
			menuItemController.StopAllCoroutines ();
			StartCoroutine (menuItemController.unhideWithDelay (delayOfAnimation));

			menuItemPosition = new Vector2 (menuItemPosition.x, menuItemPosition.y - 1.0f);
			delayOfAnimation += 0.15f; //amount of time between starting each movement (for cascading effect)
		}
		currentMenu = menuToSwitchTo;
	}
	// Update is called once per frame
	void Update () {
	
	}
}
