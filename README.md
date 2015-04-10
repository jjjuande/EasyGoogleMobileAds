# EasyGoogleMobileAds for Unity#

Prefab que permite colocar banners de Admob en Unity sin escribir una sola línea de código.

_[View the english version of this document](https://github.com/jjjuande/EasyGoogleMobileAds/blob/master/README-EN.md)._

## Descarga ##

Descárgalo [**desde aquí**](https://github.com/jjjuande/EasyGoogleMobileAds/releases/download/v0.9.10/EasyGoogleMobileAds-0.9.10.unitypackage).

## Resumen de uso ##

**Importante:** Para que este prefab funcione, tienes que instalar previamente el plugin de [Google Mobile Ads] (https://github.com/googleads/googleads-mobile-plugins/tree/master/unity) siguiendo las instrucciones de la página de ese proyecto.

### Banners ###

Para hacer que aparezca un banner en una determinada escena, sólo tienes que colocar el prefab **EasyGoogleMobileAds** en la jerarquía de objetos de esa escena.

![](Images/Prefab.png)

Después sólo tendrás que configurarlo en el inspector de Unity. Para que funcione, tendrás que especificar como mínimo el **Id del bloque de anuncios** (Ad unit ID)

![](Images/Editor.png)

### Banners - Ocultar/Mostrar Banner ###

El objeto **EasyGoogleMobileAds** hará que se muestre un banner de publicidad mientras este objeto permanezca activo en la jerarquía. Así que lo normal es que el banner permanezca activo durante toda la escena. Si durante algún momento se quisiera ocultar el banner sin tener que cambiar de escena, sólo habría que desactivar el objeto **EasyGoogleMobileAds**.

    // El código siguiente supone que "banner" está 
    // referenciando al objeto EasyGoogleMobileAds
    ...
    // Para desactivarlo
    banner.SetActive(false);
    // Para activarlo
    banner.SetActive(true);
 
### Banners - Interceptar eventos ###

Puede haber veces en donde queramos ejecutar cierto código una vez que el banner se ha cargado, o si se le ha hecho clic en el mismo. Para ello, créate un nuevo script copiando los métodos que necesites del script _/Assets/EasyGoogleMobileAds/ExampleScripts/AdEventBehaviour.cs_ y añádelo (el script creado) como componente al objeto **EasyGoogleMobileAds**. Cada vez que ocurra un evento, se ejecutará el método correspondiente.

Estos son los que no reciben ningún parámetro:
* **OnAdLoaded**. El anuncio se ha terminado de descargar y se ha mostrado. _(Si hemos configurado el banner para que cambie su contenido cada tanto tiempo, este evento saltará cada vez que se descargue y muestre un banner nuevo.)_
* **OnAdOpened**. El usuario ha hecho clic en el anuncio.
* **OnAdLeftApplication**. Se ejecuta justo después del evento _OnAdOpened_, cuando el usuario ha hecho clic en el anuncio.
* **OnAdClosing**. El usuario está a punto de volver al juego después de hacer clic en el anuncio.
* **OnAdClosed**. El usuario vuelve al juego después de hacer clic en el anuncio.


Este es el único que recibe como parámetro *errorMessage*, que contendrá el mensaje de error:
* **OnAdFailedToLoad**: Cuando ha ocurrido un error descargando el anuncio. Recuerda hacer un casting a _string_ a la variable *errorMessage* antes de usarla.

### Intersticiales ###

Recomiendo establecer los IDs de dispositivos de prueba nada más iniciarse tu juego. 
_(Por ejemplo, en el Start de la cámara de la escena inicial)_

    string[] testDeviceIDs = new string[]{"E92E9A6745B85439C2EA180AB0010A87"};
    EasyGoogleMobileAds.GetInterstitialManager().SetTestDevices(true, testDeviceIDs);

Si quieres, también puedes añadir (nada más iniciarse tu juego) los parámetros de segmentación para los anuncios de los intersticiales como se describe a continuación. _(No será obligatorio indicar ningún parámetro de los que se describen. Así que todo este siguiente bloque de código será opcional)_

    // Añadimos las keywords que definen el contenido de la publicidad que se mostrara
    string[] keywords = new string[]{"ropa", "compras", "moda"};
    EasyGoogleMobileAds.GetInterstitialManager ().SetKeywords (keywords);
    // Indicamos que la publicidad sea dirigida a hombres (por ejemplo)
    EasyGoogleMobileAds.GetInterstitialManager ().SetGender (GoogleMobileAds.Api.Gender.Male);
    // Indicamos que no se haga un trato especial para niños con la publicidad mostrada.
    EasyGoogleMobileAds.GetInterstitialManager ().TagForChildDirectedTreatment (false);
    
Justo después de las líneas anteriores (y también nada más iniciarse tu juego), usa la siguiente para preparar el intersticial pasándole tu adUnitID. 
_(Se iniciará la descarga del anuncio a mostrar.)_

    EasyGoogleMobileAds.GetInterstitialManager().PrepareInterstitial("ca-app-pub-XXXXXXXXXXXXXXXX/XXXXXXXXXX");

Usa la siguiente línea cada vez que quieras mostrar el insterticial.
_(Esta línea no hace nada mientras no se haya terminado de descargar el anuncio y esté disponible. Una vez mostrado, se iniciará automáticamente la descarga del siguiente anuncio a mostrar.)_

    EasyGoogleMobileAds.GetInterstitialManager().ShowInterstitial();

### Intersticiales - Interceptar eventos ###

Aunque en los intersticiales tenemos los mismos eventos que en los banners, algunos no se refieren a lo mismo:
* **OnAdLoaded**. El anuncio se ha terminado de descargar y está preparado para mostrarse. _(No se mostrará hasta que no se ejecute el método ShowInterstitial.)_
* **OnAdOpened**. Se ha mostrado el intersticial.
* **OnAdClosing**. El usuario está a punto de volver al juego después de ver el intersticial.
* **OnAdClosed**. El usuario vuelve al juego después de ver el intersticial.
* **OnAdLeftApplication**. El  usuario hace clic en el intersticial.
* **OnAdFailedToLoad**: Cuando ha ocurrido un error descargando el anuncio.

Todo el código siguiente deberá ejecutarse después de haber llamado al _PrepareInterstitial_. Si se hace antes, obtendremos un _NullPointerException_.

Para definir un bloque de código que se ejecute cuando se dé el evento _OnAdLoaded_:

    EasyGoogleMobileAds.GetInterstitialManager().GetInterstitial().OnAdLoaded = 
    delegate(){
        // Aquí iría el código que querremos ejecutar cuando se de ese evento.
        // ...
    };

El código anterior sirve para los eventos _OnAdLoaded_, _OnAdOpened_, _OnAdClosing_, _OnAdClosed_, _OnAdClosed_ y  _OnAdLeftApplication_. Sólo tendremos que reemplazar _OnAdLoaded_ con el nombre del evento que queremos. Repetiremos ese bloque para cada evento que vayamos a utilizar.

Para definir un bloque de código que se ejecute en caso de error descargando el anuncio: 

    EasyGoogleMobileAds.GetInterstitialManager().GetInterstitial().OnAdFailedToLoad = 
    delegate(string mensaje){
        // Aquí iría el código que querremos ejecutar cuando se de ese evento.
        // Observa que en la variable "mensaje" tienes el mensaje de error.
        // ...
    };

## Aviso Importante ##

Aunque se pueda detectar cuando el usuario hace clic en un anuncio, NO DEBEREMOS usar esto para incentivar los clics con monedas virtuales extra (o similar) por clic. Esta acción está prohibída por los términos de uso de AdMob.

## Licencia de uso ##

**EasyGoogleMobileAds** es *software libre*; puedes redistribuirlo y/o modificarlo bajo los términos de licencia MIT. Se distribuye con la esperanza de que sea útil, pero SIN NINGUNA GARANTÍA. Para más información, léete el archivo LICENSE.

## Información más completa ##

Para conocer todo sobre este prefab y el plugin oficial de Google, accede a [esta lista de reproducción](https://www.youtube.com/playlist?list=PLREdURb87ks2uIXmTOAVvnOz0JV2-ZwHH) de mi [canal de Youtube](https://www.youtube.com/juande).

[![Ir a mi canal de Youtube](Images/CanalYoutube.png)](https://www.youtube.com/playlist?list=PLREdURb87ks2uIXmTOAVvnOz0JV2-ZwHH)
