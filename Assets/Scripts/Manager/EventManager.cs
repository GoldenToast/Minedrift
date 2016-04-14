using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class EventManager : MonoBehaviour {

	private Dictionary <string, UnityEvent<Object>> eventDictionary ;
	private static EventManager eventManager;

	public static EventManager instance{
		get		{
			if (!eventManager)			{
				eventManager = FindObjectOfType (typeof (EventManager)) as EventManager;
				if (!eventManager)				{
					Debug.LogError ("There needs to be one active EventManger script on a GameObject in your scene.");
				}else{
					eventManager.Init (); 
				}
			}
			return eventManager;
		}
	}
	
	void Init (){
		if (eventDictionary == null){
			eventDictionary = new Dictionary<string, UnityEvent<Object>>();
		}
	}

	public static void StartListening(string eventName, UnityAction<Object> listener){
		UnityEvent<Object> thisEvent = null;
		if (instance.eventDictionary.TryGetValue (eventName, out thisEvent)){
			thisEvent.AddListener (listener);
		} else {
			thisEvent = new ChangeEvent();
			thisEvent.AddListener (listener);
			instance.eventDictionary.Add (eventName, thisEvent);
		}
	}
	
	public static void StopListening (string eventName, UnityAction<Object> listener){
		if (eventManager == null){	return; }
		UnityEvent<Object> thisEvent = null;
		if (instance.eventDictionary.TryGetValue (eventName, out thisEvent)){
			thisEvent.RemoveListener (listener);
		}
	}
	
	public static void TriggerEvent (string eventName, Object eventData){
		UnityEvent<Object> thisEvent = null;
		if (instance.eventDictionary.TryGetValue (eventName, out thisEvent)){
			thisEvent.Invoke (eventData);
		}
	}

	public class ChangeEvent : UnityEvent<Object>{
	}
}
