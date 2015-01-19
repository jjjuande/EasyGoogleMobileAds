// Codigo creado para el canal https://www.youtube.com/juande
// perteneciente a los videotutoriales https://www.youtube.com/playlist?list=PLREdURb87ks2uIXmTOAVvnOz0JV2-ZwHH
// y distribuido con licencia MIT. Puedes hacer con este codigo lo que quieras siempre y cuando
// incluyas visiblemente en lo que hagas, la URL de mi canal de Youtube: https://www.youtube.com/juande
// Pagina del proyecto: https://github.com/jjjuande/EasyGoogleMobileAds

using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;

public class InterstitialManager {

	private Dictionary<object, Interstitial> interstitials = new Dictionary<object, Interstitial> ();

	private bool useEmulatorAsATestDevice;
	private string[] testDeviceIDs;

	private object firstKey;

	public InterstitialManager(){
		this.useEmulatorAsATestDevice = false;
		this.testDeviceIDs = null;
	}

	public void SetTestDevices(bool useEmulatorAsATestDevice, string[] testDeviceIDs){
		this.useEmulatorAsATestDevice = useEmulatorAsATestDevice;
		this.testDeviceIDs = testDeviceIDs;
	}

	public void PrepareInterstitial(string adUnitID){
		if(!interstitials.ContainsKey(adUnitID)){
			interstitials [adUnitID] = new Interstitial (adUnitID, useEmulatorAsATestDevice, testDeviceIDs);
			if(firstKey==null) firstKey = adUnitID;
		}
	}

	public void PrepareInterstitial(string adUnitID, object key){
		if(!interstitials.ContainsKey(key)){
			interstitials[key] = new Interstitial (adUnitID, useEmulatorAsATestDevice, testDeviceIDs);
			if(firstKey==null) firstKey = key;
		}
	}

	public void ShowInterstitial(){
		if (firstKey != null) {
			interstitials[firstKey].Show();
		}
	}

	public void ShowInterstitial(object key){
		Interstitial i;
		if (interstitials.TryGetValue(key, out i)){
			i.Show();
		}
	}
}
