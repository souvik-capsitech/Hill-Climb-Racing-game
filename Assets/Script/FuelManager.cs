using UnityEngine;
using UnityEngine.UI;

public class FuelManager : MonoBehaviour
{
    public static FuelManager instance;

    [SerializeField] private Image fuelImage;
    [SerializeField, Range(0.1f , 5f)] private float fuelDrainSpeed = 1f;
    [SerializeField] private float maxFuel = 100f;
    [SerializeField] private Gradient fuelGradient;


    private float currentFuelAmount;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   private void Start()
    {
        currentFuelAmount = maxFuel;
        UpdateUI();
    }

    // Update is called once per frame
   private void Update()
    {
     currentFuelAmount -= fuelDrainSpeed* Time.deltaTime;   
        UpdateUI();

        if(currentFuelAmount <= 0f)
        {
            GameManager.instance.GameOver();
        }
    }


    private void UpdateUI()
    {
        fuelImage.fillAmount = (currentFuelAmount / maxFuel);
        fuelImage.color = fuelGradient.Evaluate(fuelImage.fillAmount);
    }

    public void FillFuel()
    {
        currentFuelAmount = maxFuel;
        UpdateUI();
    }
}
