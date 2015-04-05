// Codigo creado para el canal https://www.youtube.com/juande
// perteneciente a los videotutoriales https://www.youtube.com/playlist?list=PLREdURb87ks2uIXmTOAVvnOz0JV2-ZwHH
// y distribuido con licencia MIT. Puedes hacer con este codigo lo que quieras siempre y cuando
// incluyas visiblemente en lo que hagas, la URL de mi canal de Youtube: https://www.youtube.com/juande
// Pagina del proyecto: https://github.com/jjjuande/EasyGoogleMobileAds

// --[Español]-------------------------------------------------------------------
// Este archivo contiene todos los metodos que puedes copiar en un script nuevo.
// Luego solo tienes que añadir ese script al objeto "EasyGoogleMobileAds".
// Cada vez que ocurra algun evento, se ejecutara el metodo correspondiente.
// Usa solo los metodos en los que estes interesado. No hace falta tenerlos todos.
// SI COPIAS TODO EL SCRIPT, asegurate de cambiar el texto AdEventBehaviour
// por el nombre del archivo en el que has pegado todo el codigo.
// Asegurate de no repetir el nombre, si no, tendrás un error por nombre duplicado.
// --[English]-------------------------------------------------------------------
// This file has all the methods (events) you can copy to a new script.
// Then you just have to add that script to the "EasyGoogleMobileAds" object.
// Every time an event occurs, the corresponding method will run.
// Use only the methods on wich you are interested. It's not mandatory to use them all.
// IF YOU COPY THIS WHOLE SCRIPT, make sure to replace the AdEventBehaviour text
// with the script filename you're using.
// Be sure not to use the same name, otherwise you'll have an error because of duplicate name.

using UnityEngine;
using System.Collections;

public class AdEventBehaviour : MonoBehaviour {
	
	// Cuando el anuncio ha sido descargado y se ha mostrado en el banner
	// -
	// When the ad has been downloaded.
	void OnAdLoaded()
	{

	}

	// Cuando ha ocurrido un error descargando el anuncio.
	// Antes de usar el parametro, hazle un casting a string.
	// string message = (string) errorMessage;
	// -
	// Called when an ad request failed to load.
	// Before using the parameter, cast it to a string.
	// string message = (string) errorMessage;
	void OnAdFailedToLoad(object errorMessage)
	{

	}

	// Cuando el usuario ha pulsado sobre al anuncio.
	// -
	// Called when an ad is clicked.
	void OnAdOpened()
	{

	}

	// Este metodo se ejecuta justo despues del metodo OnAdOpened.
	// -
	// Called just after OnAdOpened.
	void OnAdLeftApplication()
	{
		
	}

	// Cuando el usuario esta a punto de volver al juego despues de hacer clic sobre un anuncio.
	// -
	// Called when the user is about to return to the game after an ad click.
	void OnAdClosing()
	{

	}

	// Cuando el usuario ha vuelto al juego despues de hacer clic sobre un anuncio.
	// -
	// Called when the user returned from the game after an ad click.
	void OnAdClosed()
	{

	}

}
