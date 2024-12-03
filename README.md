# **Escape del Calabozo**

Este proyecto es un videojuego desarrollado en **C#**, que simula la aventura de escapar de un calabozo lleno de peligros. Fue creado con el objetivo de practicar y demostrar conceptos básicos de programación como estructuras de datos, control de flujo, manipulación de archivos, y lógica de diseño de juegos.

## **Descripción del Juego**  
En este juego, el jugador deberá atravesar un calabozo representado por un mapa de texto, evitando a los monstruos y utilizando las escaleras para avanzar entre niveles. El objetivo principal es alcanzar la salida del calabozo sin perder toda la vida.

### **Elementos del Mapa**  
- **`!`**: Representa al jugador.  
- **`-`**: Espacios vacíos por los que el jugador puede desplazarse.  
- **`#`**: Paredes, las cuales son obstáculos intransitables.  
- **`m`**: Monstruos que atacan al jugador si están cerca.  
- **`+`**: Escaleras que conectan un nivel del calabozo con el siguiente.  
- **`/`**: La salida del calabozo, el objetivo final del juego.  

## **Características Principales**
- **Desarrollado en C#**: Utiliza el lenguaje de programación C# y el framework .NET para aprovechar su robustez y facilidad de uso.  
- **Generación de mapa**: El juego utiliza un archivo de texto para cargar el diseño del calabozo, lo que permite personalizar los niveles.  
- **Movimientos por turnos**: El jugador puede moverse usando las teclas de flecha, y los monstruos se desplazan tras el turno del jugador.  
- **Monstruos dinámicos**: Cada nivel contiene tres monstruos generados aleatoriamente con vida propia, añadiendo un desafío estratégico al juego.  
- **Interfaz gráfica básica**: Incluye etiquetas que muestran información clave como la vida de los monstruos y del jugador.  

## **Conceptos de Programación Aplicados**
Este proyecto aborda los fundamentos de la programación y es ideal para principiantes que deseen aprender sobre:
- **Estructuras de datos**: Uso de listas y matrices para manejar el mapa y las posiciones.  
- **Manipulación de archivos**: Lectura de mapas desde un archivo de texto para inicializar los niveles.  
- **Lógica de juego**: Implementación de turnos, interacción con monstruos, y objetivos del jugador.  
- **Generación aleatoria**: Creación de monstruos con posiciones y atributos únicos en cada nivel.  
- **Control de flujo**: Validación de movimientos y reglas del juego.  

## **Cómo Jugar**
1. **Cargar el juego**: El mapa inicial se cargará desde un archivo de texto que contiene el diseño del calabozo.  
2. **Moverse**: Usa las teclas de flecha para mover al jugador (`!`).  
3. **Evitar peligros**: Mantente alejado de los monstruos (`m`) para evitar perder vida.  
4. **Avanzar niveles**: Encuentra las escaleras (`+`) para ascender en el calabozo.  
5. **Ganar el juego**: Llega a la salida (`/`) para escapar.  

## **Requisitos del Sistema**
- **Lenguaje**: C#  
- **Framework**: .NET  
- **Entorno de desarrollo recomendado**: Visual Studio  
