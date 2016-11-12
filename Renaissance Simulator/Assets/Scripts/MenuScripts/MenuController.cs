using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class MenuController : MonoBehaviour
{
    public GameObject MenuItemPrefab;
    public GameObject MenuItemPrefab2;
    public Dictionary<GameObject, Action> MenuItems = new Dictionary<GameObject, Action>();
    public Dictionary<GameObject, Action> MenuItems2 = new Dictionary<GameObject, Action>();
    private Dictionary<GameObject, Action> CurrentMenu = null;

    Vector2 positionOfFirstMenuItem = new Vector2(-7.16f, -0.73f);
    // Use this for initialization
    void Start()
    {
        MenuItems.Add(Instantiate(MenuItemPrefab), () =>
            { //make individual menu item objects later
                Debug.Log("Menu Item 1-1 Pressed");
            }); 
        MenuItems.Add(Instantiate(MenuItemPrefab), () =>
            {
                Debug.Log("Menu Item 1-2 Pressed");

            });
        MenuItems.Add(Instantiate(MenuItemPrefab), () =>
            {
                Debug.Log("Menu Item 1-3 Pressed");

            });
        MenuItems.Add(Instantiate(MenuItemPrefab), () =>
            {
                Debug.Log("Menu Item 1-4 Pressed");
                switchMenus(MenuItems2);

            });
        MenuItems2.Add(Instantiate(MenuItemPrefab2), () =>
            { 
                Debug.Log("Menu Item 2-1 Pressed");
            }); 
        MenuItems2.Add(Instantiate(MenuItemPrefab2), () =>
            {
                Debug.Log("Menu Item 2-2 Pressed");

            });
        MenuItems2.Add(Instantiate(MenuItemPrefab2), () =>
            {
                Debug.Log("Menu Item 2-3 Pressed");

            });
        MenuItems2.Add(Instantiate(MenuItemPrefab2), () =>
            {
                Debug.Log("Menu Item 2-4 Pressed");
                switchMenus(MenuItems);

            });
        switchMenus(MenuItems);

    }

    public void doMenuAction(GameObject menuItem)
    {
        CurrentMenu[menuItem]();
    }

    public void switchMenus(Dictionary<GameObject, Action> menuToSwitchTo)
    {

        float delayOfAnimation = 0;
        if (CurrentMenu != null)
        {
            foreach (GameObject menuItem in CurrentMenu.Keys)
            {
                MenuItemController menuItemController = menuItem.GetComponent<MenuItemController>();
                menuItemController.StopAllCoroutines();
                menuItemController.acceptingMouseActions = false;
                StartCoroutine(menuItemController.hideWithDelay(delayOfAnimation));

                delayOfAnimation += 0.15f; //amount of time between starting each movement (for cascading effect)
            }
            delayOfAnimation *= 0.4f; //overlap

        }


        Vector2 menuItemPosition = positionOfFirstMenuItem;
        foreach (GameObject menuItem in menuToSwitchTo.Keys)
        {
            MenuItemController menuItemController = menuItem.GetComponent<MenuItemController>();
            menuItemController.init(menuItemPosition, this);
            menuItem.transform.position = menuItemController.hidePosition;
            menuItemController.StopAllCoroutines();
            StartCoroutine(menuItemController.unhideWithDelay(delayOfAnimation));

            menuItemPosition = new Vector2(menuItemPosition.x, menuItemPosition.y - 1.0f);
            delayOfAnimation += 0.15f; //amount of time between starting each movement (for cascading effect)
        }
        CurrentMenu = menuToSwitchTo;
    }
    // Update is called once per frame
    void Update()
    {
	
    }
}
