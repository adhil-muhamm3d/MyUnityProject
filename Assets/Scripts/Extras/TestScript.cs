using UnityEngine;
using System.Threading.Tasks;

public class TestScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    async void Start()
    {
        Debug.Log("Start waiting...");
        await Task.Delay(3000);
        Debug.Log("Waiting Ends...");
    }

}
