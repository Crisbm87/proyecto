def traductor():
    diccionario = {
        "time": "tiempo",
        "person": "persona",
        "year": "año",
        "way": "camino/forma",
        "day": "día",
        "thing": "cosa",
        "man": "hombre",
        "world": "mundo",
        "life": "vida",
        "hand": "mano",
        "part": "parte",
        "child": "niño/a",
        "eye": "ojo",
        "woman": "mujer",
        "place": "lugar",
        "work": "trabajo",
        "week": "semana",
        "case": "caso",
        "point": "punto/tema",
        "government": "gobierno",
        "company": "empresa/compañía"
    }

    def traducir_frase(frase):
        palabras = frase.lower().split()
        frase_traducida = []
        for palabra in palabras:
            if palabra in diccionario:
                frase_traducida.append(diccionario[palabra])
            elif palabra in diccionario.values():
                for key, value in diccionario.items():
                    if value == palabra:
                        frase_traducida.append(key)
                        break
            else:
                frase_traducida.append(palabra)
        return " ".join(frase_traducida)

    def agregar_palabra(ingles, espanol):
        diccionario[ingles.lower()] = espanol.lower()
        print(f"Palabra '{ingles}' agregada al diccionario.")

    while True:
        print("\nMENU")
        print("=======================================================")
        print("1. Traducir una frase")
        print("2. Ingresar más palabras al diccionario")
        print("0. Salir")

        opcion = input("Seleccione una opción: ")

        if opcion == "1":
            frase = input("Ingrese la frase: ")
            print("Su frase traducida es:", traducir_frase(frase))
        elif opcion == "2":
            ingles = input("Ingrese la palabra en inglés: ")
            espanol = input("Ingrese la traducción en español: ")
            agregar_palabra(ingles, espanol)
        elif opcion == "0":
            break
        else:
            print("Opción inválida. Intente de nuevo.")

traductor()
