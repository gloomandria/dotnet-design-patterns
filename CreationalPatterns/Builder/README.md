# Builder Pattern

## Description
Le pattern Builder sépare la construction d'un objet complexe de sa représentation, permettant le même processus de construction de créer différentes représentations.

## Utilisation
- Construction d'objets complexes avec de nombreux paramètres
- Objets nécessitant une construction étape par étape
- Objets immuables

## Avantages
- Code plus lisible (fluent API)
- Contrôle précis sur le processus de construction
- Permet de construire des objets immuables
- Isole le code de construction du code métier

## Inconvénients
- Augmente le nombre de classes
- Peut être excessif pour des objets simples
