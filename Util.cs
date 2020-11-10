using Il2CppSystem.Collections.Generic;
using UnityEngine;
using VRC;

namespace DirectionalVoice
{
  static class Util
  {
    public static PlayerManager GetPlayerManager() =>PlayerManager.prop_PlayerManager_0;

    public static VRCPlayer GetLocalPlayer() => VRCPlayer.field_Internal_Static_VRCPlayer_0;

    public static Player[] GetPlayers()
    {
      var players = GetPlayerManager()?.field_Private_List_1_Player_0;

      if (players == null) {
        return new Player[0];
      } else {
        lock (players) {
          return players.ToArray();
        }
      }
    }

    public static GameObject GetAvatar(this Player player) => player.prop_VRCPlayer_0.prop_VRCAvatarManager_0.prop_GameObject_0;

    public static bool IsLocal(this Player p) => p.name == GetLocalPlayer().name;
  }
}
