using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class Link : MonoBehaviour 
{

	public void OpenLinkJSPlugin()
	{
		#if !UNITY_EDITOR
		openWindow("https://github.com/OlaAni/ZombieProject/tree/Beta");
		#endif
	}

	[DllImport("__Internal")]
	private static extern void openWindow(string url);

}