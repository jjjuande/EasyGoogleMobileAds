// Codigo creado para el canal https://www.youtube.com/juande
// perteneciente a los videotutoriales https://www.youtube.com/playlist?list=PLREdURb87ks2uIXmTOAVvnOz0JV2-ZwHH
// y distribuido con licencia MIT. Puedes hacer con este codigo lo que quieras siempre y cuando
// incluyas visiblemente en lo que hagas, la URL de mi canal de Youtube: https://www.youtube.com/juande
// Pagina del proyecto: https://github.com/jjjuande/EasyGoogleMobileAds

using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;

public class EasyGoogleMobileAds : MonoBehaviour {
	
	public enum Languages
	{
		English, Español
	}
	
	public enum Sizes
	{
		Banner, IABBanner, Leaderboard, MediumRectangle, SmartBanner
	}

	public enum TagForChildDirectedTreatment
	{
		NotTagged, True, False
	}
	
	public Languages editorLanguage = Languages.English;
	
	public string adUnitID;			// This will contain the ID for the generated platform
	public string adUnitIDAndroid;
	public string adUnitIDIOS;
	
	public Sizes adSize = Sizes.Banner;
	public AdPosition adPosition = AdPosition.Top;
	
	public bool customSize = false;
	public int customWidth = 320;
	public int customHeight = 50;	

	public List<string> testDevices = new List<string>();
	public bool useEmulatorAsATestDevice = false;
	
	public string keywords = string.Empty;
	public Gender gender = Gender.Unknown;

	public TagForChildDirectedTreatment tagForChildDirectedTreatment = TagForChildDirectedTreatment.NotTagged;
	
	public BannerView bannerView;
	
	void OnEnable(){
		// Destroy the banner if exists (This can happen. I don't know why)
		destroyAd();
		
		// Select the proper Ad ID by build platform
#if UNITY_ANDROID
		adUnitID = adUnitIDAndroid;
#elif UNITY_IPHONE
		adUnitID = adUnitIDIOS;
#else
		adUnitID = string.Empty;
#endif

		// Create banner
		bannerView = new BannerView(adUnitID, getAdSize(), adPosition);

		// Register for events
		bannerView.OnAdLoaded += HandleAdLoaded;
		bannerView.OnAdFailedToLoad += HandleAdFailedToLoad;
		bannerView.OnAdOpening += HandleAdOpened;
		bannerView.OnAdClosed += HandleAdClosed;
		bannerView.OnAdLeavingApplication += HandleAdLeftApplication;

        // Load the banner with the request.
        bannerView.LoadAd(getAdRequest());
	}
	
	void OnDisable(){
		destroyAd();
	}

	void OnDestroy() {
		destroyAd();
	}
	
	private void destroyAd(){
		if(bannerView!=null){
			bannerView.Hide();
			bannerView.Destroy();
			bannerView = null;
		}
	}	
	
	private AdRequest getAdRequest(){
		
		// Creating the request builder
		AdRequest.Builder requestBuilder = new AdRequest.Builder();
		
		// Test devices
		if(useEmulatorAsATestDevice){
			requestBuilder.AddTestDevice(AdRequest.TestDeviceSimulator);
		}
		foreach(string deviceID in testDevices){
			if(!string.IsNullOrEmpty(deviceID)){
				requestBuilder.AddTestDevice(deviceID);
			}
		}
		
		// Keywords
		string[] words = keywords.Split(',');
		foreach(string word in words){
			if(word.Trim() != string.Empty) 
				requestBuilder.AddKeyword(word.Trim());
		}
		
		// Gender
		if(gender != Gender.Unknown) 
			requestBuilder.SetGender(gender);

		// Tag for child directed treatment
		if (tagForChildDirectedTreatment != TagForChildDirectedTreatment.NotTagged) {
			requestBuilder.TagForChildDirectedTreatment (tagForChildDirectedTreatment == TagForChildDirectedTreatment.True);
		}
		
		return requestBuilder.Build();
	}
	
	private GoogleMobileAds.Api.AdSize getAdSize(){
		AdSize result = null;
		if(customSize){
			result = new AdSize(customWidth, customHeight);
		}else{
			switch(adSize){
			case Sizes.Banner:
				result = AdSize.Banner;
				break;
			case Sizes.IABBanner:
				result = AdSize.IABBanner;
				break;
			case Sizes.Leaderboard:
				result = AdSize.Leaderboard;
				break;
			case Sizes.MediumRectangle:
				result = AdSize.MediumRectangle;
				break;
			case Sizes.SmartBanner:
				result = AdSize.SmartBanner;
				break;
			}
		}
		return result;
	}	

	// Interstitial support

	private static InterstitialManager interstitialManager;
	
	public static InterstitialManager GetInterstitialManager(){
		if (EasyGoogleMobileAds.interstitialManager == null) {
			EasyGoogleMobileAds.interstitialManager = new InterstitialManager();
		}
		return EasyGoogleMobileAds.interstitialManager;
	}

	// Events support

	public void HandleAdLoaded(object sender, EventArgs args)
	{
		// Called when an ad request has successfully loaded.
		SendMessage ("OnAdLoaded", SendMessageOptions.DontRequireReceiver);
	}

	public void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
		// Called when an ad request failed to load.
		SendMessage ("OnAdFailedToLoad", args.Message, SendMessageOptions.DontRequireReceiver);
	}

	public void HandleAdOpened(object sender, EventArgs args)
	{
		// Called when an ad is clicked.
		SendMessage ("OnAdOpened", SendMessageOptions.DontRequireReceiver);
	}

	public void HandleAdClosed(object sender, EventArgs args)
	{
		// Called when the user returned from the app after an ad click.
		SendMessage ("OnAdClosed", SendMessageOptions.DontRequireReceiver);
	}

	public void HandleAdLeftApplication(object sender, EventArgs args)
	{
		// Called when the ad click caused the user to leave the application.
		SendMessage ("OnAdLeftApplication", SendMessageOptions.DontRequireReceiver);
	}

}
