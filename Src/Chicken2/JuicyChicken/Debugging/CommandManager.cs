// Decompiled with JetBrains decompiler
// Type: JuicyChicken.CommandManager
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

#nullable enable
namespace JuicyChicken
{
  public static class CommandManager
  {
    private static 
    #nullable disable
    Dictionary<string, Command> commands = new Dictionary<string, Command>((IEqualityComparer<string>) StringComparer.InvariantCultureIgnoreCase);
    private static Dictionary<string, PropertyInfo> properties = new Dictionary<string, PropertyInfo>((IEqualityComparer<string>) StringComparer.InvariantCultureIgnoreCase);
    private static Dictionary<string, FieldInfo> fields = new Dictionary<string, FieldInfo>((IEqualityComparer<string>) StringComparer.InvariantCultureIgnoreCase);

    [ConsoleVariable("")]
    public static int AccessLevel { get; set; } = 0;

    public static void ExecuteCommand(string name, params object[] args)
    {
      Command command;
      if (CommandManager.commands.TryGetValue(name, out command))
      {
        if (CommandManager.AccessLevel < command.AccessLevel)
        {
          Debug.Log<string>("Command above your current privilege level.", Debug.ErrorColor);
        }
        else
        {
          ParameterInfo[] parameters1 = command.Method.GetParameters();
          int length = parameters1.Length;
          object[] parameters2 = new object[length];
          if (args.Length != length)
          {
            DefaultInterpolatedStringHandler interpolatedStringHandler = 
                            new DefaultInterpolatedStringHandler(20, 2);
            interpolatedStringHandler.AppendFormatted(name);
            interpolatedStringHandler.AppendLiteral(" needs ");
            interpolatedStringHandler.AppendFormatted<int>(length);
            interpolatedStringHandler.AppendLiteral(" parameters: ");
            string str1 = interpolatedStringHandler.ToStringAndClear();

            //  Math.Clamp(args.Length, 0, length) ".NET8 emulation"
            int clamp = args.Length;

            if (args.Length > length)
                clamp = length;

            if (args.Length < 0)
                clamp = 0;
                       
            for (int index = clamp; index < length; ++index)
            {
              if (parameters1[index].HasDefaultValue)
              {
                string str2 = str1;
                interpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 3);
                interpolatedStringHandler.AppendLiteral("<");
                interpolatedStringHandler.AppendFormatted<Type>(parameters1[index].ParameterType);
                interpolatedStringHandler.AppendLiteral(">");
                interpolatedStringHandler.AppendFormatted(parameters1[index].Name);
                interpolatedStringHandler.AppendLiteral(" = ");
                interpolatedStringHandler.AppendFormatted<object>(parameters1[index].DefaultValue);
                interpolatedStringHandler.AppendLiteral("; ");
                string stringAndClear = interpolatedStringHandler.ToStringAndClear();
                str1 = str2 + stringAndClear;
              }
              else
              {
                string str3 = str1;
                interpolatedStringHandler = new DefaultInterpolatedStringHandler(15, 2);
                interpolatedStringHandler.AppendLiteral("<");
                interpolatedStringHandler.AppendFormatted<Type>(parameters1[index].ParameterType);
                interpolatedStringHandler.AppendLiteral(">");
                interpolatedStringHandler.AppendFormatted(parameters1[index].Name);
                interpolatedStringHandler.AppendLiteral(" no default; ");
                string stringAndClear = interpolatedStringHandler.ToStringAndClear();
                str1 = str3 + stringAndClear;
              }
            }
            DebugConsole.Write<string>(str1.Replace("System.", "").Replace("Single", "Float").Replace("Int32", "Int"));
          }
          for (int index = 0; index < length; ++index)
          {
            Type parameterType = parameters1[index].ParameterType;
            if (args.Length < index + 1)
            {
              if (!parameters1[index].HasDefaultValue)
                return;
              parameters2[index] = parameters1[index].DefaultValue;
            }
            else if (parameterType != typeof (string))
            {
              try
              {
                CommandManager.ConvertArg(args[index], parameterType, out parameters2[index]);
              }
              catch
              {
                Debug.Log<string>("Could not parse input", Debug.ErrorColor);
              }
            }
            else
              parameters2[index] = args[index];
          }
          command.Method.Invoke((object) null, parameters2);
        }
      }
      else
      {
        PropertyInfo propertyInfo;
        if (CommandManager.properties.TryGetValue(name, out propertyInfo))
        {
          object obj = propertyInfo.GetValue((object) null, (object[]) null);
          Type type = obj.GetType();
          DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 2);
          interpolatedStringHandler.AppendFormatted(propertyInfo.Name);
          interpolatedStringHandler.AppendLiteral(": ");
          interpolatedStringHandler.AppendFormatted<object>(obj);
          string str4 = "" + interpolatedStringHandler.ToStringAndClear();
          if (!type.IsPrimitive || type == typeof (string))
          {
            Debug.Log<string>(str4 + " - Note: value is not primitive and thus is restricted");
          }
          else
          {
            if (propertyInfo.SetMethod.IsPrivate && args.Length == 1)
              str4 += " - Set accesor is private cannot be set";
            else if (propertyInfo.SetMethod.IsPublic && args.Length == 1)
            {
              object instance = Activator.CreateInstance(type);
              try
              {
                CommandManager.ConvertArg(args[0], type, out instance);
                propertyInfo.SetValue((object) null, instance);
                string str5 = str4;
                interpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 1);
                interpolatedStringHandler.AppendLiteral(" - Set value to ");
                interpolatedStringHandler.AppendFormatted<object>(instance);
                string stringAndClear = interpolatedStringHandler.ToStringAndClear();
                str4 = str5 + stringAndClear;
              }
              catch
              {
                str4 += " - Couldn't parse value";
              }
            }
            else if (args.Length > 1)
              str4 += " - Properties cannot take more than 1 argument";
            Debug.Log<string>(str4);
          }
        }
        else
        {
          FieldInfo fieldInfo;
          if (CommandManager.fields.TryGetValue(name, out fieldInfo))
          {
            object obj = fieldInfo.GetValue((object) null);
            Type type = obj.GetType();
            DefaultInterpolatedStringHandler interpolatedStringHandler1 = new DefaultInterpolatedStringHandler(2, 2);
            interpolatedStringHandler1.AppendFormatted(fieldInfo.Name);
            interpolatedStringHandler1.AppendLiteral(": ");
            interpolatedStringHandler1.AppendFormatted<object>(obj);
            string str6 = "" + interpolatedStringHandler1.ToStringAndClear();
            if (!type.IsPrimitive || type == typeof (string))
            {
              Debug.Log<string>(str6 + " - Note: value is not primitive and thus is restricted");
            }
            else
            {
              if (args.Length == 1)
              {
                object instance = Activator.CreateInstance(type);
                try
                {
                  CommandManager.ConvertArg(args[0], type, out instance);
                  fieldInfo.SetValue((object) null, instance);
                  string str7 = str6;
                  DefaultInterpolatedStringHandler interpolatedStringHandler2 = new DefaultInterpolatedStringHandler(16, 1);
                  interpolatedStringHandler2.AppendLiteral(" - Set value to ");
                  interpolatedStringHandler2.AppendFormatted<object>(instance);
                  string stringAndClear = interpolatedStringHandler2.ToStringAndClear();
                  str6 = str7 + stringAndClear;
                }
                catch
                {
                  str6 += " - Couldn't parse value";
                }
              }
              else if (args.Length > 1)
                str6 += " - Properties cannot take more than 1 argument";
              Debug.Log<string>(str6);
            }
          }
          else
            Debug.Log<string>("Command '" + name + "' not found", Debug.ErrorColor);
        }
      }
    }

    private static void ConvertArg(object input, Type type, out object value)
    {
      if (type == typeof (bool) && (string) input == "1")
        input = (object) "true";
      else if (type == typeof (bool) && (string) input == "0")
        input = (object) "false";
      value = Convert.ChangeType(input, type, (IFormatProvider) CultureInfo.InvariantCulture);
    }

    public static void GetCommands()
    {
      foreach (MethodInfo info in ((IEnumerable<Type>) Assembly.GetEntryAssembly().GetTypes()).SelectMany<Type, MethodInfo>((Func<Type, IEnumerable<MethodInfo>>) (t => (IEnumerable<MethodInfo>) t.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))).Where<MethodInfo>((Func<MethodInfo, bool>) (m => m.GetCustomAttributes(typeof (ConsoleCommandAttribute), false).Length != 0)).ToArray<MethodInfo>())
      {
        ConsoleCommandAttribute customAttribute = (ConsoleCommandAttribute) info.GetCustomAttributes(typeof (ConsoleCommandAttribute), false)[0];
        string key = customAttribute.Name == "" ? info.Name : customAttribute.Name;
        CommandManager.commands.Add(key, new Command(customAttribute.Name, customAttribute.Description, info, customAttribute.AccessLevel));
      }
      CommandManager.GetProperties();
      CommandManager.GetFields();
    }

    private static void GetProperties()
    {
      foreach (PropertyInfo propertyInfo in ((IEnumerable<Type>) Assembly.GetEntryAssembly().GetTypes()).SelectMany<Type, PropertyInfo>((Func<Type, IEnumerable<PropertyInfo>>) (t => (IEnumerable<PropertyInfo>) t.GetProperties(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))).Where<PropertyInfo>((Func<PropertyInfo, bool>) (m => m.GetCustomAttributes(typeof (ConsoleVariableAttribute), false).Length != 0)).ToArray<PropertyInfo>())
      {
        ConsoleVariableAttribute customAttribute = (ConsoleVariableAttribute) propertyInfo.GetCustomAttributes(typeof (ConsoleVariableAttribute), false)[0];
        string key = customAttribute.Name == "" ? propertyInfo.Name : customAttribute.Name;
        CommandManager.properties.Add(key, propertyInfo);
      }
    }

    private static void GetFields()
    {
      foreach (FieldInfo fieldInfo in ((IEnumerable<Type>) Assembly.GetEntryAssembly().GetTypes()).SelectMany<Type, FieldInfo>((Func<Type, IEnumerable<FieldInfo>>) (t => (IEnumerable<FieldInfo>) t.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))).Where<FieldInfo>((Func<FieldInfo, bool>) (m => m.GetCustomAttributes(typeof (ConsoleVariableAttribute), false).Length != 0)).ToArray<FieldInfo>())
      {
        ConsoleVariableAttribute customAttribute = (ConsoleVariableAttribute) fieldInfo.GetCustomAttributes(typeof (ConsoleVariableAttribute), false)[0];
        string key = customAttribute.Name == "" ? fieldInfo.Name : customAttribute.Name;
        CommandManager.fields.Add(key, fieldInfo);
      }
    }

    [ConsoleCommand("Help", "Show a list of all available commands", 0)]
    private static void Help()
    {
      List<string> list = CommandManager.commands.Keys.ToList<string>();
      string str = "";
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 1);
      interpolatedStringHandler.AppendFormatted<int>(list.Count);
      interpolatedStringHandler.AppendLiteral(" commands:");
      DebugConsole.Write<string>(interpolatedStringHandler.ToStringAndClear(), Debug.AlertColor);
      for (int index = 0; index < list.Count; ++index)
      {
        str = str + list[index] + ", ";
        if (index != 0 && index % 5 == 0 || index == list.Count - 1)
        {
          DebugConsole.Write<string>(str);
          str = "";
        }
      }
    }

    [ConsoleCommand("Variables", "Show all available variables", 0)]
    private static void Variables()
    {
      List<string> list = CommandManager.properties.Keys.ToList<string>();
      list.AddRange((IEnumerable<string>) CommandManager.fields.Keys.ToList<string>());
      string str = "";
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(11, 1);
      interpolatedStringHandler.AppendFormatted<int>(list.Count);
      interpolatedStringHandler.AppendLiteral(" Variables:");
      DebugConsole.Write<string>(interpolatedStringHandler.ToStringAndClear(), Debug.AlertColor);
      for (int index = 0; index < list.Count; ++index)
      {
        str = str + list[index] + ", ";
        if (index != 0 && index % 5 == 0 || index == list.Count - 1)
        {
          DebugConsole.Write<string>(str);
          str = "";
        }
      }
    }

    [ConsoleCommand("Describe", "Describes any command| Syntax: describe <commandname>", 0)]
    private static void Describe(string commandName)
    {
      DebugConsole.Write<string>(commandName + ":", Debug.AlertColor);
      Command command;
      if (CommandManager.commands.TryGetValue(commandName, out command))
      {
        if (CommandManager.AccessLevel < command.AccessLevel)
        {
          DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(26, 2);
          interpolatedStringHandler.AppendFormatted(command.Description);
          interpolatedStringHandler.AppendLiteral(" - Required access level: ");
          interpolatedStringHandler.AppendFormatted<int>(command.AccessLevel);
          DebugConsole.Write<string>(interpolatedStringHandler.ToStringAndClear());
        }
        else
          DebugConsole.Write<string>(command.Description ?? "");
      }
      else
        DebugConsole.Write<string>("is an unknown command");
    }
  }
}
