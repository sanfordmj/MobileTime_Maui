package crc64602301a5c26457c5;


public class BorderRenderer
	extends crc6477f0d89a9cfd64b1.VisualElementRenderer_1
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_dispatchDraw:(Landroid/graphics/Canvas;)V:GetDispatchDraw_Landroid_graphics_Canvas_Handler\n" +
			"";
		mono.android.Runtime.register ("Telerik.XamarinForms.PrimitivesRenderer.Android.BorderRenderer, Telerik.Maui.Controls.Compatibility", BorderRenderer.class, __md_methods);
	}


	public BorderRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == BorderRenderer.class)
			mono.android.TypeManager.Activate ("Telerik.XamarinForms.PrimitivesRenderer.Android.BorderRenderer, Telerik.Maui.Controls.Compatibility", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public BorderRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == BorderRenderer.class)
			mono.android.TypeManager.Activate ("Telerik.XamarinForms.PrimitivesRenderer.Android.BorderRenderer, Telerik.Maui.Controls.Compatibility", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public BorderRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == BorderRenderer.class)
			mono.android.TypeManager.Activate ("Telerik.XamarinForms.PrimitivesRenderer.Android.BorderRenderer, Telerik.Maui.Controls.Compatibility", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public void dispatchDraw (android.graphics.Canvas p0)
	{
		n_dispatchDraw (p0);
	}

	private native void n_dispatchDraw (android.graphics.Canvas p0);

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
