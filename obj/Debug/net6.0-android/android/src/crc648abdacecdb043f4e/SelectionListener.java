package crc648abdacecdb043f4e;


public class SelectionListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.telerik.widget.list.SelectionBehavior.SelectionChangedListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onItemIsSelectedChanged:(IZ)V:GetOnItemIsSelectedChanged_IZHandler:Com.Telerik.Widget.List.SelectionBehavior/ISelectionChangedListenerInvoker, Telerik.Android.List\n" +
			"n_onSelectionEnded:()V:GetOnSelectionEndedHandler:Com.Telerik.Widget.List.SelectionBehavior/ISelectionChangedListenerInvoker, Telerik.Android.List\n" +
			"n_onSelectionStarted:()V:GetOnSelectionStartedHandler:Com.Telerik.Widget.List.SelectionBehavior/ISelectionChangedListenerInvoker, Telerik.Android.List\n" +
			"";
		mono.android.Runtime.register ("Telerik.XamarinForms.DataControlsRenderer.Android.SelectionListener, Telerik.Maui.Controls.Compatibility", SelectionListener.class, __md_methods);
	}


	public SelectionListener ()
	{
		super ();
		if (getClass () == SelectionListener.class)
			mono.android.TypeManager.Activate ("Telerik.XamarinForms.DataControlsRenderer.Android.SelectionListener, Telerik.Maui.Controls.Compatibility", "", this, new java.lang.Object[] {  });
	}


	public void onItemIsSelectedChanged (int p0, boolean p1)
	{
		n_onItemIsSelectedChanged (p0, p1);
	}

	private native void n_onItemIsSelectedChanged (int p0, boolean p1);


	public void onSelectionEnded ()
	{
		n_onSelectionEnded ();
	}

	private native void n_onSelectionEnded ();


	public void onSelectionStarted ()
	{
		n_onSelectionStarted ();
	}

	private native void n_onSelectionStarted ();

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
