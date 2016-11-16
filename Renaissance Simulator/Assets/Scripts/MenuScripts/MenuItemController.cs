using UnityEngine;
using System.Collections;

public class MenuItemController : MonoBehaviour
{
    private Vector2 originalPosition;
    private Vector2 finalPosition;
    public Vector2 hidePosition;
    public bool acceptingMouseActions = false;
    private int hoveringTimer = 0;
    private MenuController parentMenuController;
    private float interpolation = 0;
    // Use this for initialization
    public void init(Vector2 originalPosition, MenuController parentMenuController)
    {
        this.originalPosition = originalPosition;
        this.parentMenuController = parentMenuController;
        finalPosition = new Vector2(originalPosition.x + 1.0f, originalPosition.y);
        hidePosition = new Vector2(-9f - 0.5f * transform.localScale.x, originalPosition.y);
    }

    void Update()
    {
        if (acceptingMouseActions)
        {
            if (hoveringTimer > 0)
            {
                interpolation += 0.1f;
                hoveringTimer--;
            }
            else
            {
                interpolation -= 0.1f;
            }
            interpolation = Mathf.Clamp(interpolation, 0, 1f);
            transform.position = Vector2.Lerp(originalPosition, finalPosition, interpolation * interpolation);
        }
        else
        {
            interpolation = 0;
        }
    }

    void OnMouseOver()
    {
        if (acceptingMouseActions == true)
        {
            hoveringTimer = 8;
        }
    }


    void OnMouseDown()
    {
        if (acceptingMouseActions == true)
        {
            parentMenuController.doMenuAction(gameObject);
        }
    }

    public IEnumerator hideWithDelay(float delay)
    {
        Vector2 currentPosition = transform.position;
        yield return new WaitForSeconds(delay);
        for (float i = 1; i > 0.05; i -= 0.05f)
        {
            transform.position = Vector2.Lerp(hidePosition, currentPosition, i * i);
            yield return null;
        }
    }

    public IEnumerator unhideWithDelay(float delay)
    {
        Vector2 currentPosition = transform.position;
        yield return new WaitForSeconds(delay);
        for (float i = 1; i > 0; i -= 0.05f)
        {
            transform.position = Vector2.Lerp(originalPosition, currentPosition, i * i);
            yield return null;
        }
        acceptingMouseActions = true;
    }
}