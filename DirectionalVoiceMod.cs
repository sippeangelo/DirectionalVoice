using MelonLoader;
using UnityEngine;
using VRC;

namespace DirectionalVoice
{
  public static class BuildInfo
  {
    public const string Name = "DirectionalVoice";
    public const string Author = "Jace";
    public const string Version = "0.1.0";
    public const string DownloadLink = "https://gitlab.com/sippeangelo/DirectionalVoice";
  }

  public class DirectionalVoiceMod : MelonMod
  {
    private bool mEnabled;
    private float mMinVolume;
#if DEBUG
    private string mDebugTarget;
#endif

    public override void OnApplicationStart()
    {
      MelonPrefs.RegisterCategory("DirectionalVoice", "Directional Voice");

      MelonPrefs.RegisterBool("DirectionalVoice", "Enabled", true, "Directional Voice");
      MelonPrefs.RegisterFloat("DirectionalVoice", "MinVolume", 25f, "Minimum volume when behind speaker (percent)");
#if DEBUG
      MelonPrefs.RegisterString("DirectionalVoice", "DebugTarget", "", "Debug Target");
#endif

      OnModSettingsApplied();
    }

    public override void OnUpdate()
    {
      if (!mEnabled) {
        return;
      }

      foreach (Player player in Util.GetPlayers()) {
        if (player == null || player.IsLocal()) {
          continue;
        }

        Transform head = player.prop_VRCPlayer_0?.field_Internal_Animator_0?.GetBoneTransform(HumanBodyBones.Head);
        if (!head) {
          continue;
        }

        // Calculate the volume as a function of the angle between our postition and the other player's head rotation. Our own rotation shouldn't have an effect on the volume.
        Vector3 directionToAvatar = Vector3.Normalize(Util.GetLocalPlayer().transform.position - head.position);
        Vector3 avatarForward = head.forward;
        float factor = (Vector3.Dot(directionToAvatar, avatarForward) + 1) / 2f;
        float volume = 1 - (1 - factor) * (1 - mMinVolume / 100f);

        player.field_Private_USpeaker_0.SpeakerVolume = volume;

#if DEBUG
        if (mDebugTarget.Length > 0 && player.prop_APIUser_0.displayName.ToLower().Contains(mDebugTarget.ToLower())) {
          MelonLogger.Log($"directionToAvatar: {directionToAvatar.ToString()}");
          MelonLogger.Log($"avatarForward: {avatarForward.ToString()}");
          MelonLogger.Log($"Dot: {Vector3.Dot(directionToAvatar, avatarForward)} ({factor}), vol: {volume}");
        }
#endif
      }
    }

    public override void OnModSettingsApplied()
    {
      bool enabled = MelonPrefs.GetBool("DirectionalVoice", "Enabled");
      if (!enabled && mEnabled) {
        foreach (Player player in Util.GetPlayers()) {
          player.field_Private_USpeaker_0.SpeakerVolume = 1f;
        }
      }
      mEnabled = enabled;

      mMinVolume = MelonPrefs.GetFloat("DirectionalVoice", "MinVolume");

#if DEBUG
      mDebugTarget = MelonPrefs.GetString("DirectionalVoice", "DebugTarget");
#endif
    }
  }
}
