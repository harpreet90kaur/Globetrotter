package md51cabb59ed0853480b67b53e1a68ba59d;


public class ChangePassword_Activity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("GlobeTrotter.ChangePassword_Activity, GlobeTrotter", ChangePassword_Activity.class, __md_methods);
	}


	public ChangePassword_Activity ()
	{
		super ();
		if (getClass () == ChangePassword_Activity.class)
			mono.android.TypeManager.Activate ("GlobeTrotter.ChangePassword_Activity, GlobeTrotter", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
