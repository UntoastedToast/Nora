//-----------------------------------------------------------------------
// <copyright file="CameraPointer.cs" company="Google LLC">
// Copyright 2020 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using UnityEngine;

/// <summary>
/// Sends messages to gazed GameObject.
/// </summary>
public class CameraPointer : MonoBehaviour
{
    private const float _maxDistance = 10;
    private GameObject _gazedAtObject = null;

     //Bewegung
    public GameObject player;
    public GameObject moveSphere;
    public float speed;
    //
    public bool clickedFirstTime;

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    public void Start()
    {
        //clickedFirstTime = true;
        Debug.Log(clickedFirstTime);
    }
    public void Update()
    {
        // Casts ray towards camera's forward direction, to detect if a GameObject is being gazed
        // at.
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _maxDistance))
        {
            // GameObject detected in front of the camera.
            if (_gazedAtObject != hit.transform.gameObject)
            {
                // New GameObject.
                _gazedAtObject?.SendMessage("OnPointerExit");
                _gazedAtObject = hit.transform.gameObject;
                _gazedAtObject.SendMessage("OnPointerEnter");
            }
        }
        else
        {
            // No GameObject detected in front of the camera.
            _gazedAtObject?.SendMessage("OnPointerExit");
            _gazedAtObject = null;






            // Use Physics.Raycast to check for walls and adjust player position if necessary
            RaycastHit wallHit;
            if (Physics.Raycast(player.transform.position, moveSphere.transform.position - player.transform.position, out wallHit, Vector3.Distance(moveSphere.transform.position, player.transform.position)))
            {
                // If the player is about to hit a wall, adjust their position to be just before the wall
                player.transform.position = wallHit.point - (moveSphere.transform.position - player.transform.position).normalized * 0.1f;
            }
            else
            {
                // Stop the player object's movement if clickedFirstTime is false.
                player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }




        }

        // Checks for screen touches.
        if (Google.XR.Cardboard.Api.IsTriggerPressed)
        {
            //Test mit eleganter Funktion
           
            if(!clickedFirstTime)
            {
                clickedFirstTime = true;
            }
            else if(clickedFirstTime)
            {
                clickedFirstTime = false;
            }
            //
            
             //checken ob rihtig geschrieben
            _gazedAtObject?.SendMessage("OnPointerClick");
            
        }
        if(clickedFirstTime)
            {
            player.transform.position = Vector3.MoveTowards(player.transform.position, moveSphere.transform.position, speed);
            }

         else
            {
            // Stop the player object's movement if clickedFirstTime is false.
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        
    }

    
}
