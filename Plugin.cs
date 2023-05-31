using BepInEx;
using BepInEx.Configuration;
using System;
using UnityEngine;

namespace VeryRGB
{
    /// <summary>
    /// This is your mod's main class.
    /// </summary>

    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        Color rgbcolor;
        float rgbcolortimer = 0;
        private ModConfig config;
        void Start()
        {
            
        }

        void OnGameInitialized(object sender, EventArgs e)
        {
            
        }

        void Update()
        {
            config = new ModConfig(Config);
            float r = Mathf.Lerp(0f, 1f, Mathf.Abs(Mathf.Sin(rgbcolortimer * 0.4f)));
            float g = Mathf.Lerp(0f, 1f, Mathf.Abs(Mathf.Sin(rgbcolortimer * 0.5f)));
            float b = Mathf.Lerp(0f, 1f, Mathf.Abs(Mathf.Sin(rgbcolortimer * 0.6f)));
            rgbcolor = new Color(r, g, b);
            rgbcolortimer += Time.deltaTime * config.RgbSpeed.Value;
            GamePlayer[] GamePlayerb = UnityEngine.Object.FindObjectsOfType<GamePlayer>();
            foreach (GamePlayer GamePlayers in GamePlayerb)
            {
                if(GamePlayers.IsLocalPlayer)
                {
                    GamePlayers.NetworkPlayerColor = rgbcolor;
                    GamePlayers.PlayerColor = rgbcolor;
                }
                GamePlayers.LocalPlayer.PlayerCharacter.PlayerColor = rgbcolor;
                GamePlayers.LocalPlayer.PlayerCharacter.NetworkplayerColor = rgbcolor;
                GamePlayers.LocalPlayer.PlayerCharacter.CallCmdSetPlayerColor(rgbcolor);
                GamePlayers.LocalPlayer.PlayerCharacter.SpriteRenderer.color = rgbcolor;
            }
            LobbyPlayer[] LobbyPlayerb = UnityEngine.Object.FindObjectsOfType<LobbyPlayer>();
            foreach (LobbyPlayer LobbyPlayers in LobbyPlayerb)
            {
                if (LobbyPlayers.IsLocalPlayer)
                {
                    LobbyPlayers.NetworkPlayerColor = rgbcolor;
                    LobbyPlayers.PlayerColor = rgbcolor;
                }
                LobbyPlayers.LocalPlayer.PlayerCharacter.PlayerColor = rgbcolor;
                LobbyPlayers.LocalPlayer.PlayerCharacter.NetworkplayerColor = rgbcolor;
                LobbyPlayers.LocalPlayer.PlayerCharacter.CallCmdSetPlayerColor(rgbcolor);
                LobbyPlayers.LocalPlayer.PlayerCharacter.SpriteRenderer.color = rgbcolor;
            }
            GameSettings.GetInstance().CharacterHighlightColor = rgbcolor;
            GameSettings.GetInstance().CharacterNegativeColor = rgbcolor;
            GameSettings.GetInstance().neutralColor = rgbcolor;
            GameSettings.GetInstance().beatColor = rgbcolor;
            GameSettings.GetInstance().DiabledXoutColor = rgbcolor;
            GameSettings.GetInstance().highlightColor = rgbcolor;
            GameSettings.GetInstance().highlightColor2 = rgbcolor;
            GameSettings.GetInstance().highlightColor3 = rgbcolor;
            GameSettings.GetInstance().highlightColor4 = rgbcolor;
            GameSettings.GetInstance().ItemPickupDeHighlightColor = rgbcolor;
            GameSettings.GetInstance().ItemPickupHighlightColor = rgbcolor;
            GameSettings.GetInstance().ItemPickupHighlightColor2 = rgbcolor;
            GameSettings.GetInstance().SystemAlertColor = rgbcolor;
            GameSettings.GetInstance().SystemColor = rgbcolor;
            GameSettings.GetInstance().unbeatColor = rgbcolor;
            GameSettings.GetInstance().negativeColor = rgbcolor;
        }
    }
}
