# Mini projet Unity - EVHI 2020

# Étudiant

Nartz Kévin  
n° 3526226  
kevinnartz@gmail.com

# Contrôles

## Clavier et souris
* Souris pour la caméra  
* Z : Avancer  
* S : Reculer  
* Q : Déplacement latéral gauche  
* D : Déplacement latéral droit  
* E : Intéragir  
* Space : Sauter  
* Clic gauche : Tirer  
* Esc : Pause  

## Manette (Xbox Pad)
* Stick Analogique gauche pour se déplacer  
* Stick Analogique droit pour déplacer la caméra  
* A : Sauter  
* B : Intéragir  
* Start : Pause  
* RT : Tirer  
  
Attention on ne peut pas naviguer dans les menus avec la manette.

# Niveaux

## Niveau 1
Intéragir avec le bouton sur le mur pour sortir.

## Niveau 2
Le bouton sur le pylone est bloqué, détruire l'ennemi (3 points de vie) pour le débloquer et ensuite l'activer pour sortir.

## Niveau 3
Un ennemi vous poursuit, échappez vous en vous dirigeant vers l'isoloir et en activant le bouton tout en évitant l'ennemi.  
Les boules rouges dans le niveau sont des points de vie, récupèrables uniquement si vous perdez de la vie (si l'ennemi vous touche par exemple).

## Niveau 4
Vous devez sauter de plateforme en plateforme pour atteindre l'autre rive qui donne accès au prochain niveau.
Tomber vous fait perdre 1 point de vie.

## Niveau 5
Vous êtes dans une grotte mal éclairé avec un trésor au milieu. Approchez vous du trésor, cela va déclancher un tremblement, le plafond va s'écrouler laissant place à plus de lumière dans la salle ainsi qu'à un dragon. Battez le dragon pour finir le jeu.  
Le dragon a 20 points de vie, sa barre de vie est visible en bas de l'écran.  
Il y a des boules rouges dans le niveau pour récupèrer de la vie.  
Les boules jaunes permettent de rendre votre personnage invincible pendant 5s (l'écran a un filtre jaune pendant toute la durée).

# UI
## Interface en jeu
* Points de vie (3PVs) sous forme de coeurs en haut à gauche.  
* Viseur pour le tir.  
* Barre de vie pour le dragon au niveau 5.  
* Filtre coloré lors de la prise de dégat (rouge), de boule de vie (vert) et d'invinciblité (jaune).

## Écran titre
Au lancement du jeu.  
Jouer : Lance le 1er niveau.

## Menu pause
* Accès avec esc ou pause.  
* Continuer : Reprend là où la pause a été déclenché.  
* Relancer : Relance le niveau.  
* Quitter : Quitte le jeu.

## Menu de mort
* S'active quand le personnage perd tout ses points de vie.  
* Continuer : Relance le niveau.  
* Quitter : Quitte le jeu.

## Écran de fin
* S'active peu après la mort du dragon.  
* Affiche un message qui félicite le joueur et propose un bouton pour quitter le jeu.

# Différences par rapport aux consignes
* La porte battante demandé au niveau 5 est à la fin du niveau 4, le niveau 4 ne comporte donc pas de bouton pour accèder au niveau 5.  
* Dans le niveau 5, il y a déjà un peu de lumière au centre de la pièce pour indiquer la position du trésor. La lumière s'amplifie une fois le trésor atteint.
