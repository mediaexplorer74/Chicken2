﻿// Decompiled with JetBrains decompiler
// Type: ImGuiNET.ImGuiIO
// Assembly: ImGui.NET, Version=1.88.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3106752-9302-4F2B-A152-41A2C87F4A1D
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\ImGui.NET.dll

using System;
using System.Numerics;

#nullable disable
namespace ImGuiNET
{
  public struct ImGuiIO
  {
    public ImGuiConfigFlags ConfigFlags;
    public ImGuiBackendFlags BackendFlags;
    public Vector2 DisplaySize;
    public float DeltaTime;
    public float IniSavingRate;
    public unsafe byte* IniFilename;
    public unsafe byte* LogFilename;
    public float MouseDoubleClickTime;
    public float MouseDoubleClickMaxDist;
    public float MouseDragThreshold;
    public float KeyRepeatDelay;
    public float KeyRepeatRate;
    public unsafe void* UserData;
    public unsafe ImFontAtlas* Fonts;
    public float FontGlobalScale;
    public byte FontAllowUserScaling;
    public unsafe ImFont* FontDefault;
    public Vector2 DisplayFramebufferScale;
    public byte ConfigDockingNoSplit;
    public byte ConfigDockingWithShift;
    public byte ConfigDockingAlwaysTabBar;
    public byte ConfigDockingTransparentPayload;
    public byte ConfigViewportsNoAutoMerge;
    public byte ConfigViewportsNoTaskBarIcon;
    public byte ConfigViewportsNoDecoration;
    public byte ConfigViewportsNoDefaultParent;
    public byte MouseDrawCursor;
    public byte ConfigMacOSXBehaviors;
    public byte ConfigInputTrickleEventQueue;
    public byte ConfigInputTextCursorBlink;
    public byte ConfigDragClickToInputText;
    public byte ConfigWindowsResizeFromEdges;
    public byte ConfigWindowsMoveFromTitleBarOnly;
    public float ConfigMemoryCompactTimer;
    public unsafe byte* BackendPlatformName;
    public unsafe byte* BackendRendererName;
    public unsafe void* BackendPlatformUserData;
    public unsafe void* BackendRendererUserData;
    public unsafe void* BackendLanguageUserData;
    public IntPtr GetClipboardTextFn;
    public IntPtr SetClipboardTextFn;
    public unsafe void* ClipboardUserData;
    public IntPtr SetPlatformImeDataFn;
    public unsafe void* _UnusedPadding;
    public byte WantCaptureMouse;
    public byte WantCaptureKeyboard;
    public byte WantTextInput;
    public byte WantSetMousePos;
    public byte WantSaveIniSettings;
    public byte NavActive;
    public byte NavVisible;
    public float Framerate;
    public int MetricsRenderVertices;
    public int MetricsRenderIndices;
    public int MetricsRenderWindows;
    public int MetricsActiveWindows;
    public int MetricsActiveAllocations;
    public Vector2 MouseDelta;
    public unsafe fixed int KeyMap[645];
    public unsafe fixed byte KeysDown[645];
    public Vector2 MousePos;
    public unsafe fixed byte MouseDown[5];
    public float MouseWheel;
    public float MouseWheelH;
    public uint MouseHoveredViewport;
    public byte KeyCtrl;
    public byte KeyShift;
    public byte KeyAlt;
    public byte KeySuper;
    public unsafe fixed float NavInputs[20];
    public ImGuiModFlags KeyMods;
    public ImGuiKeyData KeysData_0;
    public ImGuiKeyData KeysData_1;
    public ImGuiKeyData KeysData_2;
    public ImGuiKeyData KeysData_3;
    public ImGuiKeyData KeysData_4;
    public ImGuiKeyData KeysData_5;
    public ImGuiKeyData KeysData_6;
    public ImGuiKeyData KeysData_7;
    public ImGuiKeyData KeysData_8;
    public ImGuiKeyData KeysData_9;
    public ImGuiKeyData KeysData_10;
    public ImGuiKeyData KeysData_11;
    public ImGuiKeyData KeysData_12;
    public ImGuiKeyData KeysData_13;
    public ImGuiKeyData KeysData_14;
    public ImGuiKeyData KeysData_15;
    public ImGuiKeyData KeysData_16;
    public ImGuiKeyData KeysData_17;
    public ImGuiKeyData KeysData_18;
    public ImGuiKeyData KeysData_19;
    public ImGuiKeyData KeysData_20;
    public ImGuiKeyData KeysData_21;
    public ImGuiKeyData KeysData_22;
    public ImGuiKeyData KeysData_23;
    public ImGuiKeyData KeysData_24;
    public ImGuiKeyData KeysData_25;
    public ImGuiKeyData KeysData_26;
    public ImGuiKeyData KeysData_27;
    public ImGuiKeyData KeysData_28;
    public ImGuiKeyData KeysData_29;
    public ImGuiKeyData KeysData_30;
    public ImGuiKeyData KeysData_31;
    public ImGuiKeyData KeysData_32;
    public ImGuiKeyData KeysData_33;
    public ImGuiKeyData KeysData_34;
    public ImGuiKeyData KeysData_35;
    public ImGuiKeyData KeysData_36;
    public ImGuiKeyData KeysData_37;
    public ImGuiKeyData KeysData_38;
    public ImGuiKeyData KeysData_39;
    public ImGuiKeyData KeysData_40;
    public ImGuiKeyData KeysData_41;
    public ImGuiKeyData KeysData_42;
    public ImGuiKeyData KeysData_43;
    public ImGuiKeyData KeysData_44;
    public ImGuiKeyData KeysData_45;
    public ImGuiKeyData KeysData_46;
    public ImGuiKeyData KeysData_47;
    public ImGuiKeyData KeysData_48;
    public ImGuiKeyData KeysData_49;
    public ImGuiKeyData KeysData_50;
    public ImGuiKeyData KeysData_51;
    public ImGuiKeyData KeysData_52;
    public ImGuiKeyData KeysData_53;
    public ImGuiKeyData KeysData_54;
    public ImGuiKeyData KeysData_55;
    public ImGuiKeyData KeysData_56;
    public ImGuiKeyData KeysData_57;
    public ImGuiKeyData KeysData_58;
    public ImGuiKeyData KeysData_59;
    public ImGuiKeyData KeysData_60;
    public ImGuiKeyData KeysData_61;
    public ImGuiKeyData KeysData_62;
    public ImGuiKeyData KeysData_63;
    public ImGuiKeyData KeysData_64;
    public ImGuiKeyData KeysData_65;
    public ImGuiKeyData KeysData_66;
    public ImGuiKeyData KeysData_67;
    public ImGuiKeyData KeysData_68;
    public ImGuiKeyData KeysData_69;
    public ImGuiKeyData KeysData_70;
    public ImGuiKeyData KeysData_71;
    public ImGuiKeyData KeysData_72;
    public ImGuiKeyData KeysData_73;
    public ImGuiKeyData KeysData_74;
    public ImGuiKeyData KeysData_75;
    public ImGuiKeyData KeysData_76;
    public ImGuiKeyData KeysData_77;
    public ImGuiKeyData KeysData_78;
    public ImGuiKeyData KeysData_79;
    public ImGuiKeyData KeysData_80;
    public ImGuiKeyData KeysData_81;
    public ImGuiKeyData KeysData_82;
    public ImGuiKeyData KeysData_83;
    public ImGuiKeyData KeysData_84;
    public ImGuiKeyData KeysData_85;
    public ImGuiKeyData KeysData_86;
    public ImGuiKeyData KeysData_87;
    public ImGuiKeyData KeysData_88;
    public ImGuiKeyData KeysData_89;
    public ImGuiKeyData KeysData_90;
    public ImGuiKeyData KeysData_91;
    public ImGuiKeyData KeysData_92;
    public ImGuiKeyData KeysData_93;
    public ImGuiKeyData KeysData_94;
    public ImGuiKeyData KeysData_95;
    public ImGuiKeyData KeysData_96;
    public ImGuiKeyData KeysData_97;
    public ImGuiKeyData KeysData_98;
    public ImGuiKeyData KeysData_99;
    public ImGuiKeyData KeysData_100;
    public ImGuiKeyData KeysData_101;
    public ImGuiKeyData KeysData_102;
    public ImGuiKeyData KeysData_103;
    public ImGuiKeyData KeysData_104;
    public ImGuiKeyData KeysData_105;
    public ImGuiKeyData KeysData_106;
    public ImGuiKeyData KeysData_107;
    public ImGuiKeyData KeysData_108;
    public ImGuiKeyData KeysData_109;
    public ImGuiKeyData KeysData_110;
    public ImGuiKeyData KeysData_111;
    public ImGuiKeyData KeysData_112;
    public ImGuiKeyData KeysData_113;
    public ImGuiKeyData KeysData_114;
    public ImGuiKeyData KeysData_115;
    public ImGuiKeyData KeysData_116;
    public ImGuiKeyData KeysData_117;
    public ImGuiKeyData KeysData_118;
    public ImGuiKeyData KeysData_119;
    public ImGuiKeyData KeysData_120;
    public ImGuiKeyData KeysData_121;
    public ImGuiKeyData KeysData_122;
    public ImGuiKeyData KeysData_123;
    public ImGuiKeyData KeysData_124;
    public ImGuiKeyData KeysData_125;
    public ImGuiKeyData KeysData_126;
    public ImGuiKeyData KeysData_127;
    public ImGuiKeyData KeysData_128;
    public ImGuiKeyData KeysData_129;
    public ImGuiKeyData KeysData_130;
    public ImGuiKeyData KeysData_131;
    public ImGuiKeyData KeysData_132;
    public ImGuiKeyData KeysData_133;
    public ImGuiKeyData KeysData_134;
    public ImGuiKeyData KeysData_135;
    public ImGuiKeyData KeysData_136;
    public ImGuiKeyData KeysData_137;
    public ImGuiKeyData KeysData_138;
    public ImGuiKeyData KeysData_139;
    public ImGuiKeyData KeysData_140;
    public ImGuiKeyData KeysData_141;
    public ImGuiKeyData KeysData_142;
    public ImGuiKeyData KeysData_143;
    public ImGuiKeyData KeysData_144;
    public ImGuiKeyData KeysData_145;
    public ImGuiKeyData KeysData_146;
    public ImGuiKeyData KeysData_147;
    public ImGuiKeyData KeysData_148;
    public ImGuiKeyData KeysData_149;
    public ImGuiKeyData KeysData_150;
    public ImGuiKeyData KeysData_151;
    public ImGuiKeyData KeysData_152;
    public ImGuiKeyData KeysData_153;
    public ImGuiKeyData KeysData_154;
    public ImGuiKeyData KeysData_155;
    public ImGuiKeyData KeysData_156;
    public ImGuiKeyData KeysData_157;
    public ImGuiKeyData KeysData_158;
    public ImGuiKeyData KeysData_159;
    public ImGuiKeyData KeysData_160;
    public ImGuiKeyData KeysData_161;
    public ImGuiKeyData KeysData_162;
    public ImGuiKeyData KeysData_163;
    public ImGuiKeyData KeysData_164;
    public ImGuiKeyData KeysData_165;
    public ImGuiKeyData KeysData_166;
    public ImGuiKeyData KeysData_167;
    public ImGuiKeyData KeysData_168;
    public ImGuiKeyData KeysData_169;
    public ImGuiKeyData KeysData_170;
    public ImGuiKeyData KeysData_171;
    public ImGuiKeyData KeysData_172;
    public ImGuiKeyData KeysData_173;
    public ImGuiKeyData KeysData_174;
    public ImGuiKeyData KeysData_175;
    public ImGuiKeyData KeysData_176;
    public ImGuiKeyData KeysData_177;
    public ImGuiKeyData KeysData_178;
    public ImGuiKeyData KeysData_179;
    public ImGuiKeyData KeysData_180;
    public ImGuiKeyData KeysData_181;
    public ImGuiKeyData KeysData_182;
    public ImGuiKeyData KeysData_183;
    public ImGuiKeyData KeysData_184;
    public ImGuiKeyData KeysData_185;
    public ImGuiKeyData KeysData_186;
    public ImGuiKeyData KeysData_187;
    public ImGuiKeyData KeysData_188;
    public ImGuiKeyData KeysData_189;
    public ImGuiKeyData KeysData_190;
    public ImGuiKeyData KeysData_191;
    public ImGuiKeyData KeysData_192;
    public ImGuiKeyData KeysData_193;
    public ImGuiKeyData KeysData_194;
    public ImGuiKeyData KeysData_195;
    public ImGuiKeyData KeysData_196;
    public ImGuiKeyData KeysData_197;
    public ImGuiKeyData KeysData_198;
    public ImGuiKeyData KeysData_199;
    public ImGuiKeyData KeysData_200;
    public ImGuiKeyData KeysData_201;
    public ImGuiKeyData KeysData_202;
    public ImGuiKeyData KeysData_203;
    public ImGuiKeyData KeysData_204;
    public ImGuiKeyData KeysData_205;
    public ImGuiKeyData KeysData_206;
    public ImGuiKeyData KeysData_207;
    public ImGuiKeyData KeysData_208;
    public ImGuiKeyData KeysData_209;
    public ImGuiKeyData KeysData_210;
    public ImGuiKeyData KeysData_211;
    public ImGuiKeyData KeysData_212;
    public ImGuiKeyData KeysData_213;
    public ImGuiKeyData KeysData_214;
    public ImGuiKeyData KeysData_215;
    public ImGuiKeyData KeysData_216;
    public ImGuiKeyData KeysData_217;
    public ImGuiKeyData KeysData_218;
    public ImGuiKeyData KeysData_219;
    public ImGuiKeyData KeysData_220;
    public ImGuiKeyData KeysData_221;
    public ImGuiKeyData KeysData_222;
    public ImGuiKeyData KeysData_223;
    public ImGuiKeyData KeysData_224;
    public ImGuiKeyData KeysData_225;
    public ImGuiKeyData KeysData_226;
    public ImGuiKeyData KeysData_227;
    public ImGuiKeyData KeysData_228;
    public ImGuiKeyData KeysData_229;
    public ImGuiKeyData KeysData_230;
    public ImGuiKeyData KeysData_231;
    public ImGuiKeyData KeysData_232;
    public ImGuiKeyData KeysData_233;
    public ImGuiKeyData KeysData_234;
    public ImGuiKeyData KeysData_235;
    public ImGuiKeyData KeysData_236;
    public ImGuiKeyData KeysData_237;
    public ImGuiKeyData KeysData_238;
    public ImGuiKeyData KeysData_239;
    public ImGuiKeyData KeysData_240;
    public ImGuiKeyData KeysData_241;
    public ImGuiKeyData KeysData_242;
    public ImGuiKeyData KeysData_243;
    public ImGuiKeyData KeysData_244;
    public ImGuiKeyData KeysData_245;
    public ImGuiKeyData KeysData_246;
    public ImGuiKeyData KeysData_247;
    public ImGuiKeyData KeysData_248;
    public ImGuiKeyData KeysData_249;
    public ImGuiKeyData KeysData_250;
    public ImGuiKeyData KeysData_251;
    public ImGuiKeyData KeysData_252;
    public ImGuiKeyData KeysData_253;
    public ImGuiKeyData KeysData_254;
    public ImGuiKeyData KeysData_255;
    public ImGuiKeyData KeysData_256;
    public ImGuiKeyData KeysData_257;
    public ImGuiKeyData KeysData_258;
    public ImGuiKeyData KeysData_259;
    public ImGuiKeyData KeysData_260;
    public ImGuiKeyData KeysData_261;
    public ImGuiKeyData KeysData_262;
    public ImGuiKeyData KeysData_263;
    public ImGuiKeyData KeysData_264;
    public ImGuiKeyData KeysData_265;
    public ImGuiKeyData KeysData_266;
    public ImGuiKeyData KeysData_267;
    public ImGuiKeyData KeysData_268;
    public ImGuiKeyData KeysData_269;
    public ImGuiKeyData KeysData_270;
    public ImGuiKeyData KeysData_271;
    public ImGuiKeyData KeysData_272;
    public ImGuiKeyData KeysData_273;
    public ImGuiKeyData KeysData_274;
    public ImGuiKeyData KeysData_275;
    public ImGuiKeyData KeysData_276;
    public ImGuiKeyData KeysData_277;
    public ImGuiKeyData KeysData_278;
    public ImGuiKeyData KeysData_279;
    public ImGuiKeyData KeysData_280;
    public ImGuiKeyData KeysData_281;
    public ImGuiKeyData KeysData_282;
    public ImGuiKeyData KeysData_283;
    public ImGuiKeyData KeysData_284;
    public ImGuiKeyData KeysData_285;
    public ImGuiKeyData KeysData_286;
    public ImGuiKeyData KeysData_287;
    public ImGuiKeyData KeysData_288;
    public ImGuiKeyData KeysData_289;
    public ImGuiKeyData KeysData_290;
    public ImGuiKeyData KeysData_291;
    public ImGuiKeyData KeysData_292;
    public ImGuiKeyData KeysData_293;
    public ImGuiKeyData KeysData_294;
    public ImGuiKeyData KeysData_295;
    public ImGuiKeyData KeysData_296;
    public ImGuiKeyData KeysData_297;
    public ImGuiKeyData KeysData_298;
    public ImGuiKeyData KeysData_299;
    public ImGuiKeyData KeysData_300;
    public ImGuiKeyData KeysData_301;
    public ImGuiKeyData KeysData_302;
    public ImGuiKeyData KeysData_303;
    public ImGuiKeyData KeysData_304;
    public ImGuiKeyData KeysData_305;
    public ImGuiKeyData KeysData_306;
    public ImGuiKeyData KeysData_307;
    public ImGuiKeyData KeysData_308;
    public ImGuiKeyData KeysData_309;
    public ImGuiKeyData KeysData_310;
    public ImGuiKeyData KeysData_311;
    public ImGuiKeyData KeysData_312;
    public ImGuiKeyData KeysData_313;
    public ImGuiKeyData KeysData_314;
    public ImGuiKeyData KeysData_315;
    public ImGuiKeyData KeysData_316;
    public ImGuiKeyData KeysData_317;
    public ImGuiKeyData KeysData_318;
    public ImGuiKeyData KeysData_319;
    public ImGuiKeyData KeysData_320;
    public ImGuiKeyData KeysData_321;
    public ImGuiKeyData KeysData_322;
    public ImGuiKeyData KeysData_323;
    public ImGuiKeyData KeysData_324;
    public ImGuiKeyData KeysData_325;
    public ImGuiKeyData KeysData_326;
    public ImGuiKeyData KeysData_327;
    public ImGuiKeyData KeysData_328;
    public ImGuiKeyData KeysData_329;
    public ImGuiKeyData KeysData_330;
    public ImGuiKeyData KeysData_331;
    public ImGuiKeyData KeysData_332;
    public ImGuiKeyData KeysData_333;
    public ImGuiKeyData KeysData_334;
    public ImGuiKeyData KeysData_335;
    public ImGuiKeyData KeysData_336;
    public ImGuiKeyData KeysData_337;
    public ImGuiKeyData KeysData_338;
    public ImGuiKeyData KeysData_339;
    public ImGuiKeyData KeysData_340;
    public ImGuiKeyData KeysData_341;
    public ImGuiKeyData KeysData_342;
    public ImGuiKeyData KeysData_343;
    public ImGuiKeyData KeysData_344;
    public ImGuiKeyData KeysData_345;
    public ImGuiKeyData KeysData_346;
    public ImGuiKeyData KeysData_347;
    public ImGuiKeyData KeysData_348;
    public ImGuiKeyData KeysData_349;
    public ImGuiKeyData KeysData_350;
    public ImGuiKeyData KeysData_351;
    public ImGuiKeyData KeysData_352;
    public ImGuiKeyData KeysData_353;
    public ImGuiKeyData KeysData_354;
    public ImGuiKeyData KeysData_355;
    public ImGuiKeyData KeysData_356;
    public ImGuiKeyData KeysData_357;
    public ImGuiKeyData KeysData_358;
    public ImGuiKeyData KeysData_359;
    public ImGuiKeyData KeysData_360;
    public ImGuiKeyData KeysData_361;
    public ImGuiKeyData KeysData_362;
    public ImGuiKeyData KeysData_363;
    public ImGuiKeyData KeysData_364;
    public ImGuiKeyData KeysData_365;
    public ImGuiKeyData KeysData_366;
    public ImGuiKeyData KeysData_367;
    public ImGuiKeyData KeysData_368;
    public ImGuiKeyData KeysData_369;
    public ImGuiKeyData KeysData_370;
    public ImGuiKeyData KeysData_371;
    public ImGuiKeyData KeysData_372;
    public ImGuiKeyData KeysData_373;
    public ImGuiKeyData KeysData_374;
    public ImGuiKeyData KeysData_375;
    public ImGuiKeyData KeysData_376;
    public ImGuiKeyData KeysData_377;
    public ImGuiKeyData KeysData_378;
    public ImGuiKeyData KeysData_379;
    public ImGuiKeyData KeysData_380;
    public ImGuiKeyData KeysData_381;
    public ImGuiKeyData KeysData_382;
    public ImGuiKeyData KeysData_383;
    public ImGuiKeyData KeysData_384;
    public ImGuiKeyData KeysData_385;
    public ImGuiKeyData KeysData_386;
    public ImGuiKeyData KeysData_387;
    public ImGuiKeyData KeysData_388;
    public ImGuiKeyData KeysData_389;
    public ImGuiKeyData KeysData_390;
    public ImGuiKeyData KeysData_391;
    public ImGuiKeyData KeysData_392;
    public ImGuiKeyData KeysData_393;
    public ImGuiKeyData KeysData_394;
    public ImGuiKeyData KeysData_395;
    public ImGuiKeyData KeysData_396;
    public ImGuiKeyData KeysData_397;
    public ImGuiKeyData KeysData_398;
    public ImGuiKeyData KeysData_399;
    public ImGuiKeyData KeysData_400;
    public ImGuiKeyData KeysData_401;
    public ImGuiKeyData KeysData_402;
    public ImGuiKeyData KeysData_403;
    public ImGuiKeyData KeysData_404;
    public ImGuiKeyData KeysData_405;
    public ImGuiKeyData KeysData_406;
    public ImGuiKeyData KeysData_407;
    public ImGuiKeyData KeysData_408;
    public ImGuiKeyData KeysData_409;
    public ImGuiKeyData KeysData_410;
    public ImGuiKeyData KeysData_411;
    public ImGuiKeyData KeysData_412;
    public ImGuiKeyData KeysData_413;
    public ImGuiKeyData KeysData_414;
    public ImGuiKeyData KeysData_415;
    public ImGuiKeyData KeysData_416;
    public ImGuiKeyData KeysData_417;
    public ImGuiKeyData KeysData_418;
    public ImGuiKeyData KeysData_419;
    public ImGuiKeyData KeysData_420;
    public ImGuiKeyData KeysData_421;
    public ImGuiKeyData KeysData_422;
    public ImGuiKeyData KeysData_423;
    public ImGuiKeyData KeysData_424;
    public ImGuiKeyData KeysData_425;
    public ImGuiKeyData KeysData_426;
    public ImGuiKeyData KeysData_427;
    public ImGuiKeyData KeysData_428;
    public ImGuiKeyData KeysData_429;
    public ImGuiKeyData KeysData_430;
    public ImGuiKeyData KeysData_431;
    public ImGuiKeyData KeysData_432;
    public ImGuiKeyData KeysData_433;
    public ImGuiKeyData KeysData_434;
    public ImGuiKeyData KeysData_435;
    public ImGuiKeyData KeysData_436;
    public ImGuiKeyData KeysData_437;
    public ImGuiKeyData KeysData_438;
    public ImGuiKeyData KeysData_439;
    public ImGuiKeyData KeysData_440;
    public ImGuiKeyData KeysData_441;
    public ImGuiKeyData KeysData_442;
    public ImGuiKeyData KeysData_443;
    public ImGuiKeyData KeysData_444;
    public ImGuiKeyData KeysData_445;
    public ImGuiKeyData KeysData_446;
    public ImGuiKeyData KeysData_447;
    public ImGuiKeyData KeysData_448;
    public ImGuiKeyData KeysData_449;
    public ImGuiKeyData KeysData_450;
    public ImGuiKeyData KeysData_451;
    public ImGuiKeyData KeysData_452;
    public ImGuiKeyData KeysData_453;
    public ImGuiKeyData KeysData_454;
    public ImGuiKeyData KeysData_455;
    public ImGuiKeyData KeysData_456;
    public ImGuiKeyData KeysData_457;
    public ImGuiKeyData KeysData_458;
    public ImGuiKeyData KeysData_459;
    public ImGuiKeyData KeysData_460;
    public ImGuiKeyData KeysData_461;
    public ImGuiKeyData KeysData_462;
    public ImGuiKeyData KeysData_463;
    public ImGuiKeyData KeysData_464;
    public ImGuiKeyData KeysData_465;
    public ImGuiKeyData KeysData_466;
    public ImGuiKeyData KeysData_467;
    public ImGuiKeyData KeysData_468;
    public ImGuiKeyData KeysData_469;
    public ImGuiKeyData KeysData_470;
    public ImGuiKeyData KeysData_471;
    public ImGuiKeyData KeysData_472;
    public ImGuiKeyData KeysData_473;
    public ImGuiKeyData KeysData_474;
    public ImGuiKeyData KeysData_475;
    public ImGuiKeyData KeysData_476;
    public ImGuiKeyData KeysData_477;
    public ImGuiKeyData KeysData_478;
    public ImGuiKeyData KeysData_479;
    public ImGuiKeyData KeysData_480;
    public ImGuiKeyData KeysData_481;
    public ImGuiKeyData KeysData_482;
    public ImGuiKeyData KeysData_483;
    public ImGuiKeyData KeysData_484;
    public ImGuiKeyData KeysData_485;
    public ImGuiKeyData KeysData_486;
    public ImGuiKeyData KeysData_487;
    public ImGuiKeyData KeysData_488;
    public ImGuiKeyData KeysData_489;
    public ImGuiKeyData KeysData_490;
    public ImGuiKeyData KeysData_491;
    public ImGuiKeyData KeysData_492;
    public ImGuiKeyData KeysData_493;
    public ImGuiKeyData KeysData_494;
    public ImGuiKeyData KeysData_495;
    public ImGuiKeyData KeysData_496;
    public ImGuiKeyData KeysData_497;
    public ImGuiKeyData KeysData_498;
    public ImGuiKeyData KeysData_499;
    public ImGuiKeyData KeysData_500;
    public ImGuiKeyData KeysData_501;
    public ImGuiKeyData KeysData_502;
    public ImGuiKeyData KeysData_503;
    public ImGuiKeyData KeysData_504;
    public ImGuiKeyData KeysData_505;
    public ImGuiKeyData KeysData_506;
    public ImGuiKeyData KeysData_507;
    public ImGuiKeyData KeysData_508;
    public ImGuiKeyData KeysData_509;
    public ImGuiKeyData KeysData_510;
    public ImGuiKeyData KeysData_511;
    public ImGuiKeyData KeysData_512;
    public ImGuiKeyData KeysData_513;
    public ImGuiKeyData KeysData_514;
    public ImGuiKeyData KeysData_515;
    public ImGuiKeyData KeysData_516;
    public ImGuiKeyData KeysData_517;
    public ImGuiKeyData KeysData_518;
    public ImGuiKeyData KeysData_519;
    public ImGuiKeyData KeysData_520;
    public ImGuiKeyData KeysData_521;
    public ImGuiKeyData KeysData_522;
    public ImGuiKeyData KeysData_523;
    public ImGuiKeyData KeysData_524;
    public ImGuiKeyData KeysData_525;
    public ImGuiKeyData KeysData_526;
    public ImGuiKeyData KeysData_527;
    public ImGuiKeyData KeysData_528;
    public ImGuiKeyData KeysData_529;
    public ImGuiKeyData KeysData_530;
    public ImGuiKeyData KeysData_531;
    public ImGuiKeyData KeysData_532;
    public ImGuiKeyData KeysData_533;
    public ImGuiKeyData KeysData_534;
    public ImGuiKeyData KeysData_535;
    public ImGuiKeyData KeysData_536;
    public ImGuiKeyData KeysData_537;
    public ImGuiKeyData KeysData_538;
    public ImGuiKeyData KeysData_539;
    public ImGuiKeyData KeysData_540;
    public ImGuiKeyData KeysData_541;
    public ImGuiKeyData KeysData_542;
    public ImGuiKeyData KeysData_543;
    public ImGuiKeyData KeysData_544;
    public ImGuiKeyData KeysData_545;
    public ImGuiKeyData KeysData_546;
    public ImGuiKeyData KeysData_547;
    public ImGuiKeyData KeysData_548;
    public ImGuiKeyData KeysData_549;
    public ImGuiKeyData KeysData_550;
    public ImGuiKeyData KeysData_551;
    public ImGuiKeyData KeysData_552;
    public ImGuiKeyData KeysData_553;
    public ImGuiKeyData KeysData_554;
    public ImGuiKeyData KeysData_555;
    public ImGuiKeyData KeysData_556;
    public ImGuiKeyData KeysData_557;
    public ImGuiKeyData KeysData_558;
    public ImGuiKeyData KeysData_559;
    public ImGuiKeyData KeysData_560;
    public ImGuiKeyData KeysData_561;
    public ImGuiKeyData KeysData_562;
    public ImGuiKeyData KeysData_563;
    public ImGuiKeyData KeysData_564;
    public ImGuiKeyData KeysData_565;
    public ImGuiKeyData KeysData_566;
    public ImGuiKeyData KeysData_567;
    public ImGuiKeyData KeysData_568;
    public ImGuiKeyData KeysData_569;
    public ImGuiKeyData KeysData_570;
    public ImGuiKeyData KeysData_571;
    public ImGuiKeyData KeysData_572;
    public ImGuiKeyData KeysData_573;
    public ImGuiKeyData KeysData_574;
    public ImGuiKeyData KeysData_575;
    public ImGuiKeyData KeysData_576;
    public ImGuiKeyData KeysData_577;
    public ImGuiKeyData KeysData_578;
    public ImGuiKeyData KeysData_579;
    public ImGuiKeyData KeysData_580;
    public ImGuiKeyData KeysData_581;
    public ImGuiKeyData KeysData_582;
    public ImGuiKeyData KeysData_583;
    public ImGuiKeyData KeysData_584;
    public ImGuiKeyData KeysData_585;
    public ImGuiKeyData KeysData_586;
    public ImGuiKeyData KeysData_587;
    public ImGuiKeyData KeysData_588;
    public ImGuiKeyData KeysData_589;
    public ImGuiKeyData KeysData_590;
    public ImGuiKeyData KeysData_591;
    public ImGuiKeyData KeysData_592;
    public ImGuiKeyData KeysData_593;
    public ImGuiKeyData KeysData_594;
    public ImGuiKeyData KeysData_595;
    public ImGuiKeyData KeysData_596;
    public ImGuiKeyData KeysData_597;
    public ImGuiKeyData KeysData_598;
    public ImGuiKeyData KeysData_599;
    public ImGuiKeyData KeysData_600;
    public ImGuiKeyData KeysData_601;
    public ImGuiKeyData KeysData_602;
    public ImGuiKeyData KeysData_603;
    public ImGuiKeyData KeysData_604;
    public ImGuiKeyData KeysData_605;
    public ImGuiKeyData KeysData_606;
    public ImGuiKeyData KeysData_607;
    public ImGuiKeyData KeysData_608;
    public ImGuiKeyData KeysData_609;
    public ImGuiKeyData KeysData_610;
    public ImGuiKeyData KeysData_611;
    public ImGuiKeyData KeysData_612;
    public ImGuiKeyData KeysData_613;
    public ImGuiKeyData KeysData_614;
    public ImGuiKeyData KeysData_615;
    public ImGuiKeyData KeysData_616;
    public ImGuiKeyData KeysData_617;
    public ImGuiKeyData KeysData_618;
    public ImGuiKeyData KeysData_619;
    public ImGuiKeyData KeysData_620;
    public ImGuiKeyData KeysData_621;
    public ImGuiKeyData KeysData_622;
    public ImGuiKeyData KeysData_623;
    public ImGuiKeyData KeysData_624;
    public ImGuiKeyData KeysData_625;
    public ImGuiKeyData KeysData_626;
    public ImGuiKeyData KeysData_627;
    public ImGuiKeyData KeysData_628;
    public ImGuiKeyData KeysData_629;
    public ImGuiKeyData KeysData_630;
    public ImGuiKeyData KeysData_631;
    public ImGuiKeyData KeysData_632;
    public ImGuiKeyData KeysData_633;
    public ImGuiKeyData KeysData_634;
    public ImGuiKeyData KeysData_635;
    public ImGuiKeyData KeysData_636;
    public ImGuiKeyData KeysData_637;
    public ImGuiKeyData KeysData_638;
    public ImGuiKeyData KeysData_639;
    public ImGuiKeyData KeysData_640;
    public ImGuiKeyData KeysData_641;
    public ImGuiKeyData KeysData_642;
    public ImGuiKeyData KeysData_643;
    public ImGuiKeyData KeysData_644;
    public byte WantCaptureMouseUnlessPopupClose;
    public Vector2 MousePosPrev;
    public Vector2 MouseClickedPos_0;
    public Vector2 MouseClickedPos_1;
    public Vector2 MouseClickedPos_2;
    public Vector2 MouseClickedPos_3;
    public Vector2 MouseClickedPos_4;
    public unsafe fixed double MouseClickedTime[5];
    public unsafe fixed byte MouseClicked[5];
    public unsafe fixed byte MouseDoubleClicked[5];
    public unsafe fixed ushort MouseClickedCount[5];
    public unsafe fixed ushort MouseClickedLastCount[5];
    public unsafe fixed byte MouseReleased[5];
    public unsafe fixed byte MouseDownOwned[5];
    public unsafe fixed byte MouseDownOwnedUnlessPopupClose[5];
    public unsafe fixed float MouseDownDuration[5];
    public unsafe fixed float MouseDownDurationPrev[5];
    public Vector2 MouseDragMaxDistanceAbs_0;
    public Vector2 MouseDragMaxDistanceAbs_1;
    public Vector2 MouseDragMaxDistanceAbs_2;
    public Vector2 MouseDragMaxDistanceAbs_3;
    public Vector2 MouseDragMaxDistanceAbs_4;
    public unsafe fixed float MouseDragMaxDistanceSqr[5];
    public unsafe fixed float NavInputsDownDuration[20];
    public unsafe fixed float NavInputsDownDurationPrev[20];
    public float PenPressure;
    public byte AppFocusLost;
    public byte AppAcceptingEvents;
    public sbyte BackendUsingLegacyKeyArrays;
    public byte BackendUsingLegacyNavInputArray;
    public ushort InputQueueSurrogate;
    public ImVector InputQueueCharacters;
  }
}
