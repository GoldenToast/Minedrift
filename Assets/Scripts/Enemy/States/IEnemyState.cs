﻿using UnityEngine;
using System.Collections;

public interface IEnemyState {

    void OnTriggerEnter(Collider other);

    void OnTriggerExit(Collider other);

    //void OnTriggerStay (Collider other); 

    void Update();

    void Start();
}
