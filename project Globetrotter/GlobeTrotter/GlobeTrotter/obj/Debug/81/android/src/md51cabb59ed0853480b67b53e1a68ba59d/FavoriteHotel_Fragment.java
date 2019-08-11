package md51cabb59ed0853480b67b53e1a68ba59d;


public class FavoriteHotel_Fragment
	extends android.app.Fragment
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onCreateView:(Landroid/view/LayoutInflater;Landroid/view/ViewGroup;Landroid/os/Bundle;)Landroid/view/View;:GetOnCreateView_Landroid_view_LayoutInflater_Landroid_view_ViewGroup_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("GlobeTrotter.FavoriteHotel_Fragment, GlobeTrotter", FavoriteHotel_Fragment.class, __md_methods);
	}


	public FavoriteHotel_Fragment ()
	{
		super ();
		if (getClass () == FavoriteHotel_Fragment.class)
			mono.android.TypeManager.Activate ("GlobeTrotter.FavoriteHotel_Fragment, GlobeTrotter", "", this, new java.lang.Object[] {  });
	}

	public FavoriteHotel_Fragment (android.app.Activity p0, android.os.Bundle p1)
	{
		super ();
		if (getClass () == FavoriteHotel_Fragment.class)
			mono.android.TypeManager.Activate ("GlobeTrotter.FavoriteHotel_Fragment, GlobeTrotter", "Android.App.Activity, Mono.Android:Android.OS.Bundle, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public android.view.View onCreateView (android.view.LayoutInflater p0, android.view.ViewGroup p1, android.os.Bundle p2)
	{
		return n_onCreateView (p0, p1, p2);
	}

	private native android.view.View n_onCreateView (android.view.LayoutInflater p0, android.view.ViewGroup p1, android.os.Bundle p2);

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
