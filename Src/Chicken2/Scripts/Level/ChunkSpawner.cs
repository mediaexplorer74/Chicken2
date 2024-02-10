// Decompiled with JetBrains decompiler
// Type: ChickenRemake.ChunkSpawner
// Assembly: Chicken2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A3CF9AB0-735E-4893-A3F9-5337EA664FC9
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Chicken2.dll

using JuicyChicken;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

#nullable disable
namespace ChickenRemake
{
  public class ChunkSpawner : Component
  {
    private List<Func<CreateChunk>> chunkBlueprints = new List<Func<CreateChunk>>();
    private Queue<GameObject> chunks = new Queue<GameObject>();
    private GameObject leaderChunk;
    private GameObject previousChunk;
    private const float StartOffset = -150f;
    private const int ChunkAmount = 6;
    private const float DespawnDistance = -300f;

    public bool AllowDecoration { get; set; } = true;

    public void Begin()
    {
      this.SpawnStartChunk();
      for (int index = 1; index < 6; ++index)
        this.AppendChunk(false);
    }

    private void UpdateLeader()
    {
      GameObject leaderChunk = this.leaderChunk;
      this.leaderChunk = this.chunks.Dequeue();
      this.leaderChunk.SetParent((GameObject) null);
      this.leaderChunk.SetParent(Level.Instance.Owner);
      if (leaderChunk == null)
        return;
      GameObject.Despawn(leaderChunk);
    }

    private void SpawnStartChunk()
    {
      GameObject gameObject = Blueprint.Spawn<CreateGrassPowerupChunk>().GameObject;
      gameObject.Transform.Position = new Vector2(-150f, 0.0f);
      gameObject.SetParent(Level.Instance.Owner);
      Debug.Log<Vector2>(gameObject.Transform.Position);
      this.leaderChunk = gameObject;
      this.previousChunk = gameObject;
    }

    private void AppendChunk(bool decorate)
    {
      CreateChunk createChunk = this.chunkBlueprints[Randomizer.Next(0, this.chunkBlueprints.Count)]();
      GameObject gameObject = createChunk.GameObject;
      ChunkData data = ChunkReader.GetData(this.previousChunk.GetComponent<Sprite>().Texture, 16, 16);
      List<TileData> column1 = data.GetColumn(data.Width - 1);
      TileData tileData1 = column1[0];
      foreach (TileData tileData2 in column1)
      {
        if (!tileData2.IsEmpty(0.95f))
        {
          tileData1 = tileData2;
          break;
        }
      }
      List<TileData> column2 = createChunk.GetChunkData().GetColumn(0);
      TileData tileData3 = column2[0];
      foreach (TileData tileData4 in column2)
      {
        if (!tileData4.IsEmpty(0.95f))
        {
          tileData3 = tileData4;
          break;
        }
      }
      float y = (float) (16 * (tileData1.Y - tileData3.Y));
      gameObject.Transform.Position = new Vector2((float) this.previousChunk.GetComponent<Sprite>().Texture.Width, y);
      gameObject.SetParent(this.previousChunk);
      this.chunks.Enqueue(gameObject);
      if (decorate)
        createChunk.Decorate();
      this.previousChunk = gameObject;
    }

    public void AddBlueprint<T>() where T : CreateChunk, new()
    {
      this.chunkBlueprints.Add((Func<CreateChunk>) (() => (CreateChunk) Blueprint.Spawn<T>()));
    }

    protected override void Update()
    {
      this.leaderChunk.Transform.Translate(-Vector2.UnitX * Level.Instance.Speed * Time.DeltaTime);
      if ((double) this.leaderChunk.Transform.Position.X > -300.0 - (double) this.leaderChunk.GetComponent<Sprite>().Texture.Width)
        return;
      this.UpdateLeader();
      this.AppendChunk(this.AllowDecoration);
    }

    public override void Reset()
    {
    }
  }
}
