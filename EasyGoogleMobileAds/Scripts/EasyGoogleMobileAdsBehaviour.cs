// Codigo creado para el canal https://www.youtube.com/juande
// perteneciente a los videotutoriales https://www.youtube.com/playlist?list=PLREdURb87ks2uIXmTOAVvnOz0JV2-ZwHH
// y distribuido con licencia MIT. Puedes hacer con este codigo lo que quieras siempre y cuando
// incluyas visiblemente en lo que hagas, la URL de mi canal de Youtube: https://www.youtube.com/juande
// Pagina del proyecto: https://github.com/jjjuande/EasyGoogleMobileAds

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;

public class EasyGoogleMobileAdsBehaviour : MonoBehaviour {
	
	public enum Languages
	{
		English, Español
	}
	
	public enum Sizes
	{
		Banner, IABBanner, Leaderboard, MediumRectangle, SmartBanner
	}
	
	public Languages editorLanguage = Languages.English;
	
	public string adUnitID;
	
	public Sizes adSize = Sizes.Banner;
	public AdPosition adPosition = AdPosition.Top;
	
	public bool customSize = false;
	public int customWidth = 320;
	public int customHeight = 50;	

	public List<string> testDevices = new List<string>();
	public bool useEmulatorAsATestDevice = false;
	
	public string keywords = string.Empty;
	public Gender gender = Gender.Unknown;
	
	public BannerView bannerView;
	
	void Start () {
	
		// Create banner
		bannerView = new BannerView(
			adUnitID, getAdSize(), adPosition);
			
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
		
		AdRequest request = requestBuilder.Build();
		
		// Load the banner with the request.
		bannerView.LoadAd(request);
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

	void OnDestroy() {
		bannerView.Destroy();
	}

}
