// Decompiled with JetBrains decompiler
// Type: JuicyChicken.JuicySoundEffectInstance
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using Microsoft.Xna.Framework.Audio;

#nullable disable
namespace JuicyChicken
{
  internal class JuicySoundEffectInstance
  {
    public SoundEffectInstance Instance { get; private set; }

    public float ReferencePitch { get; private set; }

    public bool AllowTimePitching { get; set; }

    public bool AllowPitchingMod { get; set; }

    public JuicySoundEffectInstance(
      SoundEffectInstance instance,
      float referencePitch = 0.0f,
      bool allowTimePitch = true,
      bool allowPitchMod = true)
    {
      this.Instance = instance;
      this.ReferencePitch = referencePitch;
      this.AllowTimePitching = allowTimePitch;
      this.AllowPitchingMod = allowPitchMod;
    }
  }
}
