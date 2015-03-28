// Codigo creado para el canal https://www.youtube.com/juande
// perteneciente a los videotutoriales https://www.youtube.com/playlist?list=PLREdURb87ks2uIXmTOAVvnOz0JV2-ZwHH
// y distribuido con licencia MIT. Puedes hacer con este codigo lo que quieras siempre y cuando
// incluyas visiblemente en lo que hagas, la URL de mi canal de Youtube: https://www.youtube.com/juande
// Pagina del proyecto: https://github.com/jjjuande/EasyGoogleMobileAds

using GoogleMobileAds.Api;
using System;

public class Interstitial {
		
	string adUnitID;
	bool useEmulatorAsATestDevice;
	string[] testDeviceIDs;
	string[] keywords;
	GoogleMobileAds.Api.Gender? gender;
	bool? childDirectedTreatment;
	InterstitialAd interstitial;
	
	bool failedLoading;

	public Interstitial(string adUnitID, bool useEmulatorAsATestDevice, string[] testDeviceIDs, string[] keywords, GoogleMobileAds.Api.Gender? gender, bool? childDirectedTreatment){
		this.adUnitID = adUnitID;
		this.useEmulatorAsATestDevice = useEmulatorAsATestDevice;
		this.testDeviceIDs = testDeviceIDs;
		this.keywords = keywords;
		this.gender = gender;
		this.childDirectedTreatment = childDirectedTreatment;
		BuildInterstitial ();
	}

	public void BuildInterstitial(){
		failedLoading = false;
		interstitial = new InterstitialAd(adUnitID);
		interstitial.AdClosed += HandleInterstitialClosed;
		interstitial.AdFailedToLoad += HandleInterstitialFailedToLoad;
		AdRequest.Builder builder = new AdRequest.Builder ();
		if (useEmulatorAsATestDevice) {
			builder.AddTestDevice(AdRequest.TestDeviceSimulator);
		}
		if (testDeviceIDs != null && testDeviceIDs.Length > 0) {
			foreach(string testDeviceID in testDeviceIDs){
				builder.AddTestDevice(testDeviceID);
			}
		}
		if (keywords != null && keywords.Length > 0) {
			foreach (string keyword in keywords) {
				builder.AddKeyword (keyword);
			}
		}
		if (gender.HasValue) {
			builder.SetGender (gender.Value);
		}
		if (childDirectedTreatment.HasValue) {
			builder.TagForChildDirectedTreatment (childDirectedTreatment.Value);
		}
		AdRequest request = builder.Build();
		interstitial.LoadAd(request);
	}

	private void HandleInterstitialClosed(object sender, EventArgs args)
	{
		RebuildInterstitial ();
	}

	private void HandleInterstitialFailedToLoad(object sender, EventArgs args)
	{
		failedLoading = true;
	}

	public void RebuildInterstitial(){
		if (interstitial != null) {
			interstitial.Destroy ();
			interstitial = null;
		}
		BuildInterstitial ();
	}

	public void Show(){
		if (failedLoading) {
			// In case of error loading the ad, rebuild the interstitial again.
			RebuildInterstitial();
		}else if (interstitial!=null && interstitial.IsLoaded()) {
			// At this point there is an interstitial loaded and ready to rock.
			interstitial.Show();
		}
	}

}
