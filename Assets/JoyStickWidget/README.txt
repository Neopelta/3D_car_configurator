  _____       _        _   _                    _                 _   _      _    
 |  __ \     | |      | | (_)                  | |               | | (_)    | |   
 | |__) |___ | |_ __ _| |_ _  ___  _ __        | | ___  _   _ ___| |_ _  ___| | __
 |  _  // _ \| __/ _` | __| |/ _ \| '_ \   _   | |/ _ \| | | / __| __| |/ __| |/ /
 | | \ \ (_) | || (_| | |_| | (_) | | | | | |__| | (_) | |_| \__ \ |_| | (__|   < 
 |_|  \_\___/ \__\__,_|\__|_|\___/|_| |_|  \____/ \___/ \__, |___/\__|_|\___|_|\_\
                                                         __/ |                    
                                                        |___/                                              

=============================================================================
ROTATION JOYSTICK WIDGET - ENGLISH DOCUMENTATION
=============================================================================

Version: 1.0
Date: 12/04/2025
Unity: Unity 6 (6000.0.40f1)
Creators: Ronan PLUTA & Lillo GAVOIS
Team: Radiateur
Course: Interface Homme-Machine (IHM)
Institution: Université de Poitiers (SFA)
Program: Master 1 Computer Science

=============================================================================
DESCRIPTION
=============================================================================

The RotationJoystickWidget allows intuitive control of 3D object rotation using 
a joystick interface. Control rotation around any axis with adjustable speed and 
direction settings.

Note: Optimized for 1920x1080 resolution.

=============================================================================
FEATURES
=============================================================================

- Intuitive joystick control for object rotation
- Configurable rotation speed
- Support for rotation around X, Y, and Z axes
- Option to invert X and Y axis controls
- Support for local or world space rotation
- Real-time response to input
- Visual feedback through joystick movement

=============================================================================
PARAMETERS MODIFIABLE IN THE INSPECTOR
=============================================================================

1. ROTATION PARAMETERS
   - Rotation Speed
     - Description: Controls the speed of rotation
     - Type: float
     - Default value: 100.0
     - Usage: Higher values result in faster rotation

   - Invert X Axis
     - Description: Reverses the X-axis rotation direction
     - Type: bool
     - Default value: false
     - Usage: Toggle to reverse horizontal joystick control

   - Invert Y Axis
     - Description: Reverses the Y-axis rotation direction
     - Type: bool
     - Default value: false
     - Usage: Toggle to reverse vertical joystick control

   - Use Local Rotation
     - Description: Determines whether rotation is in local or world space
     - Type: bool
     - Default value: true
     - Usage: When true, rotation is relative to the object's current orientation

2. ROTATION AXES
   - Rotate Around X
     - Description: Enables rotation around the X axis
     - Type: bool
     - Default value: true
     - Usage: Toggle to enable/disable X-axis rotation

   - Rotate Around Y
     - Description: Enables rotation around the Y axis
     - Type: bool
     - Default value: true
     - Usage: Toggle to enable/disable Y-axis rotation

   - Rotate Around Z
     - Description: Enables rotation around the Z axis
     - Type: bool
     - Default value: false
     - Usage: Toggle to enable/disable Z-axis rotation

3. TARGET
   - Target Transform
     - Description: The object that will be rotated by the joystick
     - Type: Transform
     - Usage: Drag and drop the 3D object you want to control

=============================================================================
USAGE
=============================================================================

1. INTEGRATION INTO A SCENE

   a) Add the RotationJoystick prefab to your UI Canvas
   b) Adjust its size and position according to your needs
   c) Configure the parameters in the inspector
   d) Drag and drop a target object into the "Target" field

2. INTERACTION WITH THE WIDGET

   a) Touch and drag the joystick handle in any direction
   b) The target object will rotate according to the direction and distance
      of the joystick from its center
   c) Release the joystick to stop rotation (the handle will return to center)

3. CODE CONTROL

   To set a target object dynamically:
   
   RotationJoystickScript joystick = GetComponent<RotationJoystickScript>();
   joystick.SetTargetTransform(myTransform);
   

   To adjust rotation speed at runtime:
   
   joystick.SetRotationSpeed(150f);
   

   To toggle axis inversion:
   
   joystick.ToggleAxisInversion("x"); // Toggles X-axis inversion
   joystick.ToggleAxisInversion("y"); // Toggles Y-axis inversion
   

   To enable/disable rotation around specific axes:
   
   joystick.ToggleRotationAxis("x"); // Toggles X-axis rotation
   joystick.ToggleRotationAxis("y"); // Toggles Y-axis rotation
   joystick.ToggleRotationAxis("z"); // Toggles Z-axis rotation
   

=============================================================================
TECHNICAL OPERATION
=============================================================================

Components:
1. RotationJoystickScript - Controls rotation logic and target manipulation
2. RotationStickScript - Manages joystick handle interactions

The joystick automatically detects Image (background) and RawImage (handle) 
components. Handle movement is constrained within the joystick radius, with 
position translated to normalized values (-1 to 1) for rotation control.

=============================================================================
TROUBLESHOOTING
=============================================================================

Problem: Joystick not responding to input
Solution: Make sure your Canvas has an EventSystem in the scene and the joystick
          components are properly set up with Image and RawImage

Problem: Object rotates in unexpected directions
Solution: Try adjusting the axis inversion settings or change between local and
          world space rotation

Problem: Rotation speed seems inconsistent
Solution: Check if any other scripts are also rotating the target object or if
          the frame rate is unstable

Problem: Joystick visual elements don't display correctly
Solution: Verify that you have a proper UI hierarchy with an Image component for
          the background and a RawImage for the handle

=============================================================================
NOTES AND LIMITATIONS
=============================================================================

- The widget works best in a Canvas set to Screen Space - Overlay or 
  Screen Space - Camera
- For precise rotation control, consider adjusting the rotation speed based on
  your specific use case
- Multiple joysticks can control different aspects of the same object
  (e.g., one for X/Y rotation, another for Z rotation)
- This widget is optimized for touch and mouse input
- This widget is optimized for a 1920x1080 resolution configuration

=============================================================================
END OF DOCUMENT - ENGLISH DOCUMENTATION
=============================================================================

  _____       _        _   _                    _                 _   _      _    
 |  __ \     | |      | | (_)                  | |               | | (_)    | |   
 | |__) |___ | |_ __ _| |_ _  ___  _ __        | | ___  _   _ ___| |_ _  ___| | __
 |  _  // _ \| __/ _` | __| |/ _ \| '_ \   _   | |/ _ \| | | / __| __| |/ __| |/ /
 | | \ \ (_) | || (_| | |_| | (_) | | | | | |__| | (_) | |_| \__ \ |_| | (__|   < 
 |_|  \_\___/ \__\__,_|\__|_|\___/|_| |_|  \____/ \___/ \__, |___/\__|_|\___|_|\_\
                                                         __/ |                    
                                                        |___/                     

=============================================================================
ROTATION JOYSTICK WIDGET - DOCUMENTATION EN FRANCAIS
=============================================================================

Version: 1.0
Date: 12/04/2025
Unity: Unity 6 (6000.0.40f1)
Créateurs: Ronan PLUTA & Lillo GAVOIS
Equipe: Radiateur
UE: Interface Homme-Machine (IHM)
Institution: Université de Poitiers (SFA)
Programme: Master 1 Informatique

=============================================================================
DESCRIPTION
=============================================================================

Le RotationJoystickWidget permet de contrôler intuitivement la rotation d'objets 
3D via une interface joystick. Contrôlez la rotation autour de n'importe quel 
axe avec des paramètres ajustables.

Note: Optimisé pour résolution 1920x1080.

=============================================================================
CARACTÉRISTIQUES
=============================================================================

- Contrôle par joystick pour la rotation d'objets
- Vitesse de rotation configurable
- Support de rotation autour des axes X, Y et Z
- Option pour inverser les contrôles des axes X et Y
- Support pour la rotation en espace local ou mondial
- Réponse en temps réel aux entrées
- Retour visuel à travers le mouvement du joystick

=============================================================================
PARAMÈTRES MODIFIABLES DANS L'INSPECTEUR
=============================================================================

1. PARAMÈTRES DE ROTATION
   - Vitesse de rotation (rotationSpeed)
     - Description: Contrôle la vitesse de rotation
     - Type: float
     - Valeur par défaut: 100.0
     - Utilisation: Des valeurs plus élevées entraînent une rotation plus rapide

   - Inverser l'axe X (invertXAxis)
     - Description: Inverse la direction de rotation de l'axe X
     - Type: bool
     - Valeur par défaut: false
     - Utilisation: Activer pour inverser le contrôle horizontal du joystick

   - Inverser l'axe Y (invertYAxis)
     - Description: Inverse la direction de rotation de l'axe Y
     - Type: bool
     - Valeur par défaut: false
     - Utilisation: Activer pour inverser le contrôle vertical du joystick

   - Utiliser la rotation locale (useLocalRotation)
     - Description: Détermine si la rotation est en espace local ou mondial
     - Type: bool
     - Valeur par défaut: true
     - Utilisation: Quand vrai, la rotation est relative à l'orientation actuelle de l'objet

2. AXES DE ROTATION
   - Rotation autour de X (rotateAroundX)
     - Description: Active la rotation autour de l'axe X
     - Type: bool
     - Valeur par défaut: true
     - Utilisation: Activer/désactiver la rotation sur l'axe X

   - Rotation autour de Y (rotateAroundY)
     - Description: Active la rotation autour de l'axe Y
     - Type: bool
     - Valeur par défaut: true
     - Utilisation: Activer/désactiver la rotation sur l'axe Y

   - Rotation autour de Z (rotateAroundZ)
     - Description: Active la rotation autour de l'axe Z
     - Type: bool
     - Valeur par défaut: false
     - Utilisation: Activer/désactiver la rotation sur l'axe Z

3. CIBLE
   - Transform cible (targetTransform)
     - Description: L'objet qui sera pivoté par le joystick
     - Type: Transform
     - Utilisation: Glisser-déposer l'objet 3D que vous souhaitez contrôler

=============================================================================
UTILISATION
=============================================================================

1. INTÉGRATION DANS UNE SCÈNE

   a) Ajoutez le préfabriqué RotationJoystick à votre Canvas UI
   b) Ajustez sa taille et sa position selon vos besoins
   c) Configurez les paramètres dans l'inspecteur
   d) Glissez-déposez un objet cible dans le champ "Target"

2. INTERACTION AVEC LE WIDGET

   a) Touchez et faites glisser la poignée du joystick dans n'importe quelle direction
   b) L'objet cible pivotera en fonction de la direction et de la distance
      du joystick par rapport à son centre
   c) Relâchez le joystick pour arrêter la rotation (la poignée reviendra au centre)

3. CONTRÔLE PAR CODE

   Pour définir un objet cible dynamiquement:
   
   RotationJoystickScript joystick = GetComponent<RotationJoystickScript>();
   joystick.SetTargetTransform(myTransform);
   

   Pour ajuster la vitesse de rotation pendant l'exécution:
   
   joystick.SetRotationSpeed(150f);
   

   Pour basculer l'inversion des axes:
   
   joystick.ToggleAxisInversion("x"); // Bascule l'inversion de l'axe X
   joystick.ToggleAxisInversion("y"); // Bascule l'inversion de l'axe Y
   

   Pour activer/désactiver la rotation autour d'axes spécifiques:
   
   joystick.ToggleRotationAxis("x"); // Bascule la rotation sur l'axe X
   joystick.ToggleRotationAxis("y"); // Bascule la rotation sur l'axe Y
   joystick.ToggleRotationAxis("z"); // Bascule la rotation sur l'axe Z
   

=============================================================================
FONCTIONNEMENT TECHNIQUE
=============================================================================

Composants:
1. RotationJoystickScript - Contrôle la logique de rotation et la cible
2. RotationStickScript - Gère les interactions de la poignée

Le joystick détecte automatiquement les composants Image (arrière-plan) et 
RawImage (poignée). Le mouvement est contraint dans le rayon du joystick, avec 
position traduite en valeurs normalisées (-1 à 1) pour contrôler la rotation.

=============================================================================
AIDE AU DÉPANNAGE
=============================================================================

Problème: Le joystick ne répond pas aux entrées
Solution: Assurez-vous que votre Canvas a un EventSystem dans la scène et que les
          composants du joystick sont correctement configurés avec Image et RawImage

Problème: L'objet tourne dans des directions inattendues
Solution: Essayez d'ajuster les paramètres d'inversion d'axe ou de changer entre
          rotation en espace local et mondial

Problème: La vitesse de rotation semble incohérente
Solution: Vérifiez si d'autres scripts font également pivoter l'objet cible ou si
          le taux d'images est instable

Problème: Les éléments visuels du joystick ne s'affichent pas correctement
Solution: Vérifiez que vous avez une hiérarchie UI appropriée avec un composant Image
          pour l'arrière-plan et un RawImage pour la poignée

=============================================================================
NOTES ET LIMITATIONS
=============================================================================

- Le widget fonctionne mieux dans un Canvas défini sur Screen Space - Overlay ou
  Screen Space - Camera
- Pour un contrôle précis de la rotation, envisagez d'ajuster la vitesse de rotation
  en fonction de votre cas d'utilisation spécifique
- Plusieurs joysticks peuvent contrôler différents aspects du même objet
  (par exemple, un pour la rotation X/Y, un autre pour la rotation Z)
- Ce widget est optimisé pour les entrées tactiles et souris
- Ce widget est optimisé pour une configuration de résolution 1920x1080

=============================================================================
FIN DU DOCUMENT - DOCUMENTATION EN FRANCAIS
=============================================================================