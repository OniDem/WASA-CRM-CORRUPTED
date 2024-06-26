package crc64bcce8c39838b345c;


public class BarcodeAnalyzer
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		androidx.camera.core.ImageAnalysis.Analyzer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getDefaultTargetResolution:()Landroid/util/Size;:GetGetDefaultTargetResolutionHandler:AndroidX.Camera.Core.ImageAnalysis/IAnalyzer, Xamarin.AndroidX.Camera.Core\n" +
			"n_getTargetCoordinateSystem:()I:GetGetTargetCoordinateSystemHandler:AndroidX.Camera.Core.ImageAnalysis/IAnalyzer, Xamarin.AndroidX.Camera.Core\n" +
			"n_analyze:(Landroidx/camera/core/ImageProxy;)V:GetAnalyze_Landroidx_camera_core_ImageProxy_Handler:AndroidX.Camera.Core.ImageAnalysis/IAnalyzerInvoker, Xamarin.AndroidX.Camera.Core\n" +
			"n_updateTransform:(Landroid/graphics/Matrix;)V:GetUpdateTransform_Landroid_graphics_Matrix_Handler:AndroidX.Camera.Core.ImageAnalysis/IAnalyzer, Xamarin.AndroidX.Camera.Core\n" +
			"";
		mono.android.Runtime.register ("BarcodeScanning.BarcodeAnalyzer, BarcodeScanning.Native.Maui", BarcodeAnalyzer.class, __md_methods);
	}


	public BarcodeAnalyzer ()
	{
		super ();
		if (getClass () == BarcodeAnalyzer.class) {
			mono.android.TypeManager.Activate ("BarcodeScanning.BarcodeAnalyzer, BarcodeScanning.Native.Maui", "", this, new java.lang.Object[] {  });
		}
	}


	public android.util.Size getDefaultTargetResolution ()
	{
		return n_getDefaultTargetResolution ();
	}

	private native android.util.Size n_getDefaultTargetResolution ();


	public int getTargetCoordinateSystem ()
	{
		return n_getTargetCoordinateSystem ();
	}

	private native int n_getTargetCoordinateSystem ();


	public void analyze (androidx.camera.core.ImageProxy p0)
	{
		n_analyze (p0);
	}

	private native void n_analyze (androidx.camera.core.ImageProxy p0);


	public void updateTransform (android.graphics.Matrix p0)
	{
		n_updateTransform (p0);
	}

	private native void n_updateTransform (android.graphics.Matrix p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
