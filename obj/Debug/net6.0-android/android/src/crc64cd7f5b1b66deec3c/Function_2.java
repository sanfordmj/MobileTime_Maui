package crc64cd7f5b1b66deec3c;


public class Function_2
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
		mono.android.Runtime.register ("Telerik.XamarinForms.Common.Android.Function`2, Telerik.Maui.Controls.Compatibility", Function_2.class, __md_methods);
	}


	public Function_2 ()
	{
		super ();
		if (getClass () == Function_2.class)
			mono.android.TypeManager.Activate ("Telerik.XamarinForms.Common.Android.Function`2, Telerik.Maui.Controls.Compatibility", "", this, new java.lang.Object[] {  });
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
