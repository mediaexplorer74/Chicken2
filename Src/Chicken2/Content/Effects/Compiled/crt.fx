MGFX
 ΗD�   ps_uniforms_vec4                #ifdef GL_ES
precision mediump float;
precision mediump int;
#endif

uniform vec4 ps_uniforms_vec4[1];
const vec4 ps_c1 = vec4(-0.5, 4.2, -0.25, -0.525);
const vec4 ps_c2 = vec4(0.25, 0.515, 0.499, 0.999);
const vec4 ps_c3 = vec4(0.0, 1.0, 1.025, 1.015);
const vec4 ps_c4 = vec4(1000.0, 0.6, 0.03, 0.0);
const vec4 ps_c5 = vec4(0.2, 0.25, 0.47, 2.0);
const vec4 ps_c6 = vec4(2.0, 0.5, -2.0, -0.5);
vec4 ps_r0;
vec4 ps_r1;
vec4 ps_r2;
vec4 ps_r3;
vec4 ps_r4;
#define ps_c0 ps_uniforms_vec4[0]
uniform sampler2D ps_s0;
varying vec4 vTexCoord0;
#define ps_v0 vTexCoord0
#define ps_oC0 gl_FragColor

void main()
{
	ps_r0.x = ps_c5.x;
	ps_r0.x = ps_r0.x * ps_c0.x;
	ps_r0.x = fract(abs(ps_r0.x));
	ps_r0.x = ((ps_c0.x >= 0.0) ? ps_r0.x : -ps_r0.x);
	ps_r1 = ps_c1.xxxx + ps_v0.xyxy;
	ps_r0.y = dot(ps_r1.zw, ps_r1.zw) + ps_c1.y;
	ps_r1 = ps_r0.yyyy * ps_r1;
	ps_r0.y = (ps_r1.w * ps_c5.y) + ps_c5.z;
	ps_r0.y = -ps_r0.x + ps_r0.y;
	ps_r0.y = ((ps_r0.y >= 0.0) ? -ps_c3.x : -ps_c3.y);
	ps_r2 = (ps_r1.zwzw * -ps_c1.zzzz) + -ps_c1.xxww;
	ps_r1 = (ps_r1 * ps_c2.xxxx) + ps_c2.yyzz;
	ps_r1.x = ((ps_r1.x >= 0.0) ? ps_c3.x : ps_c3.y);
	ps_r1.y = ((ps_r1.y >= 0.0) ? ps_c3.x : ps_c3.y);
	ps_r1.z = ((ps_r1.z >= 0.0) ? ps_c3.x : ps_c3.y);
	ps_r1.w = ((ps_r1.w >= 0.0) ? ps_c3.x : ps_c3.y);
	ps_r0.zw = ps_r1.yw + ps_r1.xz;
	ps_r0.x = ps_r0.x + -ps_r2.y;
	ps_r0.y = ((ps_r0.x >= 0.0) ? ps_c3.x : ps_r0.y);
	ps_r1 = texture2D(ps_s0, ps_r2.xy);
	ps_r3.xyz = (ps_r0.xxx * ps_c5.www) + ps_r1.xyz;
	ps_r1.xyz = ((ps_r0.y >= 0.0) ? ps_r1.xyz : ps_r3.xyz);
	ps_r3.xyz = ps_r1.xyz * ps_c4.yyy;
	ps_r3.w = ps_c3.x;
	ps_r0.x = ps_r2.y * ps_c4.x;
	ps_r0.y = fract(ps_r0.x);
	ps_r0.x = -ps_r0.y + ps_r0.x;
	ps_r4.xy = ((ps_r0.x >= 0.0) ? ps_c6.xy : ps_c6.zw);
	ps_r0.x = ps_r0.x * ps_r4.y;
	ps_r0.x = fract(ps_r0.x);
	ps_r0.x = ps_r0.x * ps_r4.x;
	ps_r1 = ((-abs(ps_r0.x) >= 0.0) ? ps_r1 : ps_r3);
	ps_r0.xy = -ps_r2.xy + ps_c2.ww;
	ps_r0.x = ((ps_r0.x >= 0.0) ? ps_c3.x : ps_c3.y);
	ps_r0.y = ((ps_r0.y >= 0.0) ? ps_c3.x : ps_c3.y);
	ps_r0.x = ps_r0.y + ps_r0.x;
	ps_r1 = ((-ps_r0.x >= 0.0) ? ps_r1 : ps_c3.xxxx);
	ps_r1 = ((-ps_r0.w >= 0.0) ? ps_r1 : ps_c3.xxxx);
	ps_r3 = -ps_r2.xyxy + ps_c3.zzww;
	ps_r0.x = ((ps_r2.z >= 0.0) ? ps_c3.x : ps_c3.y);
	ps_r0.y = ((ps_r2.w >= 0.0) ? ps_c3.x : ps_c3.y);
	ps_r0.x = ps_r0.y + ps_r0.x;
	ps_r2.x = ((ps_r3.x >= 0.0) ? ps_c3.x : ps_c3.y);
	ps_r2.y = ((ps_r3.y >= 0.0) ? ps_c3.x : ps_c3.y);
	ps_r2.z = ((ps_r3.z >= 0.0) ? ps_c3.x : ps_c3.y);
	ps_r2.w = ((ps_r3.w >= 0.0) ? ps_c3.x : ps_c3.y);
	ps_r0.yw = ps_r2.yw + ps_r2.xz;
	ps_r1 = ((-ps_r0.w >= 0.0) ? ps_r1 : ps_c4.zzzw);
	ps_r1 = ((-ps_r0.z >= 0.0) ? ps_r1 : ps_c4.zzzw);
	ps_r1 = ((-ps_r0.y >= 0.0) ? ps_r1 : ps_c3.xxxx);
	ps_oC0 = ((-ps_r0.x >= 0.0) ? ps_r1 : ps_c3.xxxx);
}

    ps_s0      Time                 samplerState+shaderTexture                  
Technique1       Pass1    ����       MGFX