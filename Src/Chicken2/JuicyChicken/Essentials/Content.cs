// Decompiled with JetBrains decompiler
// Type: JuicyChicken.Content
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using ImGuiNET;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
//using System.Diagnostics;
using System.IO;

#nullable disable
namespace JuicyChicken
{
  public static class Content
  {
    private static readonly Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();
    private static readonly Dictionary<string, SoundEffect> sounds = new Dictionary<string, SoundEffect>();
    private static readonly Dictionary<string, SpriteFont> fonts = new Dictionary<string, SpriteFont>();
    private static readonly Dictionary<string, Effect> effects = new Dictionary<string, Effect>();
    private static ContentManager contentManager;
    private static Texture2D missingTexture;
    private static bool showUI = false;
    private static List<ImageWindow> openImages = new List<ImageWindow>();

    public static event Action OnContentLoaded;

    public static void Load(
      ContentManager contentManager,
      string textureDirectory,
      string soundDirectory,
      string fontDirectory,
      string effectDirectory)
    {
      JuicyChicken.Content.textures.Clear();
      JuicyChicken.Content.sounds.Clear();
      JuicyChicken.Content.fonts.Clear();
      JuicyChicken.Content.effects.Clear();
      JuicyChicken.Content.contentManager = contentManager;
      GameLoop.OnGUI += new Action(JuicyChicken.Content.DrawUI);
      JuicyChicken.Content.missingTexture = new Texture2D(JuicyChicken.Graphics.Device, 32, 32);
      Color[] data = new Color[JuicyChicken.Content.missingTexture.Width * JuicyChicken.Content.missingTexture.Height];
      for (int index = 0; index < data.Length; ++index)
        data[index] = index % 2 != 0 ? Color.Black : Color.Magenta;
      JuicyChicken.Content.missingTexture.SetData<Color>(data);
      if (!Directory.Exists(textureDirectory))
        Directory.CreateDirectory(textureDirectory);
      if (!Directory.Exists(soundDirectory))
        Directory.CreateDirectory(soundDirectory);
      if (!Directory.Exists(fontDirectory))
        Directory.CreateDirectory(fontDirectory);
      if (!Directory.Exists(effectDirectory))
        Directory.CreateDirectory(effectDirectory);
      JuicyChicken.Content.ScanTextures(textureDirectory);
      JuicyChicken.Content.ScanSounds(soundDirectory);
      JuicyChicken.Content.ScanFonts(fontDirectory);
      JuicyChicken.Content.ScanEffects(effectDirectory);
      Action onContentLoaded = JuicyChicken.Content.OnContentLoaded;
      if (onContentLoaded == null)
        return;
      onContentLoaded();
    }

    private static void ScanEffects(string effectDirectory)
    {
      foreach (string file in Directory.GetFiles(effectDirectory))
      {
        string lower = Path.GetFileNameWithoutExtension(file).ToLower();
        if (!(Path.GetExtension(file).ToLower() != ".fx"))
        {
          Effect effect = JuicyChicken.Content.CreateEffect(file);
          if (effect != null)
            JuicyChicken.Content.effects.Add(lower, effect);
        }
      }
      foreach (string directory in Directory.GetDirectories(effectDirectory, "*", SearchOption.AllDirectories))
      {
        foreach (string file in Directory.GetFiles(directory))
        {
          string lower = Path.GetFileNameWithoutExtension(file).ToLower();
          if (!(Path.GetExtension(file).ToLower() != ".fx"))
          {
            Effect effect = JuicyChicken.Content.CreateEffect(file);
            if (effect != null)
              JuicyChicken.Content.effects.Add(lower, effect);
          }
        }
      }
    }

    private static void ScanTextures(string textureDirectory)
    {
      foreach (string file in Directory.GetFiles(textureDirectory))
      {
        string lower = Path.GetFileNameWithoutExtension(file).ToLower();
        Texture2D texture = JuicyChicken.Content.CreateTexture(file);
        if (texture != null)
          JuicyChicken.Content.textures.Add(lower, texture);
      }
      foreach (string directory in Directory.GetDirectories(textureDirectory, "*", SearchOption.AllDirectories))
      {
        foreach (string file in Directory.GetFiles(directory))
        {
          string lower = Path.GetFileNameWithoutExtension(file).ToLower();
          Texture2D texture = JuicyChicken.Content.CreateTexture(file);
          if (texture != null)
            JuicyChicken.Content.textures.Add(lower, texture);
        }
      }
    }

    private static void ScanSounds(string soundDirectory)
    {
      foreach (string file in Directory.GetFiles(soundDirectory))
      {
        string lower = Path.GetFileNameWithoutExtension(file).ToLower();
        SoundEffect sound = JuicyChicken.Content.CreateSound(file);
        if (sound != null)
          JuicyChicken.Content.sounds.Add(lower, sound);
      }
      foreach (string directory in Directory.GetDirectories(soundDirectory, "*", SearchOption.AllDirectories))
      {
        foreach (string file in Directory.GetFiles(directory))
        {
          string lower = Path.GetFileNameWithoutExtension(file).ToLower();
          SoundEffect sound = JuicyChicken.Content.CreateSound(file);
          if (sound != null)
            JuicyChicken.Content.sounds.Add(lower, sound);
        }
      }
    }

    private static void ScanFonts(string fontDirectory)
    {
      foreach (string file in Directory.GetFiles(fontDirectory))
      {
        string lower = Path.GetFileNameWithoutExtension(file).ToLower();
        SpriteFont font = JuicyChicken.Content.CreateFont(file);
        if (font != null)
          JuicyChicken.Content.fonts.Add(lower, font);
      }
      foreach (string directory in Directory.GetDirectories(fontDirectory, "*", SearchOption.AllDirectories))
      {
        foreach (string file in Directory.GetFiles(directory))
        {
          string lower = Path.GetFileNameWithoutExtension(file).ToLower();
          SpriteFont font = JuicyChicken.Content.CreateFont(file);
          if (font != null)
            JuicyChicken.Content.fonts.Add(lower, font);
        }
      }
    }

    private static Effect CreateEffect(string file)
    {
            Effect effect = default;

            try
            {
                effect = new Effect(JuicyChicken.Graphics.Device, File.ReadAllBytes(file));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("[ex] Content - CreateEffect error: " + ex.Message);
            }

            return effect;
            
    }

    private static Texture2D CreateTexture(string path)
    {
      Texture2D texture = (Texture2D) null;
      string assetName = Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path));
      switch (Path.GetExtension(path).ToLower())
      {
        case ".bmp":
        case ".dds":
        case ".gif":
        case ".jpg":
        case ".png":
        case ".tif":
          FileStream fileStream = new FileStream(path, FileMode.Open);
          texture = Texture2D.FromStream(JuicyChicken.Graphics.Device, (Stream) fileStream);
          fileStream.Dispose();
          Color[] data = new Color[texture.Width * texture.Height];
          texture.GetData<Color>(data);
          for (int index = 0; index < data.Length; ++index)
            data[index] = Color.FromNonPremultiplied((int) data[index].R, (int) data[index].G, (int) data[index].B, (int) data[index].A);
          texture.SetData<Color>(data);
          break;
        case ".xnb":
          texture = JuicyChicken.Content.contentManager.Load<Texture2D>(assetName);
          break;
      }
      return texture;
    }

    private static SoundEffect CreateSound(string path)
    {
      SoundEffect sound = (SoundEffect) null;
      string assetName = Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path));
      switch (Path.GetExtension(path).ToLower())
      {
        case ".xnb":
          sound = JuicyChicken.Content.contentManager.Load<SoundEffect>(assetName);
          break;
        case ".wav":
          FileStream fileStream = new FileStream(path, FileMode.Open);
          sound = SoundEffect.FromStream((Stream) fileStream);
          fileStream.Dispose();
          break;
      }
      return sound;
    }

    private static SpriteFont CreateFont(string path)
    {
      string assetName = Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path));
      return JuicyChicken.Content.contentManager.Load<SpriteFont>(assetName);
    }

    public static Texture2D GetTexture(string key)
    {
      Texture2D texture2D;
      return JuicyChicken.Content.textures.TryGetValue(key.ToLower(), out texture2D) ? texture2D : JuicyChicken.Content.missingTexture;
    }

    public static SoundEffect GetSound(string key)
    {
      SoundEffect sound;
      if (JuicyChicken.Content.sounds.TryGetValue(key.ToLower(), out sound))
        return sound;
      throw new Exception("Could not find a sound instance with the specified key: '" + key + "'");
    }

    public static SpriteFont GetFont(string key)
    {
      SpriteFont font;
      if (JuicyChicken.Content.fonts.TryGetValue(key.ToLower(), out font))
        return font;
      throw new Exception("Could not find a font with the specified key: '" + key + "'");
    }

    public static Effect GetEffect(string key)
    {
      Effect effect;
      if (JuicyChicken.Content.effects.TryGetValue(key.ToLower(), out effect))
        return effect;
      throw new Exception("Could not find an effect with the specified key: '" + key + "'");
    }

    private static void DrawUI()
    {
      if (!JuicyChicken.Content.showUI)
        return;
      if (!ImGui.Begin(nameof (Content), ref JuicyChicken.Content.showUI))
      {
        ImGui.End();
      }
      else
      {
        if (ImGui.CollapsingHeader("Textures"))
        {
          foreach (string key in JuicyChicken.Content.textures.Keys)
          {
            if (ImGui.Selectable(key))
            {
              Texture2D texture = JuicyChicken.Content.GetTexture(key);
              IntPtr pointer = JuicyChicken.Graphics.GuiRenderer.BindTexture(texture);
              JuicyChicken.Content.openImages.Add(new ImageWindow(pointer, key, new System.Numerics.Vector2((float) texture.Width, (float) texture.Height)));
            }
          }
        }
        if (ImGui.CollapsingHeader("Sounds"))
        {
          foreach (string key in JuicyChicken.Content.sounds.Keys)
          {
            if (ImGui.Selectable(key))
              JuicyChicken.Audio.Play(key);
          }
          if (ImGui.Button("Stop sounds"))
            JuicyChicken.Audio.StopAll();
        }
        if (ImGui.CollapsingHeader("Effects"))
        {
          foreach (string key in JuicyChicken.Content.effects.Keys)
          {
            if (ImGui.Selectable(key))
              JuicyChicken.Graphics.ScreenEffect = JuicyChicken.Content.GetEffect(key);
          }
          if (ImGui.Button("Clear effect"))
            JuicyChicken.Graphics.ScreenEffect = (Effect) null;
        }
        if (ImGui.CollapsingHeader("Fonts"))
        {
          foreach (string key in JuicyChicken.Content.fonts.Keys)
            ImGui.Selectable(key);
        }
        ImGui.End();
        List<ImageWindow> imageWindowList = new List<ImageWindow>();
        foreach (ImageWindow openImage in JuicyChicken.Content.openImages)
        {
          bool p_open = true;
          ImGui.Begin(openImage.key, ref p_open);
          try
          {
            ImGui.Image(openImage.pointer, openImage.size * (ImGui.GetWindowWidth() / openImage.size.X), new System.Numerics.Vector2(0.0f, 0.0f));
          }
          catch (InvalidOperationException ex)
          {
            ImGui.Text(ex.Message);
          }
          ImGui.End();
          if (!p_open)
            imageWindowList.Add(openImage);
        }
        foreach (ImageWindow imageWindow in imageWindowList)
        {
          JuicyChicken.Content.openImages.Remove(imageWindow);
          JuicyChicken.Graphics.GuiRenderer.UnbindTexture(imageWindow.pointer);
        }
      }
    }

    public static void MenuItem() => ImGui.MenuItem("Loaded content", "", ref JuicyChicken.Content.showUI);
  }
}
