package crc6472121154f22be707;


public class LinearAxisLabelFormatter
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.telerik.android.common.Function
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_apply:(Ljava/lang/Object;)Ljava/lang/Object;:GetApply_Ljava_lang_Object_Handler:Com.Telerik.Android.Common.IFunctionInvoker, Telerik.Android.Common\n" +
			"";
		mono.android.Runtime.register ("Telerik.XamarinForms.ChartRenderer.Android.LinearAxisLabelFormatter, Telerik.Maui.Controls.Compatibility", LinearAxisLabelFormatter.class, __md_methods);
	}


	public LinearAxisLabelFormatter ()
	{
		super ();
		if (getClass () == LinearAxisLabelFormatter.class)
			mono.android.TypeManager.Activate ("Telerik.XamarinForms.ChartRenderer.Android.LinearAxisLabelFormatter, Telerik.Maui.Controls.Compatibility", "", this, new java.lang.Object[] {  });
	}


	public java.lang.Object apply (java.lang.Object p0)
	{
		return n_apply (p0);
	}

	private native java.lang.Object n_apply (java.lang.Object p0);

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
