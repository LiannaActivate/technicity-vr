using UnityEngine;
using UnityEngine.UI;

public class CarouselController : MonoBehaviour
{
    public GameObject[] carouselItems; // Assign all the carousel items here
    public Button leftButton; // Assign the left button
    public Button rightButton; // Assign the right button

    private int currentIndex = 0;

    void Start()
    {
        // Initialize carousel
        UpdateCarousel();

        // Add listeners to buttons
        leftButton.onClick.AddListener(ShowPrevious);
        rightButton.onClick.AddListener(ShowNext);
    }

    void ShowPrevious()
    {
        // Decrement index
        if (currentIndex > 0)
        {
            currentIndex--;
            UpdateCarousel();
        }
    }

    void ShowNext()
    {
        // Increment index
        if (currentIndex < carouselItems.Length - 1)
        {
            currentIndex++;
            UpdateCarousel();
        }
    }

    void UpdateCarousel()
    {
        // Enable the current item and disable others
        for (int i = 0; i < carouselItems.Length; i++)
        {
            carouselItems[i].SetActive(i == currentIndex);
        }

        // Update button states
        leftButton.interactable = currentIndex > 0;
        rightButton.interactable = currentIndex < carouselItems.Length - 1;
    }
}
