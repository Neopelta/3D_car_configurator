  _____                                _     ___ ____  
 / ____|                              | |   |__ \|  _ \ 
| |     __ _ _ __ ___  _   _ ___  ___| |      ) | | | |
| |    / _` | '__/ _ \| | | / __|/ _ \ |     / /| | | |
| |___| (_| | | | (_) | |_| \__ \  __/ |    / /_| |__| |
 \_____\__,_|_|  \___/ \__,_|___/\___|_|   |____|_____/ 
                                                        
=============================================================================
CAROUSEL 2D WIDGET - ENGLISH DOCUMENTATION
=============================================================================

Version: 1.0
Date: 13/04/2025
Unity: Unity 6 (6000.0.35f1)
Creators: Ronan PLUTA & Lillo GAVOIS
Team: Radiateur
Course: Interface Homme-Machine (IHM)
Institution: Université de Poitiers (SFA)
Program: Master 1 Computer Science

=============================================================================
DESCRIPTION
=============================================================================

The Carousel2D is a standalone UI widget that displays images in a carousel format
with three positions (left, center, right). The center image is the selected one.
Users can navigate using left and right arrow buttons.

Note: This widget is optimized for a 1920x1080 resolution configuration.

=============================================================================
FEATURES
=============================================================================

- Displays a central image and two secondary images (previous and next)
- Navigation with left/right buttons
- Highlighted center image (zoomed)
- Automatic hierarchy detection (no manual configuration required)
- Easy access to the currently selected image
- Circular navigation (loops back to start/end)

=============================================================================
EXPECTED STRUCTURE
=============================================================================

The prefab must contain the following hierarchy:
- Canvas
  └── Carousel2D (containing the script)
      ├── Container
      │   ├── LeftImage (UI.Image)
      │   ├── CenterImage (UI.Image)
      │   └── RightImage (UI.Image)
      ├── LeftButton (UI.Button)
      └── RightButton (UI.Button)

=============================================================================
PARAMETERS MODIFIABLE IN THE INSPECTOR
=============================================================================

1. SPRITES TO SHOW
   - Description: List of sprites to display in the carousel
   - Type: List<Sprite>
   - Usage: Drag and drop your sprites here (minimum 3 required)

=============================================================================
USAGE
=============================================================================

1. INTEGRATION INTO A SCENE

   a) Import the Carousel2D prefab into your scene (in a Canvas)
   b) Drag your Sprites into the "sprites" field of the script (in the Inspector)
   c) Press Play to see the carousel in action

2. INTERACTION WITH THE WIDGET

   a) Click on the left arrow: show previous image
   b) Click on the right arrow: show next image

3. CODE CONTROL

   To get the currently selected sprite:
   
   Carousel2DManager carousel = GetComponent<Carousel2DManager>();
   Sprite selectedSprite = carousel.GetSelectedCarousel();
   

   To programmatically navigate:
   
   carousel.Next();     // Move to next image
   carousel.Previous(); // Move to previous image
   

=============================================================================
TECHNICAL OPERATION
=============================================================================

The widget uses a simple index-based approach to track the currently selected
image. When navigating, it updates three Image components (left, center, right)
with the appropriate sprites from the collection.

Navigation is circular, meaning that when you reach the end of the collection
and press Next, it loops back to the first image. Similarly, when at the first
image, pressing Previous loops to the last image.

The widget automatically finds all necessary UI components based on the expected
hierarchy structure, making it easy to integrate into any UI canvas.

=============================================================================
TROUBLESHOOTING
=============================================================================

Problem: "One or more elements not found in hierarchy" error
Solution: Ensure your prefab follows the expected hierarchy structure exactly

Problem: "Provide at least 3 sprites" error
Solution: Add at least 3 sprites to the sprites list in the Inspector

Problem: Images don't appear in the carousel
Solution: Make sure the sprites are properly assigned and are compatible with
          the UI.Image component (they should be marked as "Sprite" in import settings)

Problem: Navigation buttons don't work
Solution: Verify the Button components have proper interaction settings and 
          that there's an EventSystem in your scene

=============================================================================
NOTES AND LIMITATIONS
=============================================================================

- The widget requires at least 3 sprites to function properly
- For best visual results, use sprites of similar dimensions
- The carousel is designed for horizontal navigation only
- This widget is optimized for a 1920x1080 resolution configuration

=============================================================================
END OF DOCUMENT - ENGLISH DOCUMENTATION
=============================================================================


  _____                                _     ___ ____  
 / ____|                              | |   |__ \|  _ \ 
| |     __ _ _ __ ___  _   _ ___  ___| |      ) | | | |
| |    / _` | '__/ _ \| | | / __|/ _ \ |     / /| | | |
| |___| (_| | | | (_) | |_| \__ \  __/ |    / /_| |__| |
 \_____\__,_|_|  \___/ \__,_|___/\___|_|   |____|_____/ 
                                                        
=============================================================================
CAROUSEL 2D WIDGET - DOCUMENTATION EN FRANCAIS
=============================================================================

Version: 1.0
Date: 13/04/2025
Unity: Unity 6 (6000.0.35f1)
Créateurs: Ronan PLUTA & Lillo GAVOIS
Equipe: Radiateur
UE: Interface Homme-Machine (IHM)
Institution: Université de Poitiers (SFA)
Programme: Master 1 Informatique

=============================================================================
DESCRIPTION
=============================================================================

Le Carousel2D est un widget UI autonome permettant d'afficher un carrousel d'images
sous forme de trois positions (gauche, centre, droite). L'image centrale est la 
sélectionnée. Les utilisateurs peuvent naviguer à l'aide de deux flèches.

Note: Ce widget est optimisé pour une configuration de résolution 1920x1080.

=============================================================================
CARACTÉRISTIQUES
=============================================================================

- Affiche une image centrale et deux images secondaires (précédente et suivante)
- Navigation avec boutons gauche/droite
- Image centrale mise en valeur (zoomée)
- Utilise la hiérarchie automatiquement (pas de configuration manuelle nécessaire)
- Accès facile à l'image sélectionnée
- Navigation circulaire (revient au début/fin)

=============================================================================
STRUCTURE ATTENDUE
=============================================================================

Le prefab doit contenir la hiérarchie suivante:
- Canvas
  └── Carousel2D (contenant le script)
      ├── Container
      │   ├── LeftImage (UI.Image)
      │   ├── CenterImage (UI.Image)
      │   └── RightImage (UI.Image)
      ├── LeftButton (UI.Button)
      └── RightButton (UI.Button)

=============================================================================
PARAMÈTRES MODIFIABLES DANS L'INSPECTEUR
=============================================================================

1. SPRITES TO SHOW
   - Description: Liste des sprites à afficher dans le carrousel
   - Type: List<Sprite>
   - Utilisation: Glisser-déposer vos sprites ici (minimum 3 requis)

=============================================================================
UTILISATION
=============================================================================

1. INTÉGRATION DANS UNE SCÈNE

   a) Importer le prefab Carousel2D dans votre scène (dans un Canvas)
   b) Glisser vos Sprites dans le champ "sprites" du script (dans l'Inspector)
   c) Appuyez sur Play pour voir le carrousel fonctionner

2. INTERACTION AVEC LE WIDGET

   a) Clic sur la flèche gauche: image précédente
   b) Clic sur la flèche droite: image suivante

3. CONTRÔLE PAR CODE

   Pour obtenir le sprite actuellement sélectionné:
   
   Carousel2DManager carousel = GetComponent<Carousel2DManager>();
   Sprite selectedSprite = carousel.GetSelectedCarousel();
   

   Pour naviguer par programmation:
   
   carousel.Next();     // Passer à l'image suivante
   carousel.Previous(); // Revenir à l'image précédente
   

=============================================================================
FONCTIONNEMENT TECHNIQUE
=============================================================================

Le widget utilise une approche simple basée sur un index pour suivre l'image
actuellement sélectionnée. Lors de la navigation, il met à jour trois composants
Image (gauche, centre, droite) avec les sprites appropriés de la collection.

La navigation est circulaire, ce qui signifie que lorsque vous atteignez la fin
de la collection et appuyez sur Suivant, elle revient à la première image.
De même, à la première image, appuyer sur Précédent ramène à la dernière image.

Le widget trouve automatiquement tous les composants UI nécessaires en fonction
de la structure hiérarchique attendue, ce qui facilite son intégration dans
n'importe quel canvas UI.

=============================================================================
AIDE AU DÉPANNAGE
=============================================================================

Problème: Erreur "Un ou plusieurs éléments sont introuvables dans la hiérarchie"
Solution: Assurez-vous que votre prefab suit exactement la structure hiérarchique attendue

Problème: Erreur "Provide at least 3 sprites"
Solution: Ajoutez au moins 3 sprites à la liste des sprites dans l'Inspector

Problème: Les images n'apparaissent pas dans le carrousel
Solution: Assurez-vous que les sprites sont correctement assignés et sont compatibles
          avec le composant UI.Image (ils doivent être marqués comme "Sprite" 
          dans les paramètres d'importation)

Problème: Les boutons de navigation ne fonctionnent pas
Solution: Vérifiez que les composants Button ont des paramètres d'interaction
          appropriés et qu'il y a un EventSystem dans votre scène

=============================================================================
NOTES ET LIMITATIONS
=============================================================================

- Le widget nécessite au moins 3 sprites pour fonctionner correctement
- Pour de meilleurs résultats visuels, utilisez des sprites de dimensions similaires
- Le carrousel est conçu uniquement pour la navigation horizontale
- Ce widget est optimisé pour une configuration de résolution 1920x1080

=============================================================================
FIN DU DOCUMENT - DOCUMENTATION EN FRANCAIS
=============================================================================