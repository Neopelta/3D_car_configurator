  _____      _            __  __ _                 __          ___     _            _   
 / ____|    | |          |  \/  (_)               \ \        / (_)   | |          | |  
| |     ___ | | ___  _ __| \  / |___  _____ _ __   \ \  /\  / / _  __| | __ _  ___| |_ 
| |    / _ \| |/ _ \| '__| |\/| | \ \/ / _ \ '__|   \ \/  \/ / | |/ _` |/ _` |/ _ \ __|
| |___| (_) | | (_) | |  | |  | | |>  <  __/ |       \  /\  /  | | (_| | (_| |  __/ |_ 
 \_____\___/|_|\___/|_|  |_|  |_|_/_/\_\___|_|        \/  \/   |_|\__,_|\__, |\___|\__|
                                                                          __/ |         
                                                                         |___/          

=============================================================================
COLOR MIXER WIDGET - ENGLISH DOCUMENTATION
=============================================================================

Version: 1.0
Date : 09/05/2025
Unity : Unity 6 (6000.0.40f1)
Creators: Ronan PLUTA & Lillo GAVOIS
Team: Radiateur
Course: Interface Homme-Machine (IHM)
Institution: Université de Poitiers (SFA)
Program: Master 1 Computer Science

=============================================================================
DESCRIPTION
=============================================================================

The ColorMixerWidget is a Unity widget that allows you to mix colors and apply 
them to 3D objects. It provides an intuitive user interface for selecting 
different colors, adjusting their brightness, and applying the result to objects 
in the scene.

Note : This widget is optimised for a 1920x1080 resolution configuration.

=============================================================================
FEATURES
=============================================================================

- Selection of multiple colors to mix
- Brightness adjustment via a slider
- Real-time preview of the resulting color
- Application of the color to one or more 3D objects
- Fully customizable user interface
- Ability to add/remove colors through code

=============================================================================
PARAMETERS MODIFIABLE IN THE INSPECTOR
=============================================================================

1. AVAILABLE COLORS
   - Description: List of colors available for mixing
   - Type: List<Color>
   - Default: Cyan, Magenta, Yellow (primary colors in subtractive synthesis)
   - Usage: Modify this list to change the colors available in the widget

2. TARGETS
   - Description: List of renderers to which the color will be applied
   - Type: List<Renderer>
   - Usage: Drag and drop 3D objects that should receive the mixed color

3. SETTINGS
   - Button Spacing (btnSpacing)
     - Description: Spacing between color buttons
     - Type: float (range: 0.1 to 1.0)
     - Default value: 0.7
     - Usage: A higher value increases spacing, a lower value brings them closer together

   - Buttons Per Row (btnsPerRow)
     - Description: Number of color buttons per row
     - Type: int
     - Default value: 4
     - Usage: Adjust to optimize display based on widget size

4. BUTTON COLOR APPEARANCE
   - Selected Scale (selScale)
     - Description: Scale of buttons when selected
     - Type: float
     - Default value: 1.1
     - Usage: A value greater than 1.0 enlarges the button when selected

   - Deselected Scale (deselScale)
     - Description: Scale of buttons when not selected
     - Type: float
     - Default value: 1.0
     - Usage: Usually kept at 1.0 for normal size

   - Dark Factor (darkFactor)
     - Description: Darkening factor for unselected buttons
     - Type: float (range: 0 to 1)
     - Default value: 0.3
     - Usage: A value closer to 0 makes unselected buttons darker

=============================================================================
USAGE
=============================================================================

1. INTEGRATION INTO A SCENE

   a) Add the ColorMixerWidget prefab to your UI Canvas
   b) Adjust its size and position according to your needs
   c) Configure the parameters in the inspector
   d) Drag and drop target objects into the "Targets" list

2. INTERACTION WITH THE WIDGET

   a) Click on one or more color buttons to select them
   b) Adjust brightness with the slider
   c) Observe the preview of the mixed color
   d) Click "Apply" to apply the color to target objects

3. CODE CONTROL

   To add a target object dynamically:
   
   ColorMixerWidget mixer = GetComponent<ColorMixerWidget>();
   mixer.SetTargetRenderer(myRenderer);
   

   To add a new color:
   
   mixer.AddColor(Color.red);
   

   To remove a color:
   
   mixer.RemoveColorAt(index);
   

   To modify the number of buttons per row:
   
   mixer.SetButtonsPerRow(5);
   

=============================================================================
TECHNICAL OPERATION
=============================================================================

The widget uses a modified additive mixing system to combine selected colors. 
Each color is added with a weighting based on the square root of the number 
of selected colors, which gives more natural mixes than simple average mixing.

Brightness works in two phases:
- When the slider is below 50%, the color is mixed with black
- When the slider is above 50%, the color is mixed with white

The color application creates a material instance for each target object 
to avoid side effects on other objects that might share the same material.

=============================================================================
TROUBLESHOOTING
=============================================================================

Problem: Colors don't apply to objects
Solution: Check that the objects have Renderers and are correctly 
          added to the "Targets" list

Problem: The preview doesn't match the applied color
Solution: Some shaders may render the color differently. Try using 
          the Standard Shader for an exact match.

Problem: Color buttons don't display correctly
Solution: Adjust the btnSpacing and btnsPerRow parameters, or resize 
          the panel containing the buttons.

=============================================================================
NOTES AND LIMITATIONS
=============================================================================

- The widget works best with materials using the Standard Shader
- The color property used is "_Color" by default
- A maximum of 20 colors is recommended for optimal performance
- This widget is optimised for a 1920x1080 resolution configuration.

=============================================================================
END OF DOCUMENT - ENGLISH DOCUMENTATION
=============================================================================


  _____      _            __  __ _                 __          ___     _            _   
 / ____|    | |          |  \/  (_)               \ \        / (_)   | |          | |  
| |     ___ | | ___  _ __| \  / |___  _____ _ __   \ \  /\  / / _  __| | __ _  ___| |_ 
| |    / _ \| |/ _ \| '__| |\/| | \ \/ / _ \ '__|   \ \/  \/ / | |/ _` |/ _` |/ _ \ __|
| |___| (_) | | (_) | |  | |  | | |>  <  __/ |       \  /\  /  | | (_| | (_| |  __/ |_ 
 \_____\___/|_|\___/|_|  |_|  |_|_/_/\_\___|_|        \/  \/   |_|\__,_|\__, |\___|\__|
                                                                          __/ |         
                                                                         |___/          

=============================================================================
COLOR MIXER WIDGET - DOCUMENTATION EN FRANCAIS
=============================================================================

Version: 1.0
Date : 09/05/2025
Unity : Unity 6 (6000.0.40f1)
Créateurs: Ronan PLUTA & Lillo GAVOIS
Equipe: Radiateur
UE: Interface Homme-Machine (IHM)
Institution: Université de Poitiers (SFA)
Programme: Master 1 Informatique

=============================================================================
DESCRIPTION
=============================================================================

Le ColorMixerWidget est un widget Unity qui vous permet de mélanger des couleurs 
et de les appliquer à des objets 3D. Il fournit une interface utilisateur intuitive 
pour sélectionner différentes couleurs, d'ajuster leur luminosité et d'appliquer 
le résultat à des objets dans la scène.

Note : Ce widget est optimisé pour une configuration de résolution 1920x1080.

=============================================================================
CARACTÉRISTIQUES
=============================================================================

- Sélection de plusieurs couleurs à mélanger
- Réglage de la luminosité à l'aide d'un curseur
- Aperçu en temps réel de la couleur obtenue
- Application de la couleur à un ou plusieurs objets 3D
- Interface utilisateur entièrement personnalisable
- Possibilité d'ajouter/supprimer des couleurs par le biais du code

=============================================================================
PARAMÈTRES MODIFIABLES DANS L'INSPECTEUR
=============================================================================

1. COULEURS DISPONIBLES
   - Description : Liste des couleurs disponibles pour le mélange
   - Type : Liste<Couleur>
   - Valeur par défaut : Cyan, Magenta, Jaune
   - Utilisation : Modifier cette liste pour changer les couleurs disponibles 
   dans le widget.

2. TARGETS
   - Description : Liste des moteurs de rendu auxquels la couleur sera appliquée.
   - Type : List<Renderer>
   - Utilisation : Glisser-déposer les objets 3D qui doivent recevoir la 
   couleur mélangée.

3. RÉGLAGES
   - Espacement des boutons (btnSpacing)
     - Description : Espacement entre les boutons de couleur
     - Type : flottant (plage : 0,1 à 1,0)
     - Valeur par défaut : 0,7
     - Utilisation : Une valeur plus élevée augmente l'espacement, une valeur 
     plus faible les rapproche.

   - Boutons par ligne (btnsPerRow)
     - Description : Nombre de boutons de couleur par ligne
     - Type : int
     - Valeur par défaut : 4
     - Utilisation : Ajuster pour optimiser l'affichage en fonction de la taille
     du widget

4. APPARENCE DE LA COULEUR DU BOUTON
   - Échelle sélectionnée (selScale)
     - Description : Échelle des boutons lorsqu'ils sont sélectionnés
     - Type : float
     - Valeur par défaut : 1.1
     - Utilisation : Une valeur supérieure à 1,0 agrandit le bouton lorsqu'il 
     est sélectionné.

   - Échelle des boutons désélectionnés (deselScale)
     - Description : Échelle des boutons lorsqu'ils ne sont pas sélectionnés
     - Type : float
     - Valeur par défaut : 1.0
     - Utilisation : Généralement maintenu à 1.0 pour une taille normale

   - Facteur d'obscurité (darkFactor)
     - Description : Facteur d'assombrissement pour les boutons non sélectionnés
     - Type : flottant (étendue : 0 à 1)
     - Valeur par défaut : 0,3
     - Utilisation : Une valeur proche de 0 rend les boutons non sélectionnés 
     plus sombres.

=============================================================================
UTILISATION
=============================================================================

1. INTÉGRATION DANS UNE SCÈNE

   a) Ajoutez le préfabriqué ColorMixerWidget à votre UI Canvas
   b) Ajustez sa taille et sa position en fonction de vos besoins
   c) Configurer les paramètres dans l'inspecteur
   d) Glisser et déposer les objets cibles dans la liste "Targets".

2. INTERACTION AVEC LE WIDGET

   a) Cliquer sur un ou plusieurs boutons de couleur pour les sélectionner
   b) Régler la luminosité à l'aide du curseur
   c) Observer l'aperçu de la couleur mélangée
   d) Cliquez sur "Apply" pour appliquer la couleur aux objets cibles.

3. CONTRÔLE DU CODE

   Pour ajouter un objet cible de manière dynamique :

   ColorMixerWidget mixer = GetComponent<ColorMixerWidget>() ;
   mixer.SetTargetRenderer(myRenderer) ;


   Pour ajouter une nouvelle couleur :
   
   mixer.AddColor(Color.red);
   

   Pour supprimer une couleur :
   
   mixer.RemoveColorAt(index);
   

   Pour modifier le nombre de boutons par ligne :
   
   mixer.SetButtonsPerRow(5);
   

=============================================================================
FONCTIONNEMENT TECHNIQUE
=============================================================================

Le widget utilise un système de mélange additif modifié pour combiner les 
couleurs sélectionnées.
Chaque couleur est ajoutée avec une pondération basée sur la racine carrée 
du nombre de couleurs sélectionnées, ce qui donne des mélanges plus naturels 
qu'un simple mélange moyen.

La luminosité fonctionne en deux phases :
- Lorsque le curseur est inférieur à 50 %, la couleur est mélangée au noir
- Lorsque le curseur est supérieur à 50 %, la couleur est mélangée au blanc.

L'application couleur crée une instance de matériau pour chaque objet cible.
afin d'éviter les effets secondaires sur d'autres objets qui pourraient partager
le même matériau.



=============================================================================
AIDES
=============================================================================

Problème : les couleurs ne s'appliquent pas aux objets
Solution : Vérifiez que les objets ont des Renderers et qu'ils sont correctement 
        ajoutés à la liste des "cibles".

Problème : L'aperçu ne correspond pas à la couleur appliquée
Solution : Certains shaders peuvent rendre la couleur différemment. Essayez d'utiliser
        le shader standard pour obtenir une correspondance exacte.

Problème : les boutons de couleur ne s'affichent pas correctement.
Solution : Ajustez les paramètres btnSpacing et btnsPerRow, ou redimensionnez 
        le panneau contenant les boutons.

=============================================================================
NOTES ET LIMITATIONS
=============================================================================

- Le widget fonctionne mieux avec les matériaux utilisant le shader standard.
- La propriété de couleur utilisée est "_Color" par défaut.
- Un maximum de 20 couleurs est recommandé pour des performances optimales.
- Ce widget est optimisé pour une configuration de résolution 1920x1080.

=============================================================================
FIN DU DOCUMENT - DOCUMENTATION EN FRANCAIS
=============================================================================