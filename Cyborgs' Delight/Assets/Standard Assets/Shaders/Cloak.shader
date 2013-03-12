Shader "Custom/Cloak" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
	}
	SubShader {
		GrabPass{}
		
		Pass{
			SetTexture[_GrabTexture]{combine one-texture}
		}	
	} 
	
}
