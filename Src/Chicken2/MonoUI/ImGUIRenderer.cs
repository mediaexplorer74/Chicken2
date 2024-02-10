// MGUI.MonoUI.ImGuiRenderer

using ImGuiNET;
using JuicyChicken;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable enable
namespace MGUI.MonoUI
{
  public class ImGuiRenderer
  {
    private 
    #nullable disable
    Game _game;
    private GraphicsDevice _graphicsDevice;
    private BasicEffect _effect;
    private RasterizerState _rasterizerState;
    private byte[] _vertexData;
    private VertexBuffer _vertexBuffer;
    private int _vertexBufferSize;
    private byte[] _indexData;
    private IndexBuffer _indexBuffer;
    private int _indexBufferSize;
    private Dictionary<IntPtr, Texture2D> _loadedTextures;
    private int _textureId = 1;
    private IntPtr? _fontTextureId;
    private int _scrollWheelValue;
    private List<int> _keys = new List<int>();

    public ImGuiRenderer(Game game, string customFontPath = "")
    {
      ImGui.SetCurrentContext(ImGui.CreateContext());
      this._game = game ?? throw new ArgumentNullException(nameof (game));
      this._graphicsDevice = game.GraphicsDevice;
      this._loadedTextures = new Dictionary<IntPtr, Texture2D>();
      this._rasterizerState = new RasterizerState()
      {
        CullMode = CullMode.None,
        DepthBias = 0.0f,
        FillMode = FillMode.Solid,
        MultiSampleAntiAlias = false,
        ScissorTestEnable = true,
        SlopeScaleDepthBias = 0.0f
      };
      this.SetupInput(customFontPath);
    }

    public virtual unsafe void RebuildFontAtlas()
    {
      ImGuiIOPtr io = ImGui.GetIO();
      byte* out_pixels;
      int out_width;
      int out_height;
      int out_bytes_per_pixel;
      io.Fonts.GetTexDataAsRGBA32(out out_pixels, out out_width, out out_height, out out_bytes_per_pixel);
      byte[] numArray = new byte[out_width * out_height * out_bytes_per_pixel];
      Marshal.Copy(new IntPtr((void*) out_pixels), numArray, 0, numArray.Length);
      Texture2D texture = new Texture2D(this._graphicsDevice, out_width, out_height, false, SurfaceFormat.Color);
      texture.SetData<byte>(numArray);
      if (this._fontTextureId.HasValue)
        this.UnbindTexture(this._fontTextureId.Value);
      this._fontTextureId = new IntPtr?(this.BindTexture(texture));
      io.Fonts.SetTexID(this._fontTextureId.Value);
      io.Fonts.ClearTexData();
    }

    public virtual IntPtr BindTexture(Texture2D texture)
    {
      IntPtr key = new IntPtr(this._textureId++);
      this._loadedTextures.Add(key, texture);
      return key;
    }

    public void RenderBuffer(Texture2D texture)
    {
      IntPtr key = new IntPtr(0);
      if (!this._loadedTextures.TryGetValue(key, out Texture2D _))
        this._loadedTextures.Add(key, texture);
      else
        this._loadedTextures[key] = texture;
    }

    public virtual void UnbindTexture(IntPtr textureId) => this._loadedTextures.Remove(textureId);

    public virtual void BeforeLayout()
    {
      ImGui.GetIO().DeltaTime = Time.UnscaledDeltaTime;
      this.UpdateInput();
      ImGui.NewFrame();
    }

    public virtual void AfterLayout()
    {
      ImGui.Render();
      this.RenderDrawData(ImGui.GetDrawData());
    }

    protected virtual void SetupInput(string customFontPath)
    {
      ImGuiIOPtr io = ImGui.GetIO();
      this._keys.Add(io.KeyMap[512] = 9);
      this._keys.Add(io.KeyMap[513] = 37);
      this._keys.Add(io.KeyMap[514] = 39);
      this._keys.Add(io.KeyMap[515] = 38);
      this._keys.Add(io.KeyMap[516] = 40);
      this._keys.Add(io.KeyMap[517] = 33);
      this._keys.Add(io.KeyMap[518] = 34);
      this._keys.Add(io.KeyMap[519] = 36);
      this._keys.Add(io.KeyMap[520] = 35);
      this._keys.Add(io.KeyMap[522] = 46);
      this._keys.Add(io.KeyMap[523] = 8);
      this._keys.Add(io.KeyMap[525] = 13);
      this._keys.Add(io.KeyMap[526] = 27);
      this._keys.Add(io.KeyMap[524] = 32);
      this._keys.Add(io.KeyMap[546] = 65);
      this._keys.Add(io.KeyMap[548] = 67);
      this._keys.Add(io.KeyMap[567] = 86);
      this._keys.Add(io.KeyMap[569] = 88);
      this._keys.Add(io.KeyMap[570] = 89);
      this._keys.Add(io.KeyMap[571] = 90);
      this._game.Window.TextInput += (EventHandler<TextInputEventArgs>) ((s, a) =>
      {
        if (a.Character == '\t')
          return;
        io.AddInputCharacter((uint) a.Character);
      });
      if (customFontPath != "")
        ImGui.GetIO().Fonts.AddFontFromFileTTF(customFontPath, 16f);
      else
        ImGui.GetIO().Fonts.AddFontDefault();
    }

    protected virtual Effect UpdateEffect(Texture2D texture)
    {
      this._effect = this._effect ?? new BasicEffect(this._graphicsDevice);
      ImGuiIOPtr io = ImGui.GetIO();
      this._effect.World = Matrix.Identity;
      this._effect.View = Matrix.Identity;
      this._effect.Projection = Matrix.CreateOrthographicOffCenter(0.0f, io.DisplaySize.X, io.DisplaySize.Y, 0.0f, -1f, 1f);
      this._effect.TextureEnabled = true;
      this._effect.Texture = texture;
      this._effect.VertexColorEnabled = true;
      this._effect.GraphicsDevice.SamplerStates[0] = new SamplerState()
      {
        Filter = TextureFilter.Point
      };
      return (Effect) this._effect;
    }

    protected virtual void UpdateInput()
    {
      ImGuiIOPtr io = ImGui.GetIO();
      MouseState state1 = Mouse.GetState();
      KeyboardState state2 = Keyboard.GetState();
      RangeAccessor<bool> rangeAccessor;
      for (int index = 0; index < this._keys.Count; ++index)
      {
        rangeAccessor = io.KeysDown;
        rangeAccessor[this._keys[index]] = state2.IsKeyDown((Keys) this._keys[index]);
      }
      io.KeyShift = state2.IsKeyDown(Keys.LeftShift) || state2.IsKeyDown(Keys.RightShift);
      io.KeyCtrl = state2.IsKeyDown(Keys.LeftControl) || state2.IsKeyDown(Keys.RightControl);
      io.KeyAlt = state2.IsKeyDown(Keys.LeftAlt) || state2.IsKeyDown(Keys.RightAlt);
      io.KeySuper = state2.IsKeyDown(Keys.LeftWindows) || state2.IsKeyDown(Keys.RightWindows);
      io.DisplaySize = new System.Numerics.Vector2((float) this._graphicsDevice.PresentationParameters.BackBufferWidth, (float) this._graphicsDevice.PresentationParameters.BackBufferHeight);
      io.DisplayFramebufferScale = new System.Numerics.Vector2(1f, 1f);
      io.MousePos = new System.Numerics.Vector2((float) state1.X, (float) state1.Y);
      rangeAccessor = io.MouseDown;
      rangeAccessor[0] = state1.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed;
      rangeAccessor = io.MouseDown;
      rangeAccessor[1] = state1.RightButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed;
      rangeAccessor = io.MouseDown;
      rangeAccessor[2] = state1.MiddleButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed;
      int num = state1.ScrollWheelValue - this._scrollWheelValue;
      io.MouseWheel = num > 0 ? 1f : (num < 0 ? -1f : 0.0f);
      this._scrollWheelValue = state1.ScrollWheelValue;
    }

    private void RenderDrawData(ImDrawDataPtr drawData)
    {
      Viewport viewport = this._graphicsDevice.Viewport;
      Rectangle scissorRectangle = this._graphicsDevice.ScissorRectangle;
      this._graphicsDevice.BlendFactor = Color.White;
      this._graphicsDevice.BlendState = BlendState.NonPremultiplied;
      this._graphicsDevice.RasterizerState = this._rasterizerState;
      this._graphicsDevice.DepthStencilState = DepthStencilState.DepthRead;
      drawData.ScaleClipRects(ImGui.GetIO().DisplayFramebufferScale);
      this._graphicsDevice.Viewport = new Viewport(0, 0, this._graphicsDevice.PresentationParameters.BackBufferWidth, this._graphicsDevice.PresentationParameters.BackBufferHeight);
      this.UpdateBuffers(drawData);
      this.RenderCommandLists(drawData);
      this._graphicsDevice.Viewport = viewport;
      this._graphicsDevice.ScissorRectangle = scissorRectangle;
    }

    private unsafe void UpdateBuffers(ImDrawDataPtr drawData)
    {
      if (drawData.TotalVtxCount == 0)
        return;
      if (drawData.TotalVtxCount > this._vertexBufferSize)
      {
        this._vertexBuffer?.Dispose();
        this._vertexBufferSize = (int) ((double) drawData.TotalVtxCount * 1.5);
        this._vertexBuffer = new VertexBuffer(this._graphicsDevice, DrawVertDeclaration.Declaration, this._vertexBufferSize, BufferUsage.None);
        this._vertexData = new byte[this._vertexBufferSize * DrawVertDeclaration.Size];
      }
      if (drawData.TotalIdxCount > this._indexBufferSize)
      {
        this._indexBuffer?.Dispose();
        this._indexBufferSize = (int) ((double) drawData.TotalIdxCount * 1.5);
        this._indexBuffer = new IndexBuffer(this._graphicsDevice, IndexElementSize.SixteenBits, this._indexBufferSize, BufferUsage.None);
        this._indexData = new byte[this._indexBufferSize * 2];
      }
      int num1 = 0;
      int num2 = 0;
      for (int index = 0; index < drawData.CmdListsCount; ++index)
      {
        ImDrawListPtr imDrawListPtr = drawData.CmdListsRange[index];
        fixed (byte* destination1 = &this._vertexData[num1 * DrawVertDeclaration.Size])
          fixed (byte* destination2 = &this._indexData[num2 * 2])
          {
            Buffer.MemoryCopy((void*) imDrawListPtr.VtxBuffer.Data, (void*) destination1, (long) this._vertexData.Length, (long) (imDrawListPtr.VtxBuffer.Size * DrawVertDeclaration.Size));
            Buffer.MemoryCopy((void*) imDrawListPtr.IdxBuffer.Data, (void*) destination2, (long) this._indexData.Length, (long) (imDrawListPtr.IdxBuffer.Size * 2));
          }
        num1 += imDrawListPtr.VtxBuffer.Size;
        num2 += imDrawListPtr.IdxBuffer.Size;
      }
      this._vertexBuffer.SetData<byte>(this._vertexData, 0, drawData.TotalVtxCount * DrawVertDeclaration.Size);
      this._indexBuffer.SetData<byte>(this._indexData, 0, drawData.TotalIdxCount * 2);
    }

    private void RenderCommandLists(ImDrawDataPtr drawData)
    {
      this._graphicsDevice.SetVertexBuffer(this._vertexBuffer);
      this._graphicsDevice.Indices = this._indexBuffer;
      int num1 = 0;
      int num2 = 0;
      for (int index1 = 0; index1 < drawData.CmdListsCount; ++index1)
      {
        ImDrawListPtr imDrawListPtr = drawData.CmdListsRange[index1];
        for (int index2 = 0; index2 < imDrawListPtr.CmdBuffer.Size; ++index2)
        {
          ImDrawCmdPtr imDrawCmdPtr = imDrawListPtr.CmdBuffer[index2];
          if (imDrawCmdPtr.ElemCount != 0U)
          {
            if (!this._loadedTextures.ContainsKey(imDrawCmdPtr.TextureId))
            {
              DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(63, 1);
              interpolatedStringHandler.AppendLiteral("Could not find a texture with id '");
              interpolatedStringHandler.AppendFormatted<IntPtr>(imDrawCmdPtr.TextureId);
              interpolatedStringHandler.AppendLiteral("', please check your bindings");
              Debug.Log<string>(interpolatedStringHandler.ToStringAndClear());
              return;
            }
            this._graphicsDevice.ScissorRectangle = new Rectangle((int) imDrawCmdPtr.ClipRect.X, (int) imDrawCmdPtr.ClipRect.Y, (int) ((double) imDrawCmdPtr.ClipRect.Z - (double) imDrawCmdPtr.ClipRect.X), (int) ((double) imDrawCmdPtr.ClipRect.W - (double) imDrawCmdPtr.ClipRect.Y));
            foreach (EffectPass pass in this.UpdateEffect(this._loadedTextures[imDrawCmdPtr.TextureId]).CurrentTechnique.Passes)
            {
              pass.Apply();
              this._graphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, (int) imDrawCmdPtr.VtxOffset + num1, 0, imDrawListPtr.VtxBuffer.Size, (int) imDrawCmdPtr.IdxOffset + num2, (int) imDrawCmdPtr.ElemCount / 3);
            }
          }
        }
        num1 += imDrawListPtr.VtxBuffer.Size;
        num2 += imDrawListPtr.IdxBuffer.Size;
      }
    }
  }
}
