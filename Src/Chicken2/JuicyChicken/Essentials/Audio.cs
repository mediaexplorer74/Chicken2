// Decompiled with JetBrains decompiler
// Type: JuicyChicken.Audio
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using ImGuiNET;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;

#nullable disable
namespace JuicyChicken
{
  public static class Audio
  {
    private static Dictionary<string, SoundEffectInstance> singleInstances = new Dictionary<string, SoundEffectInstance>();
    private static List<JuicySoundEffectInstance> allInstances = new List<JuicySoundEffectInstance>();
    private static float pitchModifier = 1f;
    private static bool ShowUI = false;

    [ConsoleVariable("AudioPitchMod")]
    public static float PitchModifier
    {
      get => JuicyChicken.Audio.pitchModifier;
      set
      {
        JuicyChicken.Audio.pitchModifier = value;
        JuicyChicken.Audio.UpdateInstancePitch();
      }
    }

    static Audio()
    {
      Time.OnTimeScaleChanged += new Action(JuicyChicken.Audio.UpdateInstancePitch);
      GameLoop.OnUpdate += new Action(JuicyChicken.Audio.Update);
      GameLoop.OnGUI += new Action(JuicyChicken.Audio.DrawUI);
    }

    private static void Update()
    {
      for (int index = 0; index < JuicyChicken.Audio.allInstances.Count; ++index)
      {
        if (JuicyChicken.Audio.allInstances[index].Instance.State == SoundState.Stopped)
        {
          JuicyChicken.Audio.allInstances[index].Instance.Dispose();
          JuicyChicken.Audio.allInstances.RemoveAt(index);
        }
      }
    }

    private static void UpdateInstancePitch()
    {
      for (int index = 0; index < JuicyChicken.Audio.allInstances.Count && JuicyChicken.Audio.allInstances[index].AllowPitchingMod; ++index)
      {
        float amount = JuicyChicken.Audio.allInstances[index].AllowTimePitching ? Time.TimeScale : JuicyChicken.Audio.PitchModifier;
        JuicyChicken.Audio.allInstances[index].Instance.Pitch = MathHelper.Clamp(JuicyChicken.Audio.allInstances[index].ReferencePitch.AlterPitch(amount), -1f, 1f);
      }
    }

    public static SoundEffectInstance Play(
      string key,
      float volume = 1f,
      Vector2 pitchRange = default (Vector2),
      bool loop = false,
      bool allowMultiple = true,
      bool timePitch = true,
      bool allowPitching = true)
    {
      SoundEffectInstance instance;
      if (!allowMultiple)
      {
        SoundEffectInstance soundEffectInstance;
        if (JuicyChicken.Audio.singleInstances.TryGetValue(key, out soundEffectInstance))
        {
          if (soundEffectInstance.State == SoundState.Playing)
            return soundEffectInstance;
          JuicyChicken.Audio.singleInstances.Remove(key);
          instance = Content.GetSound(key).CreateInstance();
          JuicyChicken.Audio.singleInstances.Add(key, instance);
        }
        else
        {
          instance = Content.GetSound(key).CreateInstance();
          JuicyChicken.Audio.singleInstances.Add(key, instance);
        }
      }
      else
        instance = Content.GetSound(key).CreateInstance();
      if (instance != null)
      {
        instance.Volume = volume;
        instance.Pitch = pitchRange == new Vector2() ? 0.0f : Randomizer.Next(pitchRange.X, pitchRange.Y);
        JuicyChicken.Audio.allInstances.Add(new JuicySoundEffectInstance(instance, instance.Pitch, timePitch, allowPitching));
        if (allowPitching)
        {
          float amount = timePitch ? Time.TimeScale : JuicyChicken.Audio.pitchModifier;
          instance.Pitch = MathHelper.Clamp(instance.Pitch.AlterPitch(amount), -1f, 1f);
        }
        instance.IsLooped = loop;
        instance.Play();
      }
      return instance;
    }

    private static float AlterPitch(this float value, float amount)
    {
      return (value.Remap(new Vector2(-1f, 1f), new Vector2(0.0f, 1f)) * amount).Remap(new Vector2(0.0f, 1f), new Vector2(-1f, 1f));
    }

    public static void Stop(SoundEffectInstance value)
    {
      if (value == null)
        return;
      if (value.State == SoundState.Playing)
        value.Stop();
      value.Dispose();
      JuicyChicken.Audio.allInstances.RemoveAll((Predicate<JuicySoundEffectInstance>) (x => x.Instance == value));
    }

    public static void StopAll()
    {
      foreach (JuicySoundEffectInstance allInstance in JuicyChicken.Audio.allInstances)
      {
        allInstance.Instance.Stop();
        allInstance.Instance.Dispose();
      }
      foreach (string key in JuicyChicken.Audio.singleInstances.Keys)
      {
        JuicyChicken.Audio.singleInstances[key].Stop();
        JuicyChicken.Audio.singleInstances[key].Dispose();
      }
      JuicyChicken.Audio.singleInstances.Clear();
      JuicyChicken.Audio.allInstances.Clear();
    }

    private static void DrawUI()
    {
      if (!JuicyChicken.Audio.ShowUI)
        return;
      if (!ImGui.Begin(nameof (Audio), ref JuicyChicken.Audio.ShowUI, ImGuiWindowFlags.AlwaysAutoResize))
      {
        ImGui.End();
      }
      else
      {
        ImGui.Value("Audio instances", JuicyChicken.Audio.allInstances.Count);
        ImGui.Value("Solo instances", JuicyChicken.Audio.singleInstances.Count);
        if (ImGui.Button("Stop all instances"))
          JuicyChicken.Audio.StopAll();
        ImGui.End();
      }
    }

    public static void MenuItem() => ImGui.MenuItem("Audio Info", "", ref JuicyChicken.Audio.ShowUI);
  }
}
