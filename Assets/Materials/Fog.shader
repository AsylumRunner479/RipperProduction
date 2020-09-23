// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Fog"
{
	Properties
	{
		_Color1("Color 0", Color) = (1,1,1,1)
		_Color2("Color 1", Color) = (1,1,1,1)
		_Metallic1("Metallic", Float) = 0
		_Smoothness1("Smoothness", Float) = 0
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" }
		Cull Back
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float3 worldPos;
		};

		uniform float4 _Color2;
		uniform float4 _Color1;
		uniform float _Smoothness1;
		uniform float _Metallic1;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float3 ase_worldPos = i.worldPos;
			float4 lerpResult13 = lerp( _Color2 , _Color1 , pow( ( distance( _WorldSpaceCameraPos , ase_worldPos ) / 190.0 ) , 10.0 ));
			o.Albedo = lerpResult13.rgb;
			float temp_output_8_0 = _Smoothness1;
			o.Metallic = temp_output_8_0;
			float temp_output_9_0 = _Metallic1;
			o.Smoothness = temp_output_9_0;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=17800
0;12;1680;977;1330.297;299.5725;1;True;False
Node;AmplifyShaderEditor.WorldSpaceCameraPos;1;-1428.705,-237.4547;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.WorldPosInputsNode;2;-1400.104,-16.45473;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.DistanceOpNode;3;-1127.104,-117.8547;Inherit;False;2;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;4;-938.6045,6.945328;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;190;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;5;-1111.458,230.3985;Inherit;False;Property;_Color2;Color 1;1;0;Create;True;0;0;False;0;1,1,1,1;0.4811321,0.4811321,0.4811321,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;6;-1057.73,429.9614;Inherit;False;Property;_Color1;Color 0;0;0;Create;True;0;0;False;0;1,1,1,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.PowerNode;7;-773.738,-119.9288;Inherit;False;False;2;0;FLOAT;0;False;1;FLOAT;10;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;10;-466.4575,268.3985;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0.5;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;11;-211.4575,275.3985;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.OneMinusNode;12;-330.4364,-68.59702;Inherit;False;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.LerpOp;13;-705.2903,100.8902;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;9;-478.4575,98.3985;Inherit;False;Property;_Metallic1;Metallic;2;0;Create;True;0;0;False;0;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;8;-572.4575,-26.6015;Inherit;False;Property;_Smoothness1;Smoothness;3;0;Create;True;0;0;False;0;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;0,0;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;Fog;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;3;0;1;0
WireConnection;3;1;2;0
WireConnection;4;0;3;0
WireConnection;7;0;4;0
WireConnection;10;0;13;0
WireConnection;10;1;8;0
WireConnection;11;0;10;0
WireConnection;11;1;9;0
WireConnection;12;0;11;0
WireConnection;13;0;5;0
WireConnection;13;1;6;0
WireConnection;13;2;7;0
WireConnection;0;0;13;0
WireConnection;0;3;8;0
WireConnection;0;4;9;0
ASEEND*/
//CHKSM=91A35AC99DD3FEECA727714A4019C009713F2269