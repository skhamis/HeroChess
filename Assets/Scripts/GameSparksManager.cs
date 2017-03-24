using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSparks.Api.Responses;
using GameSparks.Api.Requests;
using GameSparks.Api.Messages;
using System;
using GameSparks.Api;
using UnityEngine.UI;
using GameSparks.Core;

public class GameSparksManager : MonoBehaviour
{

    public static GameSparksManager Instance = null;
    public string displayNameInput, userNameInput, passwordInput;

    public void Awake()
    {
        
        if (Instance == null)
        {
            Debug.Log("GameSparksManager Created");
            Instance = this;
            
            //DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Debug.Log("GameSparksManager: SHOULDN'T HAPPEN");
            Destroy(this.gameObject);
        }

        ScriptMessage.Listener = ((ScriptMessage message) =>
        {
            Debug.Log("ScriptMessage Recieved");
        });

        GSMessageHandler._AllMessages = (GSMessage e) =>
        {
            Debug.Log("ALL HANDLER " + e.MessageId);
        };
    }

    public void RegisterPlayer()
    {
        Debug.Log("Registering player...");
        new RegistrationRequest()
            .SetDisplayName(displayNameInput)
            .SetUserName(userNameInput)
            .SetPassword(passwordInput)
            .Send((response) =>
           {
               if (!response.HasErrors)
               {
                   Debug.Log("Registration successful! \n Username: " + response.DisplayName);
                   Debug.Log("Registration ScriptData: " + response.ScriptData);
               }
               else
               {
                   Debug.Log("Failed to registered player... \n" + response.Errors.JSON.ToString());
               }
           });

    }

    public void LoginPlayer()
    {
        Debug.Log("Logging in..");
        new AuthenticationRequest()
                .SetUserName(userNameInput)
                .SetPassword(passwordInput)
                .Send((response) =>
                {
                    if (!response.HasErrors)
                    {
                        Debug.Log("Player " + response.DisplayName + "successfully logged in!");
                    }
                    else
                    {
                        Debug.Log("Could not log in: " + response.Errors.JSON.ToString());
                    }
                });
    }

    //If we just want to use the device they have
    public void DeviceAuthenticate()
    {
        new DeviceAuthenticationRequest().Send((response) =>
        {
            //HandleLog("DeviceAuthenticationRequest.JSON:" + response.JSONString);
            //HandleLog("DeviceAuthenticationRequest.HasErrors:" + response.HasErrors);
            //HandleLog("DeviceAuthenticationRequest.UserId:" + response.UserId);
            if (response.HasErrors)
            {
                Debug.Log("error authenticating");
            }
            else
            {
                Debug.Log("success");
            }
        });

    }

    public void SavePlayerData(int exp, string position, int gold)
    {
        new LogEventRequest().SetEventKey("SAVE_PLAYER")
            .SetEventAttribute("EXP", exp)
            .SetEventAttribute("POS", position)
            .SetEventAttribute("GOLD",gold)
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
                    Debug.Log("Player Saved To GameSparks...");
                }
                else
                {
                    Debug.Log("Error Saving Player Data...");
                }
            });

    }

    public void LoadPlayerData()
    {
        new LogEventRequest().SetEventKey("LOAD_PLAYER")
            .Send((response) => {
                if (!response.HasErrors)
                {
                    GSData data = response.ScriptData.GetGSData("player_Data");

                    Debug.Log("Id: " + data.GetString("playerID"));
                    Debug.Log("EXP: " + data.GetNumber("playerExp"));
                    Debug.Log("POS: " + data.GetString("playerPos"));
                    Debug.Log("GOLD: " + data.GetNumber("playerGold"));
                }
                else
                {
                    Debug.Log("Error Loading player data!");
                }
            });
    }

    public void UserName_Changed(string newText)
    {
        Debug.Log("username: " + newText);
        userNameInput = newText;
    }

    public void DisplayName_Changed(string newText)
    {
        Debug.Log("displayname: " + newText);
        userNameInput = newText;
    }

    public void Password_Changed(string newText)
    {
        Debug.Log("password: " + newText);
        userNameInput = newText;
    }

}
