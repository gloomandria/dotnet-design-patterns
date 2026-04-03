# Factory Method Pattern

## Description
Le pattern Factory Method définit une interface pour créer un objet, mais laisse les sous-classes décider quelle classe instancier. Il permet de déléguer l'instantiation aux sous-classes.

## Utilisation
- Création d'objets dont le type exact n'est pas connu à l'avance
- Frameworks et bibliothèques qui délèguent la création d'objets
- Système de plugins

## Avantages
- Évite le couplage fort entre le créateur et les produits concrets
- Principe ouvert/fermé (Open/Closed)
- Centralise la logique de création

## Inconvénients
- Peut devenir complexe avec beaucoup de sous-classes
- Augmente le nombre de classes
