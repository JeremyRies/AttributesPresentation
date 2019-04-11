using UnityEngine;

[Tracker("Car")]
public class Car : MonoBehaviour
{
	[Header("--- Car Specs ---")]
	
	[Range(1, 4)] 
	public int Speed;

	[Tooltip("Name needs to be cool")]
	public string Name;

	public CarType CarType;
}