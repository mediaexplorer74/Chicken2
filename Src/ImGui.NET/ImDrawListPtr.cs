// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImDrawListPtr
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

#nullable disable
namespace ImGuiNET
{
  public struct ImDrawListPtr
  {
    public unsafe ImDrawList* NativePtr { get; }

    public unsafe ImDrawListPtr(ImDrawList* nativePtr) => this.NativePtr = nativePtr;

    public unsafe ImDrawListPtr(IntPtr nativePtr)
    {
      this.NativePtr = (ImDrawList*) (void*) nativePtr;
    }

    public static unsafe implicit operator ImDrawListPtr(ImDrawList* nativePtr)
    {
      return new ImDrawListPtr(nativePtr);
    }

    public static unsafe implicit operator ImDrawList*(ImDrawListPtr wrappedPtr)
    {
      return wrappedPtr.NativePtr;
    }

    public static implicit operator ImDrawListPtr(IntPtr nativePtr) => new ImDrawListPtr(nativePtr);

    public unsafe ImPtrVector<ImDrawCmdPtr> CmdBuffer
    {
      get => new ImPtrVector<ImDrawCmdPtr>(this.NativePtr->CmdBuffer, Unsafe.SizeOf<ImDrawCmd>());
    }

    public unsafe ImVector<ushort> IdxBuffer => new ImVector<ushort>(this.NativePtr->IdxBuffer);

    public unsafe ImPtrVector<ImDrawVertPtr> VtxBuffer
    {
      get => new ImPtrVector<ImDrawVertPtr>(this.NativePtr->VtxBuffer, Unsafe.SizeOf<ImDrawVert>());
    }

    public unsafe ref ImDrawListFlags Flags
    {
      get => ref Unsafe.AsRef<ImDrawListFlags>((void*) &this.NativePtr->Flags);
    }

    public unsafe ref uint _VtxCurrentIdx
    {
      get => ref Unsafe.AsRef<uint>((void*) &this.NativePtr->_VtxCurrentIdx);
    }

    public unsafe ref IntPtr _Data => ref Unsafe.AsRef<IntPtr>((void*) &this.NativePtr->_Data);

    public unsafe NullTerminatedString _OwnerName
    {
      get => new NullTerminatedString(this.NativePtr->_OwnerName);
    }

    public unsafe ImDrawVertPtr _VtxWritePtr => new ImDrawVertPtr(this.NativePtr->_VtxWritePtr);

    public unsafe IntPtr _IdxWritePtr
    {
      get => (IntPtr) (void*) this.NativePtr->_IdxWritePtr;
      set => this.NativePtr->_IdxWritePtr = (ushort*) (void*) value;
    }

    public unsafe ImVector<Vector4> _ClipRectStack
    {
      get => new ImVector<Vector4>(this.NativePtr->_ClipRectStack);
    }

    public unsafe ImVector<IntPtr> _TextureIdStack
    {
      get => new ImVector<IntPtr>(this.NativePtr->_TextureIdStack);
    }

    public unsafe ImVector<Vector2> _Path => new ImVector<Vector2>(this.NativePtr->_Path);

    public unsafe ref ImDrawCmdHeader _CmdHeader
    {
      get => ref Unsafe.AsRef<ImDrawCmdHeader>((void*) &this.NativePtr->_CmdHeader);
    }

    public unsafe ref ImDrawListSplitter _Splitter
    {
      get => ref Unsafe.AsRef<ImDrawListSplitter>((void*) &this.NativePtr->_Splitter);
    }

    public unsafe ref float _FringeScale
    {
      get => ref Unsafe.AsRef<float>((void*) &this.NativePtr->_FringeScale);
    }

    public unsafe int _CalcCircleAutoSegmentCount(float radius)
    {
      return ImGuiNative.ImDrawList__CalcCircleAutoSegmentCount(this.NativePtr, radius);
    }

    public unsafe void _ClearFreeMemory()
    {
      ImGuiNative.ImDrawList__ClearFreeMemory(this.NativePtr);
    }

    public unsafe void _OnChangedClipRect()
    {
      ImGuiNative.ImDrawList__OnChangedClipRect(this.NativePtr);
    }

    public unsafe void _OnChangedTextureID()
    {
      ImGuiNative.ImDrawList__OnChangedTextureID(this.NativePtr);
    }

    public unsafe void _OnChangedVtxOffset()
    {
      ImGuiNative.ImDrawList__OnChangedVtxOffset(this.NativePtr);
    }

    public unsafe void _PathArcToFastEx(
      Vector2 center,
      float radius,
      int a_min_sample,
      int a_max_sample,
      int a_step)
    {
      ImGuiNative.ImDrawList__PathArcToFastEx(this.NativePtr, center, radius, a_min_sample, a_max_sample, a_step);
    }

    public unsafe void _PathArcToN(
      Vector2 center,
      float radius,
      float a_min,
      float a_max,
      int num_segments)
    {
      ImGuiNative.ImDrawList__PathArcToN(this.NativePtr, center, radius, a_min, a_max, num_segments);
    }

    public unsafe void _PopUnusedDrawCmd()
    {
      ImGuiNative.ImDrawList__PopUnusedDrawCmd(this.NativePtr);
    }

    public unsafe void _ResetForNewFrame()
    {
      ImGuiNative.ImDrawList__ResetForNewFrame(this.NativePtr);
    }

    public unsafe void _TryMergeDrawCmds()
    {
      ImGuiNative.ImDrawList__TryMergeDrawCmds(this.NativePtr);
    }

    public unsafe void AddBezierCubic(
      Vector2 p1,
      Vector2 p2,
      Vector2 p3,
      Vector2 p4,
      uint col,
      float thickness)
    {
      int num_segments = 0;
      ImGuiNative.ImDrawList_AddBezierCubic(this.NativePtr, p1, p2, p3, p4, col, thickness, num_segments);
    }

    public unsafe void AddBezierCubic(
      Vector2 p1,
      Vector2 p2,
      Vector2 p3,
      Vector2 p4,
      uint col,
      float thickness,
      int num_segments)
    {
      ImGuiNative.ImDrawList_AddBezierCubic(this.NativePtr, p1, p2, p3, p4, col, thickness, num_segments);
    }

    public unsafe void AddBezierQuadratic(
      Vector2 p1,
      Vector2 p2,
      Vector2 p3,
      uint col,
      float thickness)
    {
      int num_segments = 0;
      ImGuiNative.ImDrawList_AddBezierQuadratic(this.NativePtr, p1, p2, p3, col, thickness, num_segments);
    }

    public unsafe void AddBezierQuadratic(
      Vector2 p1,
      Vector2 p2,
      Vector2 p3,
      uint col,
      float thickness,
      int num_segments)
    {
      ImGuiNative.ImDrawList_AddBezierQuadratic(this.NativePtr, p1, p2, p3, col, thickness, num_segments);
    }

    public unsafe void AddCallback(IntPtr callback, IntPtr callback_data)
    {
      void* pointer = callback_data.ToPointer();
      ImGuiNative.ImDrawList_AddCallback(this.NativePtr, callback, pointer);
    }

    public unsafe void AddCircle(Vector2 center, float radius, uint col)
    {
      int num_segments = 0;
      float thickness = 1f;
      ImGuiNative.ImDrawList_AddCircle(this.NativePtr, center, radius, col, num_segments, thickness);
    }

    public unsafe void AddCircle(Vector2 center, float radius, uint col, int num_segments)
    {
      float thickness = 1f;
      ImGuiNative.ImDrawList_AddCircle(this.NativePtr, center, radius, col, num_segments, thickness);
    }

    public unsafe void AddCircle(
      Vector2 center,
      float radius,
      uint col,
      int num_segments,
      float thickness)
    {
      ImGuiNative.ImDrawList_AddCircle(this.NativePtr, center, radius, col, num_segments, thickness);
    }

    public unsafe void AddCircleFilled(Vector2 center, float radius, uint col)
    {
      int num_segments = 0;
      ImGuiNative.ImDrawList_AddCircleFilled(this.NativePtr, center, radius, col, num_segments);
    }

    public unsafe void AddCircleFilled(Vector2 center, float radius, uint col, int num_segments)
    {
      ImGuiNative.ImDrawList_AddCircleFilled(this.NativePtr, center, radius, col, num_segments);
    }

    public unsafe void AddConvexPolyFilled(ref Vector2 points, int num_points, uint col)
    {
      fixed (Vector2* points1 = &points)
        ImGuiNative.ImDrawList_AddConvexPolyFilled(this.NativePtr, points1, num_points, col);
    }

    public unsafe void AddDrawCmd() => ImGuiNative.ImDrawList_AddDrawCmd(this.NativePtr);

    public unsafe void AddImage(IntPtr user_texture_id, Vector2 p_min, Vector2 p_max)
    {
      Vector2 uv_min = new Vector2();
      Vector2 uv_max = new Vector2(1f, 1f);
      uint maxValue = uint.MaxValue;
      ImGuiNative.ImDrawList_AddImage(this.NativePtr, user_texture_id, p_min, p_max, uv_min, uv_max, maxValue);
    }

    public unsafe void AddImage(
      IntPtr user_texture_id,
      Vector2 p_min,
      Vector2 p_max,
      Vector2 uv_min)
    {
      Vector2 uv_max = new Vector2(1f, 1f);
      uint maxValue = uint.MaxValue;
      ImGuiNative.ImDrawList_AddImage(this.NativePtr, user_texture_id, p_min, p_max, uv_min, uv_max, maxValue);
    }

    public unsafe void AddImage(
      IntPtr user_texture_id,
      Vector2 p_min,
      Vector2 p_max,
      Vector2 uv_min,
      Vector2 uv_max)
    {
      uint maxValue = uint.MaxValue;
      ImGuiNative.ImDrawList_AddImage(this.NativePtr, user_texture_id, p_min, p_max, uv_min, uv_max, maxValue);
    }

    public unsafe void AddImage(
      IntPtr user_texture_id,
      Vector2 p_min,
      Vector2 p_max,
      Vector2 uv_min,
      Vector2 uv_max,
      uint col)
    {
      ImGuiNative.ImDrawList_AddImage(this.NativePtr, user_texture_id, p_min, p_max, uv_min, uv_max, col);
    }

    public unsafe void AddImageQuad(
      IntPtr user_texture_id,
      Vector2 p1,
      Vector2 p2,
      Vector2 p3,
      Vector2 p4)
    {
      Vector2 uv1 = new Vector2();
      Vector2 uv2 = new Vector2(1f, 0.0f);
      Vector2 uv3 = new Vector2(1f, 1f);
      Vector2 uv4 = new Vector2(0.0f, 1f);
      uint maxValue = uint.MaxValue;
      ImGuiNative.ImDrawList_AddImageQuad(this.NativePtr, user_texture_id, p1, p2, p3, p4, uv1, uv2, uv3, uv4, maxValue);
    }

    public unsafe void AddImageQuad(
      IntPtr user_texture_id,
      Vector2 p1,
      Vector2 p2,
      Vector2 p3,
      Vector2 p4,
      Vector2 uv1)
    {
      Vector2 uv2 = new Vector2(1f, 0.0f);
      Vector2 uv3 = new Vector2(1f, 1f);
      Vector2 uv4 = new Vector2(0.0f, 1f);
      uint maxValue = uint.MaxValue;
      ImGuiNative.ImDrawList_AddImageQuad(this.NativePtr, user_texture_id, p1, p2, p3, p4, uv1, uv2, uv3, uv4, maxValue);
    }

    public unsafe void AddImageQuad(
      IntPtr user_texture_id,
      Vector2 p1,
      Vector2 p2,
      Vector2 p3,
      Vector2 p4,
      Vector2 uv1,
      Vector2 uv2)
    {
      Vector2 uv3 = new Vector2(1f, 1f);
      Vector2 uv4 = new Vector2(0.0f, 1f);
      uint maxValue = uint.MaxValue;
      ImGuiNative.ImDrawList_AddImageQuad(this.NativePtr, user_texture_id, p1, p2, p3, p4, uv1, uv2, uv3, uv4, maxValue);
    }

    public unsafe void AddImageQuad(
      IntPtr user_texture_id,
      Vector2 p1,
      Vector2 p2,
      Vector2 p3,
      Vector2 p4,
      Vector2 uv1,
      Vector2 uv2,
      Vector2 uv3)
    {
      Vector2 uv4 = new Vector2(0.0f, 1f);
      uint maxValue = uint.MaxValue;
      ImGuiNative.ImDrawList_AddImageQuad(this.NativePtr, user_texture_id, p1, p2, p3, p4, uv1, uv2, uv3, uv4, maxValue);
    }

    public unsafe void AddImageQuad(
      IntPtr user_texture_id,
      Vector2 p1,
      Vector2 p2,
      Vector2 p3,
      Vector2 p4,
      Vector2 uv1,
      Vector2 uv2,
      Vector2 uv3,
      Vector2 uv4)
    {
      uint maxValue = uint.MaxValue;
      ImGuiNative.ImDrawList_AddImageQuad(this.NativePtr, user_texture_id, p1, p2, p3, p4, uv1, uv2, uv3, uv4, maxValue);
    }

    public unsafe void AddImageQuad(
      IntPtr user_texture_id,
      Vector2 p1,
      Vector2 p2,
      Vector2 p3,
      Vector2 p4,
      Vector2 uv1,
      Vector2 uv2,
      Vector2 uv3,
      Vector2 uv4,
      uint col)
    {
      ImGuiNative.ImDrawList_AddImageQuad(this.NativePtr, user_texture_id, p1, p2, p3, p4, uv1, uv2, uv3, uv4, col);
    }

    public unsafe void AddImageRounded(
      IntPtr user_texture_id,
      Vector2 p_min,
      Vector2 p_max,
      Vector2 uv_min,
      Vector2 uv_max,
      uint col,
      float rounding)
    {
      ImDrawFlags flags = ImDrawFlags.None;
      ImGuiNative.ImDrawList_AddImageRounded(this.NativePtr, user_texture_id, p_min, p_max, uv_min, uv_max, col, rounding, flags);
    }

    public unsafe void AddImageRounded(
      IntPtr user_texture_id,
      Vector2 p_min,
      Vector2 p_max,
      Vector2 uv_min,
      Vector2 uv_max,
      uint col,
      float rounding,
      ImDrawFlags flags)
    {
      ImGuiNative.ImDrawList_AddImageRounded(this.NativePtr, user_texture_id, p_min, p_max, uv_min, uv_max, col, rounding, flags);
    }

    public unsafe void AddLine(Vector2 p1, Vector2 p2, uint col)
    {
      float thickness = 1f;
      ImGuiNative.ImDrawList_AddLine(this.NativePtr, p1, p2, col, thickness);
    }

    public unsafe void AddLine(Vector2 p1, Vector2 p2, uint col, float thickness)
    {
      ImGuiNative.ImDrawList_AddLine(this.NativePtr, p1, p2, col, thickness);
    }

    public unsafe void AddNgon(Vector2 center, float radius, uint col, int num_segments)
    {
      float thickness = 1f;
      ImGuiNative.ImDrawList_AddNgon(this.NativePtr, center, radius, col, num_segments, thickness);
    }

    public unsafe void AddNgon(
      Vector2 center,
      float radius,
      uint col,
      int num_segments,
      float thickness)
    {
      ImGuiNative.ImDrawList_AddNgon(this.NativePtr, center, radius, col, num_segments, thickness);
    }

    public unsafe void AddNgonFilled(Vector2 center, float radius, uint col, int num_segments)
    {
      ImGuiNative.ImDrawList_AddNgonFilled(this.NativePtr, center, radius, col, num_segments);
    }

    public unsafe void AddPolyline(
      ref Vector2 points,
      int num_points,
      uint col,
      ImDrawFlags flags,
      float thickness)
    {
      fixed (Vector2* points1 = &points)
        ImGuiNative.ImDrawList_AddPolyline(this.NativePtr, points1, num_points, col, flags, thickness);
    }

    public unsafe void AddQuad(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, uint col)
    {
      float thickness = 1f;
      ImGuiNative.ImDrawList_AddQuad(this.NativePtr, p1, p2, p3, p4, col, thickness);
    }

    public unsafe void AddQuad(
      Vector2 p1,
      Vector2 p2,
      Vector2 p3,
      Vector2 p4,
      uint col,
      float thickness)
    {
      ImGuiNative.ImDrawList_AddQuad(this.NativePtr, p1, p2, p3, p4, col, thickness);
    }

    public unsafe void AddQuadFilled(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, uint col)
    {
      ImGuiNative.ImDrawList_AddQuadFilled(this.NativePtr, p1, p2, p3, p4, col);
    }

    public unsafe void AddRect(Vector2 p_min, Vector2 p_max, uint col)
    {
      float rounding = 0.0f;
      ImDrawFlags flags = ImDrawFlags.None;
      float thickness = 1f;
      ImGuiNative.ImDrawList_AddRect(this.NativePtr, p_min, p_max, col, rounding, flags, thickness);
    }

    public unsafe void AddRect(Vector2 p_min, Vector2 p_max, uint col, float rounding)
    {
      ImDrawFlags flags = ImDrawFlags.None;
      float thickness = 1f;
      ImGuiNative.ImDrawList_AddRect(this.NativePtr, p_min, p_max, col, rounding, flags, thickness);
    }

    public unsafe void AddRect(
      Vector2 p_min,
      Vector2 p_max,
      uint col,
      float rounding,
      ImDrawFlags flags)
    {
      float thickness = 1f;
      ImGuiNative.ImDrawList_AddRect(this.NativePtr, p_min, p_max, col, rounding, flags, thickness);
    }

    public unsafe void AddRect(
      Vector2 p_min,
      Vector2 p_max,
      uint col,
      float rounding,
      ImDrawFlags flags,
      float thickness)
    {
      ImGuiNative.ImDrawList_AddRect(this.NativePtr, p_min, p_max, col, rounding, flags, thickness);
    }

    public unsafe void AddRectFilled(Vector2 p_min, Vector2 p_max, uint col)
    {
      float rounding = 0.0f;
      ImDrawFlags flags = ImDrawFlags.None;
      ImGuiNative.ImDrawList_AddRectFilled(this.NativePtr, p_min, p_max, col, rounding, flags);
    }

    public unsafe void AddRectFilled(Vector2 p_min, Vector2 p_max, uint col, float rounding)
    {
      ImDrawFlags flags = ImDrawFlags.None;
      ImGuiNative.ImDrawList_AddRectFilled(this.NativePtr, p_min, p_max, col, rounding, flags);
    }

    public unsafe void AddRectFilled(
      Vector2 p_min,
      Vector2 p_max,
      uint col,
      float rounding,
      ImDrawFlags flags)
    {
      ImGuiNative.ImDrawList_AddRectFilled(this.NativePtr, p_min, p_max, col, rounding, flags);
    }

    public unsafe void AddRectFilledMultiColor(
      Vector2 p_min,
      Vector2 p_max,
      uint col_upr_left,
      uint col_upr_right,
      uint col_bot_right,
      uint col_bot_left)
    {
      ImGuiNative.ImDrawList_AddRectFilledMultiColor(this.NativePtr, p_min, p_max, col_upr_left, col_upr_right, col_bot_right, col_bot_left);
    }

    public unsafe void AddTriangle(Vector2 p1, Vector2 p2, Vector2 p3, uint col)
    {
      float thickness = 1f;
      ImGuiNative.ImDrawList_AddTriangle(this.NativePtr, p1, p2, p3, col, thickness);
    }

    public unsafe void AddTriangle(Vector2 p1, Vector2 p2, Vector2 p3, uint col, float thickness)
    {
      ImGuiNative.ImDrawList_AddTriangle(this.NativePtr, p1, p2, p3, col, thickness);
    }

    public unsafe void AddTriangleFilled(Vector2 p1, Vector2 p2, Vector2 p3, uint col)
    {
      ImGuiNative.ImDrawList_AddTriangleFilled(this.NativePtr, p1, p2, p3, col);
    }

    public unsafe void ChannelsMerge() => ImGuiNative.ImDrawList_ChannelsMerge(this.NativePtr);

    public unsafe void ChannelsSetCurrent(int n)
    {
      ImGuiNative.ImDrawList_ChannelsSetCurrent(this.NativePtr, n);
    }

    public unsafe void ChannelsSplit(int count)
    {
      ImGuiNative.ImDrawList_ChannelsSplit(this.NativePtr, count);
    }

    public unsafe ImDrawListPtr CloneOutput()
    {
      return new ImDrawListPtr(ImGuiNative.ImDrawList_CloneOutput(this.NativePtr));
    }

    public unsafe void Destroy() => ImGuiNative.ImDrawList_destroy(this.NativePtr);

    public unsafe Vector2 GetClipRectMax()
    {
      Vector2 clipRectMax;
      ImGuiNative.ImDrawList_GetClipRectMax(&clipRectMax, this.NativePtr);
      return clipRectMax;
    }

    public unsafe Vector2 GetClipRectMin()
    {
      Vector2 clipRectMin;
      ImGuiNative.ImDrawList_GetClipRectMin(&clipRectMin, this.NativePtr);
      return clipRectMin;
    }

    public unsafe void PathArcTo(Vector2 center, float radius, float a_min, float a_max)
    {
      int num_segments = 0;
      ImGuiNative.ImDrawList_PathArcTo(this.NativePtr, center, radius, a_min, a_max, num_segments);
    }

    public unsafe void PathArcTo(
      Vector2 center,
      float radius,
      float a_min,
      float a_max,
      int num_segments)
    {
      ImGuiNative.ImDrawList_PathArcTo(this.NativePtr, center, radius, a_min, a_max, num_segments);
    }

    public unsafe void PathArcToFast(
      Vector2 center,
      float radius,
      int a_min_of_12,
      int a_max_of_12)
    {
      ImGuiNative.ImDrawList_PathArcToFast(this.NativePtr, center, radius, a_min_of_12, a_max_of_12);
    }

    public unsafe void PathBezierCubicCurveTo(Vector2 p2, Vector2 p3, Vector2 p4)
    {
      int num_segments = 0;
      ImGuiNative.ImDrawList_PathBezierCubicCurveTo(this.NativePtr, p2, p3, p4, num_segments);
    }

    public unsafe void PathBezierCubicCurveTo(
      Vector2 p2,
      Vector2 p3,
      Vector2 p4,
      int num_segments)
    {
      ImGuiNative.ImDrawList_PathBezierCubicCurveTo(this.NativePtr, p2, p3, p4, num_segments);
    }

    public unsafe void PathBezierQuadraticCurveTo(Vector2 p2, Vector2 p3)
    {
      int num_segments = 0;
      ImGuiNative.ImDrawList_PathBezierQuadraticCurveTo(this.NativePtr, p2, p3, num_segments);
    }

    public unsafe void PathBezierQuadraticCurveTo(Vector2 p2, Vector2 p3, int num_segments)
    {
      ImGuiNative.ImDrawList_PathBezierQuadraticCurveTo(this.NativePtr, p2, p3, num_segments);
    }

    public unsafe void PathClear() => ImGuiNative.ImDrawList_PathClear(this.NativePtr);

    public unsafe void PathFillConvex(uint col)
    {
      ImGuiNative.ImDrawList_PathFillConvex(this.NativePtr, col);
    }

    public unsafe void PathLineTo(Vector2 pos)
    {
      ImGuiNative.ImDrawList_PathLineTo(this.NativePtr, pos);
    }

    public unsafe void PathLineToMergeDuplicate(Vector2 pos)
    {
      ImGuiNative.ImDrawList_PathLineToMergeDuplicate(this.NativePtr, pos);
    }

    public unsafe void PathRect(Vector2 rect_min, Vector2 rect_max)
    {
      float rounding = 0.0f;
      ImDrawFlags flags = ImDrawFlags.None;
      ImGuiNative.ImDrawList_PathRect(this.NativePtr, rect_min, rect_max, rounding, flags);
    }

    public unsafe void PathRect(Vector2 rect_min, Vector2 rect_max, float rounding)
    {
      ImDrawFlags flags = ImDrawFlags.None;
      ImGuiNative.ImDrawList_PathRect(this.NativePtr, rect_min, rect_max, rounding, flags);
    }

    public unsafe void PathRect(
      Vector2 rect_min,
      Vector2 rect_max,
      float rounding,
      ImDrawFlags flags)
    {
      ImGuiNative.ImDrawList_PathRect(this.NativePtr, rect_min, rect_max, rounding, flags);
    }

    public unsafe void PathStroke(uint col)
    {
      ImDrawFlags flags = ImDrawFlags.None;
      float thickness = 1f;
      ImGuiNative.ImDrawList_PathStroke(this.NativePtr, col, flags, thickness);
    }

    public unsafe void PathStroke(uint col, ImDrawFlags flags)
    {
      float thickness = 1f;
      ImGuiNative.ImDrawList_PathStroke(this.NativePtr, col, flags, thickness);
    }

    public unsafe void PathStroke(uint col, ImDrawFlags flags, float thickness)
    {
      ImGuiNative.ImDrawList_PathStroke(this.NativePtr, col, flags, thickness);
    }

    public unsafe void PopClipRect() => ImGuiNative.ImDrawList_PopClipRect(this.NativePtr);

    public unsafe void PopTextureID() => ImGuiNative.ImDrawList_PopTextureID(this.NativePtr);

    public unsafe void PrimQuadUV(
      Vector2 a,
      Vector2 b,
      Vector2 c,
      Vector2 d,
      Vector2 uv_a,
      Vector2 uv_b,
      Vector2 uv_c,
      Vector2 uv_d,
      uint col)
    {
      ImGuiNative.ImDrawList_PrimQuadUV(this.NativePtr, a, b, c, d, uv_a, uv_b, uv_c, uv_d, col);
    }

    public unsafe void PrimRect(Vector2 a, Vector2 b, uint col)
    {
      ImGuiNative.ImDrawList_PrimRect(this.NativePtr, a, b, col);
    }

    public unsafe void PrimRectUV(Vector2 a, Vector2 b, Vector2 uv_a, Vector2 uv_b, uint col)
    {
      ImGuiNative.ImDrawList_PrimRectUV(this.NativePtr, a, b, uv_a, uv_b, col);
    }

    public unsafe void PrimReserve(int idx_count, int vtx_count)
    {
      ImGuiNative.ImDrawList_PrimReserve(this.NativePtr, idx_count, vtx_count);
    }

    public unsafe void PrimUnreserve(int idx_count, int vtx_count)
    {
      ImGuiNative.ImDrawList_PrimUnreserve(this.NativePtr, idx_count, vtx_count);
    }

    public unsafe void PrimVtx(Vector2 pos, Vector2 uv, uint col)
    {
      ImGuiNative.ImDrawList_PrimVtx(this.NativePtr, pos, uv, col);
    }

    public unsafe void PrimWriteIdx(ushort idx)
    {
      ImGuiNative.ImDrawList_PrimWriteIdx(this.NativePtr, idx);
    }

    public unsafe void PrimWriteVtx(Vector2 pos, Vector2 uv, uint col)
    {
      ImGuiNative.ImDrawList_PrimWriteVtx(this.NativePtr, pos, uv, col);
    }

    public unsafe void PushClipRect(Vector2 clip_rect_min, Vector2 clip_rect_max)
    {
      byte intersect_with_current_clip_rect = 0;
      ImGuiNative.ImDrawList_PushClipRect(this.NativePtr, clip_rect_min, clip_rect_max, intersect_with_current_clip_rect);
    }

    public unsafe void PushClipRect(
      Vector2 clip_rect_min,
      Vector2 clip_rect_max,
      bool intersect_with_current_clip_rect)
    {
      byte intersect_with_current_clip_rect1 = intersect_with_current_clip_rect ? (byte) 1 : (byte) 0;
      ImGuiNative.ImDrawList_PushClipRect(this.NativePtr, clip_rect_min, clip_rect_max, intersect_with_current_clip_rect1);
    }

    public unsafe void PushClipRectFullScreen()
    {
      ImGuiNative.ImDrawList_PushClipRectFullScreen(this.NativePtr);
    }

    public unsafe void PushTextureID(IntPtr texture_id)
    {
      ImGuiNative.ImDrawList_PushTextureID(this.NativePtr, texture_id);
    }

    public unsafe void AddText(Vector2 pos, uint col, string text_begin)
    {
      int byteCount = Encoding.UTF8.GetByteCount(text_begin);
      byte* numPtr = stackalloc byte[byteCount + 1];
      IntPtr chars;
      if (text_begin == null)
      {
        chars = IntPtr.Zero;
      }
      else
      {
        fixed (char* chPtr = &text_begin.GetPinnableReference())
          chars = (IntPtr) chPtr;
      }
      int bytes = Encoding.UTF8.GetBytes((char*) chars, text_begin.Length, numPtr, byteCount);
      numPtr[bytes] = (byte) 0;
      // ISSUE: fixed variable is out of scope
      // ISSUE: __unpin statement
      __unpin(chPtr);
      byte* text_end = (byte*) null;
      ImGuiNative.ImDrawList_AddText_Vec2(this.NativePtr, pos, col, numPtr, text_end);
    }

    public unsafe void AddText(
      ImFontPtr font,
      float font_size,
      Vector2 pos,
      uint col,
      string text_begin)
    {
      ImFont* nativePtr = font.NativePtr;
      int byteCount = Encoding.UTF8.GetByteCount(text_begin);
      byte* numPtr = stackalloc byte[byteCount + 1];
      IntPtr chars;
      if (text_begin == null)
      {
        chars = IntPtr.Zero;
      }
      else
      {
        fixed (char* chPtr = &text_begin.GetPinnableReference())
          chars = (IntPtr) chPtr;
      }
      int bytes = Encoding.UTF8.GetBytes((char*) chars, text_begin.Length, numPtr, byteCount);
      numPtr[bytes] = (byte) 0;
      // ISSUE: fixed variable is out of scope
      // ISSUE: __unpin statement
      __unpin(chPtr);
      byte* text_end = (byte*) null;
      float wrap_width = 0.0f;
      Vector4* cpu_fine_clip_rect = (Vector4*) null;
      ImGuiNative.ImDrawList_AddText_FontPtr(this.NativePtr, nativePtr, font_size, pos, col, numPtr, text_end, wrap_width, cpu_fine_clip_rect);
    }
  }
}
