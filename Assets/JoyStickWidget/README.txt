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
Institution: Universit� de Poitiers (SFA)
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
Cr�ateurs: Ronan PLUTA & Lillo GAVOIS
Equipe: Radiateur
UE: Interface Homme-Machine (IHM)
Institution: Universit� de Poitiers (SFA)
Programme: Master 1 Informatique

=============================================================================
DESCRIPTION
=============================================================================

Le RotationJoystickWidget permet de contr�ler intuitivement la rotation d'objets 
3D via une interface joystick. Contr�lez la rotation autour de n'importe quel 
axe avec des param�tres ajustables.

Note: Optimis� pour r�solution 1920x1080.

=============================================================================
CARACT�RISTIQUES
=============================================================================

- Contr�le par joystick pour la rotation d'objets
- Vitesse de rotation configurable
- Support de rotation autour des axes X, Y et Z
- Option pour inverser les contr�les des axes X et Y
- Support pour la rotation en espace local ou mondial
- R�ponse en temps r�el aux entr�es
- Retour visuel � travers le mouvement du joystick

=============================================================================
PARAM�TRES MODIFIABLES DANS L'INSPECTEUR
=============================================================================

1. PARAM�TRES DE ROTATION
   - Vitesse de rotation (rotationSpeed)
     - Description: Contr�le la vitesse de rotation
     - Type: float
     - Valeur par d�faut: 100.0
     - Utilisation: Des valeurs plus �lev�es entra�nent une rotation plus rapide

   - Inverser l'axe X (invertXAxis)
     - Description: Inverse la direction de rotation de l'axe X
     - Type: bool
     - Valeur par d�faut: false
     - Utilisation: Activer pour inverser le contr�le horizontal du joystick

   - Inverser l'axe Y (invertYAxis)
     - Description: Inverse la direction de rotation de l'axe Y
     - Type: bool
     - Valeur par d�faut: false
     - Utilisation: Activer pour inverser le contr�le vertical du joystick

   - Utiliser la rotation locale (useLocalRotation)
     - Description: D�termine si la rotation est en espace local ou mondial
     - Type: bool
     - Valeur par d�faut: true
     - Utilisation: Quand vrai, la rotation est relative � l'orientation actuelle de l'objet

2. AXES DE ROTATION
   - Rotation autour de X (rotateAroundX)
     - Description: Active la rotation autour de l'axe X
     - Type: bool
     - Valeur par d�faut: true
     - Utilisation: Activer/d�sactiver la rotation sur l'axe X

   - Rotation autour de Y (rotateAroundY)
     - Description: Active la rotation autour de l'axe Y
     - Type: bool
     - Valeur par d�faut: true
     - Utilisation: Activer/d�sactiver la rotation sur l'axe Y

   - Rotation autour de Z (rotateAroundZ)
     - Description: Active la rotation autour de l'axe Z
     - Type: bool
     - Valeur par d�faut: false
     - Utilisation: Activer/d�sactiver la rotation sur l'axe Z

3. CIBLE
   - Transform cible (targetTransform)
     - Description: L'objet qui sera pivot� par le joystick
     - Type: Transform
     - Utilisation: Glisser-d�poser l'objet 3D que vous souhaitez contr�ler

=============================================================================
UTILISATION
=============================================================================

1. INT�GRATION DANS UNE SC�NE

   a) Ajoutez le pr�fabriqu� RotationJoystick � votre Canvas UI
   b) Ajustez sa taille et sa position selon vos besoins
   c) Configurez les param�tres dans l'inspecteur
   d) Glissez-d�posez un objet cible dans le champ "Target"

2. INTERACTION AVEC LE WIDGET

   a) Touchez et faites glisser la poign�e du joystick dans n'importe quelle direction
   b) L'objet cible pivotera en fonction de la direction et de la distance
      du joystick par rapport � son centre
   c) Rel�chez le joystick pour arr�ter la rotation (la poign�e reviendra au centre)

3. CONTR�LE PAR CODE

   Pour d�finir un objet cible dynamiquement:
   
   RotationJoystickScript joystick = GetComponent<RotationJoystickScript>();
   joystick.SetTargetTransform(myTransform);
   

   Pour ajuster la vitesse de rotation pendant l'ex�cution:
   
   joystick.SetRotationSpeed(150f);
   

   Pour basculer l'inversion des axes:
   
   joystick.ToggleAxisInversion("x"); // Bascule l'inversion de l'axe X
   joystick.ToggleAxisInversion("y"); // Bascule l'inversion de l'axe Y
   

   Pour activer/d�sactiver la rotation autour d'axes sp�cifiques:
   
   joystick.ToggleRotationAxis("x"); // Bascule la rotation sur l'axe X
   joystick.ToggleRotationAxis("y"); // Bascule la rotation sur l'axe Y
   joystick.ToggleRotationAxis("z"); // Bascule la rotation sur l'axe Z
   

=============================================================================
FONCTIONNEMENT TECHNIQUE
=============================================================================

Composants:
1. RotationJoystickScript - Contr�le la logique de rotation et la cible
2. RotationStickScript - G�re les interactions de la poign�e

Le joystick d�tecte automatiquement les composants Image (arri�re-plan) et 
RawImage (poign�e). Le mouvement est contraint dans le rayon du joystick, avec 
position traduite en valeurs normalis�es (-1 � 1) pour contr�ler la rotation.

=============================================================================
AIDE AU D�PANNAGE
=============================================================================

Probl�me: Le joystick ne r�pond pas aux entr�es
Solution: Assurez-vous que votre Canvas a un EventSystem dans la sc�ne et que les
          composants du joystick sont correctement configur�s avec Image et RawImage

Probl�me: L'objet tourne dans des directions inattendues
Solution: Essayez d'ajuster les param�tres d'inversion d'axe ou de changer entre
          rotation en espace local et mondial

Probl�me: La vitesse de rotation semble incoh�rente
Solution: V�rifiez si d'autres scripts font �galement pivoter l'objet cible ou si
          le taux d'images est instable

Probl�me: Les �l�ments visuels du joystick ne s'affichent pas correctement
Solution: V�rifiez que vous avez une hi�rarchie UI appropri�e avec un composant Image
          pour l'arri�re-plan et un RawImage pour la poign�e

=============================================================================
NOTES ET LIMITATIONS
=============================================================================

- Le widget fonctionne mieux dans un Canvas d�fini sur Screen Space - Overlay ou
  Screen Space - Camera
- Pour un contr�le pr�cis de la rotation, envisagez d'ajuster la vitesse de rotation
  en fonction de votre cas d'utilisation sp�cifique
- Plusieurs joysticks peuvent contr�ler diff�rents aspects du m�me objet
  (par exemple, un pour la rotation X/Y, un autre pour la rotation Z)
- Ce widget est optimis� pour les entr�es tactiles et souris
- Ce widget est optimis� pour une configuration de r�solution 1920x1080

=============================================================================
FIN DU DOCUMENT - DOCUMENTATION EN FRANCAIS
=============================================================================