using UnityEngine;
using UnityEngine.UI;

public class VehicleSelector : MonoBehaviour
{
    [Header("Vehicles")]
    public GameObject[] vehicles;
    private int currentIndex = 0;
    private Vector3 spawnPosition;

    [Header("UI Elements")]
    public GameObject selectionPanel;
    public Button leftButton;
    public Button rightButton;
    public Button playButton;

    void Start()
    {
        
        spawnPosition = vehicles[0].transform.position;

     
        foreach (GameObject v in vehicles)
            v.SetActive(false);

      
        ShowVehicle(currentIndex);

        
        leftButton.onClick.AddListener(PrevVehicle);
        rightButton.onClick.AddListener(NextVehicle);
        playButton.onClick.AddListener(StartGame);
    }

    void ShowVehicle(int index)
    {
        
        foreach (GameObject v in vehicles)
            v.SetActive(false);

        
        vehicles[index].transform.position = spawnPosition;
        vehicles[index].SetActive(true);
    }

    public void NextVehicle()
    {
        currentIndex++;
        if (currentIndex >= vehicles.Length)
            currentIndex = 0;
        ShowVehicle(currentIndex);
    }

    public void PrevVehicle()
    {
        currentIndex--;
        if (currentIndex < 0)
            currentIndex = vehicles.Length - 1;
        ShowVehicle(currentIndex);
    }

    public void StartGame()
    {
       
        selectionPanel.SetActive(false);

      
        var driver = vehicles[currentIndex].GetComponent<Driver>();
        if (driver != null)
            driver.enabled = true;
    }
}
