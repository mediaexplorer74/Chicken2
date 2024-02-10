// Decompiled with JetBrains decompiler
// Type: JuicyChicken.ConsoleCommandAttribute
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using System;

#nullable disable
namespace JuicyChicken
{
  [AttributeUsage(AttributeTargets.Method)]
  public class ConsoleCommandAttribute : Attribute
  {
    public string Name { get; private set; }

    public string Description { get; private set; }

    public int AccessLevel { get; private set; }

    public ConsoleCommandAttribute(string name = "", string description = "No Description", int privilegeLevel = 0)
    {
      this.Name = name;
      this.Description = description;
      this.AccessLevel = privilegeLevel;
    }
  }
}
