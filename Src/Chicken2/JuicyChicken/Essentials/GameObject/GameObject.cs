// Decompiled with JetBrains decompiler
// Type: JuicyChicken.GameObject
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using ImGuiNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

#nullable disable
namespace JuicyChicken
{
  public sealed class GameObject
  {
    private HashSet<Component> components = new HashSet<Component>();
    private GameObject parent;
    private List<GameObject> children = new List<GameObject>();
    private static List<GameObject> activeGameObjects = new List<GameObject>();
    private static int nextObjectIndex = 0;
    private static int nextComponentIndex = 0;
    private static bool debug = false;
    private static int selected = 0;

    public static int ActiveCount => GameObject.activeGameObjects.Count;

    public string Tag { get; set; } = "";

    public Enum Layer { get; set; }

    public int Index { get; private set; }

    public bool IsActive { get; private set; } = true;

    public bool Static { get; set; }

    public Transform Transform { get; private set; }

    public GameObject Parent => this.parent;

    public GameObject Root => this.parent != null ? this.parent.Root : this;

    public int ChildCount => this.children.Count;

    public bool IsChild => this.Parent != null;

    public event Action OnDespawn;

    public event Action OnActivate;

    public event Action OnDeactivate;

    public event Action<Component> OnAddComponent;

    public event Action<Component> OnRemoveComponent;

    private GameObject() => this.Index = GameObject.nextObjectIndex++;

    public static GameObject Spawn(
      Microsoft.Xna.Framework.Vector2 position = default (Microsoft.Xna.Framework.Vector2),
      float rotation = 0.0f,
      Microsoft.Xna.Framework.Vector2 scale = default (Microsoft.Xna.Framework.Vector2),
      GameObject parent = null)
    {
      GameObject gameObject = new GameObject();
      gameObject.IsActive = true;
      gameObject.SetParent(parent);
      gameObject.Transform = 
                new Transform( gameObject, position, rotation,
                                scale == new Microsoft.Xna.Framework.Vector2()
                                        ? Microsoft.Xna.Framework.Vector2.One 
                                        : scale );
      GameObject.activeGameObjects.Add(gameObject);
      return gameObject;
    }

    public static void Despawn(GameObject gameObject)
    {
      foreach (Component component in 
                new HashSet<Component>((IEnumerable<Component>) gameObject.components))
        gameObject.RemoveComponent(component);
      gameObject.components.Clear();
      Action onDespawn = gameObject.OnDespawn;
      if (onDespawn != null)
        onDespawn();
      gameObject.OnDespawn = (Action) null;
      gameObject.OnActivate = (Action) null;
      gameObject.OnDeactivate = (Action) null;
      gameObject.OnAddComponent = (Action<Component>) null;
      gameObject.OnRemoveComponent = (Action<Component>) null;
      for (int index = 0; index < gameObject.children.Count; ++index)
        GameObject.Despawn(gameObject.children[index]);
      gameObject.children.Clear();
      GameObject.activeGameObjects.Remove(gameObject);
    }

    public static GameObject Find(Predicate<GameObject> match)
    {
      for (int index = 0; index < GameObject.activeGameObjects.Count; ++index)
      {
        if (match(GameObject.activeGameObjects[index]))
          return GameObject.activeGameObjects[index];
      }
      return (GameObject) null;
    }

    public static T Find<T>(Predicate<GameObject> match) where T : Component
    {
      for (int index = 0; index < GameObject.activeGameObjects.Count; ++index)
      {
        T component;
        if (match(GameObject.activeGameObjects[index])
                    && GameObject.activeGameObjects[index].TryGetComponent<T>(out component))
          return component;
      }
      return default (T);
    }

    public static List<GameObject> FindAll(Predicate<GameObject> match)
    {
      List<GameObject> all = new List<GameObject>();
      for (int index = 0; index < GameObject.activeGameObjects.Count; ++index)
      {
        if (match(GameObject.activeGameObjects[index]))
          all.Add(GameObject.activeGameObjects[index]);
      }
      return all;
    }

    public void SetActive(bool state)
    {
      foreach (GameObject child in this.children)
        child.SetActive(state);
      if (state && !this.IsActive)
      {
        Action onActivate = this.OnActivate;
        if (onActivate != null)
          onActivate();
      }
      else if (!state && this.IsActive)
      {
        Action onDeactivate = this.OnDeactivate;
        if (onDeactivate != null)
          onDeactivate();
      }
      this.IsActive = state;
    }

    public void SetParent(GameObject newParent)
    {
      if (this.parent != null)
        this.parent.children.Remove(this);
      if (newParent != null)
        newParent.children.Add(this);
      else if (this.parent != null)
        this.Transform.Position = this.parent.Transform.ToWorldPosition(this.Transform.LocalPosition);
      this.parent = newParent;
    }

    public void SetChildren(params GameObject[] gameObjects)
    {
      for (int index = 0; index < gameObjects.Length; ++index)
        gameObjects[index].SetParent(this);
    }

    public GameObject GetChild(int index)
    {
      return index < 0 || index >= this.children.Count ? (GameObject) null : this.children[index];
    }

    public GameObject FindChild(Predicate<GameObject> match) => this.children.Find(match);

    public bool CompareTag(string tag) => this.Tag.ToLower() == tag.ToLower();

    public bool CompareLayer(Enum layer) => this.Layer != null && this.Layer.HasFlag(layer);

    public void Reset()
    {
      foreach (Component component in this.components)
        component.Reset();
      foreach (GameObject child in this.children)
        child.Reset();
    }

    public T AddComponent<T>() where T : Component, new()
    {
      T obj = new T();
      obj.Initialize(this, GameObject.nextComponentIndex++);
      this.components.Add((Component) obj);
      Action<Component> onAddComponent = this.OnAddComponent;
      if (onAddComponent != null)
        onAddComponent((Component) obj);
      return obj;
    }

    public T GetComponent<T>() where T : class
    {
      Component component = this.components.FirstOrDefault<Component>((Func<Component, bool>) (x => x is T));
      return component != null ? component as T : default (T);
    }

    public T GetComponent<T>(Predicate<T> match) where T : class
    {
      Component component = this.components.FirstOrDefault<Component>((Func<Component, bool>) (x => x is T obj && match(obj)));
      return component != null ? component as T : default (T);
    }

    public bool TryGetComponent<T>(out T component) where T : class
    {
      Component component1 = this.components.FirstOrDefault<Component>((Func<Component, bool>) (x => x is T));
      if (component1 != null)
      {
        component = component1 as T;
        return true;
      }
      component = default (T);
      return false;
    }

    public bool TryGetComponent<T>(out T component, Predicate<T> match) where T : class
    {
      Component component1 = this.components.FirstOrDefault<Component>((Func<Component, bool>) (x => x is T obj && match(obj)));
      if (component1 != null)
      {
        component = component1 as T;
        return true;
      }
      component = default (T);
      return false;
    }

    public List<Component> GetComponents() => this.components.ToList<Component>();

    public List<Component> GetComponents(Predicate<Component> match)
    {
      return this.components.Where<Component>((Func<Component, bool>) (x => match(x))).ToList<Component>();
    }

    public List<T> GetComponents<T>() where T : class => this.components.OfType<T>().ToList<T>();

    public List<T> GetComponents<T>(Predicate<T> match) where T : class
    {
      return this.components.OfType<T>().Where<T>((Func<T, bool>) (x => match(x))).ToList<T>();
    }

    public bool HasComponent<T>() where T : class
    {
      return this.components.Any<Component>((Func<Component, bool>) (x => x is T));
    }

    public void RemoveComponent(Component component)
    {
      if (this.components.Contains(component))
        this.components.Remove(component);
      Action<Component> onRemoveComponent = this.OnRemoveComponent;
      if (onRemoveComponent == null)
        return;
      onRemoveComponent(component);
    }

    public void RemoveComponent<T>() where T : class, new()
    {
      Component component = this.components.FirstOrDefault<Component>((Func<Component, bool>) (x => x is T));
      if (component == null)
        return;
      this.components.Remove(component);
      Action<Component> onRemoveComponent = this.OnRemoveComponent;
      if (onRemoveComponent == null)
        return;
      onRemoveComponent(component);
    }

    public void RemoveComponent<T>(Predicate<T> match) where T : class, new()
    {
      Component component = this.components.FirstOrDefault<Component>((Func<Component, bool>) (x => x is T obj && match(obj)));
      if (component == null)
        return;
      this.components.Remove(component);
      Action<Component> onRemoveComponent = this.OnRemoveComponent;
      if (onRemoveComponent == null)
        return;
      onRemoveComponent(component);
    }

    public static void DrawUI()
    {
      if (!GameObject.debug)
        return;
      if (!ImGui.Begin("GameObjects", ref GameObject.debug))
      {
        ImGui.End();
      }
      else
      {
        ImGui.Value("Active GameObject", GameObject.ActiveCount);
        ImGui.Separator();
        ImGui.BeginGroup();
        List<int> intList = new List<int>();
        foreach (GameObject gameObject in GameObject.activeGameObjects.Where<GameObject>((Func<GameObject, bool>) (x => x.parent == null)))
        {
          DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
          interpolatedStringHandler.AppendFormatted<int>(gameObject.Index);
          interpolatedStringHandler.AppendLiteral(" ");
          interpolatedStringHandler.AppendFormatted(gameObject.Tag);
          if (ImGui.TreeNode(interpolatedStringHandler.ToStringAndClear()))
          {
            GameObject.DisplayObjectInfo(gameObject);
            GameObject.AddChildrenRecursively(gameObject);
            ImGui.TreePop();
          }
        }
        ImGui.EndGroup();
        ImGui.End();
      }
    }

    private static void AddChildrenRecursively(GameObject gameObject)
    {
      foreach (GameObject child in gameObject.children)
      {
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
        interpolatedStringHandler.AppendFormatted<int>(child.Index);
        interpolatedStringHandler.AppendLiteral(" ");
        interpolatedStringHandler.AppendFormatted(child.Tag);
        if (ImGui.TreeNode(interpolatedStringHandler.ToStringAndClear()))
        {
          GameObject.DisplayObjectInfo(child);
          GameObject.AddChildrenRecursively(child);
          ImGui.TreePop();
        }
      }
    }

    private static void DisplayObjectInfo(GameObject gameObject)
    {
      if (gameObject.children.Count > 0)
      {
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(13, 1);
        interpolatedStringHandler.AppendLiteral("Has ");
        interpolatedStringHandler.AppendFormatted<int>(gameObject.children.Count);
        interpolatedStringHandler.AppendLiteral(" children");
        ImGui.Text(interpolatedStringHandler.ToStringAndClear());
      }
      System.Numerics.Vector2 v = new System.Numerics.Vector2(gameObject.Transform.LocalPosition.X, gameObject.Transform.LocalPosition.Y);
      float localRotation = gameObject.Transform.LocalRotation;
      ImGui.DragFloat2("Position", ref v, 0.1f, float.MinValue, float.MaxValue, (string) null);
      ImGui.DragFloat("Rotation", ref localRotation);
      gameObject.Transform.Position = new Microsoft.Xna.Framework.Vector2(v.X, v.Y);
      gameObject.Transform.Rotation = localRotation;
      if (gameObject.components.Count <= 0)
        return;
      ImGui.PushStyleColor(ImGuiCol.Text, new System.Numerics.Vector4(0.75f, 0.466f, 0.142f, 1f));
      int num = ImGui.TreeNode("Components") ? 1 : 0;
      ImGui.PopStyleColor();
      if (num == 0)
        return;
      foreach (object component in gameObject.GetComponents())
        ImGui.Text(component.GetType().ToString());
      ImGui.TreePop();
    }

    public static void MenuItem()
    {
        ImGui.MenuItem("GameObjects", "", ref GameObject.debug);
    }
  }
}
