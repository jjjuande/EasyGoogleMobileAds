// Codigo creado para el canal https://www.youtube.com/juande
// perteneciente a los videotutoriales https://www.youtube.com/playlist?list=PLREdURb87ks2uIXmTOAVvnOz0JV2-ZwHH
// y distribuido con licencia MIT. Puedes hacer con este codigo lo que quieras siempre y cuando
// incluyas visiblemente en lo que hagas, la URL de mi canal de Youtube: https://www.youtube.com/juande
// Pagina del proyecto: https://github.com/jjjuande/EasyGoogleMobileAds

// Haz una copia de este script y añadelo como componente al objeto "EasyGoogleMobileAds".
// Cada vez que ocurra algun evento, se ejecutara el metodo de este script correspondiente al mismo.
// Elimina los metodos en los que no estes interesado. No hace falta tenerlos todos.

using UnityEngine;
using System.Collections;

public class AdEventBehaviour : MonoBehaviour {
	
	// Called when an ad request has successfully loaded.
	void OnAdLoaded()
	{

	}

	// Called when an ad request failed to load.
	// Before using the parameter, cast it to a string.
	// string message = (string) errorMessage
	void OnAdFailedToLoad(object errorMessage)
	{

	}

	// Called when an ad is clicked.
	void OnAdOpened()
	{

	}

	// Called when the user is about to return to the app after an ad click.
	void OnAdClosing()
	{

	}

	// Called when the user returned from the app after an ad click.
	void OnAdClosed()
	{

	}

	// Called when the ad click caused the user to leave the application.
	void OnAdLeftApplication()
	{

	}
}
