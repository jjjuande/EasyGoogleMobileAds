# EasyGoogleMobileAds for Unity#

Prefab que permite colocar banners de Admob en Unity sin escribir una sola línea de código.

## Descarga ##

Descárgalo [**desde aquí**](https://github.com/jjjuande/EasyGoogleMobileAds/releases/download/v0.9.4/EasyGoogleMobileAds-0.9.4.unitypackage).

## Resumen de uso ##

**Importante:** Para que este prefab funcione, tienes que instalar previamente el plugin de [Google Mobile Ads] (https://github.com/googleads/googleads-mobile-plugins/tree/master/unity) siguiendo las instrucciones de la página de ese proyecto.

### Banners ###

Para hacer que aparezca un banner en una determinada escena, sólo tienes que colocar el prefab **EasyGoogleMobileAds** en la jerarquía de objetos de esa escena.

![](Images/Prefab.png)

Después sólo tendrás que configurarlo en el inspector de Unity. Para que funcione, tendrás que especificar como mínimo el **Id del bloque de anuncios** (Ad unit ID)

![](Images/Editor.png)

### Intersticiales ###

Recomiendo establecer los IDs de dispositivos de prueba nada más iniciarse tu juego. 
_(Por ejemplo, en el Start de la cámara de la escena inicial)_

    string[] testDeviceIDs = new string[]{"E92E9A6745B85439C2EA180AB0010A87"};
    EasyGoogleMobileAds.GetInterstitialManager().SetTestDevices(true, testDeviceIDs);

Justo después de las líneas anteriores, usa la siguiente para preparar el intersticial pasándole tu adUnitID. 
_(Se iniciará la descarga del anuncio que se mostrará.)_

    EasyGoogleMobileAds.GetInterstitialManager().PrepareInterstitial("ca-app-pub-XXXXXXXXXXXXXXXX/XXXXXXXXXX");

Usa la siguiente línea cada vez que quieras mostrar el insterticial.
_(Esta línea no hace nada mientras no se haya terminado de descargar el anuncio y esté disponible. Una vez mostrado, se iniciará la descarga del siguiente anuncio que se mostrará.)_

    EasyGoogleMobileAds.GetInterstitialManager().ShowInterstitial();

## Licencia de uso ##

**EasyGoogleMobileAds** es *software libre*; puedes redistribuirlo y/o modificarlo bajo los términos de licencia MIT. Se distribuye con la esperanza de que sea útil, pero SIN NINGUNA GARANTÍA. Para más información, léete el archivo LICENSE.

## Información más completa ##

Para conocer todo sobre este prefab y el plugin oficial de Google, accede a [esta lista de reproducción](https://www.youtube.com/playlist?list=PLREdURb87ks2uIXmTOAVvnOz0JV2-ZwHH) de mi [canal de Youtube](https://www.youtube.com/juande).

[![Ir a mi canal de Youtube](Images/CanalYoutube.png)](https://www.youtube.com/juande)
