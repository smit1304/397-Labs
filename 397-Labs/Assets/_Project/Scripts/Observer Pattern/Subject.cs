using System.Collections.Generic;   
using UnityEngine;

namespace Platformer397
{
    public abstract class Subject : MonoBehaviour
    {
        //List of observers 
        //Add and/or remove observers from this list
        //Notify all observers in the list
        [SerializeField] private List<IObserver> observers = new List<IObserver>();

        public void AddObserver(IObserver observer) => observers.Add(observer);
        public void RemoveObserver(IObserver observer) => observers.Remove(observer);
        public void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.OnNotify();
            }
        }
    }
}
 