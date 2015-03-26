// Codigo creado para el canal https://www.youtube.com/juande
// perteneciente a los videotutoriales https://www.youtube.com/playlist?list=PLREdURb87ks2uIXmTOAVvnOz0JV2-ZwHH
// y distribuido con licencia MIT. Puedes hacer con este codigo lo que quieras siempre y cuando
// incluyas visiblemente en lo que hagas, la URL de mi canal de Youtube: https://www.youtube.com/juande
// Pagina del proyecto: https://github.com/jjjuande/EasyGoogleMobileAds

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using GoogleMobileAds.Api;

[CustomEditor(typeof(EasyGoogleMobileAds))]
public class EasyGoogleMobileAdsEditor : Editor {

	private enum Item {
		EDITOR_LANGUAGE, LANGUAGE, LANGUAGE_HINT, BASE_SETTINGS, AD_UNIT_ID_ANDROID, AD_UNIT_ID_IOS, AD_UNIT_ID_HINT_ANDROID, AD_UNIT_ID_HINT_IOS, VISUAL_SETTINGS, AD_SIZE, AD_SIZE_HINT, POSITION, POSITION_HINT,
		CUSTOM_SIZE, CUSTOM_SIZE_HINT, WIDTH, WIDTH_HINT, HEIGHT, HEIGHT_HINT, FOR_TESTING, FOR_TESTING_HINT,
		USE_EMULATOR_FOR_TESTING, USE_EMULATOR_FOR_TESTING_HINT, TEST_DEVICE, TEST_DEVICE_HINT, REMOVE,
		ADD_TEST_DEVICE_ID, TARGET_SETTINGS, GENDER, GENDER_HINT, KEYWORDS, KEYWORDS_HINT, TAG_FOR_CHILD_DIRECTED_TREATMENT,
		TAG_FOR_CHILD_DIRECTED_TREATMENT_HINT, ABOUT_TITLE, ABOUT_DESC
	}

	Dictionary<string, Dictionary<Item, string>> text = new Dictionary<string, Dictionary<Item, string>>
	{{
		EasyGoogleMobileAds.Languages.English.ToString(), new Dictionary<Item, string> 
		{
				{Item.EDITOR_LANGUAGE, "Editor Language"},
				{Item.LANGUAGE, "Language"},
				{Item.LANGUAGE_HINT, "Language for this component editor.\nIt doesn't affect to the Ad in the game."},
				{Item.BASE_SETTINGS, "Base Settings"}, 
				{Item.AD_UNIT_ID_ANDROID, "Ad unit ID (Android)"}, 
				{Item.AD_UNIT_ID_HINT_ANDROID, "Ad unit ID generated from AdMob.\nIt looks like this:\nca-app-pub-6951234567896290/2123456789"},
				{Item.AD_UNIT_ID_IOS, "Ad unit ID (iOS)"}, 
				{Item.AD_UNIT_ID_HINT_IOS, "Ad unit ID generated from AdMob.\nIt looks like this:\nca-app-pub-6951234567896290/2123456789"},				
				{Item.VISUAL_SETTINGS, "Visual Settings"}, 
				{Item.AD_SIZE, "Type"},
				{Item.AD_SIZE_HINT, "Banner: Phones & Tablets (320x50)\nIABBanner: Tablets Only (468x60)\nLeaderboard: Tablets Only (720x90)\nMediumRectangle: Phones & Tablets (300x250)\nSmartBanner: Phones & Tablets (Variable)"}, 
				{Item.POSITION, "Position"},
				{Item.POSITION_HINT, "The banner position on the screen."}, 
				{Item.CUSTOM_SIZE, "Custom size"},
				{Item.CUSTOM_SIZE_HINT, "Overrides the Type selection above."}, 
				{Item.WIDTH, "Width"},
				{Item.WIDTH_HINT, "Custom desired width."}, 
				{Item.HEIGHT, "Height"}, 
				{Item.HEIGHT_HINT, "Custom desired height."}, 
				{Item.FOR_TESTING, "For Testing"}, 
				{Item.FOR_TESTING_HINT, "No real ads requests will be made while runnin on a test device."},
				{Item.USE_EMULATOR_FOR_TESTING, "Use the emulator as a test device"}, 
				{Item.USE_EMULATOR_FOR_TESTING_HINT, "No real ads requests will be made while running on a test device."},
				{Item.TEST_DEVICE, "Test device ID #{0}"}, 
				{Item.TEST_DEVICE_HINT, "Test device ID is like:\n0123456789ABCDEF0123456789ABCDEF\n\nWhen this game is run on a phone with this ID, there will be no real Ad requests.\n\nTo get your phone ID use the Google Play App: Admob Test Device Id."},
				{Item.REMOVE, " Remove "}, 
				{Item.ADD_TEST_DEVICE_ID, "Add test device ID"},
				{Item.TARGET_SETTINGS, "Target Settings"}, 
				{Item.GENDER, "Gender"},
				{Item.GENDER_HINT, "Gender this game is aimed for\nSelect UNKNOWN for both genders."}, 
				{Item.KEYWORDS, "Keywords"},		
				{Item.KEYWORDS_HINT, "Comma separated keywords related to the game."},	
				{Item.TAG_FOR_CHILD_DIRECTED_TREATMENT, "Tagging for COPPA"},
				{Item.TAG_FOR_CHILD_DIRECTED_TREATMENT_HINT, "These are the values:\n\nNot Tagged (default) - No indication of the content treatment with respect to COPPA.\nTrue - Content treated as child-directed for purposes of COPPA.\nFalse - Content should not be treated as child-directed for purposes of COPPA.\n\nBy setting this tag (to True or False), you certify that this notification is accurate and you are authorized to act on behalf of the owner of the app. You understand that abuse of this setting may result in termination of your Google account."},
				{Item.ABOUT_TITLE, "About this component"},	
				{Item.ABOUT_DESC, "https://www.youtube.com/juande"},	
		}
	},{
		EasyGoogleMobileAds.Languages.Español.ToString(), new Dictionary<Item, string>
		{
				{Item.EDITOR_LANGUAGE, "Idioma del Editor"}, 
				{Item.LANGUAGE, "Idioma"},
				{Item.LANGUAGE_HINT, "Idioma para este componente.\nNo afectará al anuncio dentro del juego."},				
				{Item.BASE_SETTINGS, "Ajustes Principales"}, 
				{Item.AD_UNIT_ID_ANDROID, "Id del bloque de anuncios (Android)"}, 
				{Item.AD_UNIT_ID_HINT_ANDROID, "Id del bloque de anuncios generado desde AdMob.\nSe parece a esto:\nca-app-pub-6951234567896290/2123456789"},
				{Item.AD_UNIT_ID_IOS, "Id del bloque de anuncios (iOS)"}, 
				{Item.AD_UNIT_ID_HINT_IOS, "Id del bloque de anuncios generado desde AdMob.\nSe parece a esto:\nca-app-pub-6951234567896290/2123456789"},
				{Item.VISUAL_SETTINGS, "Ajustes Visuales"}, 
				{Item.AD_SIZE, "Tipo"},
				{Item.AD_SIZE_HINT, "Banner: Teléfonos y Tablets (320x50)\nIABBanner: Sólo Tablets (468x60)\nLeaderboard: Sólo Tablets (720x90)\nMediumRectangle: Teléfonos y Tablets (300x250)\nSmartBanner: Teléfonos y Tablets (Variable)"}, 
				{Item.POSITION, "Posición"},
				{Item.POSITION_HINT, "Posicion del banner en la pantalla:\nTop (Arriba)\nBottom (Abajo)\nTop Left (Arriba a la izquierda)\nTop Right (Arriba a la derecha)\nBottom Left (Abajo a la izquierda)\nBottom Right (Abajo a la derecha)"}, 
				{Item.CUSTOM_SIZE, "Tamaño personalizado"},
				{Item.CUSTOM_SIZE_HINT, "Este tamaño personalizado tendrá prioridad sobre lo indicado en 'Tipo'."}, 
				{Item.WIDTH, "Ancho"},
				{Item.WIDTH_HINT, "Ancho deseado."}, 
				{Item.HEIGHT, "Alto"}, 
				{Item.HEIGHT_HINT, "Alto deseado."}, 
				{Item.FOR_TESTING, "Dispositivos para Pruebas"}, 
				{Item.FOR_TESTING_HINT, "No se realizarán peticiones de anuncios reales mientras se ejecute en un dispositivo de pruebas."},
				{Item.USE_EMULATOR_FOR_TESTING, "Emulador como dispositivo de pruebas"}, 
				{Item.USE_EMULATOR_FOR_TESTING_HINT, "No se realizarán peticiones de anuncios reales mientras se ejecute desde un emulador."},
				{Item.TEST_DEVICE, "ID Dispositivo #{0}"}, 
				{Item.TEST_DEVICE_HINT, "Este identificador se debe parecer a: 0123456789ABCDEF0123456789ABCDEF\n\nCuando este juego se ejecute en un dispositivo con este identificador, no se solicitarán peticiones reales de anuncios.\n\nPara obtener el de tu teléfono, utiliza la aplicación 'Admob Test Device Id' que puedes descargar desde Google Play."},
				{Item.REMOVE, " Quitar "}, 
				{Item.ADD_TEST_DEVICE_ID, "Añadir ID dispositivo para pruebas"},
				{Item.TARGET_SETTINGS, "Ajustes de Audiencia"}, 
				{Item.GENDER, "Género"},
				{Item.GENDER_HINT, "El Género para el que este juego está destinado.\n\nMALE para masculino\nFEMALE para femenino\nUNKNOWN para ambos."}, 
				{Item.KEYWORDS, "Palabras clave (separadas por coma)"},		
				{Item.KEYWORDS_HINT, "Palabras clave relacionadas con el juego separadas por comas."},
				{Item.TAG_FOR_CHILD_DIRECTED_TREATMENT, "Etiquetado COPPA"},
				{Item.TAG_FOR_CHILD_DIRECTED_TREATMENT_HINT, "Estos son los valores:\n\nNot Tagged (recomendado) - No se indica cómo deben ser tratado el contenido.\nTrue - Contenido con tratamiento dirigido a niños.\nFalse - Contenido sin tratamiento dirigido a niños.\n\nEstableciendo el valor 'True' o 'False', certificas que esta categorización es correcta y que estás autorizado para actuar en nombre del dueño de la aplicación. Entiendes que abusar de este ajuste puede resultar en la terminación de tu cuenta de Google."},
				{Item.ABOUT_TITLE, "Sobre este componente"},	
				{Item.ABOUT_DESC, "https://www.youtube.com/juande"},	
		}
	}};
	
	private Dictionary<Item, string> selectedLanguage;
	
	SerializedProperty adUnitIDAndroid;
	SerializedProperty adUnitIDIOS;
	SerializedProperty editorLanguage;
	SerializedProperty adSize;
	SerializedProperty adPosition;
	SerializedProperty customSize;
	SerializedProperty customWidth;
	SerializedProperty customHeight;
	SerializedProperty useEmulatorAsATestDevice;
	SerializedProperty testDevices;
	SerializedProperty gender;
	SerializedProperty keywords;	
	SerializedProperty tagForChildDirectedTreatment;	
	
	void OnEnable(){
		adUnitIDAndroid = serializedObject.FindProperty("adUnitIDAndroid");
		adUnitIDIOS = serializedObject.FindProperty("adUnitIDIOS");
		editorLanguage = serializedObject.FindProperty("editorLanguage");
		adSize = serializedObject.FindProperty("adSize");
		adPosition = serializedObject.FindProperty("adPosition");
		customSize = serializedObject.FindProperty("customSize");
		customWidth = serializedObject.FindProperty("customWidth");
		customHeight = serializedObject.FindProperty("customHeight");
		useEmulatorAsATestDevice = serializedObject.FindProperty("useEmulatorAsATestDevice");
		testDevices = serializedObject.FindProperty("testDevices");
		gender = serializedObject.FindProperty("gender");
		keywords = serializedObject.FindProperty("keywords");
		tagForChildDirectedTreatment = serializedObject.FindProperty("tagForChildDirectedTreatment");
	}

	override public void OnInspectorGUI () {
	
		serializedObject.Update ();

		selectedLanguage = text[editorLanguage.enumNames[editorLanguage.enumValueIndex]];

		GUILayout.Label(getText(Item.EDITOR_LANGUAGE), EditorStyles.boldLabel);
		editorLanguage.enumValueIndex = (int)(EasyGoogleMobileAds.Languages)EditorGUILayout.EnumPopup(new GUIContent(getText(Item.LANGUAGE), getText(Item.LANGUAGE_HINT)), (EasyGoogleMobileAds.Languages) Enum.Parse(typeof(EasyGoogleMobileAds.Languages), editorLanguage.enumNames[editorLanguage.enumValueIndex]));
		EditorGUILayout.Space();
	
		GUILayout.Label(getText(Item.BASE_SETTINGS), EditorStyles.boldLabel);
		
		EditorGUILayout.LabelField(new GUIContent(getText(Item.AD_UNIT_ID_ANDROID), getText(Item.AD_UNIT_ID_HINT_ANDROID)));
		adUnitIDAndroid.stringValue = EditorGUILayout.TextField(adUnitIDAndroid.stringValue);
		EditorGUILayout.LabelField(new GUIContent(getText(Item.AD_UNIT_ID_IOS), getText(Item.AD_UNIT_ID_HINT_IOS)));
		adUnitIDIOS.stringValue = EditorGUILayout.TextField(adUnitIDIOS.stringValue);
		EditorGUILayout.Space();
		
		GUILayout.Label (getText(Item.VISUAL_SETTINGS), EditorStyles.boldLabel);
		
		adSize.enumValueIndex = (int)(EasyGoogleMobileAds.Sizes)EditorGUILayout.EnumPopup(new GUIContent(getText(Item.AD_SIZE), getText(Item.AD_SIZE_HINT)), (EasyGoogleMobileAds.Sizes) Enum.Parse(typeof(EasyGoogleMobileAds.Sizes), adSize.enumNames[adSize.enumValueIndex]));
		adPosition.enumValueIndex = (int)(AdPosition)EditorGUILayout.EnumPopup(new GUIContent(getText(Item.POSITION), getText(Item.POSITION_HINT)), (AdPosition) Enum.Parse(typeof(AdPosition), adPosition.enumNames[adPosition.enumValueIndex]));

		customSize.boolValue = EditorGUILayout.BeginToggleGroup(new GUIContent(getText(Item.CUSTOM_SIZE), getText(Item.CUSTOM_SIZE_HINT)), customSize.boolValue);
		if(customSize.boolValue){
			EditorGUI.indentLevel++;
			customWidth.intValue = EditorGUILayout.IntField(new GUIContent(getText(Item.WIDTH), getText(Item.WIDTH_HINT)), customWidth.intValue);
			customHeight.intValue = EditorGUILayout.IntField(new GUIContent(getText(Item.HEIGHT), getText(Item.HEIGHT_HINT)), customHeight.intValue);
			EditorGUI.indentLevel--;
		}
		EditorGUILayout.EndToggleGroup ();
		EditorGUILayout.Space();
		
		GUILayout.Label(new GUIContent(getText(Item.FOR_TESTING), getText(Item.FOR_TESTING_HINT)), EditorStyles.boldLabel);
		
		useEmulatorAsATestDevice.boolValue = GUILayout.Toggle(useEmulatorAsATestDevice.boolValue, new GUIContent(getText(Item.USE_EMULATOR_FOR_TESTING), getText(Item.USE_EMULATOR_FOR_TESTING_HINT)));
		
		EditorGUILayout.BeginVertical();

		for (int i = 0; i < testDevices.arraySize; i++)
		{
			EditorGUILayout.BeginHorizontal();
			
			testDevices.GetArrayElementAtIndex(i).stringValue = EditorGUILayout.TextField(new GUIContent(string.Format(getText(Item.TEST_DEVICE), i+1), getText(Item.TEST_DEVICE_HINT)), testDevices.GetArrayElementAtIndex(i).stringValue);

			if (GUILayout.Button(getText(Item.REMOVE)))
			{
				testDevices.DeleteArrayElementAtIndex(i);
			}

			EditorGUILayout.EndHorizontal();
		} 
		
		if(GUILayout.Button(getText(Item.ADD_TEST_DEVICE_ID))){
			int nuevaPosicion = testDevices.arraySize;
			testDevices.InsertArrayElementAtIndex(nuevaPosicion);
			testDevices.GetArrayElementAtIndex(nuevaPosicion).stringValue = string.Empty;
		}

		EditorGUILayout.EndVertical();
		EditorGUILayout.Space();
		
		GUILayout.Label (getText(Item.TARGET_SETTINGS), EditorStyles.boldLabel);
	
		gender.enumValueIndex = (int)(Gender)EditorGUILayout.EnumPopup(new GUIContent(getText(Item.GENDER), getText(Item.GENDER_HINT)), (Gender) Enum.Parse(typeof(Gender), gender.enumNames[gender.enumValueIndex]));
		keywords.stringValue = EditorGUILayout.TextField(new GUIContent(getText(Item.KEYWORDS), getText(Item.KEYWORDS_HINT)), keywords.stringValue);
		tagForChildDirectedTreatment.enumValueIndex = (int)(EasyGoogleMobileAds.TagForChildDirectedTreatment)EditorGUILayout.EnumPopup(new GUIContent(getText(Item.TAG_FOR_CHILD_DIRECTED_TREATMENT), getText(Item.TAG_FOR_CHILD_DIRECTED_TREATMENT_HINT)), (EasyGoogleMobileAds.TagForChildDirectedTreatment) Enum.Parse(typeof(EasyGoogleMobileAds.TagForChildDirectedTreatment), tagForChildDirectedTreatment.enumNames[tagForChildDirectedTreatment.enumValueIndex]));

		EditorGUILayout.Space();
		GUILayout.Label (getText(Item.ABOUT_TITLE), EditorStyles.boldLabel);
		GUILayout.Label (getText(Item.ABOUT_DESC));
		
		serializedObject.ApplyModifiedProperties ();
	}
	
	private string getText(Item item){
		return selectedLanguage[item];
	}
}
