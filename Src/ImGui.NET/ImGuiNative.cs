// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImGuiNative
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;
using System.Numerics;
using System.Runtime.InteropServices;

#nullable disable
namespace ImGuiNET
{
  public static class ImGuiNative
  {
    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImGuiPayload* igAcceptDragDropPayload(
      byte* type,
      ImGuiDragDropFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igAlignTextToFramePadding();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igArrowButton(byte* str_id, ImGuiDir dir);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igBegin(byte* name, byte* p_open, ImGuiWindowFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igBeginChild_Str(
      byte* str_id,
      Vector2 size,
      byte border,
      ImGuiWindowFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern byte igBeginChild_ID(
      uint id,
      Vector2 size,
      byte border,
      ImGuiWindowFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern byte igBeginChildFrame(uint id, Vector2 size, ImGuiWindowFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igBeginCombo(
      byte* label,
      byte* preview_value,
      ImGuiComboFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igBeginDisabled(byte disabled);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern byte igBeginDragDropSource(ImGuiDragDropFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern byte igBeginDragDropTarget();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igBeginGroup();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igBeginListBox(byte* label, Vector2 size);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern byte igBeginMainMenuBar();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igBeginMenu(byte* label, byte enabled);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern byte igBeginMenuBar();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igBeginPopup(byte* str_id, ImGuiWindowFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igBeginPopupContextItem(
      byte* str_id,
      ImGuiPopupFlags popup_flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igBeginPopupContextVoid(
      byte* str_id,
      ImGuiPopupFlags popup_flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igBeginPopupContextWindow(
      byte* str_id,
      ImGuiPopupFlags popup_flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igBeginPopupModal(
      byte* name,
      byte* p_open,
      ImGuiWindowFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igBeginTabBar(byte* str_id, ImGuiTabBarFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igBeginTabItem(
      byte* label,
      byte* p_open,
      ImGuiTabItemFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igBeginTable(
      byte* str_id,
      int column,
      ImGuiTableFlags flags,
      Vector2 outer_size,
      float inner_width);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igBeginTooltip();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igBullet();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igBulletText(byte* fmt);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igButton(byte* label, Vector2 size);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern float igCalcItemWidth();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igCalcTextSize(
      Vector2* pOut,
      byte* text,
      byte* text_end,
      byte hide_text_after_double_hash,
      float wrap_width);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igCheckbox(byte* label, byte* v);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igCheckboxFlags_IntPtr(
      byte* label,
      int* flags,
      int flags_value);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igCheckboxFlags_UintPtr(
      byte* label,
      uint* flags,
      uint flags_value);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igCloseCurrentPopup();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igCollapsingHeader_TreeNodeFlags(
      byte* label,
      ImGuiTreeNodeFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igCollapsingHeader_BoolPtr(
      byte* label,
      byte* p_visible,
      ImGuiTreeNodeFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igColorButton(
      byte* desc_id,
      Vector4 col,
      ImGuiColorEditFlags flags,
      Vector2 size);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern uint igColorConvertFloat4ToU32(Vector4 @in);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igColorConvertHSVtoRGB(
      float h,
      float s,
      float v,
      float* out_r,
      float* out_g,
      float* out_b);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igColorConvertRGBtoHSV(
      float r,
      float g,
      float b,
      float* out_h,
      float* out_s,
      float* out_v);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igColorConvertU32ToFloat4(Vector4* pOut, uint @in);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igColorEdit3(
      byte* label,
      Vector3* col,
      ImGuiColorEditFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igColorEdit4(
      byte* label,
      Vector4* col,
      ImGuiColorEditFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igColorPicker3(
      byte* label,
      Vector3* col,
      ImGuiColorEditFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igColorPicker4(
      byte* label,
      Vector4* col,
      ImGuiColorEditFlags flags,
      float* ref_col);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igColumns(int count, byte* id, byte border);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igCombo_Str_arr(
      byte* label,
      int* current_item,
      byte** items,
      int items_count,
      int popup_max_height_in_items);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igCombo_Str(
      byte* label,
      int* current_item,
      byte* items_separated_by_zeros,
      int popup_max_height_in_items);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe IntPtr igCreateContext(ImFontAtlas* shared_font_atlas);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igDebugCheckVersionAndDataLayout(
      byte* version_str,
      uint sz_io,
      uint sz_style,
      uint sz_vec2,
      uint sz_vec4,
      uint sz_drawvert,
      uint sz_drawidx);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igDebugTextEncoding(byte* text);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igDestroyContext(IntPtr ctx);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igDestroyPlatformWindows();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe uint igDockSpace(
      uint id,
      Vector2 size,
      ImGuiDockNodeFlags flags,
      ImGuiWindowClass* window_class);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe uint igDockSpaceOverViewport(
      ImGuiViewport* viewport,
      ImGuiDockNodeFlags flags,
      ImGuiWindowClass* window_class);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igDragFloat(
      byte* label,
      float* v,
      float v_speed,
      float v_min,
      float v_max,
      byte* format,
      ImGuiSliderFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igDragFloat2(
      byte* label,
      Vector2* v,
      float v_speed,
      float v_min,
      float v_max,
      byte* format,
      ImGuiSliderFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igDragFloat3(
      byte* label,
      Vector3* v,
      float v_speed,
      float v_min,
      float v_max,
      byte* format,
      ImGuiSliderFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igDragFloat4(
      byte* label,
      Vector4* v,
      float v_speed,
      float v_min,
      float v_max,
      byte* format,
      ImGuiSliderFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igDragFloatRange2(
      byte* label,
      float* v_current_min,
      float* v_current_max,
      float v_speed,
      float v_min,
      float v_max,
      byte* format,
      byte* format_max,
      ImGuiSliderFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igDragInt(
      byte* label,
      int* v,
      float v_speed,
      int v_min,
      int v_max,
      byte* format,
      ImGuiSliderFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igDragInt2(
      byte* label,
      int* v,
      float v_speed,
      int v_min,
      int v_max,
      byte* format,
      ImGuiSliderFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igDragInt3(
      byte* label,
      int* v,
      float v_speed,
      int v_min,
      int v_max,
      byte* format,
      ImGuiSliderFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igDragInt4(
      byte* label,
      int* v,
      float v_speed,
      int v_min,
      int v_max,
      byte* format,
      ImGuiSliderFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igDragIntRange2(
      byte* label,
      int* v_current_min,
      int* v_current_max,
      float v_speed,
      int v_min,
      int v_max,
      byte* format,
      byte* format_max,
      ImGuiSliderFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igDragScalar(
      byte* label,
      ImGuiDataType data_type,
      void* p_data,
      float v_speed,
      void* p_min,
      void* p_max,
      byte* format,
      ImGuiSliderFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igDragScalarN(
      byte* label,
      ImGuiDataType data_type,
      void* p_data,
      int components,
      float v_speed,
      void* p_min,
      void* p_max,
      byte* format,
      ImGuiSliderFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igDummy(Vector2 size);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igEnd();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igEndChild();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igEndChildFrame();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igEndCombo();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igEndDisabled();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igEndDragDropSource();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igEndDragDropTarget();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igEndFrame();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igEndGroup();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igEndListBox();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igEndMainMenuBar();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igEndMenu();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igEndMenuBar();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igEndPopup();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igEndTabBar();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igEndTabItem();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igEndTable();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igEndTooltip();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImGuiViewport* igFindViewportByID(uint id);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImGuiViewport* igFindViewportByPlatformHandle(void* platform_handle);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igGetAllocatorFunctions(
      IntPtr* p_alloc_func,
      IntPtr* p_free_func,
      void** p_user_data);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImDrawList* igGetBackgroundDrawList_Nil();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImDrawList* igGetBackgroundDrawList_ViewportPtr(
      ImGuiViewport* viewport);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte* igGetClipboardText();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern uint igGetColorU32_Col(ImGuiCol idx, float alpha_mul);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern uint igGetColorU32_Vec4(Vector4 col);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern uint igGetColorU32_U32(uint col);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern int igGetColumnIndex();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern float igGetColumnOffset(int column_index);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern int igGetColumnsCount();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern float igGetColumnWidth(int column_index);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igGetContentRegionAvail(Vector2* pOut);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igGetContentRegionMax(Vector2* pOut);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern IntPtr igGetCurrentContext();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igGetCursorPos(Vector2* pOut);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern float igGetCursorPosX();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern float igGetCursorPosY();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igGetCursorScreenPos(Vector2* pOut);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igGetCursorStartPos(Vector2* pOut);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImGuiPayload* igGetDragDropPayload();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImDrawData* igGetDrawData();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern IntPtr igGetDrawListSharedData();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImFont* igGetFont();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern float igGetFontSize();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igGetFontTexUvWhitePixel(Vector2* pOut);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImDrawList* igGetForegroundDrawList_Nil();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImDrawList* igGetForegroundDrawList_ViewportPtr(
      ImGuiViewport* viewport);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern int igGetFrameCount();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern float igGetFrameHeight();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern float igGetFrameHeightWithSpacing();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe uint igGetID_Str(byte* str_id);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe uint igGetID_StrStr(byte* str_id_begin, byte* str_id_end);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe uint igGetID_Ptr(void* ptr_id);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImGuiIO* igGetIO();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igGetItemRectMax(Vector2* pOut);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igGetItemRectMin(Vector2* pOut);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igGetItemRectSize(Vector2* pOut);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern int igGetKeyIndex(ImGuiKey key);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte* igGetKeyName(ImGuiKey key);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern int igGetKeyPressedAmount(ImGuiKey key, float repeat_delay, float rate);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImGuiViewport* igGetMainViewport();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern int igGetMouseClickedCount(ImGuiMouseButton button);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern ImGuiMouseCursor igGetMouseCursor();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igGetMouseDragDelta(
      Vector2* pOut,
      ImGuiMouseButton button,
      float lock_threshold);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igGetMousePos(Vector2* pOut);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igGetMousePosOnOpeningCurrentPopup(Vector2* pOut);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImGuiPlatformIO* igGetPlatformIO();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern float igGetScrollMaxX();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern float igGetScrollMaxY();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern float igGetScrollX();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern float igGetScrollY();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImGuiStorage* igGetStateStorage();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImGuiStyle* igGetStyle();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte* igGetStyleColorName(ImGuiCol idx);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe Vector4* igGetStyleColorVec4(ImGuiCol idx);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern float igGetTextLineHeight();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern float igGetTextLineHeightWithSpacing();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern double igGetTime();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern float igGetTreeNodeToLabelSpacing();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte* igGetVersion();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igGetWindowContentRegionMax(Vector2* pOut);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igGetWindowContentRegionMin(Vector2* pOut);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern uint igGetWindowDockID();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern float igGetWindowDpiScale();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImDrawList* igGetWindowDrawList();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern float igGetWindowHeight();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igGetWindowPos(Vector2* pOut);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igGetWindowSize(Vector2* pOut);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImGuiViewport* igGetWindowViewport();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern float igGetWindowWidth();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igImage(
      IntPtr user_texture_id,
      Vector2 size,
      Vector2 uv0,
      Vector2 uv1,
      Vector4 tint_col,
      Vector4 border_col);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern byte igImageButton(
      IntPtr user_texture_id,
      Vector2 size,
      Vector2 uv0,
      Vector2 uv1,
      int frame_padding,
      Vector4 bg_col,
      Vector4 tint_col);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igIndent(float indent_w);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igInputDouble(
      byte* label,
      double* v,
      double step,
      double step_fast,
      byte* format,
      ImGuiInputTextFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igInputFloat(
      byte* label,
      float* v,
      float step,
      float step_fast,
      byte* format,
      ImGuiInputTextFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igInputFloat2(
      byte* label,
      Vector2* v,
      byte* format,
      ImGuiInputTextFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igInputFloat3(
      byte* label,
      Vector3* v,
      byte* format,
      ImGuiInputTextFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igInputFloat4(
      byte* label,
      Vector4* v,
      byte* format,
      ImGuiInputTextFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igInputInt(
      byte* label,
      int* v,
      int step,
      int step_fast,
      ImGuiInputTextFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igInputInt2(byte* label, int* v, ImGuiInputTextFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igInputInt3(byte* label, int* v, ImGuiInputTextFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igInputInt4(byte* label, int* v, ImGuiInputTextFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igInputScalar(
      byte* label,
      ImGuiDataType data_type,
      void* p_data,
      void* p_step,
      void* p_step_fast,
      byte* format,
      ImGuiInputTextFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igInputScalarN(
      byte* label,
      ImGuiDataType data_type,
      void* p_data,
      int components,
      void* p_step,
      void* p_step_fast,
      byte* format,
      ImGuiInputTextFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igInputText(
      byte* label,
      byte* buf,
      uint buf_size,
      ImGuiInputTextFlags flags,
      ImGuiInputTextCallback callback,
      void* user_data);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igInputTextMultiline(
      byte* label,
      byte* buf,
      uint buf_size,
      Vector2 size,
      ImGuiInputTextFlags flags,
      ImGuiInputTextCallback callback,
      void* user_data);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igInputTextWithHint(
      byte* label,
      byte* hint,
      byte* buf,
      uint buf_size,
      ImGuiInputTextFlags flags,
      ImGuiInputTextCallback callback,
      void* user_data);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igInvisibleButton(
      byte* str_id,
      Vector2 size,
      ImGuiButtonFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern byte igIsAnyItemActive();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern byte igIsAnyItemFocused();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern byte igIsAnyItemHovered();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern byte igIsAnyMouseDown();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern byte igIsItemActivated();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern byte igIsItemActive();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern byte igIsItemClicked(ImGuiMouseButton mouse_button);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern byte igIsItemDeactivated();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern byte igIsItemDeactivatedAfterEdit();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern byte igIsItemEdited();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern byte igIsItemFocused();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern byte igIsItemHovered(ImGuiHoveredFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern byte igIsItemToggledOpen();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern byte igIsItemVisible();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern byte igIsKeyDown(ImGuiKey key);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern byte igIsKeyPressed(ImGuiKey key, byte repeat);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern byte igIsKeyReleased(ImGuiKey key);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern byte igIsMouseClicked(ImGuiMouseButton button, byte repeat);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern byte igIsMouseDoubleClicked(ImGuiMouseButton button);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern byte igIsMouseDown(ImGuiMouseButton button);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern byte igIsMouseDragging(ImGuiMouseButton button, float lock_threshold);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern byte igIsMouseHoveringRect(Vector2 r_min, Vector2 r_max, byte clip);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igIsMousePosValid(Vector2* mouse_pos);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern byte igIsMouseReleased(ImGuiMouseButton button);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igIsPopupOpen_Str(byte* str_id, ImGuiPopupFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern byte igIsRectVisible_Nil(Vector2 size);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern byte igIsRectVisible_Vec2(Vector2 rect_min, Vector2 rect_max);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern byte igIsWindowAppearing();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern byte igIsWindowCollapsed();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern byte igIsWindowDocked();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern byte igIsWindowFocused(ImGuiFocusedFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern byte igIsWindowHovered(ImGuiHoveredFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igLabelText(byte* label, byte* fmt);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igListBox_Str_arr(
      byte* label,
      int* current_item,
      byte** items,
      int items_count,
      int height_in_items);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igLoadIniSettingsFromDisk(byte* ini_filename);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igLoadIniSettingsFromMemory(byte* ini_data, uint ini_size);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igLogButtons();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igLogFinish();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igLogText(byte* fmt);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igLogToClipboard(int auto_open_depth);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igLogToFile(int auto_open_depth, byte* filename);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igLogToTTY(int auto_open_depth);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void* igMemAlloc(uint size);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igMemFree(void* ptr);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igMenuItem_Bool(
      byte* label,
      byte* shortcut,
      byte selected,
      byte enabled);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igMenuItem_BoolPtr(
      byte* label,
      byte* shortcut,
      byte* p_selected,
      byte enabled);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igNewFrame();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igNewLine();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igNextColumn();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igOpenPopup_Str(byte* str_id, ImGuiPopupFlags popup_flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igOpenPopup_ID(uint id, ImGuiPopupFlags popup_flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igOpenPopupOnItemClick(
      byte* str_id,
      ImGuiPopupFlags popup_flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igPlotHistogram_FloatPtr(
      byte* label,
      float* values,
      int values_count,
      int values_offset,
      byte* overlay_text,
      float scale_min,
      float scale_max,
      Vector2 graph_size,
      int stride);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igPlotLines_FloatPtr(
      byte* label,
      float* values,
      int values_count,
      int values_offset,
      byte* overlay_text,
      float scale_min,
      float scale_max,
      Vector2 graph_size,
      int stride);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igPopAllowKeyboardFocus();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igPopButtonRepeat();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igPopClipRect();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igPopFont();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igPopID();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igPopItemWidth();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igPopStyleColor(int count);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igPopStyleVar(int count);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igPopTextWrapPos();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igProgressBar(float fraction, Vector2 size_arg, byte* overlay);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igPushAllowKeyboardFocus(byte allow_keyboard_focus);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igPushButtonRepeat(byte repeat);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igPushClipRect(
      Vector2 clip_rect_min,
      Vector2 clip_rect_max,
      byte intersect_with_current_clip_rect);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igPushFont(ImFont* font);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igPushID_Str(byte* str_id);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igPushID_StrStr(byte* str_id_begin, byte* str_id_end);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igPushID_Ptr(void* ptr_id);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igPushID_Int(int int_id);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igPushItemWidth(float item_width);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igPushStyleColor_U32(ImGuiCol idx, uint col);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igPushStyleColor_Vec4(ImGuiCol idx, Vector4 col);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igPushStyleVar_Float(ImGuiStyleVar idx, float val);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igPushStyleVar_Vec2(ImGuiStyleVar idx, Vector2 val);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igPushTextWrapPos(float wrap_local_pos_x);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igRadioButton_Bool(byte* label, byte active);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igRadioButton_IntPtr(byte* label, int* v, int v_button);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igRender();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igRenderPlatformWindowsDefault(
      void* platform_render_arg,
      void* renderer_render_arg);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igResetMouseDragDelta(ImGuiMouseButton button);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igSameLine(float offset_from_start_x, float spacing);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igSaveIniSettingsToDisk(byte* ini_filename);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte* igSaveIniSettingsToMemory(uint* out_ini_size);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igSelectable_Bool(
      byte* label,
      byte selected,
      ImGuiSelectableFlags flags,
      Vector2 size);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igSelectable_BoolPtr(
      byte* label,
      byte* p_selected,
      ImGuiSelectableFlags flags,
      Vector2 size);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igSeparator();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igSetAllocatorFunctions(
      IntPtr alloc_func,
      IntPtr free_func,
      void* user_data);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igSetClipboardText(byte* text);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igSetColorEditOptions(ImGuiColorEditFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igSetColumnOffset(int column_index, float offset_x);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igSetColumnWidth(int column_index, float width);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igSetCurrentContext(IntPtr ctx);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igSetCursorPos(Vector2 local_pos);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igSetCursorPosX(float local_x);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igSetCursorPosY(float local_y);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igSetCursorScreenPos(Vector2 pos);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igSetDragDropPayload(
      byte* type,
      void* data,
      uint sz,
      ImGuiCond cond);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igSetItemAllowOverlap();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igSetItemDefaultFocus();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igSetKeyboardFocusHere(int offset);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igSetMouseCursor(ImGuiMouseCursor cursor_type);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igSetNextFrameWantCaptureKeyboard(byte want_capture_keyboard);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igSetNextFrameWantCaptureMouse(byte want_capture_mouse);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igSetNextItemOpen(byte is_open, ImGuiCond cond);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igSetNextItemWidth(float item_width);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igSetNextWindowBgAlpha(float alpha);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igSetNextWindowClass(ImGuiWindowClass* window_class);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igSetNextWindowCollapsed(byte collapsed, ImGuiCond cond);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igSetNextWindowContentSize(Vector2 size);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igSetNextWindowDockID(uint dock_id, ImGuiCond cond);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igSetNextWindowFocus();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igSetNextWindowPos(Vector2 pos, ImGuiCond cond, Vector2 pivot);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igSetNextWindowSize(Vector2 size, ImGuiCond cond);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igSetNextWindowSizeConstraints(
      Vector2 size_min,
      Vector2 size_max,
      ImGuiSizeCallback custom_callback,
      void* custom_callback_data);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igSetNextWindowViewport(uint viewport_id);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igSetScrollFromPosX_Float(float local_x, float center_x_ratio);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igSetScrollFromPosY_Float(float local_y, float center_y_ratio);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igSetScrollHereX(float center_x_ratio);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igSetScrollHereY(float center_y_ratio);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igSetScrollX_Float(float scroll_x);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igSetScrollY_Float(float scroll_y);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igSetStateStorage(ImGuiStorage* storage);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igSetTabItemClosed(byte* tab_or_docked_window_label);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igSetTooltip(byte* fmt);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igSetWindowCollapsed_Bool(byte collapsed, ImGuiCond cond);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igSetWindowCollapsed_Str(
      byte* name,
      byte collapsed,
      ImGuiCond cond);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igSetWindowFocus_Nil();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igSetWindowFocus_Str(byte* name);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igSetWindowFontScale(float scale);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igSetWindowPos_Vec2(Vector2 pos, ImGuiCond cond);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igSetWindowPos_Str(byte* name, Vector2 pos, ImGuiCond cond);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igSetWindowSize_Vec2(Vector2 size, ImGuiCond cond);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igSetWindowSize_Str(byte* name, Vector2 size, ImGuiCond cond);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igShowAboutWindow(byte* p_open);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igShowDebugLogWindow(byte* p_open);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igShowDemoWindow(byte* p_open);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igShowFontSelector(byte* label);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igShowMetricsWindow(byte* p_open);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igShowStackToolWindow(byte* p_open);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igShowStyleEditor(ImGuiStyle* @ref);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igShowStyleSelector(byte* label);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igShowUserGuide();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igSliderAngle(
      byte* label,
      float* v_rad,
      float v_degrees_min,
      float v_degrees_max,
      byte* format,
      ImGuiSliderFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igSliderFloat(
      byte* label,
      float* v,
      float v_min,
      float v_max,
      byte* format,
      ImGuiSliderFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igSliderFloat2(
      byte* label,
      Vector2* v,
      float v_min,
      float v_max,
      byte* format,
      ImGuiSliderFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igSliderFloat3(
      byte* label,
      Vector3* v,
      float v_min,
      float v_max,
      byte* format,
      ImGuiSliderFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igSliderFloat4(
      byte* label,
      Vector4* v,
      float v_min,
      float v_max,
      byte* format,
      ImGuiSliderFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igSliderInt(
      byte* label,
      int* v,
      int v_min,
      int v_max,
      byte* format,
      ImGuiSliderFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igSliderInt2(
      byte* label,
      int* v,
      int v_min,
      int v_max,
      byte* format,
      ImGuiSliderFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igSliderInt3(
      byte* label,
      int* v,
      int v_min,
      int v_max,
      byte* format,
      ImGuiSliderFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igSliderInt4(
      byte* label,
      int* v,
      int v_min,
      int v_max,
      byte* format,
      ImGuiSliderFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igSliderScalar(
      byte* label,
      ImGuiDataType data_type,
      void* p_data,
      void* p_min,
      void* p_max,
      byte* format,
      ImGuiSliderFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igSliderScalarN(
      byte* label,
      ImGuiDataType data_type,
      void* p_data,
      int components,
      void* p_min,
      void* p_max,
      byte* format,
      ImGuiSliderFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igSmallButton(byte* label);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igSpacing();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igStyleColorsClassic(ImGuiStyle* dst);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igStyleColorsDark(ImGuiStyle* dst);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igStyleColorsLight(ImGuiStyle* dst);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igTabItemButton(byte* label, ImGuiTabItemFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern int igTableGetColumnCount();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern ImGuiTableColumnFlags igTableGetColumnFlags(int column_n);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern int igTableGetColumnIndex();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte* igTableGetColumnName_Int(int column_n);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern int igTableGetRowIndex();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImGuiTableSortSpecs* igTableGetSortSpecs();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igTableHeader(byte* label);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igTableHeadersRow();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern byte igTableNextColumn();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igTableNextRow(ImGuiTableRowFlags row_flags, float min_row_height);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igTableSetBgColor(
      ImGuiTableBgTarget target,
      uint color,
      int column_n);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igTableSetColumnEnabled(int column_n, byte v);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern byte igTableSetColumnIndex(int column_n);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igTableSetupColumn(
      byte* label,
      ImGuiTableColumnFlags flags,
      float init_width_or_weight,
      uint user_id);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igTableSetupScrollFreeze(int cols, int rows);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igText(byte* fmt);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igTextColored(Vector4 col, byte* fmt);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igTextDisabled(byte* fmt);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igTextUnformatted(byte* text, byte* text_end);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igTextWrapped(byte* fmt);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igTreeNode_Str(byte* label);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igTreeNode_StrStr(byte* str_id, byte* fmt);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igTreeNode_Ptr(void* ptr_id, byte* fmt);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igTreeNodeEx_Str(byte* label, ImGuiTreeNodeFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igTreeNodeEx_StrStr(
      byte* str_id,
      ImGuiTreeNodeFlags flags,
      byte* fmt);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igTreeNodeEx_Ptr(
      void* ptr_id,
      ImGuiTreeNodeFlags flags,
      byte* fmt);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igTreePop();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igTreePush_Str(byte* str_id);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igTreePush_Ptr(void* ptr_id);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igUnindent(float indent_w);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern void igUpdatePlatformWindows();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igValue_Bool(byte* prefix, byte b);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igValue_Int(byte* prefix, int v);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igValue_Uint(byte* prefix, uint v);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void igValue_Float(byte* prefix, float v, byte* float_format);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igVSliderFloat(
      byte* label,
      Vector2 size,
      float* v,
      float v_min,
      float v_max,
      byte* format,
      ImGuiSliderFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igVSliderInt(
      byte* label,
      Vector2 size,
      int* v,
      int v_min,
      int v_max,
      byte* format,
      ImGuiSliderFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte igVSliderScalar(
      byte* label,
      Vector2 size,
      ImGuiDataType data_type,
      void* p_data,
      void* p_min,
      void* p_max,
      byte* format,
      ImGuiSliderFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImColor_destroy(ImColor* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImColor_HSV(
      ImColor* pOut,
      float h,
      float s,
      float v,
      float a);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImColor* ImColor_ImColor_Nil();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImColor* ImColor_ImColor_Float(float r, float g, float b, float a);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImColor* ImColor_ImColor_Vec4(Vector4 col);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImColor* ImColor_ImColor_Int(int r, int g, int b, int a);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImColor* ImColor_ImColor_U32(uint rgba);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImColor_SetHSV(
      ImColor* self,
      float h,
      float s,
      float v,
      float a);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawCmd_destroy(ImDrawCmd* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe IntPtr ImDrawCmd_GetTexID(ImDrawCmd* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImDrawCmd* ImDrawCmd_ImDrawCmd();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawData_Clear(ImDrawData* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawData_DeIndexAllBuffers(ImDrawData* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawData_destroy(ImDrawData* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImDrawData* ImDrawData_ImDrawData();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawData_ScaleClipRects(ImDrawData* self, Vector2 fb_scale);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe int ImDrawList__CalcCircleAutoSegmentCount(
      ImDrawList* self,
      float radius);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList__ClearFreeMemory(ImDrawList* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList__OnChangedClipRect(ImDrawList* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList__OnChangedTextureID(ImDrawList* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList__OnChangedVtxOffset(ImDrawList* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList__PathArcToFastEx(
      ImDrawList* self,
      Vector2 center,
      float radius,
      int a_min_sample,
      int a_max_sample,
      int a_step);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList__PathArcToN(
      ImDrawList* self,
      Vector2 center,
      float radius,
      float a_min,
      float a_max,
      int num_segments);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList__PopUnusedDrawCmd(ImDrawList* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList__ResetForNewFrame(ImDrawList* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList__TryMergeDrawCmds(ImDrawList* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_AddBezierCubic(
      ImDrawList* self,
      Vector2 p1,
      Vector2 p2,
      Vector2 p3,
      Vector2 p4,
      uint col,
      float thickness,
      int num_segments);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_AddBezierQuadratic(
      ImDrawList* self,
      Vector2 p1,
      Vector2 p2,
      Vector2 p3,
      uint col,
      float thickness,
      int num_segments);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_AddCallback(
      ImDrawList* self,
      IntPtr callback,
      void* callback_data);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_AddCircle(
      ImDrawList* self,
      Vector2 center,
      float radius,
      uint col,
      int num_segments,
      float thickness);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_AddCircleFilled(
      ImDrawList* self,
      Vector2 center,
      float radius,
      uint col,
      int num_segments);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_AddConvexPolyFilled(
      ImDrawList* self,
      Vector2* points,
      int num_points,
      uint col);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_AddDrawCmd(ImDrawList* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_AddImage(
      ImDrawList* self,
      IntPtr user_texture_id,
      Vector2 p_min,
      Vector2 p_max,
      Vector2 uv_min,
      Vector2 uv_max,
      uint col);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_AddImageQuad(
      ImDrawList* self,
      IntPtr user_texture_id,
      Vector2 p1,
      Vector2 p2,
      Vector2 p3,
      Vector2 p4,
      Vector2 uv1,
      Vector2 uv2,
      Vector2 uv3,
      Vector2 uv4,
      uint col);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_AddImageRounded(
      ImDrawList* self,
      IntPtr user_texture_id,
      Vector2 p_min,
      Vector2 p_max,
      Vector2 uv_min,
      Vector2 uv_max,
      uint col,
      float rounding,
      ImDrawFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_AddLine(
      ImDrawList* self,
      Vector2 p1,
      Vector2 p2,
      uint col,
      float thickness);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_AddNgon(
      ImDrawList* self,
      Vector2 center,
      float radius,
      uint col,
      int num_segments,
      float thickness);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_AddNgonFilled(
      ImDrawList* self,
      Vector2 center,
      float radius,
      uint col,
      int num_segments);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_AddPolyline(
      ImDrawList* self,
      Vector2* points,
      int num_points,
      uint col,
      ImDrawFlags flags,
      float thickness);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_AddQuad(
      ImDrawList* self,
      Vector2 p1,
      Vector2 p2,
      Vector2 p3,
      Vector2 p4,
      uint col,
      float thickness);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_AddQuadFilled(
      ImDrawList* self,
      Vector2 p1,
      Vector2 p2,
      Vector2 p3,
      Vector2 p4,
      uint col);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_AddRect(
      ImDrawList* self,
      Vector2 p_min,
      Vector2 p_max,
      uint col,
      float rounding,
      ImDrawFlags flags,
      float thickness);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_AddRectFilled(
      ImDrawList* self,
      Vector2 p_min,
      Vector2 p_max,
      uint col,
      float rounding,
      ImDrawFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_AddRectFilledMultiColor(
      ImDrawList* self,
      Vector2 p_min,
      Vector2 p_max,
      uint col_upr_left,
      uint col_upr_right,
      uint col_bot_right,
      uint col_bot_left);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_AddText_Vec2(
      ImDrawList* self,
      Vector2 pos,
      uint col,
      byte* text_begin,
      byte* text_end);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_AddText_FontPtr(
      ImDrawList* self,
      ImFont* font,
      float font_size,
      Vector2 pos,
      uint col,
      byte* text_begin,
      byte* text_end,
      float wrap_width,
      Vector4* cpu_fine_clip_rect);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_AddTriangle(
      ImDrawList* self,
      Vector2 p1,
      Vector2 p2,
      Vector2 p3,
      uint col,
      float thickness);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_AddTriangleFilled(
      ImDrawList* self,
      Vector2 p1,
      Vector2 p2,
      Vector2 p3,
      uint col);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_ChannelsMerge(ImDrawList* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_ChannelsSetCurrent(ImDrawList* self, int n);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_ChannelsSplit(ImDrawList* self, int count);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImDrawList* ImDrawList_CloneOutput(ImDrawList* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_destroy(ImDrawList* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_GetClipRectMax(Vector2* pOut, ImDrawList* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_GetClipRectMin(Vector2* pOut, ImDrawList* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImDrawList* ImDrawList_ImDrawList(IntPtr shared_data);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_PathArcTo(
      ImDrawList* self,
      Vector2 center,
      float radius,
      float a_min,
      float a_max,
      int num_segments);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_PathArcToFast(
      ImDrawList* self,
      Vector2 center,
      float radius,
      int a_min_of_12,
      int a_max_of_12);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_PathBezierCubicCurveTo(
      ImDrawList* self,
      Vector2 p2,
      Vector2 p3,
      Vector2 p4,
      int num_segments);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_PathBezierQuadraticCurveTo(
      ImDrawList* self,
      Vector2 p2,
      Vector2 p3,
      int num_segments);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_PathClear(ImDrawList* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_PathFillConvex(ImDrawList* self, uint col);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_PathLineTo(ImDrawList* self, Vector2 pos);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_PathLineToMergeDuplicate(
      ImDrawList* self,
      Vector2 pos);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_PathRect(
      ImDrawList* self,
      Vector2 rect_min,
      Vector2 rect_max,
      float rounding,
      ImDrawFlags flags);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_PathStroke(
      ImDrawList* self,
      uint col,
      ImDrawFlags flags,
      float thickness);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_PopClipRect(ImDrawList* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_PopTextureID(ImDrawList* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_PrimQuadUV(
      ImDrawList* self,
      Vector2 a,
      Vector2 b,
      Vector2 c,
      Vector2 d,
      Vector2 uv_a,
      Vector2 uv_b,
      Vector2 uv_c,
      Vector2 uv_d,
      uint col);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_PrimRect(
      ImDrawList* self,
      Vector2 a,
      Vector2 b,
      uint col);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_PrimRectUV(
      ImDrawList* self,
      Vector2 a,
      Vector2 b,
      Vector2 uv_a,
      Vector2 uv_b,
      uint col);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_PrimReserve(
      ImDrawList* self,
      int idx_count,
      int vtx_count);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_PrimUnreserve(
      ImDrawList* self,
      int idx_count,
      int vtx_count);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_PrimVtx(
      ImDrawList* self,
      Vector2 pos,
      Vector2 uv,
      uint col);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_PrimWriteIdx(ImDrawList* self, ushort idx);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_PrimWriteVtx(
      ImDrawList* self,
      Vector2 pos,
      Vector2 uv,
      uint col);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_PushClipRect(
      ImDrawList* self,
      Vector2 clip_rect_min,
      Vector2 clip_rect_max,
      byte intersect_with_current_clip_rect);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_PushClipRectFullScreen(ImDrawList* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawList_PushTextureID(ImDrawList* self, IntPtr texture_id);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawListSplitter_Clear(ImDrawListSplitter* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawListSplitter_ClearFreeMemory(ImDrawListSplitter* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawListSplitter_destroy(ImDrawListSplitter* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImDrawListSplitter* ImDrawListSplitter_ImDrawListSplitter();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawListSplitter_Merge(
      ImDrawListSplitter* self,
      ImDrawList* draw_list);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawListSplitter_SetCurrentChannel(
      ImDrawListSplitter* self,
      ImDrawList* draw_list,
      int channel_idx);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImDrawListSplitter_Split(
      ImDrawListSplitter* self,
      ImDrawList* draw_list,
      int count);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImFont_AddGlyph(
      ImFont* self,
      ImFontConfig* src_cfg,
      ushort c,
      float x0,
      float y0,
      float x1,
      float y1,
      float u0,
      float v0,
      float u1,
      float v1,
      float advance_x);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImFont_AddRemapChar(
      ImFont* self,
      ushort dst,
      ushort src,
      byte overwrite_dst);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImFont_BuildLookupTable(ImFont* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImFont_CalcTextSizeA(
      Vector2* pOut,
      ImFont* self,
      float size,
      float max_width,
      float wrap_width,
      byte* text_begin,
      byte* text_end,
      byte** remaining);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte* ImFont_CalcWordWrapPositionA(
      ImFont* self,
      float scale,
      byte* text,
      byte* text_end,
      float wrap_width);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImFont_ClearOutputData(ImFont* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImFont_destroy(ImFont* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImFontGlyph* ImFont_FindGlyph(ImFont* self, ushort c);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImFontGlyph* ImFont_FindGlyphNoFallback(ImFont* self, ushort c);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe float ImFont_GetCharAdvance(ImFont* self, ushort c);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte* ImFont_GetDebugName(ImFont* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImFont_GrowIndex(ImFont* self, int new_size);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImFont* ImFont_ImFont();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte ImFont_IsGlyphRangeUnused(
      ImFont* self,
      uint c_begin,
      uint c_last);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte ImFont_IsLoaded(ImFont* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImFont_RenderChar(
      ImFont* self,
      ImDrawList* draw_list,
      float size,
      Vector2 pos,
      uint col,
      ushort c);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImFont_RenderText(
      ImFont* self,
      ImDrawList* draw_list,
      float size,
      Vector2 pos,
      uint col,
      Vector4 clip_rect,
      byte* text_begin,
      byte* text_end,
      float wrap_width,
      byte cpu_fine_clip);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImFont_SetGlyphVisible(ImFont* self, ushort c, byte visible);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe int ImFontAtlas_AddCustomRectFontGlyph(
      ImFontAtlas* self,
      ImFont* font,
      ushort id,
      int width,
      int height,
      float advance_x,
      Vector2 offset);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe int ImFontAtlas_AddCustomRectRegular(
      ImFontAtlas* self,
      int width,
      int height);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImFont* ImFontAtlas_AddFont(
      ImFontAtlas* self,
      ImFontConfig* font_cfg);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImFont* ImFontAtlas_AddFontDefault(
      ImFontAtlas* self,
      ImFontConfig* font_cfg);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImFont* ImFontAtlas_AddFontFromFileTTF(
      ImFontAtlas* self,
      byte* filename,
      float size_pixels,
      ImFontConfig* font_cfg,
      ushort* glyph_ranges);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImFont* ImFontAtlas_AddFontFromMemoryCompressedBase85TTF(
      ImFontAtlas* self,
      byte* compressed_font_data_base85,
      float size_pixels,
      ImFontConfig* font_cfg,
      ushort* glyph_ranges);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImFont* ImFontAtlas_AddFontFromMemoryCompressedTTF(
      ImFontAtlas* self,
      void* compressed_font_data,
      int compressed_font_size,
      float size_pixels,
      ImFontConfig* font_cfg,
      ushort* glyph_ranges);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImFont* ImFontAtlas_AddFontFromMemoryTTF(
      ImFontAtlas* self,
      void* font_data,
      int font_size,
      float size_pixels,
      ImFontConfig* font_cfg,
      ushort* glyph_ranges);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte ImFontAtlas_Build(ImFontAtlas* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImFontAtlas_CalcCustomRectUV(
      ImFontAtlas* self,
      ImFontAtlasCustomRect* rect,
      Vector2* out_uv_min,
      Vector2* out_uv_max);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImFontAtlas_Clear(ImFontAtlas* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImFontAtlas_ClearFonts(ImFontAtlas* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImFontAtlas_ClearInputData(ImFontAtlas* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImFontAtlas_ClearTexData(ImFontAtlas* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImFontAtlas_destroy(ImFontAtlas* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImFontAtlasCustomRect* ImFontAtlas_GetCustomRectByIndex(
      ImFontAtlas* self,
      int index);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ushort* ImFontAtlas_GetGlyphRangesChineseFull(ImFontAtlas* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ushort* ImFontAtlas_GetGlyphRangesChineseSimplifiedCommon(
      ImFontAtlas* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ushort* ImFontAtlas_GetGlyphRangesCyrillic(ImFontAtlas* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ushort* ImFontAtlas_GetGlyphRangesDefault(ImFontAtlas* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ushort* ImFontAtlas_GetGlyphRangesJapanese(ImFontAtlas* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ushort* ImFontAtlas_GetGlyphRangesKorean(ImFontAtlas* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ushort* ImFontAtlas_GetGlyphRangesThai(ImFontAtlas* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ushort* ImFontAtlas_GetGlyphRangesVietnamese(ImFontAtlas* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte ImFontAtlas_GetMouseCursorTexData(
      ImFontAtlas* self,
      ImGuiMouseCursor cursor,
      Vector2* out_offset,
      Vector2* out_size,
      Vector2* out_uv_border,
      Vector2* out_uv_fill);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImFontAtlas_GetTexDataAsAlpha8(
      ImFontAtlas* self,
      byte** out_pixels,
      int* out_width,
      int* out_height,
      int* out_bytes_per_pixel);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImFontAtlas_GetTexDataAsAlpha8(
      ImFontAtlas* self,
      IntPtr* out_pixels,
      int* out_width,
      int* out_height,
      int* out_bytes_per_pixel);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImFontAtlas_GetTexDataAsRGBA32(
      ImFontAtlas* self,
      byte** out_pixels,
      int* out_width,
      int* out_height,
      int* out_bytes_per_pixel);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImFontAtlas_GetTexDataAsRGBA32(
      ImFontAtlas* self,
      IntPtr* out_pixels,
      int* out_width,
      int* out_height,
      int* out_bytes_per_pixel);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImFontAtlas* ImFontAtlas_ImFontAtlas();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte ImFontAtlas_IsBuilt(ImFontAtlas* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImFontAtlas_SetTexID(ImFontAtlas* self, IntPtr id);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImFontAtlasCustomRect_destroy(ImFontAtlasCustomRect* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImFontAtlasCustomRect* ImFontAtlasCustomRect_ImFontAtlasCustomRect();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte ImFontAtlasCustomRect_IsPacked(ImFontAtlasCustomRect* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImFontConfig_destroy(ImFontConfig* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImFontConfig* ImFontConfig_ImFontConfig();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImFontGlyphRangesBuilder_AddChar(
      ImFontGlyphRangesBuilder* self,
      ushort c);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImFontGlyphRangesBuilder_AddRanges(
      ImFontGlyphRangesBuilder* self,
      ushort* ranges);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImFontGlyphRangesBuilder_AddText(
      ImFontGlyphRangesBuilder* self,
      byte* text,
      byte* text_end);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImFontGlyphRangesBuilder_BuildRanges(
      ImFontGlyphRangesBuilder* self,
      ImVector* out_ranges);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImFontGlyphRangesBuilder_Clear(ImFontGlyphRangesBuilder* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImFontGlyphRangesBuilder_destroy(ImFontGlyphRangesBuilder* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte ImFontGlyphRangesBuilder_GetBit(
      ImFontGlyphRangesBuilder* self,
      uint n);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImFontGlyphRangesBuilder* ImFontGlyphRangesBuilder_ImFontGlyphRangesBuilder();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImFontGlyphRangesBuilder_SetBit(
      ImFontGlyphRangesBuilder* self,
      uint n);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiInputTextCallbackData_ClearSelection(
      ImGuiInputTextCallbackData* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiInputTextCallbackData_DeleteChars(
      ImGuiInputTextCallbackData* self,
      int pos,
      int bytes_count);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiInputTextCallbackData_destroy(
      ImGuiInputTextCallbackData* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte ImGuiInputTextCallbackData_HasSelection(
      ImGuiInputTextCallbackData* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImGuiInputTextCallbackData* ImGuiInputTextCallbackData_ImGuiInputTextCallbackData();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiInputTextCallbackData_InsertChars(
      ImGuiInputTextCallbackData* self,
      int pos,
      byte* text,
      byte* text_end);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiInputTextCallbackData_SelectAll(
      ImGuiInputTextCallbackData* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiIO_AddFocusEvent(ImGuiIO* self, byte focused);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiIO_AddInputCharacter(ImGuiIO* self, uint c);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiIO_AddInputCharactersUTF8(ImGuiIO* self, byte* str);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiIO_AddInputCharacterUTF16(ImGuiIO* self, ushort c);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiIO_AddKeyAnalogEvent(
      ImGuiIO* self,
      ImGuiKey key,
      byte down,
      float v);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiIO_AddKeyEvent(ImGuiIO* self, ImGuiKey key, byte down);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiIO_AddMouseButtonEvent(
      ImGuiIO* self,
      int button,
      byte down);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiIO_AddMousePosEvent(ImGuiIO* self, float x, float y);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiIO_AddMouseViewportEvent(ImGuiIO* self, uint id);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiIO_AddMouseWheelEvent(
      ImGuiIO* self,
      float wh_x,
      float wh_y);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiIO_ClearInputCharacters(ImGuiIO* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiIO_ClearInputKeys(ImGuiIO* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiIO_destroy(ImGuiIO* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImGuiIO* ImGuiIO_ImGuiIO();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiIO_SetAppAcceptingEvents(
      ImGuiIO* self,
      byte accepting_events);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiIO_SetKeyEventNativeData(
      ImGuiIO* self,
      ImGuiKey key,
      int native_keycode,
      int native_scancode,
      int native_legacy_index);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiListClipper_Begin(
      ImGuiListClipper* self,
      int items_count,
      float items_height);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiListClipper_destroy(ImGuiListClipper* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiListClipper_End(ImGuiListClipper* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiListClipper_ForceDisplayRangeByIndices(
      ImGuiListClipper* self,
      int item_min,
      int item_max);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImGuiListClipper* ImGuiListClipper_ImGuiListClipper();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte ImGuiListClipper_Step(ImGuiListClipper* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiOnceUponAFrame_destroy(ImGuiOnceUponAFrame* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImGuiOnceUponAFrame* ImGuiOnceUponAFrame_ImGuiOnceUponAFrame();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiPayload_Clear(ImGuiPayload* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiPayload_destroy(ImGuiPayload* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImGuiPayload* ImGuiPayload_ImGuiPayload();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte ImGuiPayload_IsDataType(ImGuiPayload* self, byte* type);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte ImGuiPayload_IsDelivery(ImGuiPayload* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte ImGuiPayload_IsPreview(ImGuiPayload* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiPlatformImeData_destroy(ImGuiPlatformImeData* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImGuiPlatformImeData* ImGuiPlatformImeData_ImGuiPlatformImeData();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiPlatformIO_destroy(ImGuiPlatformIO* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImGuiPlatformIO* ImGuiPlatformIO_ImGuiPlatformIO();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiPlatformMonitor_destroy(ImGuiPlatformMonitor* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImGuiPlatformMonitor* ImGuiPlatformMonitor_ImGuiPlatformMonitor();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiStorage_BuildSortByKey(ImGuiStorage* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiStorage_Clear(ImGuiStorage* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte ImGuiStorage_GetBool(
      ImGuiStorage* self,
      uint key,
      byte default_val);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte* ImGuiStorage_GetBoolRef(
      ImGuiStorage* self,
      uint key,
      byte default_val);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe float ImGuiStorage_GetFloat(
      ImGuiStorage* self,
      uint key,
      float default_val);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe float* ImGuiStorage_GetFloatRef(
      ImGuiStorage* self,
      uint key,
      float default_val);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe int ImGuiStorage_GetInt(
      ImGuiStorage* self,
      uint key,
      int default_val);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe int* ImGuiStorage_GetIntRef(
      ImGuiStorage* self,
      uint key,
      int default_val);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void* ImGuiStorage_GetVoidPtr(ImGuiStorage* self, uint key);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void** ImGuiStorage_GetVoidPtrRef(
      ImGuiStorage* self,
      uint key,
      void* default_val);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiStorage_SetAllInt(ImGuiStorage* self, int val);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiStorage_SetBool(ImGuiStorage* self, uint key, byte val);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiStorage_SetFloat(ImGuiStorage* self, uint key, float val);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiStorage_SetInt(ImGuiStorage* self, uint key, int val);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiStorage_SetVoidPtr(
      ImGuiStorage* self,
      uint key,
      void* val);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiStoragePair_destroy(ImGuiStoragePair* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImGuiStoragePair* ImGuiStoragePair_ImGuiStoragePair_Int(
      uint _key,
      int _val_i);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImGuiStoragePair* ImGuiStoragePair_ImGuiStoragePair_Float(
      uint _key,
      float _val_f);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImGuiStoragePair* ImGuiStoragePair_ImGuiStoragePair_Ptr(
      uint _key,
      void* _val_p);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiStyle_destroy(ImGuiStyle* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImGuiStyle* ImGuiStyle_ImGuiStyle();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiStyle_ScaleAllSizes(ImGuiStyle* self, float scale_factor);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiTableColumnSortSpecs_destroy(
      ImGuiTableColumnSortSpecs* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImGuiTableColumnSortSpecs* ImGuiTableColumnSortSpecs_ImGuiTableColumnSortSpecs();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiTableSortSpecs_destroy(ImGuiTableSortSpecs* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImGuiTableSortSpecs* ImGuiTableSortSpecs_ImGuiTableSortSpecs();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiTextBuffer_append(
      ImGuiTextBuffer* self,
      byte* str,
      byte* str_end);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiTextBuffer_appendf(ImGuiTextBuffer* self, byte* fmt);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte* ImGuiTextBuffer_begin(ImGuiTextBuffer* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte* ImGuiTextBuffer_c_str(ImGuiTextBuffer* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiTextBuffer_clear(ImGuiTextBuffer* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiTextBuffer_destroy(ImGuiTextBuffer* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte ImGuiTextBuffer_empty(ImGuiTextBuffer* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte* ImGuiTextBuffer_end(ImGuiTextBuffer* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImGuiTextBuffer* ImGuiTextBuffer_ImGuiTextBuffer();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiTextBuffer_reserve(ImGuiTextBuffer* self, int capacity);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe int ImGuiTextBuffer_size(ImGuiTextBuffer* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiTextFilter_Build(ImGuiTextFilter* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiTextFilter_Clear(ImGuiTextFilter* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiTextFilter_destroy(ImGuiTextFilter* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte ImGuiTextFilter_Draw(
      ImGuiTextFilter* self,
      byte* label,
      float width);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImGuiTextFilter* ImGuiTextFilter_ImGuiTextFilter(
      byte* default_filter);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte ImGuiTextFilter_IsActive(ImGuiTextFilter* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte ImGuiTextFilter_PassFilter(
      ImGuiTextFilter* self,
      byte* text,
      byte* text_end);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiTextRange_destroy(ImGuiTextRange* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe byte ImGuiTextRange_empty(ImGuiTextRange* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImGuiTextRange* ImGuiTextRange_ImGuiTextRange_Nil();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImGuiTextRange* ImGuiTextRange_ImGuiTextRange_Str(
      byte* _b,
      byte* _e);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiTextRange_split(
      ImGuiTextRange* self,
      byte separator,
      ImVector* @out);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiViewport_destroy(ImGuiViewport* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiViewport_GetCenter(Vector2* pOut, ImGuiViewport* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiViewport_GetWorkCenter(Vector2* pOut, ImGuiViewport* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImGuiViewport* ImGuiViewport_ImGuiViewport();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImGuiWindowClass_destroy(ImGuiWindowClass* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe ImGuiWindowClass* ImGuiWindowClass_ImGuiWindowClass();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImVec2_destroy(Vector2* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe Vector2* ImVec2_ImVec2_Nil();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe Vector2* ImVec2_ImVec2_Float(float _x, float _y);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe void ImVec4_destroy(Vector4* self);

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe Vector4* ImVec4_ImVec4_Nil();

    [DllImport("cimgui", CallingConvention = (CallingConvention) 2)]
    public static extern unsafe Vector4* ImVec4_ImVec4_Float(
      float _x,
      float _y,
      float _z,
      float _w);
  }
}
