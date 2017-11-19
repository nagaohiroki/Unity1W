
#if UNITY_DEBUG
#define DEBUG_PRINT
#endif


#if !DEBUG_PRINT
using UnityEngine;
using UnityEngine.Internal;


// --------------------------------------------------------------------------
/// @brief UnityEngine.Debugをオーバーライドする。
// --------------------------------------------------------------------------
public static class Debug
{
	public static bool developerConsoleVisible { get; set; }
	public static bool isDebugBuild {get{return false;}}
	[System.Diagnostics.Conditional( "DEBUG_PRINT" )]public static void Break() {}
	[System.Diagnostics.Conditional( "DEBUG_PRINT" )]public static void ClearDeveloperConsole() {}
	[System.Diagnostics.Conditional( "DEBUG_PRINT" )]public static void DebugBreak() {}
	[System.Diagnostics.Conditional( "DEBUG_PRINT" )]public static void DrawLine( Vector3 start, Vector3 end, [DefaultValue( "Color.white" )] Color color, [DefaultValue( "0.0f" )] float duration, [DefaultValue( "true" )] bool depthTest ) { }
	[System.Diagnostics.Conditional( "DEBUG_PRINT" )]public static void DrawLine( Vector3 start, Vector3 end, Color color, float duration ) { }
	[System.Diagnostics.Conditional( "DEBUG_PRINT" )]public static void DrawLine( Vector3 start, Vector3 end ) { }
	[System.Diagnostics.Conditional( "DEBUG_PRINT" )]public static void DrawLine( Vector3 start, Vector3 end, Color color ) { }
	[System.Diagnostics.Conditional( "DEBUG_PRINT" )]public static void DrawRay( Vector3 start, Vector3 dir, Color color ) { }
	[System.Diagnostics.Conditional( "DEBUG_PRINT" )]public static void DrawRay( Vector3 start, Vector3 dir, Color color, float duration ) { }
	[System.Diagnostics.Conditional( "DEBUG_PRINT" )]public static void DrawRay( Vector3 start, Vector3 dir ) { }
	[System.Diagnostics.Conditional( "DEBUG_PRINT" )]public static void DrawRay( Vector3 start, Vector3 dir, [DefaultValue( "Color.white" )] Color color, [DefaultValue( "0.0f" )] float duration, [DefaultValue( "true" )] bool depthTest ) { }
	[System.Diagnostics.Conditional( "DEBUG_PRINT" )]public static void Log( object message ) {}
	[System.Diagnostics.Conditional( "DEBUG_PRINT" )]public static void Log( object message, Object context ) {}
	[System.Diagnostics.Conditional( "DEBUG_PRINT" )]public static void LogError( object message ) {}
	[System.Diagnostics.Conditional( "DEBUG_PRINT" )]public static void LogError( object message, Object context ) {}
	[System.Diagnostics.Conditional( "DEBUG_PRINT" )]public static void LogErrorFormat (string format, params object[] args) { }
	[System.Diagnostics.Conditional( "DEBUG_PRINT" )]public static void LogErrorFormat (Object context, string format, params object[] args) { }
	[System.Diagnostics.Conditional( "DEBUG_PRINT" )]public static void LogException( System.Exception exception, Object context ) { }
	[System.Diagnostics.Conditional( "DEBUG_PRINT" )]public static void LogException( System.Exception exception ) { }
	[System.Diagnostics.Conditional( "DEBUG_PRINT" )]public static void LogFormat (Object context, string format, params object[] args) { }
	[System.Diagnostics.Conditional( "DEBUG_PRINT" )]public static void LogFormat (string format, params object[] args) { }
	[System.Diagnostics.Conditional( "DEBUG_PRINT" )]public static void LogWarning( object message ) {}
	[System.Diagnostics.Conditional( "DEBUG_PRINT" )]public static void LogWarning( object message, Object context ) {}
	[System.Diagnostics.Conditional( "DEBUG_PRINT" )]public static void LogWarningFormat( object message, Object context ) {}
	[System.Diagnostics.Conditional( "DEBUG_PRINT" )]public static void LogWarningFormat (string format, params object[] args) { }
	[System.Diagnostics.Conditional( "DEBUG_PRINT" )]public static void LogWarningFormat (Object context, string format, params object[] args) { }
}
#endif
