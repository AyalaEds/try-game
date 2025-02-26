using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///using UnityEngine.Events;
///using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Interactor : MonoBehaviour
{
    public LayerMask Interact = 8;
    ///UnityEvent onInteract;
    Interactable interactable;
    public GameObject Canvas;
    public Image interactImage;
    public Sprite defaultIcon;
    public Vector2 defaultIconSize;
    public Sprite defaultInteractionIcon;
    public Vector2 defaultInteractionIconSize;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2, Interact))
        {
            Canvas.SetActive(true);
            if (hit.collider.GetComponent<Interactable>() != false)
            {
                if (interactable == null || interactable.ID != hit.collider.GetComponent<Interactable>().ID)
                {
                    interactable = hit.collider.GetComponent<Interactable>();
                }
                if (interactable.interactIcon != null)
                {
                    interactImage.sprite = interactable.interactIcon;
                    if (interactable.iconSize == Vector2.zero)
                    {
                        interactImage.rectTransform.sizeDelta = defaultInteractionIconSize;
                    }
                    else
                    {
                        interactImage.rectTransform.sizeDelta = interactable.iconSize;
                    }
                }
                else
                {
                    ///pressEtoInteract.SetActive(true);
                    interactImage.sprite = defaultInteractionIcon;
                    interactImage.rectTransform.sizeDelta = defaultInteractionIconSize;
                }
                ///onInteract = hit.collider.GetComponent<Interactable>().onInteract;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    ///SceneManager.LoadScene(2);
                    interactable.onInteract.Invoke();
                }
            }
        }
        else
        {
            Canvas.SetActive(false);
            if (interactImage.sprite != defaultIcon)
            {

                interactImage.sprite = defaultIcon;
                interactImage.rectTransform.sizeDelta = defaultIconSize;
            }
        }
    }
}