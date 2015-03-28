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
	private string[] keywords;
	private GoogleMobileAds.Api.Gender? gender;
	private bool? childDirectedTreatment;

	private object firstKey;

	public InterstitialManager(){
		this.useEmulatorAsATestDevice = false;
		this.testDeviceIDs = null;
	}

	/**
	 * This call will replace the current test device IDs list.
	 **/
	public void SetTestDevices(bool useEmulatorAsATestDevice, string[] testDeviceIDs){
		this.useEmulatorAsATestDevice = useEmulatorAsATestDevice;
		this.testDeviceIDs = testDeviceIDs;
	}

	/**
	 * This call will replace the current keywords list.
	 **/
	public void SetKeywords(string[] keywords){
		this.keywords = keywords;
	}

	public void SetGender(GoogleMobileAds.Api.Gender gender){
		this.gender = gender;
	}

	public void TagForChildDirectedTreatment(bool childDirectedTreatment){
		this.childDirectedTreatment = childDirectedTreatment;
	}

	public void PrepareInterstitial(string adUnitID){
		PrepareInterstitial(adUnitID, adUnitID);
	}

	public void PrepareInterstitial(string adUnitID, object key){
		if(!interstitials.ContainsKey(key)){
			interstitials[key] = new Interstitial (adUnitID, useEmulatorAsATestDevice, testDeviceIDs, keywords, gender, childDirectedTreatment);
			if(firstKey==null) firstKey = key;
		}
	}

	public void ShowInterstitial(){
		if (firstKey != null) {
			ShowInterstitial(firstKey);
		}
	}

	public void ShowInterstitial(object key){
		Interstitial i;
		if (interstitials.TryGetValue(key, out i)){
			i.Show();
		}
	}

	/**
	* Will return null if it's called before PrepareInterstitial.
	**/
	public Interstitial GetInterstitial(){
		return (firstKey != null) ? GetInterstitial(firstKey) : null;
	}

	/**
	* Will return null if it's called before PrepareInterstitial
	* or using a non-existing key.
	**/
	public Interstitial GetInterstitial(object key){
		Interstitial result;
		interstitials.TryGetValue (key, out result);
		return result;
	}
}
