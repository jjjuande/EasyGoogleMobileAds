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

[CustomEditor(typeof(EasyGoogleMobileAdsBehaviour))]
public class EasyGoogleMobileAdsEditor : Editor {

	private enum Item {
		EDITOR_LANGUAGE, LANGUAGE, LANGUAGE_HINT, BASE_SETTINGS, AD_UNIT_ID, AD_UNIT_ID_HINT, VISUAL_SETTINGS, AD_SIZE, AD_SIZE_HINT, POSITION, POSITION_HINT,
		CUSTOM_SIZE, CUSTOM_SIZE_HINT, WIDTH, WIDTH_HINT, HEIGHT, HEIGHT_HINT, FOR_TESTING, FOR_TESTING_HINT,
		USE_EMULATOR_FOR_TESTING, USE_EMULATOR_FOR_TESTING_HINT, TEST_DEVICE, TEST_DEVICE_HINT, REMOVE,
		ADD_TEST_DEVICE_ID, TARGET_SETTINGS, GENDER, GENDER_HINT, KEYWORDS, KEYWORDS_HINT, ABOUT_TITLE, ABOUT_DESC
	}

	Dictionary<string, Dictionary<Item, string>> text = new Dictionary<string, Dictionary<Item, string>>
	{{
		EasyGoogleMobileAdsBehaviour.Languages.English.ToString(), new Dictionary<Item, string> 
		{
				{Item.EDITOR_LANGUAGE, "Editor Language"},
				{Item.LANGUAGE, "Language"},
				{Item.LANGUAGE_HINT, "Language for this component editor.\nIt doesn't affect to the Ad in the game."},
				{Item.BASE_SETTINGS, "Base Settings"}, 
				{Item.AD_UNIT_ID, "Ad unit ID"}, 
				{Item.AD_UNIT_ID_HINT, "Ad unit ID generated from AdMob.\nIt looks like this:\nca-app-pub-6951234567896290/2123456789"},
				{Item.VISUAL_SETTINGS, "Visual Settings"}, 
				{Item.AD_SIZE, "Type"},
				{Item.AD_SIZE_HINT, "Banner: Phones & Tablets (320x50)\nIABBanner: Tablets Only (468x60)\nLeaderboard: Tablets Only (720x90)\nMediumRectangle: Phones & Tablets (300x250)\nSmartBanner: Phones & Tablets (Variable)"}, 
				{Item.POSITION, "Position"},
				{Item.POSITION_HINT, "On Top or Botton of the screen."}, 
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
				{Item.ABOUT_TITLE, "About this component"},	
				{Item.ABOUT_DESC, "https://www.youtube.com/juande"},	
		}
	},{
		EasyGoogleMobileAdsBehaviour.Languages.Español.ToString(), new Dictionary<Item, string>
		{
				{Item.EDITOR_LANGUAGE, "Idioma del Editor"}, 
				{Item.LANGUAGE, "Idioma"},
				{Item.LANGUAGE_HINT, "Idioma para este componente.\nNo afectará al anuncio dentro del juego."},				
				{Item.BASE_SETTINGS, "Ajustes Principales"}, 
				{Item.AD_UNIT_ID, "Id del bloque de anuncios"}, 
				{Item.AD_UNIT_ID_HINT, "Id del bloque de anuncios generado desde AdMob.\nSe parece a esto:\nca-app-pub-6951234567896290/2123456789"},
				{Item.VISUAL_SETTINGS, "Ajustes Visuales"}, 
				{Item.AD_SIZE, "Tipo"},
				{Item.AD_SIZE_HINT, "Banner: Teléfonos y Tablets (320x50)\nIABBanner: Sólo Tablets (468x60)\nLeaderboard: Sólo Tablets (720x90)\nMediumRectangle: Teléfonos y Tablets (300x250)\nSmartBanner: Teléfonos y Tablets (Variable)"}, 
				{Item.POSITION, "Posición"},
				{Item.POSITION_HINT, "Arriba (Top) o abajo (Bottom) de la pantalla."}, 
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
				{Item.KEYWORDS, "Palabras clave"},		
				{Item.KEYWORDS_HINT, "Palabras clave relacionadas con el juego separadas por comas."},
				{Item.ABOUT_TITLE, "Sobre este componente"},	
				{Item.ABOUT_DESC, "https://www.youtube.com/juande"},	
		}
	}};
	
	private Dictionary<Item, string> selectedLanguage;
	
	SerializedProperty adUnitID;
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
	
	void OnEnable(){
		adUnitID = serializedObject.FindProperty("adUnitID");
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
	}

	override public void OnInspectorGUI () {
	
		serializedObject.Update ();
		
		EasyGoogleMobileAdsBehaviour ads = (EasyGoogleMobileAdsBehaviour)target;
		selectedLanguage = text[editorLanguage.enumNames[editorLanguage.enumValueIndex]];

		GUILayout.Label(getText(Item.EDITOR_LANGUAGE), EditorStyles.boldLabel);
		editorLanguage.enumValueIndex = (int)(EasyGoogleMobileAdsBehaviour.Languages)EditorGUILayout.EnumPopup(new GUIContent(getText(Item.LANGUAGE), getText(Item.LANGUAGE_HINT)), (EasyGoogleMobileAdsBehaviour.Languages) Enum.Parse(typeof(EasyGoogleMobileAdsBehaviour.Languages), editorLanguage.enumNames[editorLanguage.enumValueIndex]));
		EditorGUILayout.Space();
	
		GUILayout.Label(getText(Item.BASE_SETTINGS), EditorStyles.boldLabel);
		
		EditorGUILayout.LabelField(new GUIContent(getText(Item.AD_UNIT_ID), getText(Item.AD_UNIT_ID_HINT)));
		adUnitID.stringValue = EditorGUILayout.TextField(adUnitID.stringValue);
		EditorGUILayout.Space();
		
		GUILayout.Label (getText(Item.VISUAL_SETTINGS), EditorStyles.boldLabel);
		
		adSize.enumValueIndex = (int)(EasyGoogleMobileAdsBehaviour.Sizes)EditorGUILayout.EnumPopup(new GUIContent(getText(Item.AD_SIZE), getText(Item.AD_SIZE_HINT)), (EasyGoogleMobileAdsBehaviour.Sizes) Enum.Parse(typeof(EasyGoogleMobileAdsBehaviour.Sizes), adSize.enumNames[adSize.enumValueIndex]));
		adPosition.enumValueIndex = (int)(AdPosition)EditorGUILayout.EnumPopup(new GUIContent(getText(Item.POSITION), getText(Item.POSITION_HINT)), (AdPosition) Enum.Parse(typeof(AdPosition), adPosition.enumNames[adPosition.enumValueIndex]));

		customSize.boolValue = EditorGUILayout.BeginToggleGroup(new GUIContent(getText(Item.CUSTOM_SIZE), getText(Item.CUSTOM_SIZE_HINT)), customSize.boolValue);
		if(ads.customSize){
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
		
		EditorGUILayout.Space();
		GUILayout.Label (getText(Item.ABOUT_TITLE), EditorStyles.boldLabel);
		GUILayout.Label (getText(Item.ABOUT_DESC));
		
		serializedObject.ApplyModifiedProperties ();
	}
	
	private string getText(Item item){
		return selectedLanguage[item];
	}
}
