# Command Pattern

## Description
Le pattern Command encapsule une requête comme un objet, permettant ainsi de paramétrer des clients avec différentes requêtes, de mettre en file d'attente ou de journaliser les requêtes, et de supporter l'annulation d'opérations.

## Utilisation
- Opérations Undo/Redo
- Files d'attente de tâches
- Journalisation des opérations
- Macro-commandes

## Avantages
- Principe de responsabilité unique
- Principe ouvert/fermé
- Undo/Redo
- Opérations différées
- Composition de commandes

## Inconvénients
- Complexité accrue
- Beaucoup de classes pour des opérations simples
