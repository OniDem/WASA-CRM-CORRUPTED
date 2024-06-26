package crc64bcce8c39838b345c;


public class BarcodeView
	extends androidx.coordinatorlayout.widget.CoordinatorLayout
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("BarcodeScanning.BarcodeView, BarcodeScanning.Native.Maui", BarcodeView.class, __md_methods);
	}


	public BarcodeView (android.content.Context p0)
	{
		super (p0);
		if (getClass () == BarcodeView.class) {
			mono.android.TypeManager.Activate ("BarcodeScanning.BarcodeView, BarcodeScanning.Native.Maui", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
		}
	}


	public BarcodeView (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == BarcodeView.class) {
			mono.android.TypeManager.Activate ("BarcodeScanning.BarcodeView, BarcodeScanning.Native.Maui", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
		}
	}


	public BarcodeView (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == BarcodeView.class) {
			mono.android.TypeManager.Activate ("BarcodeScanning.BarcodeView, BarcodeScanning.Native.Maui", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib", this, new java.lang.Object[] { p0, p1, p2 });
		}
	}

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
