# Lennox.Encryption
LmOs-Encryption
Introducción:
Este método esta inspirado en el cifrado cesar que es un método de sustitución y cifrado de 
permutación.
Las técnicas de sustitución hacen que las letras mantengan sus posiciones en el texto, pero 
cambian su apariencia, siendo sustituidas cada una de ellas por otra letra, por un numero o por un 
símbolo cualquiera.
Con las técnicas de transposición las letras del texto en claro intercambian sus posiciones según un 
cierto patrón, de modo que el texto cifrado aparece las mismas letras con sus posiciones 
permutadas.
el secreto de este método es de que utilizo la longitud del texto para saber si la posición de un 
carácter es par o impar. Supongamos que tenemos un carácter de nuestro texto en claro en la 
posición 1, como el 1 es un numero impar, aplico una fórmula de sustitución para números en 
posiciones impares y si el siguiente carácter está en la posición 2 aplico una formula para los 
caracteres que están en posiciones pares.
Formula
X será nuestro carácter.
Para números pares
𝑦 = (𝑥 + 20)
𝑧 = (𝑥 ∗ 2)
𝑥 = (𝑦 + 𝑧)
𝑥 = (𝑥 / 2)
Para números impares
𝑦 = (𝑥 + 20)
𝑧 = (𝑥 ∗ 2)
𝑥 = (𝑦 + 𝑧)
𝑥 = (𝑥 / 4)
Primero ingresamos las palabras que queramos en el texto de la izquierda y luego presionamos el 
botón “Cifrar”cabe destacar que el usuario solo puede escribir letras y estas letras se tomaran en cuenta 
siempre como mayúsculas.
Al presionar el botón cifrar automáticamente se llama la función Cifrar.
Dentro de esta función Declaro mis variables a utilizar y uso un for para quitarle los espacios del
texto que el usuario ingreso y guardando los datos en la variable llamada texto.
Luego entramos a otro for para iterar el texto en claro validando si la posición de cada carácter es 
par o es impar.
Para ello utilizamos la función “Valida_Par_Impar”Después de entrar al if o al else básicamente hace el mismo procedimiento, pero solo varia la
fórmula que uso para sustituir los caracteres (si es par aplico una y caso contrario aplico otra 
fórmula de sustitución)
Luego para la permutación o transposición uso la fusión TranspositionEncrypt pasándole el dato x 
y luego retornando un numero en código acssi ya permutado
Utilizamos 2 abecedarios para permutar
Está basado en la tabla acssi el cual comenzar en el código 70 y termina en el 190. en total serian 
120 caracteres. 
Tememos nuestro abecedario de 120 caracteres en una sola línea y luego lo dividimos a la mitad, 
nos quedaría una matriz con 2 filas. Permutamos las letras de la primera fila y con su respectiva 
posición de columna de letra en la segunda fila.Código para crear los abecedarios
Código de la función “TranspositionEncrypt” donde permutamos un carácter utilizando los 
abecedarios.
Para finalizar ahora que la letra ya este permutada le aplicamos otro método de sustitución.
Cambiamos el carácter por su respectivo numero en un valor hexadecimal.
Utilizamos la función ConverToExadecimal que tiene el siguiente código:luego retornamos el valor salida y lo pasamos a TxtCifrado
Así terminaría nuestro texto convertido a valores en hexadecimalDescifrando
Para Descifrar hacemos lo siguiente:
1. Introducimos el texto cifrado al TextBox de la izquierda y damos click en Descifrar.
2. Sustituimos cada valor hexadecimal por su valor en decimal de código acssi.
Primero entramos en la función “Descifrar”, utilizamos un “for” para iterar el texto con la 
información cifrada. 
Dentro del for se llama a la función ConvertToDecimal que nos sirve para pasar de hexadecimal a 
decimalUtilizo esta fórmula para convertir de Hexadecimal a decimal:
Se enumera nuestro número de derecha a izquierda para la elevación,
Se multiplica desde el primer numero de la derecha por 16 elevado a la posición en que este (0,1,2 
y así sucesivamente) y luego sumamos todas las respuestas que nos de y ese es nuestro numero 
convertido a decimal.
En código se ve así:
3. Viene la permutación
Utilizamos nuestras tablas “abecedario1 y abecedario2” para permutar cada valor a su 
respectiva contraparte que este alineado en su posición. Utilizamos la función 
TranspositionDecrypt para esto.Se itera en el abecedario como lo hicimos cuando ciframos, pero ahora será a la inversa para 
que nos del valor que teníamos
4. Se aplica la fórmula para lograr ver el texto en claro 
Ahora se llama la función ConvertToPlainText. Le pasamos el dato ya en decimal permutado y 
un dato llamado “count” que nos sirve para saber si el caracter está en una posición par o 
impar
Dependiendo si la posición que tiene en el texto cada carácter es par o impar aplicamos estas 
fórmulas. 
5. Finalmente le pasamos el dato que nos retornó ConvertToPlainText a TxtCifrado y nos
